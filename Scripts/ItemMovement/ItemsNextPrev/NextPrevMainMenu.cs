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

public class NextPrevMainMenu : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private Button nextButton;
    [SerializeField] private Button previousButton;
    [SerializeField] private TextMeshProUGUI pageNumber;
    [SerializeField] private CanvasGroup prevButtonCanvasgroup;
    [SerializeField] private CanvasGroup nextButtonCanvasgroup;
    [SerializeField] private TextMeshProUGUI homeText;
    [SerializeField] private TextMeshProUGUI topTitle;

    [Header("Pages")]
    [SerializeField] private GameObject[] mainScrollerPages;
    [SerializeField] private int currentPage = 0;


    [SerializeField] private GameObject storeParent;

    [SerializeField] private GameObject onboardUI;
    [SerializeField] ARSession arSession;

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
        onboardUI.SetActive(false);

        if (currentPage == 0)
        {
            prevButtonCanvasgroup.alpha = 0;
            homeText.text = "PREV";
            nextButtonCanvasgroup.alpha = 1;
        }

        else
        {
            prevButtonCanvasgroup.alpha = 1;
        }


        if (currentPage == mainScrollerPages.Length - 1)
        {
            nextButtonCanvasgroup.alpha = 0;
            prevButtonCanvasgroup.alpha = 1;
        }


        previousButton.interactable = (_index != 0);


        nextButton.interactable = (_index != mainScrollerPages.Length - 1);


        for (int i = 0; i < transform.childCount; i++)
        {
            //transform.GetChild(i).gameObject.SetActive(i == _index);

            StartCoroutine(waitToUnhuded(_index, i));
            slidePageHolder(_index);
        }

        pageNumber.text = currentPage + 1 + "" + "/" + mainScrollerPages.Length + "";
    }


    public void slidePageHolder(int _change)
    {

        switch (_change)
        {
            case 0:
                topTitle.text = "CUISINE";

               

                LeanTween.moveLocal(mainScrollerPages[1], new Vector3(1, 0, 0), 2f).setEase(LeanTweenType.easeInOutSine);
                LeanTween.moveLocal(mainScrollerPages[0], new Vector3(0, 0, 0), 2f).setEase(LeanTweenType.easeInOutSine);
                //mainScrollerPages[1].transform.gameObject.SetActive(false);
                hidePg2Bitch();
                break;

            case 1:

                LeanTween.moveLocal(mainScrollerPages[0], new Vector3(-1, 0, 0), 2f).setEase(LeanTweenType.easeInOutSine);
                LeanTween.moveLocal(mainScrollerPages[1], new Vector3(0f, 0, 0), 2f).setEase(LeanTweenType.easeInOutSine);
                mainScrollerPages[1].SetActive(true);
                LeanTween.moveLocal(mainScrollerPages[2], new Vector3(1f, 0, 0), 2f).setEase(LeanTweenType.easeInOutSine);
                //LeanTween.moveLocal(mainScrollerPages[3], new Vector3(2, 0, 0), 2f).setEase(LeanTweenType.easeInOutSine);
                topTitle.text = "ART";
                nextButtonCanvasgroup.alpha = 1;


                //LeanTween.moveLocal(mainScrollerPages[0], new Vector3(-1, 0, 0), 2f).setEase(LeanTweenType.easeInOutSine);
                //mainScrollerPages[1].SetActive(true);
                //LeanTween.moveLocal(mainScrollerPages[1], new Vector3(0.017f, 0, 0), 2f).setEase(LeanTweenType.easeInOutSine);
                //LeanTween.moveLocal(mainScrollerPages[2], new Vector3(1f, 0, 0), 2f).setEase(LeanTweenType.easeInOutSine);
                //topTitle.text = "LEMAIRE";
                ////nextButtonCanvasgroup.alpha = 1;
                break;


            case 2:

                LeanTween.moveLocal(mainScrollerPages[0], new Vector3(-1, 0, 0), 2f).setEase(LeanTweenType.easeInOutSine);
                LeanTween.moveLocal(mainScrollerPages[1], new Vector3(-1f, 0, 0), 2f).setEase(LeanTweenType.easeInOutSine);
                LeanTween.moveLocal(mainScrollerPages[2], new Vector3(0f, 0, 0), 2f).setEase(LeanTweenType.easeInOutSine);
                mainScrollerPages[2].SetActive(true);
                //LeanTween.moveLocal(mainScrollerPages[3], new Vector3(0, 0, 0), 2f).setEase(LeanTweenType.easeInOutSine);
                topTitle.text = "FASHION";
                nextButtonCanvasgroup.alpha = 0;

                //LeanTween.moveLocal(mainScrollerPages[0], new Vector3(-1, 0, 0), 2f).setEase(LeanTweenType.easeInOutSine);
                //LeanTween.moveLocal(mainScrollerPages[1], new Vector3(-1f, 0, 0), 2f).setEase(LeanTweenType.easeInOutSine);
                //mainScrollerPages[2].SetActive(true);
                //LeanTween.moveLocal(mainScrollerPages[2], new Vector3(0.017f, 0, 0), 2f).setEase(LeanTweenType.easeInOutSine);
                //LeanTween.moveLocal(mainScrollerPages[3], new Vector3(2, 0, 0), 2f).setEase(LeanTweenType.easeInOutSine);
                //topTitle.text = "LEMAIRE ART";
                //nextButtonCanvasgroup.alpha = 1;
                break;

            case 3:
                //LeanTween.moveLocal(mainScrollerPages[0], new Vector3(-1, 0, 0), 2f).setEase(LeanTweenType.easeInOutSine);
                //LeanTween.moveLocal(mainScrollerPages[1], new Vector3(-1f, 0, 0), 2f).setEase(LeanTweenType.easeInOutSine);
                //LeanTween.moveLocal(mainScrollerPages[2], new Vector3(-1f, 0, 0), 2f).setEase(LeanTweenType.easeInOutSine);
                //mainScrollerPages[2].SetActive(true);
                //LeanTween.moveLocal(mainScrollerPages[3], new Vector3(0, 0, 0), 2f).setEase(LeanTweenType.easeInOutSine);
                //topTitle.text = "LEMAIRE MERCH";
                break;

            default:
                return;

        }

    }



    public void hidePg2Bitch()
    {
        StartCoroutine(hidePage2());
    }

    public IEnumerator hidePage2()
    {

        yield return new WaitForSeconds(2f);

        mainScrollerPages[1].transform.gameObject.SetActive(false);
    }


    public void hidePg3()
    {
        StartCoroutine(hidePage2());
    }

    public IEnumerator hidePage3()
    {

        yield return new WaitForSeconds(2f);

        mainScrollerPages[1].transform.gameObject.SetActive(false);
    }



    public void hidePg4()
    {
        StartCoroutine(hidePage4());
    }

    public IEnumerator hidePage4()
    {

        yield return new WaitForSeconds(2f);

        mainScrollerPages[3].transform.gameObject.SetActive(false);
    }



    public IEnumerator waitToUnhuded(int _index, int i)
    {

        yield return new WaitForSeconds(1f);

        transform.GetChild(i).gameObject.SetActive(i == _index);
    }
}


//public class PrevNext
//{

//    public GameObject GO { get; set; }
//    public Button nextButton { get; set; }
//    public Button previousButton { get; set; }
//    public GameObject[] pageScrollers { get; set; }
//    public int currentPage { get; set; }


//    public PrevNext(GameObject GO, Button nextButton, Button previousButton, GameObject[] pageScrollers)
//    {
//        this.GO = GO;
//        this.nextButton = nextButton;
//        this.previousButton = previousButton;
//        this.pageScrollers = pageScrollers;

//    }



//    private void selectPage(int _index)
//    {
//        previousButton.interactable = (_index != 0);
//        previousButton.enabled = (_index != 0);

//        nextButton.interactable = (_index != pageScrollers.Length);
//        nextButton.enabled = (_index != pageScrollers.Length);

//        for (int i = 0; i < GO.transform.childCount; i++)
//        {
//            GO.transform.GetChild(i).gameObject.SetActive(i == _index);
//            slidePageHolder(_index);
//            Debug.Log("Selected Page");
//        }
//    }

//    public void changePage(int _change)
//    {
//        currentPage += _change;
//        selectPage(currentPage);
//        //slidePageHolder(_change);
//        Debug.Log("Change Page ");
//    }


//    public void slidePageHolder(int _change)
//    {

//        switch (_change)
//        {
//            case 0:
//                LeanTween.moveLocal(pageScrollers[0], new Vector3(0, 0, 0), 2.5f).setEase(LeanTweenType.easeInOutSine);
//                break;

//            case 1:
//                LeanTween.moveLocal(pageScrollers[1], new Vector3(0, 0, 0), 2.5f).setEase(LeanTweenType.easeInOutSine);
//                break;

//            //case 2:
//            //    LeanTween.moveLocal(pageScrollers[2], new Vector3(0,0,0), 2.5f).setEase(LeanTweenType.easeInOutSine);
//            //    break;

//            default:
//                return;

//        }

//    }


//}




//public void moveAllOtherCategoriesDown1()
//{
//    LeanTween.moveLocal(pageScrollers[1], new Vector3(0, -1, 0), 4f).setEase(LeanTweenType.easeInOutSine);

//}

//public void moveAllOtherCategoriesDown2()
//{
//    LeanTween.moveLocal(pageScrollers[0], new Vector3(0, -10, 0), 6f).setEase(LeanTweenType.easeInOutSine);

//}

//public void moveAllOtherCategoriesDown1()
//{
//    LeanTween.moveLocal(pageScrollers[1], new Vector3(0, -1, 0), 4f).setEase(LeanTweenType.easeInOutSine);

//}

//public void moveAllOtherCategoriesDown2()
//{
//    LeanTween.moveLocal(pageScrollers[0], new Vector3(0, -10, 0), 6f).setEase(LeanTweenType.easeInOutSine);

//}
