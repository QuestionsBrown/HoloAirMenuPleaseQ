using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class MoveArtLeft : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{

    bool is_Pressed = false;

    public GameObject Artwork;




    void Update()
    {
        if (is_Pressed)
        {
            Artwork.transform.Translate(-0.002f, 0, 0);
        }
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
