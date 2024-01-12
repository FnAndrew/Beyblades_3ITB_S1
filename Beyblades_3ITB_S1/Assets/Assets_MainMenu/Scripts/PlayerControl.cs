using System.Diagnostics;
using UnityEngine;

public class PlayerControl : Entity
{
    [SerializeField]
    GameObject player;

    [SerializeField]
    Transform objectForRotation;

    protected override void Start()
    {
        base.Start();

        rb = player.GetComponent<Rigidbody>();
    }
    protected override void Update()
    {
        base.Update();

        // Optionally, you can use the speed value in your game logic
        UnityEngine.Debug.Log("Current player speed: " + speed);
        //UnityEngine.Debug.Log($"PLAYER started value: {sliderManager.started}");

        if (gameStarted) // zmenit na !started
        {
            //chargebar
            if (started)
            {
                if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    rb.AddForce(transform.right * -speed, mode);
                }
                else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
                {
                    rb.AddForce(transform.forward * -speed, mode);
                }
                else if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
                {
                    rb.AddForce(transform.forward * speed, mode);
                }
                else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
                {
                    rb.AddForce(transform.right * speed, mode);
                }
            }
            else
            {
                float pushForce = 3f * sliderManager.sliderVal; //0-5
                UnityEngine.Debug.Log(pushForce + " aiasilfkhaslkhfas");
                UnityEngine.Debug.Log(transform.forward * speed * pushForce + "Jsi kripl");
                rb.AddForce(transform.forward * speed * pushForce, mode);
                UnityEngine.Debug.Log("funguje");
                started = true;
            }

                //var step = pushForce * Time.deltaTime;

                // Rotate our transform a step closer to the target's.
                //objectForRotation.rotation = Quaternion.Euler(0, 0, 10000 * speed * pushForce);


        }
    }
    /*private void OnCollisionEnter(Collision collision)
    {
        //odeber hp
        // gameManagerScript.enemyHp -= 
        // real co
        gameManagerScript.enemyHp -= curSpeed;
        //UnityEngine.Debug.Log(gameManagerScript.enemyHp);
    }*/
}

/*
 *    private Vector3 previousPosition;
    private float speed;

    void Start()
    {
        // Initialize the previous position to the current position at the start
        previousPosition = transform.position;
    }

    void Update()
    {
        // Calculate the current speed
        CalculateSpeed();

        // Optionally, you can use the speed value in your game logic
        Debug.Log("Current Speed: " + speed);
    }

    void CalculateSpeed()
    {
        // Calculate the change in position
        Vector3 currentPosition = transform.position;
        float distance = Vector3.Distance(currentPosition, previousPosition);

        // Calculate the speed (distance divided by time)
        // Time.deltaTime represents the time taken to complete the last frame
        speed = distance / Time.deltaTime;

        // Update the previous position for the next frame
        previousPosition = currentPosition;
    }*/