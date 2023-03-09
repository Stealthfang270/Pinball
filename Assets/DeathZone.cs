using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]BallTeleporter ballTeleporter;
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ballTeleporter.SetBallPos(new Vector2(3.5f, -3f));
    }
}
