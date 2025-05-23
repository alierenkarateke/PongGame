using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class BallMovement : MonoBehaviour
{

    // Starting speed of the ball
    public float startSpeed;

    // Will add speed after collison 
    public float extraSpeed;

    // Limited add extre speed || Speed limit 
    public float maxExtraSpeed;

    // Collison count
    private float hitCounter = 0;

    // Rigidbody
    private Rigidbody2D rb;


    public bool player1Start = true;


    void Start()
    {
        // Rigidbody identify   
        rb = GetComponent<Rigidbody2D>();

        // Starting Coroutine func
        StartCoroutine(Launch());
    }

    private void RestartBall()
    {
        rb.velocity = new Vector2(0, 0);
        transform.position = new Vector2(0, 0);
    }

    public IEnumerator Launch()
    {

        RestartBall();
        // hitCounter starting 0
        hitCounter = 0;

        // 2 second wait
        yield return new WaitForSeconds(2);

        if (player1Start == true)
        {
            MoveBall(new Vector2(-1, 0));
        }
        else
        {
            MoveBall(new Vector2(1, 0));    
        }
        // Starting MoveBall func
        MoveBall(new Vector2(-1, 0));
    }

    public void MoveBall(Vector2 direction)
    {
        // Direction
        direction = direction.normalized;

        // Speed increase
        float ballSpeed = startSpeed + hitCounter * extraSpeed;

        // Speed identify
        rb.velocity = direction * ballSpeed;
    }

    public void IncreaseHitCounter()
    {
        // Extraspeed identify
        if (hitCounter * extraSpeed < maxExtraSpeed)
        {
            hitCounter++;
        }
    }
}
