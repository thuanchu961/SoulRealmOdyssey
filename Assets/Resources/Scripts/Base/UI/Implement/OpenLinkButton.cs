using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenLinkButton : AbstractBaseButton
{
    [SerializeField] private string URL = "";
    protected override void OnClick()
    {
#if UNITY_EDITOR
        Application.OpenURL(URL);

#elif PLATFORM_ANDROID
        // Đường dẫn package của CH Play
        string playStorePackageName = URL;
        //string playStorePackageName = "com.android.vending";

        // Tạo Intent để mở CH Play
        AndroidJavaClass intentClass = new AndroidJavaClass("android.content.Intent");
        AndroidJavaObject intentObject = new AndroidJavaObject("android.content.Intent");

        // Đặt hành động của Intent là ACTION_VIEW
        intentObject.Call<AndroidJavaObject>("setAction", intentClass.GetStatic<string>("ACTION_VIEW"));

        // Tạo Uri cho đường dẫn của CH Play
        AndroidJavaClass uriClass = new AndroidJavaClass("android.net.Uri");
        AndroidJavaObject uriObject = uriClass.CallStatic<AndroidJavaObject>("parse", "market://details?id=" + playStorePackageName);

        // Đặt data của Intent là Uri đã tạo
        intentObject.Call<AndroidJavaObject>("setData", uriObject);

        // Thực hiện mở Intent
        AndroidJavaClass unityPlayerClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject unityActivityObject = unityPlayerClass.GetStatic<AndroidJavaObject>("currentActivity");
        unityActivityObject.Call("startActivity", intentObject);
#endif
    }

}
