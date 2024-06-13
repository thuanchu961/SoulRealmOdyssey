using UnityEngine;
using System;
public class EnemyDeath : MonoBehaviour {
    private Animator animator;
    private EnemyHealth enemyHealth;
    private GameObject explosion;
    private GameObject itemToSpawn;
    public bool deathFromAnimator;
    
    void Start() {
        animator = GetComponent<Animator>();
        enemyHealth = gameObject.GetComponent<EnemyHealth>();
        explosion = (GameObject) Resources.Load("Prefabs/Effects/EnemyDeath1", typeof(GameObject));
        var itemIndex = UnityEngine.Random.Range(0, (int)Constant.ITEMS.end);
        var itemName = GetEnumStringByIndex(typeof(Constant.ITEMS), itemIndex);
        itemToSpawn = (GameObject) Resources.Load($"Prefabs/GeneralItems/{itemName}", typeof(GameObject));
    }
    public static string GetEnumStringByIndex(Type enumType, int index)
    {
        Array enumValues = Enum.GetValues(enumType);

        if (index < 0 || index >= enumValues.Length)
        {
            Debug.Log("Index is out of range.");
        }

        object enumValue = enumValues.GetValue(index);
        return enumValue.ToString();
    }
    void Update() {
        if (enemyHealth.health <= 0 && !deathFromAnimator) {
            Destroy(gameObject);

            if(UnityEngine.Random.Range(0,1000) % 2 == 0)
            {
                Instantiate(itemToSpawn, transform.position, transform.rotation);
            }
            
            Instantiate(explosion, transform.position, transform.rotation);
        }

        if (enemyHealth.health <= 0 && deathFromAnimator) {
            animator.SetBool("Death", true);
        }
    }

    void DestroyEnemy() {
        Destroy(gameObject);
    }
}
