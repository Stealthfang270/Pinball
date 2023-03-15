using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField][Range(0f, 30f)] float maxVelocity;

    [SerializeField] ScoreTracker scoreTracker;
    BallTeleporter ballTeleporter;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ballTeleporter = GetComponent<BallTeleporter>();
    }

    // Update is called once per frame
    void Update()
    {
        if(rb.velocity.magnitude > maxVelocity)
        {
            rb.velocity = rb.velocity.normalized * maxVelocity;
        }
        if(ballTeleporter.ballsLeft <= 0)
        {
            ballTeleporter.ballsLeft = 3;
            scoreTracker.ResetScore();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Bumper200")
        {
            scoreTracker.AddScore(200);
        }
        if(collision.gameObject.name == "Bumper400")
        {
            scoreTracker.AddScore(400);
        }
        if(collision.gameObject.name == "Bumper600")
        {
            scoreTracker.AddScore(600);
        }
        if(collision.gameObject.name == "Bumper800")
        {
            scoreTracker.AddScore(800);
        }
    }
}
