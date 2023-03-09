using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class PlayerBehavior : MonoBehaviour
{

    [SerializeField] PaddleController leftPaddle;
    [SerializeField] PaddleController rightPaddle;
    [SerializeField] Spring spring;

    [SerializeField] InputAction useLeft;
    [SerializeField] InputAction useRight;
    [SerializeField] InputAction pullSpring;

    JointToggler toggler;



    // Start is called before the first frame update
    void Start()
    {
        toggler = GetComponent<JointToggler>();
    }

    // Update is called once per frame
    void Update()
    {
        leftPaddle.FlipPaddle(useLeft.IsPressed());
        rightPaddle.FlipPaddle(useRight.IsPressed());
        if(pullSpring.IsPressed())
        {
            toggler.Disable();
            spring.PullSpring(12f);
        } else
        {
            toggler.Enable();

        }
    }

    private void OnEnable()
    {
        useLeft.Enable();
        useRight.Enable();
        pullSpring.Enable();
    }

    private void OnDisable()
    {
        useLeft.Disable();
        useRight.Disable();
        pullSpring.Disable();
    }
}
