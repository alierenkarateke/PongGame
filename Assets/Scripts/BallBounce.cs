using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBounce : MonoBehaviour
{
    public BallMovement ballMovement;
    public ScoreManager scoreManager;
    public GameObject hitSFX;

    private void Bounce(Collision2D collison)
    {
        Vector3 ballPosition = transform.position;
        Vector3 racketPosition = collison.transform.position;
        float racketHeight = collison.collider.bounds.size.y;

        float positionX;

        if (collison.gameObject.name == "Player 1")
        {
            positionX = 1;
        }
        else
        {
            positionX = -1;
        }

        float positionY = (ballPosition.y - racketPosition.y) / racketHeight;
        ballMovement.IncreaseHitCounter();
        ballMovement.MoveBall(new Vector2(positionX, positionY));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player 1" || collision.gameObject.name == "Player 2")
        {
            Bounce(collision);
        }
        else if (collision.gameObject.name == "Right Border")
        {
            scoreManager.Player1Goal();
            ballMovement.player1Start = false;
            StartCoroutine(ballMovement.Launch());
        }
        else if (collision.gameObject.name == "Left Border")
        {
            scoreManager.Player2Goal();
            ballMovement.player1Start = true;
            StartCoroutine(ballMovement.Launch());
        }
        Instantiate(hitSFX);
        
    }
}
