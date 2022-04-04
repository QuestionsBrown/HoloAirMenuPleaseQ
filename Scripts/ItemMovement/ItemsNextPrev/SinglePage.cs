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

public class SinglePage : MonoBehaviour
{

    [Header("UI")]
    [SerializeField] private GameObject uiPagePanel;
    [SerializeField] private Button previousButton;
    [SerializeField] private TextMeshProUGUI homeText;
    [SerializeField] private TextMeshProUGUI pageNumber;
    [SerializeField] private TextMeshProUGUI topTilte;
    [SerializeField] private GameObject storeParent;

    [Header("Pages")]
    [SerializeField] private GameObject[] catgeoryPages;

    [Header("Main Menu")]
    [SerializeField] private GameObject mainMenuScroller;
    [SerializeField] private GameObject mainPagePanel;
    [SerializeField] private GameObject returnBox;

    [SerializeField] private GameObject returnButton;

    [SerializeField] private GameObject topTitleGO;

    [SerializeField] private int currentPage = 0;

    [SerializeField] ARSession arSession;

    [SerializeField] Camera arCamera;

    private void Awake()
    {
        selectPage(0);
    }


    public void changePage(int _change)
    {
        currentPage += _change;
        selectPage(currentPage);
    }

    private void selectPage(int _index)
    {

        if (currentPage == 0 )
        {

            homeText.text = "Main";
        }


        previousButton.interactable = (_index != -100);

        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(i == _index);
            slidePageHolder(_index);
   
        }

        pageNumber.text = currentPage + 1 + "" + "/" + catgeoryPages.Length + "";
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
         
                uiPagePanel.transform.localPosition = new Vector3(-350, -4000f, 0);
                LeanTween.moveLocal(transform.gameObject, new Vector3(0, 1, 0), 0).setEase(LeanTweenType.easeInOutSine);
                mainPagePanel.transform.localPosition = new Vector3(-350, -1131.84f, 0);
                LeanTween.moveLocal(mainMenuScroller, new Vector3(0, 0, 0), 0).setEase(LeanTweenType.easeInOutSine);
                changePageTo0();
                transform.GetChild(0).gameObject.SetActive(false);
                returnBox.SetActive(false);
                waitToSnap();

                returnButton.SetActive(false);

                //LeanTween.scale(topTitleGO, new Vector3(0f, 0f, 0f), 0.3f).setEase(LeanTweenType.easeInSine);
                topTilte.text = "MAIN MENU";

                //LeanTween.scale(topTitleGO, new Vector3(1f, 1f, 1f), 1f).setEase(LeanTweenType.easeInOutSine);
                break;

            case 0:
                LeanTween.moveLocal(catgeoryPages[0], new Vector3(0, 0, 0), 0).setEase(LeanTweenType.easeInOutSine);
                waitToSnap();
                break;

            default:
                return;

        }

    }

    public IEnumerator waitToSnap()
    {

        yield return new WaitForSeconds(0);

        storeParent.gameObject.transform.parent = arCamera.gameObject.transform;

    }


}
