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


public class HomePage : MonoBehaviour
{

    [SerializeField] private GameObject Light1;
    [SerializeField] private GameObject Light2;
    [SerializeField] private GameObject Light3;

    #region ARSettings
    [Header("AR Settings")]
    [SerializeField] Camera arCamera;
    [SerializeField] ARSession arSession;
    [SerializeField] private GameObject itemViewingLocation;
    [SerializeField] private GameObject stopInteractionsBox;
    [SerializeField] private GameObject startBox;
    [SerializeField] private GameObject returnBox;
    [SerializeField] private GameObject storeParent;

    [SerializeField] private TextMeshProUGUI pageTitle;
    [SerializeField] private TextMeshProUGUI tapToStart;
    [SerializeField] private GameObject onboardButton;
    [SerializeField] private GameObject onBoardImage;
    [SerializeField] private GameObject onBoardDirections;
    [SerializeField] private GameObject tapToStartButton;


    [Header("Details UI")]
    UIPanelGameObject CameraPanel;
    [SerializeField] private GameObject cameraUIPanel;
    [SerializeField] private GameObject onboardUI;
    [SerializeField] private TextMeshProUGUI textTitle;
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private TextMeshProUGUI itemTitle2D;
    [SerializeField] private TextMeshProUGUI itemDescription2D;
    [SerializeField] private TextMeshProUGUI itemPrice2D;


    private string titleString;
    private string descriptionString;
    private string priceString;
    private bool isSelcted = false;


    [SerializeField] private AudioSource audioSourceCategories;
    //[SerializeField] private AudioClip[] musicClips;

    public Animator onboardFadeIn;
    public Animator onboardDescriptionFade;
    public Animator onboardButtonFade;

    private float mobileRotationSpeed = 0.1f;
    private float moveDuration = 5f;
    private float delay = 0;
    string hitName;
    private int currentIndex;

    #endregion ARSettings


    #region Item Ref


    [SerializeField] GameObject[] categoryPages;
    [SerializeField] private GameObject[] pagesNavigationPanels;
    [SerializeField] private GameObject[] returnButtonParent;
    //[SerializeField] private GameObject[] returnButton;
    [SerializeField] private Button[] returnBut;
    [SerializeField] private GameObject[] restartButtons;



    ItemRedo burgers;
    ItemRedo sides;
    ItemRedo salads;
    ItemRedo kidsMenu;
    ItemRedo beverages;
    ItemRedo desserts;
    ItemRedo sauces;
    ItemRedo merch;
    ItemRedo art;
    #endregion Item Ref


    #region Home Catgeory Items
    [Header("Burgers Category Holder")]





    [SerializeField] private GameObject Burgers;
    [SerializeField] private GameObject BurgersOrigin;
    [HideInInspector]
    [SerializeField] private string BurgersTitle;
    [HideInInspector]
    [SerializeField] private string BurgersDescription;
    [HideInInspector]
    [SerializeField] private string BurgersPrice;


    [Header("Art Category")]
    [SerializeField] private GameObject Art;
    [SerializeField] private GameObject artOrigin;
    [HideInInspector]
    [SerializeField] private string artTitle;
    [HideInInspector]
    [SerializeField] private string artDescription;
    [HideInInspector]
    [SerializeField] private string artPrice;

    [Header("Salads Category")]
    [SerializeField] private GameObject Salads;
    [SerializeField] private GameObject SaladsOrigin;
    [HideInInspector]
    [SerializeField] private string SaladsTitle;
    [HideInInspector]
    [SerializeField] private string SaladsDescription;
    [HideInInspector]
    [SerializeField] private string SaladsPrice;

    [Header("Sides Category")]
    [SerializeField] private GameObject Sides;
    [SerializeField] private GameObject SidesOrigin;
    [HideInInspector]
    [SerializeField] private string SidesTitle;
    [HideInInspector]
    [SerializeField] private string SidesDescription;
    [HideInInspector]
    [SerializeField] private string SidesPrice;

    [Header("Beverages Category")]
    [SerializeField] private GameObject Beverages;
    [SerializeField] private GameObject BeveragesOrigin;
    [HideInInspector]
    [SerializeField] private string BeveragesTitle;
    [HideInInspector]
    [SerializeField] private string BeveragesDescription;
    [HideInInspector]
    [SerializeField] private string BeveragesPrice;

    [Header("Desserts Category")]
    [SerializeField] private GameObject Desserts;
    [SerializeField] private GameObject DessertsOrigin;
    [HideInInspector]
    [SerializeField] private string DessertsTitle;
    [HideInInspector]
    [SerializeField] private string DessertssDescription;
    [HideInInspector]
    [SerializeField] private string DessertsPrice;


    [Header("Merch")]
    [SerializeField] private GameObject Merch;
    [SerializeField] private GameObject MerchOrigin;
    [HideInInspector]
    [SerializeField] private string MerchTitle;
    [HideInInspector]
    [SerializeField] private string MerchDescritpion;
    [HideInInspector]
    [SerializeField] private string MerchPrice;


    //[SerializeField] private GameObject bottomUI;


    //[Header("Kids Meals Catageory")]
    //[SerializeField] private GameObject Sauce;
    //[SerializeField] private GameObject SauceOrigin;
    //[HideInInspector]
    //[SerializeField] private string SauceTitle;
    //[HideInInspector]
    //[SerializeField] private string SauceDescription;
    //[HideInInspector]
    //[SerializeField] private string SaucePrice;


    [Header("Panels")]
    [SerializeField] private GameObject burgersPanel;
    [SerializeField] private GameObject chickenAndSuchPanel;
    [SerializeField] private GameObject saladsPanel;
    [SerializeField] private GameObject dessertsPanel;
    [SerializeField] private GameObject beveragesPanel;
    [SerializeField] private GameObject artPanel;
    [SerializeField] private GameObject merchPanel;

    //[SerializeField] private GameObject sidesAndMorePanel;
    //[SerializeField] private GameObject saucesPanel;


    #endregion Home Catgeory Items

    [SerializeField] private Rigidbody playRigidBody1;
    [SerializeField] private Rigidbody playRigidBody2;
    [SerializeField] private Rigidbody playRigidBody3;
    [SerializeField] private Rigidbody playRigidBody4;
    [SerializeField] private Rigidbody playRigidBody5;
    [SerializeField] private Rigidbody playRigidBody6;
    [SerializeField] private Rigidbody playRigidBody7;
    //[SerializeField] private Rigidbody playRigidBody8;


    private void Awake()
    {
        CameraPanel = new UIPanelGameObject(cameraUIPanel, itemTitle2D, titleString, itemDescription2D, descriptionString, itemPrice2D, priceString);
        burgers = new ItemRedo(Burgers, BurgersOrigin, BurgersTitle, BurgersDescription, BurgersPrice, itemViewingLocation, moveDuration, delay, stopInteractionsBox, isSelcted, playRigidBody1, burgersPanel, canvasGroup, textTitle);
        salads = new ItemRedo(Salads, SaladsOrigin, SaladsTitle, SaladsDescription, SaladsPrice, itemViewingLocation, moveDuration, delay, stopInteractionsBox, isSelcted, playRigidBody2, chickenAndSuchPanel, canvasGroup, textTitle);
        sides = new ItemRedo(Sides, SidesOrigin, SidesTitle, SidesDescription, SidesPrice, itemViewingLocation, moveDuration, delay, stopInteractionsBox, isSelcted, playRigidBody3, saladsPanel, canvasGroup, textTitle);
       
        beverages = new ItemRedo(Beverages, BeveragesOrigin, BeveragesTitle, BeveragesDescription, BeveragesPrice, itemViewingLocation, moveDuration, delay, stopInteractionsBox, isSelcted, playRigidBody5, beveragesPanel, canvasGroup, textTitle);
        desserts = new ItemRedo(Desserts, DessertsOrigin, DessertsTitle, DessertssDescription, DessertsPrice, itemViewingLocation, moveDuration, delay, stopInteractionsBox, isSelcted, playRigidBody6, dessertsPanel, canvasGroup, textTitle);
        art = new ItemRedo(Art, artOrigin, artTitle, artDescription, artPrice, itemViewingLocation, moveDuration, delay, stopInteractionsBox, isSelcted, playRigidBody6, artPanel, canvasGroup, textTitle);
        merch = new ItemRedo(Merch, MerchOrigin, MerchTitle, MerchDescritpion, MerchPrice, itemViewingLocation, moveDuration, delay, stopInteractionsBox, isSelcted, playRigidBody7, merchPanel, canvasGroup, textTitle);
        //weed = new ItemRedo(Sauce, SauceOrigin, SauceTitle, SauceDescription, SaucePrice, itemViewingLocation, moveDuration, delay, stopInteractionsBox, isSelcted, playRigidBody7, beveragesPanel, canvasGroup, textTitle);


        //showFirstPage();
        hideFirstPage();
        returnBox.SetActive(false);
        arSession.Reset();
        pageTitle.text = "HOLO AIR MENU";

        CameraPanel.itemTitle.text = "";


        CameraPanel.itemDescription.text = "" +
            "" +
            "" +
            "";

        //onboardUI.SetActive(true);


    }
    void Start()
    {
        //LoadAddressableScene or addressable items
        //LeanTween.moveLocal(spotLight, new Vector3(.001f, 0, .022f), moveDuration);
        CameraPanel.showPanel(CameraPanel.itemUIPanel);
        //CameraPanel.hidePanel(cameraUIPanel);
    }

    void Update()
    {
        foreach (Touch touch in Input.touches)
        {
            Ray camRay = arCamera.ScreenPointToRay(touch.position);
            RaycastHit raycastHit;
            if (Physics.Raycast(camRay, out raycastHit, 10))
            {



                hitName = raycastHit.transform.tag;
                if (Input.touchCount > 0)
                {




                    Touch first = Input.GetTouch(0);


                 

                    if (first.phase == TouchPhase.Stationary)
                    {

                        if (EventSystem.current.IsPointerOverGameObject())
                        {
                            Debug.Log("Over ui 1");
                            return;
                        }

                        switch (hitName)
                        {
                            case "Meats":
                                //Application.OpenURL("https://backyardburgers.getbento.com/online-ordering/");
                                //Debug.Log("Double Tap");
                                break;
                            default:
                                return;
  
                        }

                        //Debug.Log("Double Tap");
                    }
                }





                if (touch.phase == TouchPhase.Began)
                {
                    if (EventSystem.current.IsPointerOverGameObject())
                    {
                        Debug.Log("Over UI 2");
                        return;
                    }

                    switch (hitName)
                    {

                        case "Meats":
                            pageTitle.text = "BURGERS";
                            returnBox.SetActive(true);
                            onboardUI.SetActive(false);
                            categoryPages[1].transform.gameObject.SetActive(true);
                            arSession.Reset();
                            resetPageUI();
                            returnButtonParent[0].SetActive(true);
                            pagesNavigationPanels[1].SetActive(true);
                            returnBut[0].enabled = true;

                            restartButtons[1].SetActive(true);
                            restartButtons[0].SetActive(false);

                            categoryPages[1].transform.GetChild(0).gameObject.SetActive(true);

                            LeanTween.moveLocal(categoryPages[1].transform.gameObject, new Vector3(0, -.05f, .3f), 1.5f).setEase(LeanTweenType.easeInOutSine);
                            LeanTween.moveLocal(categoryPages[0].transform.gameObject, new Vector3(-1, 0, 0), 1f).setEase(LeanTweenType.easeInOutSine);

                            LeanTween.moveLocal(pagesNavigationPanels[1].transform.gameObject, new Vector3(0, -1150, 0), .9f).setEase(LeanTweenType.easeInOutSine);
                            LeanTween.moveLocal(pagesNavigationPanels[0].transform.gameObject, new Vector3(0, -4000, 0), 0f).setEase(LeanTweenType.easeInOutSine);
                            LeanTween.moveLocal(returnButtonParent[0].transform.gameObject, new Vector3(32, 310, 0), 1f).setEase(LeanTweenType.easeInOutSine);

                            LeanTween.moveLocal(stopInteractionsBox, new Vector3(0, 0, -1f), 0f).setEase(LeanTweenType.easeInOutSine);

                            Light1.SetActive(true);
                   
                            break;




                        case "Salad":
                            pageTitle.text = "SALADS";

   
                            onboardUI.SetActive(false);
                            categoryPages[2].transform.gameObject.SetActive(true);
                            arSession.Reset();
                            resetPageUI();



                            categoryPages[2].transform.GetChild(0).gameObject.SetActive(true);
                            LeanTween.moveLocal(categoryPages[2].transform.gameObject, new Vector3(-0.0002f, 0.15f, .3f), 1.5f).setEase(LeanTweenType.easeInOutSine);
                            LeanTween.moveLocal(categoryPages[0].transform.gameObject, new Vector3(-1, 0, 0), 1f).setEase(LeanTweenType.easeInOutSine);



                            returnButtonParent[1].SetActive(true);
                            returnBut[1].enabled = true;


                            LeanTween.moveLocal(pagesNavigationPanels[2].transform.gameObject, new Vector3(0, -1150, 0), .9f).setEase(LeanTweenType.easeInOutSine);
                            LeanTween.moveLocal(pagesNavigationPanels[0].transform.gameObject, new Vector3(0, -4000, 0), 0f).setEase(LeanTweenType.easeInOutSine);
                            LeanTween.moveLocal(returnButtonParent[1].transform.gameObject, new Vector3(32, 310, 0), 1f).setEase(LeanTweenType.easeInOutSine);

                            restartButtons[2].SetActive(true);
                            restartButtons[0].SetActive(false);

                            returnBox.SetActive(true);
                            LeanTween.moveLocal(stopInteractionsBox, new Vector3(0, 0, -1f), 0f).setEase(LeanTweenType.easeInOutSine);

                            Light1.SetActive(true);

                            break;



                        case "Sides":
                            pageTitle.text = "SIDES";

                            onboardUI.SetActive(false);
                            categoryPages[3].transform.gameObject.SetActive(true);
                            arSession.Reset();
                            resetPageUI();



                            categoryPages[3].transform.GetChild(0).gameObject.SetActive(true);
                            LeanTween.moveLocal(categoryPages[3].transform.gameObject, new Vector3(-0.03f, -0.276f, -0.039f), 1.5f).setEase(LeanTweenType.easeInOutSine);
                            LeanTween.moveLocal(categoryPages[0].transform.gameObject, new Vector3(-1, 0, 0), 1f).setEase(LeanTweenType.easeInOutSine);



                            returnButtonParent[2].SetActive(true);
                            returnBut[2].enabled = true;
                            LeanTween.moveLocal(returnButtonParent[2].transform.gameObject, new Vector3(32, 310, 0), 1f).setEase(LeanTweenType.easeInOutSine);

                            LeanTween.moveLocal(pagesNavigationPanels[3].transform.gameObject, new Vector3(0, -1150, 0), .9f).setEase(LeanTweenType.easeInOutSine);
                            LeanTween.moveLocal(pagesNavigationPanels[0].transform.gameObject, new Vector3(0, -4000, 0), 0f).setEase(LeanTweenType.easeInOutSine);

                            restartButtons[3].SetActive(true);
                            restartButtons[0].SetActive(false);

                            returnBox.SetActive(true);
                            LeanTween.moveLocal(stopInteractionsBox, new Vector3(0, 0, -1f), 0f).setEase(LeanTweenType.easeInOutSine);

                            Light2.SetActive(true);

                            break;




                        case "Beverages":

                            pageTitle.text = "BEVERAGES";


                            onboardUI.SetActive(false);
                            categoryPages[4].transform.gameObject.SetActive(true);
                            arSession.Reset();
                            resetPageUI();



                            categoryPages[4].transform.GetChild(0).gameObject.SetActive(true);
                            LeanTween.moveLocal(categoryPages[4].transform.gameObject, new Vector3(-.008f, -.317f, -.15f), 1.5f).setEase(LeanTweenType.easeInOutSine);
                            LeanTween.moveLocal(categoryPages[0].transform.gameObject, new Vector3(-2, 0, 0), 1f).setEase(LeanTweenType.easeInOutSine);



                            returnButtonParent[3].SetActive(true);
                            returnBut[3].enabled = true;
                            LeanTween.moveLocal(returnButtonParent[3].transform.gameObject, new Vector3(32, 310, 0), 1f).setEase(LeanTweenType.easeInOutSine);

                            LeanTween.moveLocal(pagesNavigationPanels[4].transform.gameObject, new Vector3(0, -1150, 0), .9f).setEase(LeanTweenType.easeInOutSine);
                            LeanTween.moveLocal(pagesNavigationPanels[0].transform.gameObject, new Vector3(0, -4000, 0), 0f).setEase(LeanTweenType.easeInOutSine);

                            restartButtons[4].SetActive(true);
                            restartButtons[0].SetActive(false);

                            returnBox.SetActive(true);
                            LeanTween.moveLocal(stopInteractionsBox, new Vector3(0, 0, -1f), 0f).setEase(LeanTweenType.easeInOutSine);


                            Light2.SetActive(true);

                            break;



                        case "Desserts":


                            pageTitle.text = "DESSERTS";



                            onboardUI.SetActive(false);
                            categoryPages[5].transform.gameObject.SetActive(true);
                            arSession.Reset();
                            resetPageUI();



                            categoryPages[5].transform.GetChild(0).gameObject.SetActive(true);
                            LeanTween.moveLocal(categoryPages[5].transform.gameObject, new Vector3(0.027f, -0.438f, 0.221f), 1.5f).setEase(LeanTweenType.easeInOutSine);
                            LeanTween.moveLocal(categoryPages[0].transform.gameObject, new Vector3(-2, 0, 0), 1f).setEase(LeanTweenType.easeInOutSine);



                            returnButtonParent[4].SetActive(true);
                            returnBut[4].enabled = true;
                            LeanTween.moveLocal(returnButtonParent[4].transform.gameObject, new Vector3(32, 310, 0), 1f).setEase(LeanTweenType.easeInOutSine);

                            LeanTween.moveLocal(pagesNavigationPanels[5].transform.gameObject, new Vector3(0, -1150, 0), .9f).setEase(LeanTweenType.easeInOutSine);
                            LeanTween.moveLocal(pagesNavigationPanels[0].transform.gameObject, new Vector3(0, -4000, 0), 0f).setEase(LeanTweenType.easeInOutSine);

                            restartButtons[5].SetActive(true);
                            restartButtons[0].SetActive(false);

                            returnBox.SetActive(true);
                            LeanTween.moveLocal(stopInteractionsBox, new Vector3(0, 0, -1f), 0f).setEase(LeanTweenType.easeInOutSine);


                            Light1.SetActive(false);
                            Light2.SetActive(true);



                            break;



                        case "art":


                            pageTitle.text = "ART";



                            onboardUI.SetActive(false);
                            categoryPages[6].transform.gameObject.SetActive(true);
                            arSession.Reset();
                            resetPageUI();



                            categoryPages[6].transform.GetChild(0).gameObject.SetActive(true);
                            LeanTween.moveLocal(categoryPages[6].transform.gameObject, new Vector3(-0.652f, -0.32f, 0f), 1.5f).setEase(LeanTweenType.easeInOutSine);
                            LeanTween.moveLocal(categoryPages[0].transform.gameObject, new Vector3(-1, 0, 0), 1f).setEase(LeanTweenType.easeInOutSine);



                            returnButtonParent[5].SetActive(true);
                            returnBut[5].enabled = true;
                            LeanTween.moveLocal(returnButtonParent[5].transform.gameObject, new Vector3(32, 310, 0), 1f).setEase(LeanTweenType.easeInOutSine);

                            LeanTween.moveLocal(pagesNavigationPanels[6].transform.gameObject, new Vector3(0, -1150, 0), .9f).setEase(LeanTweenType.easeInOutSine);
                            LeanTween.moveLocal(pagesNavigationPanels[0].transform.gameObject, new Vector3(0, -4000, 0), 0f).setEase(LeanTweenType.easeInOutSine);

                            restartButtons[6].SetActive(true);
                            restartButtons[0].SetActive(false);

                            returnBox.SetActive(true);
                            LeanTween.moveLocal(stopInteractionsBox, new Vector3(0, 0, -1f), 0f).setEase(LeanTweenType.easeInOutSine);

                            Light1.SetActive(true);

                            break;




                        case "Merch":


                            pageTitle.text = "APPERAL";



                            onboardUI.SetActive(false);
                            categoryPages[7].transform.gameObject.SetActive(true);
                            arSession.Reset();
                            resetPageUI();



                            categoryPages[7].transform.GetChild(0).gameObject.SetActive(true);
                            LeanTween.moveLocal(categoryPages[7].transform.gameObject, new Vector3(-0.66f, -0.62f, 0.18f), 1.5f).setEase(LeanTweenType.easeInOutSine);
                            LeanTween.moveLocal(categoryPages[0].transform.gameObject, new Vector3(-1, 0, 0), 1f).setEase(LeanTweenType.easeInOutSine);



                            returnButtonParent[6].SetActive(true);
                            returnBut[6].enabled = true;
                            LeanTween.moveLocal(returnButtonParent[6].transform.gameObject, new Vector3(32, 310, 0), 1f).setEase(LeanTweenType.easeInOutSine);

                            LeanTween.moveLocal(pagesNavigationPanels[7].transform.gameObject, new Vector3(0, -1150, 0), .9f).setEase(LeanTweenType.easeInOutSine);
                            LeanTween.moveLocal(pagesNavigationPanels[0].transform.gameObject, new Vector3(0, -4000, 0), 0f).setEase(LeanTweenType.easeInOutSine);

                            restartButtons[7].SetActive(true);
                            restartButtons[0].SetActive(false);

                            returnBox.SetActive(true);
                            LeanTween.moveLocal(stopInteractionsBox, new Vector3(0, 0, -1f), 0f).setEase(LeanTweenType.easeInOutSine);

                            Light3.SetActive(true);
                            Light1.SetActive(true);

                            break;



                        default:
                        return;
                    }
                }

            }
        }


    }


    public void startUpMenu()
    {

        onboardUI.SetActive(true);



        //onboardFadeIn.Play("fadein", 0, 0);


        onboardFadeIn.SetTrigger("fadein");
        onboardDescriptionFade.SetTrigger("fadein");
        onboardButtonFade.SetTrigger("fadein");

        foreach (GameObject categoryScrollers in categoryPages)
        {
            categoryScrollers.transform.gameObject.SetActive(false);
        }


        tapToStartButton.SetActive(false);
        tapToStart.text = "";
        showFirstPage();
        resetMainScrollersLeft();
        resetPageUI();
        pageTitle.text = "";


  
        //LeanTween.moveLocal(pagesNavigationPanels[0].transform.gameObject, new Vector3(0, -1118, 0), 1f).setEase(LeanTweenType.easeInOutSine);



        LeanTween.moveLocal(pagesNavigationPanels[0].transform.gameObject, new Vector3(0, -1150, 0), .9f).setEase(LeanTweenType.easeInOutSine);
        LeanTween.moveLocal(categoryPages[0].transform.gameObject, new Vector3(-.04f, .15f, 0.147f), 1.5f).setEase(LeanTweenType.easeInOutSine);

        categoryPages[0].transform.GetChild(0).gameObject.SetActive(true);
        categoryPages[0].SetActive(true);

        arSession.Reset();

        stopInteractionsBox.transform.position = new Vector3(0, 0, 2);


        pagesNavigationPanels[0].gameObject.SetActive(true);

        startBox.SetActive(false);



        //CameraPanel.showPanel(CameraPanel.itemUIPanel);

        //CameraPanel.itemTitle.text = "Instructions";


        //CameraPanel.itemDescription.text = "Tap Item To Select /   " +
        //    " Tap <- To Return    " +
        //    "Tap Item To Spin /   " +
        //    "Drag Item To Inspect   ";


//        Tap Item To Select Category
//Tap Item To View Closer
//Tap Item To Spin/ Stop
//Drag Item To Inspect
//Tap < -To Deselct Item


    }



    public void RestartMainMenu()
    {

        onboardUI.SetActive(true);



        //onboardFadeIn.Play("fadein", 0, 0);


        //onboardFadeIn.SetTrigger("fadein");
        //onboardDescriptionFade.SetTrigger("fadein");
        //onboardButtonFade.SetTrigger("fadein");

        foreach (GameObject categoryScrollers in categoryPages)
        {
            categoryScrollers.transform.gameObject.SetActive(false);
        }


        tapToStartButton.SetActive(false);
        tapToStart.text = "";
        showFirstPage();
        resetMainScrollersLeft();
        resetPageUI();
        pageTitle.text = "";



        LeanTween.moveLocal(pagesNavigationPanels[0].transform.gameObject, new Vector3(0, -1150, 0), .9f).setEase(LeanTweenType.easeInOutSine);
        LeanTween.moveLocal(categoryPages[0].transform.gameObject, new Vector3(-.04f, .15f, 0.147f), 1.5f).setEase(LeanTweenType.easeInOutSine);

        categoryPages[0].transform.GetChild(0).gameObject.SetActive(true);
        categoryPages[0].SetActive(true);

        arSession.Reset();

        stopInteractionsBox.transform.position = new Vector3(0, 0, 2);


        pagesNavigationPanels[0].gameObject.SetActive(true);

        startBox.SetActive(false);



        //CameraPanel.showPanel(CameraPanel.itemUIPanel);

        //CameraPanel.itemTitle.text = "Instructions";


        //CameraPanel.itemDescription.text = "Tap Item To Select /   " +
        //    " Tap <- To Return    " +
        //    "Tap Item To Spin /   " +
        //    "Drag Item To Inspect   ";


        //        Tap Item To Select Category
        //Tap Item To View Closer
        //Tap Item To Spin/ Stop
        //Drag Item To Inspect
        //Tap < -To Deselct Item


    }




    public void resetBurgerspg1()
    {
        categoryPages[1].transform.gameObject.SetActive(true);
        arSession.Reset();
        resetPageUI();
        //LeanTween.moveLocal(pagesNavigationPanels[0].transform.gameObject, new Vector3(-375.94f, -1084f, -0.034542f), 0f).setEase(LeanTweenType.easeInOutSine);
        //pagesNavigationPanels[0].transform.localPosition = new Vector3(-350f, -4000f, 0);
        LeanTween.moveLocal(pagesNavigationPanels[1].transform.gameObject, new Vector3(0, -1150, 0), 1f).setEase(LeanTweenType.easeInOutSine);
        resetCategoryScrollers();
        LeanTween.moveLocal(categoryPages[1].transform.gameObject, new Vector3(0, -.05f, .3f), 1.5f).setEase(LeanTweenType.easeInOutSine);
        LeanTween.moveLocal(categoryPages[0].transform.gameObject, new Vector3(0, 2f, 0), 1f).setEase(LeanTweenType.easeInOutSine);
        categoryPages[1].transform.GetChild(0).gameObject.SetActive(true);
        CameraPanel.hidePanel(CameraPanel.itemUIPanel);
        returnBox.SetActive(true);
        pageTitle.text = "BURGERS";
        returnBut[0].enabled = true;
        returnButtonParent[0].SetActive(true);
        stopInteractionsBox.transform.position = new Vector3(0, 0, 2);

    foreach(GameObject button in restartButtons)
        {
            button.SetActive(false);
        }

        restartButtons[1].SetActive(true);
    }


    public void resetColdFoodspg1()
    {
        categoryPages[2].transform.gameObject.SetActive(true);
        arSession.Reset();
        resetPageUI();
        //LeanTween.moveLocal(pagesNavigationPanels[0].transform.gameObject, new Vector3(-375.94f, -1084f, -0.034542f), 0f).setEase(LeanTweenType.easeInOutSine);
        //pagesNavigationPanels[0].transform.localPosition = new Vector3(-350f, -4000f, 0);
        LeanTween.moveLocal(pagesNavigationPanels[2].transform.gameObject, new Vector3(0, -1150, 0), 1f).setEase(LeanTweenType.easeInOutSine);
        resetCategoryScrollers();
        LeanTween.moveLocal(categoryPages[2].transform.gameObject, new Vector3(0, 0.15f, .3f), 1.5f).setEase(LeanTweenType.easeInOutSine);
        LeanTween.moveLocal(categoryPages[0].transform.gameObject, new Vector3(0, 2f, 0), 1f).setEase(LeanTweenType.easeInOutSine);
        categoryPages[2].transform.GetChild(0).gameObject.SetActive(true);
        CameraPanel.hidePanel(CameraPanel.itemUIPanel);
        returnBox.SetActive(true);
        pageTitle.text = "BURGERS";
        returnBut[2].enabled = true;
        returnButtonParent[1].SetActive(true);
        stopInteractionsBox.transform.position = new Vector3(0, 0, 2);

        foreach (GameObject button in restartButtons)
        {
            button.SetActive(false);
        }

        restartButtons[2].SetActive(true);
    }




    public void resetSidespg1()
    {
        categoryPages[3].transform.gameObject.SetActive(true);
        arSession.Reset();
        resetPageUI();
        //LeanTween.moveLocal(pagesNavigationPanels[0].transform.gameObject, new Vector3(-375.94f, -1084f, -0.034542f), 0f).setEase(LeanTweenType.easeInOutSine);
        //pagesNavigationPanels[0].transform.localPosition = new Vector3(-350f, -4000f, 0);
        LeanTween.moveLocal(pagesNavigationPanels[3].transform.gameObject, new Vector3(0, -1150, 0), 1f).setEase(LeanTweenType.easeInOutSine);
        resetCategoryScrollers();
        LeanTween.moveLocal(categoryPages[3].transform.gameObject, new Vector3(-0.03f, -0.24f, -0.07f), 1.5f).setEase(LeanTweenType.easeInOutSine);
        LeanTween.moveLocal(categoryPages[0].transform.gameObject, new Vector3(0, 2f, 0), 1f).setEase(LeanTweenType.easeInOutSine);
        categoryPages[3].transform.GetChild(0).gameObject.SetActive(true);
        CameraPanel.hidePanel(CameraPanel.itemUIPanel);
        returnBox.SetActive(true);
        pageTitle.text = "SIDES";
        returnButtonParent[2].SetActive(true);
        returnBut[2].enabled = true;
        stopInteractionsBox.transform.position = new Vector3(0, 0, 2);

        foreach (GameObject button in restartButtons)
        {
            button.SetActive(false);
        }

        restartButtons[3].SetActive(true);
    }


    public void resetBeveragesPg1()
    {
        categoryPages[4].transform.gameObject.SetActive(true);
        arSession.Reset();
        resetPageUI();
        //LeanTween.moveLocal(pagesNavigationPanels[0].transform.gameObject, new Vector3(-375.94f, -1084f, -0.034542f), 0f).setEase(LeanTweenType.easeInOutSine);
        //pagesNavigationPanels[0].transform.localPosition = new Vector3(-350f, -4000f, 0);
        LeanTween.moveLocal(pagesNavigationPanels[4].transform.gameObject, new Vector3(0, -1150, 0), 1f).setEase(LeanTweenType.easeInOutSine);
        resetCategoryScrollers();
        LeanTween.moveLocal(categoryPages[4].transform.gameObject, new Vector3(0, -0.45f, -.15f), 1.5f).setEase(LeanTweenType.easeInOutSine);
        LeanTween.moveLocal(categoryPages[0].transform.gameObject, new Vector3(0, 2f, 0), 1f).setEase(LeanTweenType.easeInOutSine);
        categoryPages[4].transform.GetChild(0).gameObject.SetActive(true);
        CameraPanel.hidePanel(CameraPanel.itemUIPanel);
        returnBox.SetActive(true);
        pageTitle.text = "BEVERAGES";
        returnBut[3].enabled = true;
        returnButtonParent[3].SetActive(true);
        stopInteractionsBox.transform.position = new Vector3(0, 0, 2);

        foreach (GameObject button in restartButtons)
        {
            button.SetActive(false);
        }

        restartButtons[4].SetActive(true);
    }



    public void resetDessertsPg1()
    {
        categoryPages[5].transform.gameObject.SetActive(true);
        arSession.Reset();
        resetPageUI();
        //LeanTween.moveLocal(pagesNavigationPanels[0].transform.gameObject, new Vector3(-375.94f, -1084f, -0.034542f), 0f).setEase(LeanTweenType.easeInOutSine);
        //pagesNavigationPanels[0].transform.localPosition = new Vector3(-350f, -4000f, 0);
        LeanTween.moveLocal(pagesNavigationPanels[5].transform.gameObject, new Vector3(0, -1150, 0), 1f).setEase(LeanTweenType.easeInOutSine);
        resetCategoryScrollers();
        LeanTween.moveLocal(categoryPages[5].transform.gameObject, new Vector3(0.02700001f, -0.63f, 0.221f), 1.5f).setEase(LeanTweenType.easeInOutSine);
        LeanTween.moveLocal(categoryPages[0].transform.gameObject, new Vector3(0, 2f, 0), 1f).setEase(LeanTweenType.easeInOutSine);
        categoryPages[5].transform.GetChild(0).gameObject.SetActive(true);
        CameraPanel.hidePanel(CameraPanel.itemUIPanel);
        returnBox.SetActive(true);
        pageTitle.text = "DESSERTS";
        returnBut[4].enabled = true;
        returnButtonParent[4].SetActive(true);
        stopInteractionsBox.transform.position = new Vector3(0, 0, 2);

        foreach (GameObject button in restartButtons)
        {
            button.SetActive(false);
        }

        restartButtons[5].SetActive(true);
    }




    public void resetArtPg1()
    {
        categoryPages[6].transform.gameObject.SetActive(true);
        arSession.Reset();
        resetPageUI();
        //LeanTween.moveLocal(pagesNavigationPanels[0].transform.gameObject, new Vector3(-375.94f, -1084f, -0.034542f), 0f).setEase(LeanTweenType.easeInOutSine);
        //pagesNavigationPanels[0].transform.localPosition = new Vector3(-350f, -4000f, 0);
        LeanTween.moveLocal(pagesNavigationPanels[6].transform.gameObject, new Vector3(0, -1150, 0), 1f).setEase(LeanTweenType.easeInOutSine);
        resetCategoryScrollers();
        LeanTween.moveLocal(categoryPages[6].transform.gameObject, new Vector3(-0.652f, -0.32f, 0f), 1.5f).setEase(LeanTweenType.easeInOutSine);

        LeanTween.moveLocal(categoryPages[0].transform.gameObject, new Vector3(0, 2f, 0), 1f).setEase(LeanTweenType.easeInOutSine);
        categoryPages[6].transform.GetChild(0).gameObject.SetActive(true);
        CameraPanel.hidePanel(CameraPanel.itemUIPanel);
        returnBox.SetActive(true);
        pageTitle.text = "ART";
        returnBut[5].enabled = true;
        returnButtonParent[5].SetActive(true);
        stopInteractionsBox.transform.position = new Vector3(0, 0, 2);

        foreach (GameObject button in restartButtons)
        {
            button.SetActive(false);
        }

        restartButtons[6].SetActive(true);
    }



    public void resetMerchsPg1()
    {
        categoryPages[7].transform.gameObject.SetActive(true);
        arSession.Reset();
        resetPageUI();
        //LeanTween.moveLocal(pagesNavigationPanels[0].transform.gameObject, new Vector3(-375.94f, -1084f, -0.034542f), 0f).setEase(LeanTweenType.easeInOutSine);
        //pagesNavigationPanels[0].transform.localPosition = new Vector3(-350f, -4000f, 0);
        LeanTween.moveLocal(pagesNavigationPanels[7].transform.gameObject, new Vector3(0, -1150, 0), 1f).setEase(LeanTweenType.easeInOutSine);
        resetCategoryScrollers();
        LeanTween.moveLocal(categoryPages[7].transform.gameObject, new Vector3(-0.66f, -0.62f, 0.18f), 1.5f).setEase(LeanTweenType.easeInOutSine);
        LeanTween.moveLocal(categoryPages[0].transform.gameObject, new Vector3(0, 2f, 0), 1f).setEase(LeanTweenType.easeInOutSine);
        categoryPages[7].transform.GetChild(0).gameObject.SetActive(true);
        CameraPanel.hidePanel(CameraPanel.itemUIPanel);
        returnBox.SetActive(true);
        pageTitle.text = "FASHION";
        returnBut[6].enabled = true;
        returnButtonParent[6].SetActive(true);
        stopInteractionsBox.transform.position = new Vector3(0, 0, 2);

        foreach (GameObject button in restartButtons)
        {
            button.SetActive(false);
        }

        restartButtons[7].SetActive(true);
    }



    public void resetStoreParent()
    {
        storeParent.gameObject.transform.localEulerAngles = new Vector3(0, 0, 0);
        storeParent.gameObject.transform.localRotation = new Quaternion(0, 0, 0, 0);
        storeParent.gameObject.transform.localPosition = new Vector3(0, 0, 0);
        storeParent.gameObject.transform.localScale = new Vector3(1f, 1f, 1);
    }

    public void resetPageUI()
    {
        foreach (GameObject pageUI in pagesNavigationPanels)
        {
            pageUI.transform.localPosition = new Vector3(0, -1425f, 0);

        }
    }


    public void resetCategoryScrollers()
    {
        foreach (GameObject categoryScrollers in categoryPages)
        {
            categoryScrollers.transform.localPosition = new Vector3(1, 0, 0);
        }
        LeanTween.moveLocal(categoryPages[0].transform.gameObject, new Vector3(-.042f, 0.136f, 0.145f), .75f).setEase(LeanTweenType.easeInOutSine);
    }


    public void resetTOMAIN()
    {
        foreach (GameObject categoryScrollers in categoryPages)
        {
            pagesNavigationPanels[0].transform.localPosition = new Vector3(0, -4000, 0);
        }
        LeanTween.moveLocal(pagesNavigationPanels[0].transform.gameObject, new Vector3(0, -1150, 0), 1.2f).setEase(LeanTweenType.easeInOutSine);
    }



    public void resetMainScrollersLeft()
    {

        categoryPages[0].transform.localPosition = new Vector3(-1, 0, 0);

    }


    public void showFirstPage()
    {
        LeanTween.scale(burgers.item, new Vector3(1f, 1f, 1f), 0f).setEase(LeanTweenType.easeInOutSine);
        LeanTween.scale(salads.item, new Vector3(1f, 1f, 1f), 0f).setEase(LeanTweenType.easeInOutSine);
        LeanTween.scale(sides.item, new Vector3(1f, 1f, 1f), 0f).setEase(LeanTweenType.easeInOutSine);
        LeanTween.scale(beverages.item, new Vector3(1f, 1f, 1f), 0f).setEase(LeanTweenType.easeInOutSine);
        LeanTween.scale(desserts.item, new Vector3(1f, 1f, 1f), 0f).setEase(LeanTweenType.easeInOutSine);
        //LeanTween.scale(art.item, new Vector3(1f, 1f, 1f), 0f).setEase(LeanTweenType.easeInOutSine);
        //LeanTween.scale(merch.item, new Vector3(1f, 1f, 1f), 0f).setEase(LeanTweenType.easeInOutSine);
    }

    public void hideFirstPage()
    {
        LeanTween.scale(burgers.item, new Vector3(0f, 0f, 0f), 0f).setEase(LeanTweenType.easeInOutSine);
        LeanTween.scale(salads.item, new Vector3(0f, 0f, 0f), 0f).setEase(LeanTweenType.easeInOutSine);
        LeanTween.scale(sides.item, new Vector3(0f, 0f, 0f), 0f).setEase(LeanTweenType.easeInOutSine);
        LeanTween.scale(beverages.item, new Vector3(0f, 0f, 0f), 0f).setEase(LeanTweenType.easeInOutSine);
        LeanTween.scale(desserts.item, new Vector3(0f, 0f, 0f), 0f).setEase(LeanTweenType.easeInOutSine);
        //LeanTween.scale(art.item, new Vector3(0f, 0f, 0f), 0f).setEase(LeanTweenType.easeInOutSine);
        //LeanTween.scale(merch.item, new Vector3(1f, 1f, 1f), 0f).setEase(LeanTweenType.easeInOutSine);

    }

    //public void start1()
    //{
    //    audioSourceCategories.clip = musicClips[1];
    //    audioSourceCategories.Play();
    //}

    //public void start2()
    //{
    //    audioSourceCategories.clip = musicClips[2];
    //    audioSourceCategories.Play();
    //}

    //public void start3()
    //{
    //    audioSourceCategories.clip = musicClips[3];
    //    audioSourceCategories.Play();
    //}

    //public void start4()
    //{
    //    audioSourceCategories.clip = musicClips[4];
    //    audioSourceCategories.Play();
    //}


}




//[HideInInspector]
//[SerializeField] private TextMeshPro itemTitle;
//[HideInInspector]
//[SerializeField] private TextMeshPro itemDescription;
//[HideInInspector]
//[SerializeField] private TextMeshPro itemPrice;

//LeanTween.moveLocal(cameraUIPanel.transform.gameObject, new Vector3(-0.932f, -0.364f, 0.472f), 1.5f).setEase(LeanTweenType.easeInOutSine);


//LeanTween.moveLocal(bottomUI.transform.gameObject, new Vector3(211.4756f, -1663, -140.9991f), 3).setEase(LeanTweenType.easeInOutSine);
//onBoardImage.gameObject.SetActive(false);
//onBoardDirections.gameObject.SetActive(false);
//onboardButton.gameObject.SetActive(false);
//resetTOMAIN();
//resetCategoryScrollers();
//CameraPanel.hidePanel(CameraPanel.itemUIPanel);
//Debug.Log("startbox tapped");




//public void resetMiscPage1()
//{
//    showFirstPage();
//    resetPageUI();
//    resetCategoryScrollers();
//    LeanTween.moveLocal(categoryPages[0].transform.gameObject, new Vector3(-.02f, 0f, 0.15f), 0).setEase(LeanTweenType.easeInOutSine);
//    categoryPages[0].transform.GetChild(0).gameObject.SetActive(true);
//    CameraPanel.hidePanel(CameraPanel.itemUIPanel);
//    startBox.SetActive(false);
//    categoryPages[0].SetActive(true);
//    CameraPanel.hidePanel(CameraPanel.itemUIPanel);
//    arSession.Reset();
//    tapToStart.text = "";
//    pagesNavigationPanels[0].gameObject.SetActive(true);
//    onBoardImage.gameObject.SetActive(false);
//    onBoardDirections.gameObject.SetActive(false);
//    onboardButton.gameObject.SetActive(false);
//    LeanTween.moveLocal(bottomUI.transform.gameObject, new Vector3(211.4756f, -1663, -140.9991f), 3).setEase(LeanTweenType.easeInOutSine);
//    LeanTween.moveLocal(pagesNavigationPanels[0].transform.gameObject, new Vector3(-350, -1131.84f, 4.2f), 0f).setEase(LeanTweenType.easeInOutSine);
//    Debug.Log("startbox tapped");
//    pageTitle.text = "MAIN MENU";
//    stopInteractionsBox.transform.position = new Vector3(0, 0, 2);
//}

//case "StartBox":

//showFirstPage();
//resetPageUI();
//resetCategoryScrollers();
//LeanTween.moveLocal(categoryPages[0].transform.gameObject, new Vector3(-.02f, 0f, 0.15f), 0).setEase(LeanTweenType.easeInOutSine);
//categoryPages[0].transform.GetChild(0).gameObject.SetActive(true);
//CameraPanel.hidePanel(CameraPanel.itemUIPanel);
//startBox.SetActive(false);
//categoryPages[0].SetActive(true);
//CameraPanel.hidePanel(CameraPanel.itemUIPanel);
//arSession.Reset();
//tapToStart.text = "";
//pagesNavigationPanels[0].gameObject.SetActive(true);
//onBoardImage.gameObject.SetActive(false);
//onBoardDirections.gameObject.SetActive(false);
//onboardButton.gameObject.SetActive(false);
//LeanTween.moveLocal(bottomUI.transform.gameObject, new Vector3(211.4756f, -1663, -140.9991f), 3).setEase(LeanTweenType.easeInOutSine);
//LeanTween.moveLocal(pagesNavigationPanels[0].transform.gameObject, new Vector3(-382, 0, -0.034542f), 3.2f).setEase(LeanTweenType.easeInOutSine);
//Debug.Log("startbox tapped");
//pageTitle.text = "MAIN MENU";


//break;



//public class NextPrevMainMenu : MonoBehaviour
//{
//    [Header("UI")]
//    [SerializeField] private Button nextButton;
//    [SerializeField] private Button previousButton;
//    [SerializeField] private TextMeshProUGUI pageNumber;
//    [SerializeField] private CanvasGroup prevButtonCanvasgroup;
//    [SerializeField] private TextMeshProUGUI homeText;
//    [SerializeField] private TextMeshProUGUI topTitle;

//    [Header("Pages")]
//    [SerializeField] private GameObject[] mainScrollerPages;
//    [SerializeField] private int currentPage = 0;


//    [SerializeField] private GameObject storeParent;

//    [SerializeField] ARSession arSession;

//    private void Awake()
//    {
//        selectPage(0);
//    }

//    public void changePage(int _change)
//    {
//        currentPage += _change;
//        selectPage(currentPage);

//    }

//    private void selectPage(int _index)
//    {


//        if (currentPage == 0)
//        {
//            prevButtonCanvasgroup.alpha = 0;
//            homeText.text = "Prev";
//            //pageNumber.text = "1";


//        }

//        else

//        {
//            //pageNumber.text = "2";
//            prevButtonCanvasgroup.alpha = 1;
//        }


//        if (currentPage == mainScrollerPages.Length - 1)
//        {
//            nextButton.gameObject.SetActive(false);

//        }

//        else
//        {
//            nextButton.gameObject.SetActive(true);
//        }

//        previousButton.interactable = (_index != 0);
//        previousButton.enabled = (_index != 0);

//        nextButton.interactable = (_index != mainScrollerPages.Length - 1);
//        nextButton.enabled = (_index != mainScrollerPages.Length - 1);

//        for (int i = 0; i < transform.childCount; i++)
//        {
//            transform.GetChild(i).gameObject.SetActive(i == _index);
//            slidePageHolder(_index);
//        }

//        //pageNumber.text = "HomePage " + currentPage + 1 + "";
//        pageNumber.text = currentPage + 1 + "" + "/" + mainScrollerPages.Length + "";
//    }


//    public void slidePageHolder(int _change)
//    {

//        switch (_change)
//        {
//            case 0:
//                topTitle.text = "MAIN MENU";
//                LeanTween.moveLocal(mainScrollerPages[0], new Vector3(0, 0, 0), 1).setEase(LeanTweenType.easeInOutSine);
//                break;

//            case 1:

//                LeanTween.moveLocal(mainScrollerPages[1], new Vector3(0, 0, 0), 1).setEase(LeanTweenType.easeInOutSine);
//                topTitle.text = "MAIN MENU PAGE 2";
//                break;
//            default:
//                return;

//        }

//    }
//}

//showFirstPage();
//resetPageUI();
//resetCategoryScrollers();
//LeanTween.moveLocal(categoryPages[0].transform.gameObject, new Vector3(-.02f, 0f, 0.15f), 0).setEase(LeanTweenType.easeInOutSine);
//categoryPages[0].transform.GetChild(0).gameObject.SetActive(true);
//CameraPanel.hidePanel(CameraPanel.itemUIPanel);
//startBox.SetActive(false);
//categoryPages[0].SetActive(true);
//CameraPanel.hidePanel(CameraPanel.itemUIPanel);
//arSession.Reset();
//tapToStart.text = "";
//Debug.Log("startbox tapped");
//pagesNavigationPanels[0].gameObject.SetActive(true);
//onBoardImage.gameObject.SetActive(false);
//onBoardDirections.gameObject.SetActive(false);
//onboardButton.gameObject.SetActive(false);
//pageTitle.text = "MAIN MENU";
//LeanTween.moveLocal(bottomUI.transform.gameObject, new Vector3(211.4756f, -1663, -140.9991f), 3).setEase(LeanTweenType.easeInOutSine);
//LeanTween.moveLocal(pagesNavigationPanels[0].transform.gameObject, new Vector3(-350, -1131.84f, 4.2f), 3.2f).setEase(LeanTweenType.easeInOutSine);
