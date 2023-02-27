using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PaddleController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] HingeJoint2D hinge;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FlipPaddle(Keyboard.current.spaceKey.isPressed);
    }

    public void FlipPaddle(bool isPressed)
    {
        hinge.useMotor = isPressed;
    }
}
