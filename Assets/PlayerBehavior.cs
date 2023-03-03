using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class PlayerBehavior : MonoBehaviour
{

    [SerializeField] PaddleController leftPaddle;
    [SerializeField] PaddleController rightPaddle;

    [SerializeField] InputAction useLeft;
    [SerializeField] InputAction useRight;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        leftPaddle.FlipPaddle(useLeft.IsPressed());
        rightPaddle.FlipPaddle(useRight.IsPressed());
    }

    private void OnEnable()
    {
        useLeft.Enable();
        useRight.Enable();
    }

    private void OnDisable()
    {
        useLeft.Disable();
        useRight.Disable();
    }
}
