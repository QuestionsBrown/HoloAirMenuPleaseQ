using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateArt : MonoBehaviour
{



    public GameObject art;

    public float rotationspeed;

    public bool rotatStatus = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (rotatStatus == true)

            art.transform.Rotate(Vector3.up, rotationspeed * Time.deltaTime);


    }



    public void Rotate()
    {

        if (rotatStatus == false)
        {
            rotatStatus = true;
        }


        else
        {

            rotatStatus = false;

        }

    }


    public void stopRotate()
    {

        if (rotatStatus == true)
        {
            rotatStatus = false;
        }


        else
        {

            rotatStatus = true;

        }

    }

}