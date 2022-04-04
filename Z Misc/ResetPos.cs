using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.ARKit;
using UnityEngine.EventSystems;

public class ResetPos : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{


    [SerializeField] private GameObject artPeice;
    [SerializeField] private GameObject artViewingLocation;
    [SerializeField] private GameObject artOrigin;
    [SerializeField] ARSession arsession;
    [SerializeField] private float moveDuration;




    bool is_Pressed = false;






    void Update()
    {
        if (is_Pressed)
        {
            moveBackToOrigin();
        }
    }



    public void moveBackToOrigin()
    {

        artPeice.transform.position = artOrigin.transform.position;
        ResetARSession();
    }



    public void ResetARSession()
    {
       arsession.Reset();
    }



    public void OnPointerUp(PointerEventData eventData)
    {
        is_Pressed = false;

        throw new System.NotImplementedException();
    }

    public void OnPointerDown(PointerEventData eventData)
    {

        is_Pressed = true;
        throw new System.NotImplementedException();
    }
}
