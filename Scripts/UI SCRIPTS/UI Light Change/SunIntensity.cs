using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SunIntensity : MonoBehaviour
{

    public Light directional_Light;
    public Slider slider;
    public float intensity_Value;


    void Awake()
    {
        // Assign a callback for when this slider changes
        this.slider.onValueChanged.AddListener(this.OnSliderChanged);

        // And current value
        this.intensity_Value = this.slider.value;
    }


    void OnSliderChanged(float value)
    {
        // How much we've changed
        float delta = value - this.intensity_Value;
        // Set our previous value for the next change
        this.intensity_Value = value;
        directional_Light.intensity = intensity_Value;
    }
}
