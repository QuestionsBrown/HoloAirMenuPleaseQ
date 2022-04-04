using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class StartArtAnimationCancelFixWithoutDoTween : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{

    [SerializeField] GameEvent _onArtAnimation;
    [SerializeField] GameEvent _onResetArtPos;



    [SerializeField] private Ease _moveEase = Ease.Linear;

    [SerializeField] private DotweenType _dotweenType = DotweenType.MovementOneway;

    private enum DotweenType
    {
        MovementOneway
    }


    Sequence mySequence = DOTween.Sequence();

    [SerializeField] private CanvasGroup canvasGroup;

    [SerializeField] private GameObject artPeice;
    [SerializeField] private Transform artViewingLocation;
    [SerializeField] private Transform artOriginssss;
    [SerializeField] private float moveDuration;

    bool is_Pressed = false;

    public GameObject Artwork;




    void Update()
    {
        if (is_Pressed)
        {
            Artwork.transform.Translate(0, 0, 0.002f);

            
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
