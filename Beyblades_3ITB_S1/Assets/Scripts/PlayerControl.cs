using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    Rigidbody rb;

    [SerializeField]
    float speed = 10f;
    ForceMode mode = ForceMode.Impulse;
    bool started = false;

    [SerializeField]
    Transform objectForRotaion;

    Quaternion axis2;

    void Start()
    {
        rb = player.GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (!started)
        {
            //chargebar
            float pushForce = 0.2f; //0-5
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(transform.forward * speed * pushForce, ForceMode.Impulse);
                Debug.Log("TVOJE MAMA");

                var step = pushForce * Time.deltaTime;

                // Rotate our transform a step closer to the target's.
                transform.rotation = Quaternion.RotateTowards(transform.rotation, objectForRotaion.rotation, step);

                started = true;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                rb.AddForce(transform.right * -speed, mode);
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                rb.AddForce(transform.forward * -speed, mode);
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                rb.AddForce(transform.forward * speed, mode);
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                rb.AddForce(transform.right * speed, mode);
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);   
    }
}
