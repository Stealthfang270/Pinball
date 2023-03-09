using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointToggler : MonoBehaviour
{
    [SerializeField] public SpringJoint2D joint;
    private Rigidbody2D connectedRb;

    // Start is called before the first frame update
    void Start()
    {
        connectedRb = joint.connectedBody;
    }

    // Update is called once per frame
    public void Enable()
    {
        joint.connectedBody = connectedRb;
    }

    public void Disable()
    {
        joint.connectedBody = null;
        connectedRb.WakeUp();
    }
}
