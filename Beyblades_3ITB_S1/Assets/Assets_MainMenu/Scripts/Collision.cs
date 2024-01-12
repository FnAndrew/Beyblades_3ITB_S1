using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    //[SerializeField]
    //Rigidbody playerRB;
    [SerializeField]
    PlayerControl playerControl;

    EnemyControl enemyControl;

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.gameObject.GetComponent<EnemyControl>() != null)
        {
            enemyControl = collision.gameObject.GetComponent<EnemyControl>();
            OnHit();
        }
    }

    private void OnHit()
    {
        float playerHitScore = Random.Range(20, 50);
        float enemyHitScore = Random.Range(20, 50);

        float playerSpeedScore = Random.Range(0, 10);
        float enemySpeedScore = Random.Range(0, 10);

        playerControl.Hit(enemyHitScore, enemySpeedScore);
        enemyControl.Hit(playerHitScore, playerSpeedScore);
    }


}
