using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Text;

public class JsonDataServiceManager : Singleton<JsonDataServiceManager>, IDataService
{
    public bool SaveData<T>(string RelativePath, T Data, bool Encrypted)
    {
        string path = Application.persistentDataPath + RelativePath;
        try
        {
            if (File.Exists(path))
            {
                Debug.Log("File exists. Deleting old file and writing a new one!");
                File.Delete(path);
            }
            else
            {
                Debug.Log("Create file for the first time!");
            }
            Debug.Log(path);
            using FileStream stream = File.Create(path);
            if (Encrypted)
            {
                WriteEncryptedData(Data, path, stream);
            }
            else
            {
                stream.Close();
                File.WriteAllText(path, JsonConvert.SerializeObject(Data));
            }
            return true;
        }
        catch (Exception e)
        {
            Debug.LogError($"Unable to save data due to: {e.Message}, {e.StackTrace}");
            return false;
        }


    }

    public T LoadData<T>(string RelativePath, bool Encrypted)
    {
        string path = Application.persistentDataPath + RelativePath;

        if (!File.Exists(path))
        {
            Debug.LogError($"Cannot load file at {path}. File does not exist!");
            throw new FileNotFoundException($"{path} does not exist!");
        }

        try
        {
            T data;
            if (Encrypted)
            {
                data = ReadEncrytedData<T>(path);
            }
            else
            {
                data = JsonConvert.DeserializeObject<T>(File.ReadAllText(path));
            }

            return data;
        }
        catch (Exception e)
        {
            Debug.LogError($"Failed to load data due to: {e.Message}, {e.StackTrace}");
            throw e;
        }
    }

    private void WriteEncryptedData<T>(T Data, string Path, FileStream Stream)
    {
        using Aes aesProvider = Aes.Create();
        aesProvider.BlockSize = 128;
        aesProvider.KeySize = 128;
        aesProvider.Mode = CipherMode.CBC;
        aesProvider.Padding = PaddingMode.PKCS7;
        aesProvider.GenerateKey();
        aesProvider.GenerateIV();

        string jsonData = JsonConvert.SerializeObject(Data);
        
        using ICryptoTransform cryptoTransform = aesProvider.CreateEncryptor();
        using CryptoStream cryptoStream = new CryptoStream(
                Stream,
                cryptoTransform,
                CryptoStreamMode.Write
            );

        PlayerPrefs.SetString("AES_KEY",
            EncryptString(Convert.ToBase64String(aesProvider.Key) + "|" + Convert.ToBase64String(aesProvider.IV), SystemInfo.deviceUniqueIdentifier)
            );

        byte[] jsonDataBytes = Encoding.ASCII.GetBytes(jsonData);
        cryptoStream.Write(jsonDataBytes, 0, jsonDataBytes.Length);
    }

    private T ReadEncrytedData<T>(string Path)
    {
        byte[] fileBytes = File.ReadAllBytes(Path);
        using Aes aesProvider = Aes.Create();
        aesProvider.BlockSize = 128;
        aesProvider.KeySize = 128;
        aesProvider.Mode = CipherMode.CBC;
        aesProvider.Padding = PaddingMode.PKCS7;

        string header = DecryptString(PlayerPrefs.GetString("AES_KEY"), SystemInfo.deviceUniqueIdentifier);
        string[] parts = header.Split('|');
        byte[] extractedKey = Convert.FromBase64String(parts[0]);
        byte[] extractedIV = Convert.FromBase64String(parts[1]);

        aesProvider.Key = extractedKey;
        aesProvider.IV = extractedIV;
        using ICryptoTransform cryptoTransform = aesProvider.CreateDecryptor(
                aesProvider.Key,
                aesProvider.IV
            );
        using MemoryStream decryptionStream = new MemoryStream(fileBytes);
        using CryptoStream cryptoStream = new CryptoStream(
                decryptionStream,
                cryptoTransform,
                CryptoStreamMode.Read
            );
        using StreamReader reader = new StreamReader(cryptoStream);
        string result = reader.ReadToEnd();
        return JsonConvert.DeserializeObject<T>(result);
    }

    private  string EncryptString(string input, string key)
    {
        byte[] keyBytes = Encoding.ASCII.GetBytes(key);
        byte[] inputBytes = Encoding.ASCII.GetBytes(input);

        // Mã hóa bằng phép XOR giữa từng byte của input và key
        for (int i = 0; i < inputBytes.Length; i++)
        {
            inputBytes[i] ^= keyBytes[i % keyBytes.Length];
        }

        // Chuyển đổi kết quả thành chuỗi hex
        StringBuilder sb = new StringBuilder();
        foreach (byte b in inputBytes)
        {
            sb.Append(b.ToString("X2"));
        }
        return sb.ToString();
    }

    private string DecryptString(string input, string key)
    {
        byte[] keyBytes = Encoding.ASCII.GetBytes(key);


        byte[] inputBytes = new byte[input.Length / 2];
        for (int i = 0; i < input.Length; i += 2)
        {
            inputBytes[i / 2] = Convert.ToByte(input.Substring(i, 2), 16);
        }

        // Giải mã bằng phép XOR giữa từng byte của input và key
        for (int i = 0; i < inputBytes.Length; i++)
        {
            inputBytes[i] ^= keyBytes[i % keyBytes.Length];
        }

        // Chuyển đổi kết quả thành chuỗi UTF-8
        return Encoding.ASCII.GetString(inputBytes);
    }
}
