using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Balls : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] BallTeleporter ballTeleporter;
    TextMeshProUGUI text;
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Balls: " + ballTeleporter.ballsLeft;
    }
}
