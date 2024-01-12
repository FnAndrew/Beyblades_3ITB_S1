using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField]
    protected Rigidbody rb;
    new Transform transform;

    [SerializeField]
    protected float speed = 2f;
    protected ForceMode mode = ForceMode.Impulse;

    protected bool gameStarted = false;

    [SerializeField]
    private MenuControl menuControl;

    [SerializeField]
    protected GameObject gameManager;
    protected GameManager gameManagerScript;
    protected SliderManager sliderManager;
    protected bool started = false;
    protected Vector3 previousPosition;
    protected float curSpeed;

    [SerializeField]
    public float hp { get; private set; } = 100;

    protected virtual void Start()
    {
        transform = GetComponent<Transform>();
        
        gameManagerScript = gameManager.GetComponent<GameManager>();
        previousPosition = rb.position;
        sliderManager = gameManager.GetComponent<SliderManager>();

        gameStarted = sliderManager.started;
    }

    protected virtual void Update()
    {
        gameStarted = sliderManager.started;

        CalculateSpeed();
        CheckPositionLevel();

        Debug.Log($"Transform Y: {transform.position.y} | map level: {gameManagerScript.mapLevel}");
    }

    protected void CalculateSpeed()
    {
        Vector3 currentPosition = transform.position;
        float distance = Vector3.Distance(currentPosition, previousPosition);
        curSpeed = distance / Time.deltaTime;
        previousPosition = currentPosition;
    }

    public void Hit(float hpVal, float speedVal)
    {
        hp -= hpVal;
        curSpeed -= speedVal;

        // zkontrolování hodnoty
        if(hp <= 0 || curSpeed <= 0)
        {
            Death();
        }
    }

    protected void CheckPositionLevel()
    {
        if(transform.position.y < gameManagerScript.mapLevel)
        {
            Debug.Log("Entita spadla z mapy!");
            Death();
        }
    }

    void Death()
    {
        Debug.Log($"Entity is dead! {hp} | {curSpeed} | {transform.position}");
        Time.timeScale = 0; //zastavit èas
        menuControl.changeSceneTo(3); //death menu
    }
}
