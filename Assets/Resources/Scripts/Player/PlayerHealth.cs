﻿using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {
    private int health;
    private bool isKill;

    [HideInInspector]
    public bool invinsible;

    private HealthBar healthBar;

    private GameObject blood1;

    private GameObject bloodHeal1;


    [Header("Player health config")]
    [SerializeField] private int baseHealth;
  
    
    void Start() {
        health = baseHealth;
        isKill = false;

        healthBar = GameObject.Find("HealthBar").GetComponent<HealthBar>();
        healthBar.SetMaxHealth(health);

        blood1 = Resources.Load<GameObject>("Prefabs/Effects/BloodEffect1");
        bloodHeal1 = Resources.Load<GameObject>("Prefabs/Effects/HealEffect1");
    }

    void Update() {   
        if (health == 0 && !isKill) {
            isKill = true;
            EventManager.Instant.Push(EventChanelID.GamePlay, EventName.GamePlay.GAME_PLAY_LOSE, null);
        }
    }

    public void DecreaseHealth(int damage) {
        if (!invinsible) {
            health = Math.Max(0, health - damage);
            healthBar.SetHealth(health);
            GameObject blood = Instantiate(blood1, transform.position, transform.rotation);
            blood.transform.SetParent(transform);
            SoundManager.Instant.PlaySound(Constant.SFX.Hurt);
        }
    }

    public void IncreaseHealth(int heal) {
        health = Math.Min(baseHealth, health + heal);
        healthBar.SetHealth(health);
        GameObject blood = Instantiate(bloodHeal1, transform.position, transform.rotation);
        blood.transform.SetParent(transform);
    }

    public bool IsKill {
        get { return isKill; }
    }
}
