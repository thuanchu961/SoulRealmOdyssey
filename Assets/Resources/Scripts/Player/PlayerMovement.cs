﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    // Movement attributes
    private Vector3 movementSpeed;
    private float speedX;
    private float speedY;

    public GameObject dust;
    private bool canDust;

    [Header("Movement config")]
    [SerializeField]
    [Range(0f, 100f)]
    private float speed;
    [SerializeField] private Joystick joystick;
    void Start() {
        InvokeRepeating ("PlaySound", 0.0f, Random.Range(0.25f, 0.45f));
        canDust = true;
    }

    void Update() {
        Movement();
    }

    void PlaySound() {
        if (Mathf.Abs(speedX) > 0 || Mathf.Abs(speedY) > 0)
            SoundManager.Instant.PlaySound(Constant.SFX.Steps);
    }

    // Player movement
    void Movement() {
#if UNITY_EDITOR || UNITY_STANDALONE_WIN
        speedX = Input.GetAxis("Horizontal") * speed;
        speedY = Input.GetAxis("Vertical") * speed;
#elif PLATFORM_ANDROID
        speedX = joystick.Horizontal  * speed;
        speedY = joystick.Vertical * speed;
#endif

        movementSpeed = new Vector3(speedX, speedY, 0f);

        if (movementSpeed.magnitude > 0 && canDust)
            StartCoroutine(WaitToDust());

        gameObject.GetComponent<Rigidbody2D>().velocity = movementSpeed;
        if (speedX != 0 || speedY != 0)
            gameObject.GetComponent<Animator>().SetBool("isMoving", true);
        else
            gameObject.GetComponent<Animator>().SetBool("isMoving", false);
    }

    private IEnumerator WaitToDust () {
        canDust = !canDust;
        yield return new WaitForSeconds(Random.Range(0.15f, 0.25f));
        canDust = !canDust;
        if (movementSpeed.magnitude > 0)
            Instantiate(dust, transform.Find("Shadow").transform.position, Quaternion.identity);
    }
}
