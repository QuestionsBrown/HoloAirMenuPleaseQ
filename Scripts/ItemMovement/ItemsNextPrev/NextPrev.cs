using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.ARKit;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NextPrev : MonoBehaviour
{
    //hide prev replace with home button?
    [Header("UI")]
    [SerializeField] private GameObject uiPagePanel;
    UIPanelGameObject CameraPanel;
    [SerializeField] private Button nextButton;
    [SerializeField] private Button previousButton;
    [SerializeField] private TextMeshProUGUI pageNumber;
    [SerializeField] private TextMeshProUGUI homeText;
    [SerializeField] private TextMeshProUGUI nextPageText;
    [SerializeField] private GameObject returnBox;
    [SerializeField] private TextMeshProUGUI topTitle;
    [SerializeField] private GameObject topTitleGO;

    [SerializeField] private GameObject returnButton;
    [SerializeField] private GameObject storeParent;


    [Header("Pages")]
    [SerializeField] private GameObject[] catgeoryPages;

    [Header("Main Menu ")]
    [SerializeField] private GameObject mainMenuScroller;
    [SerializeField] private GameObject mainMenuPagePanel;

    [SerializeField] private int currentPage = 0;

    [SerializeField] ARSession arSession;


    [SerializeField] Camera arCamera;

    private void Awake()
    {
        selectPage(1);

    }


    public void changePage(int _change)
    {
        currentPage += _change;
        selectPage(currentPage);
    }

    private void selectPage(int _index)
    {

        if (currentPage == 1)
        {
            nextPageText.text = "";
            homeText.text = "Prev";
        }


        if (currentPage == 0)
        {
            homeText.text = "Main";
            nextPageText.text = "Next";
        }



   
       if (currentPage == catgeoryPages.Length -1)
        {
            nextButton.gameObject.SetActive(false);

        }

       else
        {
            nextButton.gameObject.SetActive(true);
        }

        nextButton.interactable = (_index != catgeoryPages.Length-1);
        //previousButton.interactable = (_index != catgeoryPages.Length + 1);

        previousButton.interactable = (_index != -1);


        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(i == _index);

            slidePageHolder(_index);
            Debug.Log("Selected Page");
        }

        pageNumber.text = currentPage + 1 + "" + "/" + catgeoryPages.Length + "" ;
    }


    public void changePageTo0()
    {
        currentPage = 1;
    }


    public void slidePageHolder(int _change)
    {



        switch (_change)
        {


            case -1:

                uiPagePanel.transform.localPosition = new Vector3(-350f, -4000f, 0);
                LeanTween.moveLocal(transform.gameObject, new Vector3(0, 1, 0), 0).setEase(LeanTweenType.easeInOutSine);
                mainMenuPagePanel.transform.localPosition = new Vector3(-350, -1131.84f, 0);
                LeanTween.moveLocal(mainMenuScroller, new Vector3(0, 0, 0), 0).setEase(LeanTweenType.easeInOutSine);
                returnBox.SetActive(false);
                waitToSnap();

                returnButton.SetActive(false);

                //LeanTween.scale(topTitleGO, new Vector3(0f, 0f, 0f), 0.3f).setEase(LeanTweenType.easeInOutSine);
                topTitle.text = "MAIN MENU";
                //LeanTween.scale(topTitleGO, new Vector3(1f, 1f, 1f), 2f).setEase(LeanTweenType.easeInOutSine);
                //changePageTo0();

                break;
            case 0:
                LeanTween.moveLocal(catgeoryPages[0], new Vector3(0, 0, 0), 1.5f).setEase(LeanTweenType.easeInOutSine);
                waitToSnap();
                break;

            case 1:
                LeanTween.moveLocal(catgeoryPages[1], new Vector3(0, 0, 0), 1.5f).setEase(LeanTweenType.easeInOutSine);
                waitToSnap();
                break;

            default:
                return;

        }

    }

    public IEnumerator waitToSnap()
    {

        yield return new WaitForSeconds(0f);

        storeParent.gameObject.transform.parent = arCamera.gameObject.transform;

    }

}








