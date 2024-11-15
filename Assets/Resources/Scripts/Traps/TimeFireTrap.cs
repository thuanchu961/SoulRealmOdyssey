﻿using System.Collections;
using UnityEngine;

public class TimeFireTrap : MonoBehaviour {
    private Transform childLight;

    private Animator animator;

    private bool ableToDamage;
    private bool onCollision;

    private PlayerHealth playerHealth;
    
    public float waitTime;
    public float durationTime;
    public int damage;
    
    void Start() {
        playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
        animator = GetComponent<Animator>();
        childLight = transform.GetChild(0);
        ableToDamage = true;
    }

    void Update() {
        if (ableToDamage && onCollision) { 
            StartCoroutine(ActivateDamageBox());
            ableToDamage = false;
        }
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.CompareTag("Player"))
            onCollision = true;
    }

    void OnTriggerExit2D(Collider2D col) {
        if (col.CompareTag("Player"))
            onCollision = false;
    }

    IEnumerator ActivateDamageBox() {
        yield return new WaitForSeconds(waitTime);
        animator.SetBool("Working", true);
        childLight.gameObject.SetActive(true);

        SoundManager.Instant.PlaySound(Constant.SFX.FireShot);

        if (onCollision) 
            playerHealth.DecreaseHealth(damage);

        yield return new WaitForSeconds(durationTime);
        animator.SetBool("Working", false);
        childLight.gameObject.SetActive(false);
        ableToDamage = true;
    }
}
