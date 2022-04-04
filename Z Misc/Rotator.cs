using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Rotator : MonoBehaviour
{
    [SerializeField] GameEvent _onSpun;
    bool artStopped = true;
    public float rotationSpeed;
    public Transform customPivot;




    private void Start()
    {
        artStopped = false;
    }

    // Update is called once per frame
    void Update()
    {
       
           
       
    }


 




    private void OnMouseUpAsButton()
    {
        if (artStopped == true)
        {

            
            startSpinningArt();

        }

        else

            stopSpinningArt();


       
    }




   public void startSpinningArt()
    {
        rotationSpeed = 10f;
        transform.RotateAround(customPivot.position, Vector3.up, 10 * Time.deltaTime);
        artStopped = false;
    }



    public void stopSpinningArt()
    {

        rotationSpeed = 0f;
        transform.RotateAround(customPivot.position, Vector3.up, rotationSpeed * Time.deltaTime);
        artStopped = true;

    }


}
