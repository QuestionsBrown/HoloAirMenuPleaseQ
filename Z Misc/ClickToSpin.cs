using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ClickToSpin : MonoBehaviour
{

    [SerializeField]  GameEvent _onSpun;



    bool _artStopped;





    private void OnMouseDown()
    {
        if (_artStopped == true)

            spinArt();

    }


    void spinArt()

    {

        _onSpun.Invoke();
        Debug.Log("Art Is Now Spinning");
        _artStopped = false;


    }

    // public GameObject artParent;
    //public GameObject arCamera;
    // RaycastHit hit;

    // Scritable Object Event Reference
    // public Rotator raycastSpin;







    // Start is called before the first frame update
    //void Start()
    //  {
    //    artParent.tag = "Art 1";

    // }



    // Update is called once per frame
    //void Update()
    // {


    //    if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
    //    {


    //      if Physics.Raycast(arCamera.transform.position, arCamera.transform.forward, out hit))
    //      {

    //         if(hit.transform.tag == "Art 1")
    //         {
    //
    //             Debug.Log("Art Clicked");
    //         }
    //     }
    //  }





}

