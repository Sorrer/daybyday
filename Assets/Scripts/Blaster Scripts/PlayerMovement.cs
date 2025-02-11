﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    // Drag the Character Controller 2D script into here;
    // Now any reference to "controller" will ref that script
    /** public CharacterController2D controller;

    public float runSpeed = 40f;

    float horizontalMove = 0f;

    // Update is called once per frame
    
    void Update()
    {
        // Gets user input for direction on horizontal axis
        // A or left arrow = -1, D or right arrow = 1
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
    }

    void FixedUpdate()
    {
        // Move our character
        // Ultimately, take input from Update and apply here

        // Move takes 3 inputs: horizontal, crouch, jump
        // Since bokki only uses horizontal, false to others
        // Time.fixedDeltaTime = time elapsed since function last called --> moves same amt every time called
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, false);
    }
    **/

    public float speed;
    private Rigidbody2D rb2d;
    public int rocketHealth;
    private int maxHealth;
    public int enemyDamage;
    public int starRestore;
    public GameObject bulwark;

    public float speedEffectTimer;
    private float speedEffectDuration;

    private float unSwift;
    public float swiftTimer;
    private bool isSwift;

    void Start()
    {
        maxHealth = rocketHealth;
        rb2d = GetComponent<Rigidbody2D> ();
        //rocketHealth = 100;
        isSwift = false;
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(moveHorizontal, 0);
        rb2d.AddForce(movement * speed);
        /**if (speedEffectTimer < Time.time)
        {
            speed = 50;
        }**/
    }

    void Update()
    {
        if (isSwift == true) {
            if (Time.time >= unSwift) {
                speed = speed/2;
                isSwift = false;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            rocketHealth = rocketHealth - enemyDamage;
            //Debug.Log(rocketHealth);
            if (rocketHealth <= 0)
            {
                Destroy(gameObject);
                Debug.Log("Dead");
                SceneManager.LoadScene(3);
            }
            Destroy(col.gameObject);
        }
        if (col.gameObject.tag == "enemBullet")
        {
            rocketHealth = rocketHealth - enemyDamage;
            //Debug.Log(rocketHealth);
            if (rocketHealth <= 0)
            {
                Destroy(gameObject);
                Debug.Log("Dead");
                
            }
            Destroy(col.gameObject);
        }
        if (col.gameObject.tag == "Star")
        {
            if (rocketHealth < (maxHealth-starRestore))
            {
                rocketHealth = rocketHealth + starRestore;
                //Debug.Log(rocketHealth);
            }
            Destroy(col.gameObject);
        }
        if (col.gameObject.tag == "Swift")
        {
            speed = speed*2;
            Destroy(col.gameObject);
            //speedEffectTimer = Time.time + speedEffectDuration;
            unSwift = Time.time + swiftTimer;
            isSwift = true;
        }
        if (col.gameObject.tag == "Bulwark")
        {
            Destroy(col.gameObject);
            Instantiate(bulwark);
        }
    }

}
