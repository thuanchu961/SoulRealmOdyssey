using UnityEngine;
using System;
public class DestructiveObjects : MonoBehaviour {
    private Animator animator;
    private int health;
    private GameObject itemToSpawn;
    public int SetHealth;
    public Constant.SFX soundName;
    
    void Start() {
        animator = GetComponent<Animator>();
        health = SetHealth;
        var itemIndex = UnityEngine.Random.Range(0, (int)Constant.ITEMS.end);
        var itemName = GetEnumStringByIndex(typeof(Constant.ITEMS), itemIndex);
        itemToSpawn = (GameObject)Resources.Load($"Prefabs/GeneralItems/{itemName}", typeof(GameObject));
    }

    void Update() {
        if (health <= 0)
        {
           DestroyObject();

            if (UnityEngine.Random.Range(0, 1000) % 2 == 0)
            {
                Instantiate(itemToSpawn, transform.position, transform.rotation);
            }
        }
    }
    public string GetEnumStringByIndex(Type enumType, int index)
    {
        Array enumValues = Enum.GetValues(enumType);

        if (index < 0 || index >= enumValues.Length)
        {
            Debug.Log("Index is out of range.");
        }

        object enumValue = enumValues.GetValue(index);
        return enumValue.ToString();
    }
    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Bullet")) {
            health -= other.gameObject.GetComponent<BulletController>().Damage;
            HitObject();
        }
    }

    void HitObject() {
        animator.SetTrigger("Hit");
    }

    void DestroyObject() {
        animator.SetBool("Explode", true);
        SoundManager.Instant.PlaySound(soundName);
        Destroy(this);
    }
}
