using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using TMPro;

public class UIMovement : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI topTitle;

    [SerializeField] private GameObject sideUIPanel;
    //[SerializeField] private GameObject pagePanel;
    [SerializeField] private GameObject onboardPanel;
    [SerializeField] private GameObject musicPanel;

    [SerializeField] private Button[] onboardButtons;
    [SerializeField] private Button[] songButtons;

    [SerializeField] private Button openMenuButton1;


    [SerializeField] private GameObject openMenuButton;
    [SerializeField] private GameObject closeMenubutton;


    [SerializeField] private Button openOnBoardButton;
    [SerializeField] private Button openMusicButton;

    [SerializeField] private VideoPlayer videoPlayer;


    private Vector3 sideUIPanelOffScreenpos;
    private Vector3 sideUIPanelOnScreenPos;


    private Vector3 pagePanelFROnScreenPos;
    private Vector3 pagePanelFROffScreenPos;


    LTDescr moveTween1 = null;
    LTDescr moveBackTween1 = null;
    int moveIDStart1;
    int moveBackIDStart1;

    LTDescr moveTween2 = null;
    int moveIDStart2;

    public float moveDuration;
    public float delay;

    bool isVisisble = false;


    void Start()
    {

        //Setting Locations
        sideUIPanelOffScreenpos = new Vector3(-700, 1212, 0);
        sideUIPanelOnScreenPos = new Vector3(-364.6f, 1212, 0);

        pagePanelFROnScreenPos = new Vector3(0, -755, 0);
        pagePanelFROffScreenPos = new Vector3(0, -935, 0);


        //Placing Offscreen
        sideUIPanel.transform.localPosition = sideUIPanelOffScreenpos;
        //pagePanel.transform.localPosition = pagePanelFROffScreenPos;

        LeanTween.scale(onboardPanel, new Vector3(0, 0, 0), 0f).setEase(LeanTweenType.easeInOutSine);
        LeanTween.scale(musicPanel, new Vector3(0, 0, 0), 0f).setEase(LeanTweenType.easeInOutSine);
        //movePagePanel();

        Button btn = openMenuButton1.GetComponent<Button>();
        btn.onClick.AddListener(panelCheck2);
    }



    //Open Close Music Panel
    public void scaleMusicPanel()
    {
        if (musicPanel.transform.localScale == new Vector3(1.584344f, 0.3401819f, 1.18704f))
        {
            LeanTween.scale(musicPanel, new Vector3(0, 0, 0), .75f).setEase(LeanTweenType.easeInCirc);
            foreach (Button btn in songButtons)
            {
                btn.image.color = Color.gray;
            }
        }

        else if (musicPanel.transform.localScale == new Vector3(0, 0, 0))
        {
            LeanTween.scale(onboardPanel, new Vector3(0, 0, 0), .75f).setEase(LeanTweenType.easeInCirc);

            foreach (Button btn in songButtons)
            {
                btn.image.color = Color.gray;
            }
            //songButtons[0].image.color = Color.white;
            LeanTween.scale(musicPanel, new Vector3(1.584344f, 0.3401819f, 1.18704f), .75f).setEase(LeanTweenType.easeInCirc);
        }
    }



   //Open Close onBoardPanel
    public void scaleOnbaordpanel()
    {
        if (onboardPanel.transform.localScale == new Vector3(1, 1, 1))
        {


            LeanTween.scale(onboardPanel, new Vector3(0, 0, 0), .75f).setEase(LeanTweenType.easeInCirc);
            videoPlayer.Stop();
 
            foreach (Button btn in onboardButtons)
            {
                btn.image.color = Color.gray;

            }
        }

        else if (onboardPanel.transform.localScale == new Vector3(0, 0, 0))
        {

            LeanTween.scale(musicPanel, new Vector3(0, 0, 0), .75f).setEase(LeanTweenType.easeInCirc);
            onboardButtons[0].image.color = Color.white;

           
            LeanTween.scale(onboardPanel, new Vector3(1, 1, 1), .75f).setEase(LeanTweenType.easeInCirc);

            foreach (Button btn in onboardButtons)
            {
                btn.image.color = Color.gray;

            }
        }
    }


    //public void movePagePanel()
    //{
    //    initMoveTween2(pagePanel, pagePanelFROnScreenPos, 3, delay);
    //    moveTween2.resume();
    //}


    public void panelCheck2()
    {

        float r = 243;
        float g = 188;
        float b = 255;

        if (sideUIPanel.transform.localPosition == sideUIPanelOffScreenpos)
        {

            //openMenuButton.SetActive(false);
            //closeMenubutton.SetActive(true);
            initMoveTween(sideUIPanel, sideUIPanelOnScreenPos, moveDuration, delay);
            moveTween1.resume();
            //openMenuButton1.image.color = new Color(r, g, b);
            isVisisble = true;

        }

        else if (sideUIPanel.transform.localPosition == sideUIPanelOnScreenPos)
        {
            //openMenuButton.SetActive(true);
            //closeMenubutton.SetActive(false);
            initMoveBackTween(sideUIPanel, sideUIPanelOffScreenpos, moveDuration, delay);
            moveBackTween1.resume();
            //openMenuButton1.image.color = new Color(r, g, b);
            isVisisble = false;
        }
    }

    public void initMoveTween(GameObject sidePanel, Vector3 itemVector, float moveDuration, float delay)
    {

        LeanTween.cancel(moveIDStart1);
        int moveID = LeanTween.moveLocal(sidePanel, itemVector, moveDuration).setEaseInOutQuad().setDelay(delay).id;
        moveIDStart1 = moveID;
        moveTween1 = LeanTween.descr(moveIDStart1);
        moveTween1.pause();
    }


    public void initMoveBackTween(GameObject sidePanel, Vector3 itemVector, float moveDuration, float delay)
    {
        LeanTween.cancel(moveBackIDStart1);
        int resetID1 = LeanTween.moveLocal(sidePanel, itemVector, moveDuration).setEaseInOutSine().setDelay(delay).id;
        moveBackIDStart1 = resetID1;
        moveBackTween1 = LeanTween.descr(moveBackIDStart1);
        moveBackTween1.pause();
    }

    public void initMoveTween2(GameObject pagesPanel, Vector3 itemVector, float moveDuration, float delay)
    {
        LeanTween.cancel(moveIDStart2);
        int moveID = LeanTween.moveLocal(pagesPanel, itemVector, 3).setEaseInOutQuad().setDelay(delay).id;
        moveIDStart2 = moveID;
        moveTween2 = LeanTween.descr(moveIDStart2);
        moveTween2.pause();
    }

    public void openMapsLink ()
        {
        //Application.OpenURL("https://www.backyardburgers.com/store-locator/");

        Application.OpenURL("https://goo.gl/maps/EZkPYp7ja684EzH97");

        //Debug.Log("WTF WORK LINK PLEASE");
        }

    public void openWebsiteLink()
    {
        //Application.OpenURL("https://www.backyardburgers.com/store-locator/");

        Application.OpenURL("https://q21turner.wixsite.com/intrinsicreality");

        Debug.Log("WTF WORK LINK PLEASE");
    }

}
