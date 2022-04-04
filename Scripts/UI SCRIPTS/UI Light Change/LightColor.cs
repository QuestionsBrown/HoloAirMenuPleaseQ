using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightColor : MonoBehaviour
{
    private Light _light;
    private Material mat;
    public ColorPicker picker;


    private float timer = 0f;
    private float colorTimer = 0.25f;

    // Start is called before the first frame update
    private void Start()
    {
        //mat = GetComponent<MeshRenderer>().material;
        _light = GetComponent<Light>();
    }

        // Update is called once per
       private void Update()
        {


         
            _light.color = picker.GetColor();
 

        }
    }


