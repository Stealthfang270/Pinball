using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] SpringJoint2D spring;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PullSpring(float amount)
    {
        spring.distance = amount - 12f;

        spring.attachedRigidbody.AddForce(Vector2.down * amount * 16);
        Debug.Log("Weeee");

    }
}
