﻿using System.Collections;
using UnityEngine;

public class ShootPlayer : MonoBehaviour {
    // Bullet
    private Transform shootPoint;
    public GameObject bullet;
    private float bulletForce = 10f;
    private string path;
    public string TypeOfBullet;

    private bool ableToShoot;

    public bool shootFromAnimator;
    
    public float waitToShoot;

    private float aimAngle;

    private GameObject target;
    
    void Start() {
        ableToShoot = true;

        shootPoint = transform.Find("Cannon");

        path = "Prefabs/EnemyBullets/" + TypeOfBullet;

        bullet = (GameObject) Resources.Load(path, typeof(GameObject));

        target = GameObject.Find("Player");
    }

    void Update() {
        if (ableToShoot && !shootFromAnimator) { 
            StartCoroutine(ShootBulletCoroutine());
            ableToShoot = false;
        }
        
        RotateCannon();
    }

    IEnumerator ShootBulletCoroutine() {
        yield return new WaitForSeconds(waitToShoot);
        ShootBullet();
        ableToShoot = true;
    }

    void ShootBullet() {
        GameObject bulletInstantiated = Instantiate(bullet, shootPoint.position, shootPoint.rotation);
        Rigidbody2D bulletRB = bulletInstantiated.GetComponent<Rigidbody2D>();
        bulletRB.AddForce(shootPoint.right * bulletForce, ForceMode2D.Impulse);
    }

    void RotateCannon() {
        Vector2 aim = gameObject.transform.position - target.transform.position;
        aim *= -1f;
        aimAngle = Mathf.Atan2(aim.y, aim.x) * Mathf.Rad2Deg;
        shootPoint.transform.rotation = Quaternion.Euler(0, 0, aimAngle);
    }

    public string bulletPath {
        get { return path; }
    }
}
