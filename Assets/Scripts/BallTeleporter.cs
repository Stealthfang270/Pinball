using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallTeleporter : MonoBehaviour
{

    Rigidbody2D rb;
    public int ballsLeft = 5;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Mouse.current.leftButton.wasPressedThisFrame)
        {
            SetBallPos(Camera.main.ScreenToWorldPoint(Mouse.current.position.value));
        }
    }

    public void SetBallPos(Vector2 pos)
    {
        rb.transform.position = pos;
        rb.velocity = Vector2.zero;
        ballsLeft--;
    }
}
