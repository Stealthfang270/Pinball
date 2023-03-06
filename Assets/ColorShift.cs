using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorShift : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float _speed = 0.2f;
    [SerializeField] float _saturation = 1f;
    [SerializeField] float _value = 1f;

    private Camera cam;
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        float amount = _speed * Time.deltaTime;
        Color newColor = ShiftColor(cam.backgroundColor, amount);
        cam.backgroundColor = newColor;
    }

    private Color ShiftColor(Color color, float amount)
    {
        Color.RGBToHSV(color, out float hue, out float sat, out float val);

        hue += amount;
        sat = _saturation;
        val = _value;

        return Color.HSVToRGB(hue, sat, val);
    }
}
