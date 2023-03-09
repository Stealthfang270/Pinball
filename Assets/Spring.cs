using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] SpringJoint2D spring;
    [SerializeField] Rigidbody2D rb;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PullSpring(float amount)
    {
        spring.distance = amount - 12;

        //rb.AddForce(Vector2.down * amount * 5000f);
        rb.transform.position = new Vector2(3.51f, -4.5f);

    }
}
