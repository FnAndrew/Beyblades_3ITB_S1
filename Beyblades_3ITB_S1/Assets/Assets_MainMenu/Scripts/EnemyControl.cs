using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : Entity
{
    System.Random rnd = new System.Random();

    float aiOffset = 5f;

    protected override void Start()
    {
        base.Start();

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        //UnityEngine.Debug.Log($"ENEMY started value: {sliderManager.started}");
        if (gameStarted)
        {
            if (rb.position.x > -aiOffset && rb.position.x < aiOffset && rb.position.z > -aiOffset && rb.position.z < aiOffset)
            {
                int index = rnd.Next(0, 4);
                switch (index)
                {
                    case 0:
                        // down
                        rb.AddForce(transform.forward * -speed, mode);
                        break;
                    case 1:
                        // dopredu
                        rb.AddForce(transform.forward * speed, mode);
                        break;
                    case 2:
                        // doleva
                        rb.AddForce(transform.right * -speed, mode);
                        break;
                    case 3:
                        // doprava
                        rb.AddForce(transform.right * speed, mode);
                        break;
                    default:
                        Debug.Log("rozbil se random;");
                        break;
                }
            }
            else
            {
                if (Math.Abs(rb.position.z) > Math.Abs(rb.position.x))
                {
                    if (rb.position.z > 0)
                    {
                        rb.AddForce(transform.forward * -speed, mode);
                    }
                    else
                    {
                        rb.AddForce(transform.forward * speed, mode);
                    }
                }
                else
                {
                    if (rb.position.x > 0)
                    {
                        rb.AddForce(transform.right * -speed, mode);
                    }
                    else
                    {
                        rb.AddForce(transform.right * speed, mode);
                    }
                }
            }
        }
    }
    /*private void OnCollisionEnter(Collision collision)
    {
        //odeber hp
        // gameManagerScript.enemyHp -= 
        // real co
        gameManagerScript.playerHp -= curSpeed;
       // UnityEngine.Debug.Log(gameManagerScript.playerHp);
    }*/
}