using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ColorPicker : MonoBehaviour
{




    public Image image;




    private float r = 1f;
    private float g = 1f;
    private float b = 1f;
    private float a = 1f;

    private Color current_Color;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void SetR(float _r) {

        r = _r;
        SetColor();
    }


    public void SetG(float _g)
    {

        g = _g;
        SetColor();
    }


    public void SetB(float _b)
    {

        b = _b;
        SetColor();
    }



    public void SetA(float _a)
    {

        a = _a;
        SetColor();
    }


    private void SetColor()
    {

        current_Color = new Color(r, g, b, a);
        image.color = current_Color;
    }



    public Color GetColor()
    {
        return current_Color;
    }



}
