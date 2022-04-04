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
//using UnityEngine.UI;



public class BurgersPg1 : MonoBehaviour
{

    [SerializeField] private GameObject lastarrow;

    [SerializeField] private GameObject onboardUI;

    [SerializeField] private GameObject videoPanel;

    #region ARSettings
    [Header("ARSettings")]
    [HideInInspector]
    [SerializeField] Camera arCamera;
    //[HideInInspector]
    [SerializeField] private GameObject itemViewingLocation;
    //[HideInInspector]
    [SerializeField] private GameObject stopInteractionsBox;
    [HideInInspector]
    [SerializeField] private GameObject storeParent;
    //[HideInInspector]
    [SerializeField] private Button returnButton;
    [SerializeField] private GameObject returnButtonParent;

    [SerializeField] private GameObject restartButton;


    [SerializeField] private GameObject restartMain;

    [HideInInspector]
    [SerializeField] private GameObject returnBox;

    [SerializeField] public float rotatorSpeed = 300f;
    bool draggng = false;

    Vector3 direction;



    [SerializeField] private float mobileRotationSpeed = 0.085f;
    [SerializeField] private float moveDuration = 1.5f;
    private float delay = 0;
    string hitName;
    #endregion ARSettings

    #region Resuable Camera UIPanel
    [Header("Details Panel")]
    UIPanelGameObject CameraPanel;
    //[HideInInspector]
    [SerializeField] private GameObject cameraUIPanel;



    [SerializeField] private TextMeshProUGUI itemTitle2D;

    [SerializeField] private TextMeshProUGUI itemDescription2D;

    [SerializeField] private TextMeshProUGUI itemPrice2D;


    [HideInInspector]
    [SerializeField] private TextMeshPro itemTitle;
    [HideInInspector]
    [SerializeField] private TextMeshPro itemDescription;
    [HideInInspector]
    [SerializeField] private TextMeshPro itemPrice;
    private string titleString;
    private string descriptionString;
    private string priceString;
    #endregion  Resuable Camera UIPanel

    #region Item Details 
        [SerializeField] private GameObject[] burgerPages;

        ItemRedo classic;
        ItemRedo baconChedder;
        ItemRedo mushroomSwiss;
        ItemRedo blackJack;
        ItemRedo blackAndBlue;

    [SerializeField] private GameObject pageRef;

    [SerializeField] private GameObject ClassicUIPanel;
    [SerializeField] private GameObject BlackJackUIPanel;
    [SerializeField] private GameObject MushroomSwissUIPanel;
    [SerializeField] private GameObject BaconChedderUIPanel;
    [SerializeField] private GameObject BlackAndBlueUIPanel;


    [Header("Classic")]
        [SerializeField] private GameObject Classic;
        [SerializeField] private GameObject ClassicOrigin;
        [SerializeField] private string ClassicTitlte;
        [SerializeField] private string ClassicDescription;
        [SerializeField] private string ClassicPrice;
    [SerializeField] private Rigidbody ClassicRigidBody;

    [Header("Bacon CHedder")]
        [SerializeField] private GameObject BaconChedder;
        [SerializeField] private GameObject BaconChedderOrigin;
        [SerializeField] private string BaconChedderTitle;
        [SerializeField] private string BaconChedderDescription;
        [SerializeField] private string BaconChedderPrice;
        [SerializeField] private Rigidbody BaconChedderRigidBody;
   


    [Header("Mushroom Swiss")]
        [SerializeField] private GameObject MushroomSwiss;
        [SerializeField] private GameObject MushroomSwissOrigin;
        [SerializeField] private string MushroomSwissitle;
        [SerializeField] private string MushroomSwissDescription;
        [SerializeField] private string MushroomSwissPrice;
    [SerializeField] private Rigidbody MushroomSwissRigidBody;

    [Header("Black and Blue")]
        [SerializeField] private GameObject BlackAndBlue;
        [SerializeField] private GameObject BlackAndBlueOrigin;
        [SerializeField] private string BlackAndBlueTitle;
        [SerializeField] private string BlackAndBlueDescription;
        [SerializeField] private string BlackAndBluePrice;
    [SerializeField] private Rigidbody BlackAndBlueRigidbody;


    [Header("Black Jack")]
        [SerializeField] private GameObject BlackJack;
        [SerializeField] private GameObject BlackJackOrigin;
        [SerializeField] private string BlackJackTitle;
        [SerializeField] private string BlackJackDescription;
        [SerializeField] private string BlackJackPrice;
    [SerializeField] private Rigidbody BlackJackRigidBody;


    private bool isSelcted1 = false;
        private bool isSelcted2 = false;
        private bool isSelcted3 = false;
        private bool isSelcted4 = false;
        private bool isSelcted5 = false;
        #endregion Item Details

    #region UI
        [Header("UI")]
        [SerializeField] private TextMeshProUGUI topTitle;
        [SerializeField] private GameObject uiPagePanel;
        [SerializeField] private Button nextButton;
        [SerializeField] private Button previousButton;
        [SerializeField] private TextMeshProUGUI pageNumber;
        [SerializeField] private TextMeshProUGUI homeText;
        [SerializeField] private TextMeshProUGUI nextPageText;
 

        [Header("Main Menu ")]
        [SerializeField] private GameObject mainMenuScroller;
        [SerializeField] private GameObject mainMenuPagePanel;

        [SerializeField] private int currentPage = 0;
    #endregion UI


    [SerializeField] private TextMeshProUGUI textTitle;
    [SerializeField] private CanvasGroup canvasGroup;


    //public void OnBeginDrag(PointerEventData pointerEventData)
    //{
    //    Debug.Log("dragging");
    //    draggng = true;
    //}

    //public void OnEndDrag(PointerEventData pointerEventData)
    //{
    //    draggng = false;
    //}

    //public void OnDrag(PointerEventData pointerEventData)
    //{
    //    Debug.Log("dragging");
    //    direction = new Vector3(Input.GetAxis("Mouse Y"), -Input.GetAxis("Mouse X"), 0f);
    //}

    private void initItems()
    {

        CameraPanel = new UIPanelGameObject(cameraUIPanel, itemTitle2D, titleString, itemDescription2D, descriptionString, itemPrice2D, priceString);
        classic = new ItemRedo(Classic, ClassicOrigin, ClassicTitlte, ClassicDescription, ClassicPrice, itemViewingLocation, moveDuration, delay, stopInteractionsBox, isSelcted1, ClassicRigidBody, ClassicUIPanel, canvasGroup, textTitle);
        baconChedder = new ItemRedo(BaconChedder, BaconChedderOrigin, BaconChedderTitle, BaconChedderDescription, BaconChedderPrice, itemViewingLocation, moveDuration, delay, stopInteractionsBox, isSelcted2, BaconChedderRigidBody, BaconChedderUIPanel, canvasGroup, textTitle);
        mushroomSwiss = new ItemRedo(MushroomSwiss, MushroomSwissOrigin, MushroomSwissitle, MushroomSwissDescription, MushroomSwissPrice, itemViewingLocation, moveDuration, delay, stopInteractionsBox, isSelcted3, MushroomSwissRigidBody, MushroomSwissUIPanel, canvasGroup, textTitle);
        blackJack = new ItemRedo(BlackJack, BlackJackOrigin, BlackJackTitle, BlackJackDescription, BlackJackPrice, itemViewingLocation, moveDuration, delay, stopInteractionsBox, isSelcted5, BlackJackRigidBody, BlackJackUIPanel, canvasGroup, textTitle);
        blackAndBlue = new ItemRedo(BlackAndBlue, BlackAndBlueOrigin, BlackAndBlueTitle, BlackAndBlueDescription, BlackAndBluePrice, itemViewingLocation, moveDuration, delay, stopInteractionsBox, isSelcted4, BlackAndBlueRigidbody, BlackAndBlueUIPanel, canvasGroup, textTitle);

    }

    private void Awake()
    {
        transform.gameObject.SetActive(true);
        selectPage(0);
        initItems();
        setAllItemsActive(classic, mushroomSwiss, baconChedder, blackJack);
        //scaleUpItems(classic, mushroomSwiss, baconChedder, blackJack);
        //scaleDownItems(classic, mushroomSwiss, baconChedder, blackJack);

    }

    void Start()
    {
        //CameraPanel.showPanel(CameraPanel.itemUIPanel);
        //scaleUpItems(classic, mushroomSwiss, baconChedder, blackJack);
        //play sound for specific to category
    }

    //private void OnMouseDrag()
    //{
    //    draggng = true;
    //}


    void FixedUpdate()
    {

        foreach (Touch touch in Input.touches)
        {
            Ray camRay = arCamera.ScreenPointToRay(touch.position);
            RaycastHit raycastHit;
            if (Physics.Raycast(camRay, out raycastHit, 10))
            {

                hitName = raycastHit.transform.tag;
                //if (Input.touchCount > 0)

                //{
                //    //Touch first = Input.GetTouch(0);
                //    //if (first.phase == TouchPhase.Stationary)
                //    //{

                //    //    switch (hitName)
                //    //    {
                //    //        case "Bacon Chedder":

                //    //            //selectItem(baconChedder, classic, blackJack, mushroomSwiss, blackAndBlue, BaconChedderRigidBody);
                //    //            //resetAll();
                //    //            //Application.OpenURL("https://backyardburgers.getbento.com/online-ordering/");
                //    //            Debug.Log("Double Tap");
                //    //            break;
                //    //        default:
                //    //            return;


                //    //    }

                //    //}
                //}

                //else { draggng = false; }


                if (touch.phase == TouchPhase.Began)
                {

                    if (EventSystem.current.IsPointerOverGameObject())
                    {
                        return;
                    }

                    var touchPos = touch.position;

                    bool isOverUI = touchPos.IsPointOverUIObject();

                    if (isOverUI)
                    {
                        Debug.Log("OVER UI");
                        return;

                    }



                   else if (!isOverUI)
                    {


                        switch (hitName)
                        {
                            case "Black Jack":
                              
                                selectItem(blackJack, baconChedder, classic, mushroomSwiss, blackAndBlue, BlackAndBlueRigidbody, BlackJackUIPanel);

                                break;

                            case "Classic":
                                selectItem(classic, blackJack, baconChedder, mushroomSwiss, blackAndBlue, ClassicRigidBody, ClassicUIPanel);

                                videoPanel.SetActive(true);
                                LeanTween.scale(videoPanel, new Vector3(.0008f, .0008f, .0008f), 2f).setEase(LeanTweenType.easeInOutSine);
                                break;

                            case "Bacon Chedder":
                                selectItem(baconChedder, classic, blackJack, mushroomSwiss, blackAndBlue, BaconChedderRigidBody, BaconChedderUIPanel);
                                break;

                            case "Mushroom Swiss":
                                selectItem(mushroomSwiss, baconChedder, blackJack, classic, blackAndBlue, BlackAndBlueRigidbody, MushroomSwissUIPanel);
                                break;

                            //case "ReturnBox":
                            //  
                            //    resetAll();
                            //    break;

                            default:
                                return;
                        }
                    }
                }

                  else if (touch.phase == TouchPhase.Moved)
                    {

                    
                    switch (hitName)
                        {
                            case "Black Jack":

                                draggng = true;
                                startRotatingItem(blackJack, touch, BlackJackRigidBody);
                                break;

                            case "Classic":
                                draggng = true;
                           
                            startRotatingItem(classic, touch, ClassicRigidBody);
                                break;

                            case "Bacon Chedder":
                                draggng = true;
                                startRotatingSecretItem(baconChedder, touch, BaconChedderRigidBody);
                                break;

                            case "Mushroom Swiss":
                                draggng = true;
                                startRotatingItem(mushroomSwiss, touch, MushroomSwissRigidBody);
                                break;

                            case "ReturnBox":
                                draggng = false;
                                //enum direction swipe page left right idk

                                break;

                            default:
                                return;
                        }
                    }

                    //else { draggng =false;}

                }
            }
        }
    //}

    //}


    #region Select, Scale, Rotate, Hide Panel
    public void selectItem(ItemRedo item_Ref, ItemRedo item_Ref2, ItemRedo itemRef_3, ItemRedo itemRef4, ItemRedo item_Ref5, Rigidbody itemRigidbody, GameObject itemUIPanel)
    {
        //showPanelPlease();
        storeParent.gameObject.transform.parent = null;
        item_Ref.selectItem(item_Ref.item, item_Ref.itemOrigin, itemViewingLocation, stopInteractionsBox, moveDuration, delay, itemRigidbody, itemUIPanel);


        CameraPanel.changeItemDetails2D(itemTitle2D, item_Ref.itemTitleString, itemDescription2D, item_Ref.itemDescriptionString, itemPrice2D, item_Ref.itemPriceString);



        //CameraPanel.changeItemDetails(itemTitle, item_Ref.itemTitleString, itemDescription, item_Ref.itemDescriptionString, itemPrice, item_Ref.itemPriceString);




        item_Ref2.cancleAllTweens(item_Ref2.item, item_Ref2.itemOrigin, item_Ref2.itemUIPanel);
        itemRef_3.cancleAllTweens(itemRef_3.item, itemRef_3.itemOrigin, itemRef_3.itemUIPanel);
        itemRef4.cancleAllTweens(itemRef4.item, itemRef4.itemOrigin, itemRef4.itemUIPanel);
        item_Ref5.cancleAllTweens(item_Ref5.item, item_Ref5.itemOrigin, item_Ref5.itemUIPanel);

    }

    public void startRotatingItem(ItemRedo item_Ref, Touch touch, Rigidbody itemRefRigidbody)
    {
        if (item_Ref.item.transform.position.z != item_Ref.itemOrigin.transform.position.z && draggng == true)
        {
            Debug.Log("DRAGGING STOPPED ROTATE burger");
            item_Ref.stopRotationTween(item_Ref.item);
            float x = Input.GetAxis("Mouse X") * rotatorSpeed * Time.fixedDeltaTime;
            float y = Input.GetAxis("Mouse Y") * rotatorSpeed * Time.fixedDeltaTime;
            //itemRefRigidbody.AddRelativeTorque(Vector3.down * x);
            itemRefRigidbody.AddTorque(Vector3.down * x);

            return;
        }
    }



    public void startRotatingSecretItem(ItemRedo item_Ref, Touch touch, Rigidbody itemRefRigidbody)
    {


        if (item_Ref.item.transform.position.z != item_Ref.itemOrigin.transform.position.z && draggng == true)
        {
            item_Ref.stopRotationTween(item_Ref.item);
            float x = Input.GetAxis("Mouse X") * rotatorSpeed * Time.fixedDeltaTime;
            float y = Input.GetAxis("Mouse Y") * rotatorSpeed * Time.fixedDeltaTime;
            itemRefRigidbody.AddRelativeTorque(Vector3.down * x);
            //itemRefRigidbody.AddRelativeTorque(Vector3.right * y);
            return;
        }
    }


    public void startRotatingAllItems(ItemRedo item_Ref, ItemRedo item_Ref2, ItemRedo itemRef_3, ItemRedo itemRef4)
    {
        item_Ref.startRotationTween(item_Ref.item);
        item_Ref2.startRotationTween(item_Ref2.item);
        itemRef_3.startRotationTween(itemRef_3.item);
        itemRef4.startRotationTween(itemRef4.item);
    }

    public void scaleUpItems(ItemRedo item_Ref, ItemRedo item_Ref2, ItemRedo itemRef_3, ItemRedo itemRef4)
    {
        LeanTween.scale(item_Ref.item, new Vector3(1f, 1f, 1f), 3f).setEase(LeanTweenType.easeInOutSine);
        LeanTween.scale(item_Ref2.item, new Vector3(1f, 1f, 1f), 3f).setEase(LeanTweenType.easeInOutSine);
        LeanTween.scale(itemRef_3.item, new Vector3(1f, 1f, 1f), 3f).setEase(LeanTweenType.easeInOutSine);
        LeanTween.scale(itemRef4.item, new Vector3(1f, 1f, 1f), 3f).setEase(LeanTweenType.easeInOutSine);
    }

    public void scaleDownItems(ItemRedo item_Ref, ItemRedo item_Ref2, ItemRedo itemRef_3, ItemRedo itemRef4)

    {
        LeanTween.scale(item_Ref.item, new Vector3(0f, 0f, 0f), 0f).setEase(LeanTweenType.easeInOutSine);
        LeanTween.scale(item_Ref2.item, new Vector3(0f, 0f, 0f), 0f).setEase(LeanTweenType.easeInOutSine);
        LeanTween.scale(itemRef_3.item, new Vector3(0f, 0f, 0f), 0f).setEase(LeanTweenType.easeInOutSine);
        LeanTween.scale(itemRef4.item, new Vector3(0f, 0f, 0f), 0f).setEase(LeanTweenType.easeInOutSine);
    }

    public void setAllItemsActive(ItemRedo item_Ref, ItemRedo item_Ref2, ItemRedo itemRef_3, ItemRedo itemRef4)
    {
        item_Ref.item.SetActive(true);
        item_Ref2.item.SetActive(true);
        itemRef_3.item.SetActive(true);
        itemRef4.item.SetActive(true);
    }


    #region RESET ITEMS
    public void resetAll()
    {

        //showPanelPlease();
        BlackJackUIPanel.SetActive(true);
        ClassicUIPanel.SetActive(true);
        MushroomSwissUIPanel.SetActive(true);
        BlackJackUIPanel.SetActive(true);

        //LeanTween.moveLocal(stopInteractionsBox, new Vector3(0, 0, -1), 0f).setEase(LeanTweenType.easeInOutSine);
        CameraPanel.hidePanel(CameraPanel.itemUIPanel);
        classic.cancleAllTweens(classic.item, classic.itemOrigin, classic.itemUIPanel);
        baconChedder.cancleAllTweens(baconChedder.item, baconChedder.itemOrigin, baconChedder.itemUIPanel);
        mushroomSwiss.cancleAllTweens(mushroomSwiss.item, mushroomSwiss.itemOrigin, mushroomSwiss.itemUIPanel);
        blackJack.cancleAllTweens(blackJack.item, blackJack.itemOrigin, blackAndBlue.itemUIPanel);
        StartCoroutine(waitToSnap2());


        if (BaconChedderRigidBody.angularVelocity.magnitude > 0)
        {
            BaconChedderRigidBody.angularVelocity = Vector3.zero;
        }

        if (ClassicRigidBody.angularVelocity.magnitude > 0)
        {
            ClassicRigidBody.angularVelocity = Vector3.zero;
        }

        if (BlackJackRigidBody.angularVelocity.magnitude > 0)
        {
            BlackJackRigidBody.angularVelocity = Vector3.zero;
        }

        if (MushroomSwissRigidBody.angularVelocity.magnitude > 0)
        {
            MushroomSwissRigidBody.angularVelocity = Vector3.zero;
        }

        LeanTween.scale(videoPanel, new Vector3(0f, 0f, 0f), .5f).setEase(LeanTweenType.easeInOutSine);

    }

    public void showPanelPlease()
    {
        StartCoroutine(showPanelsir());
    }

    public IEnumerator showPanelsir()
    {

        yield return new WaitForSeconds(1.75f);


       //CameraPanel.changeItemDetails2D()

        //LeanTween.moveLocal(cameraUIPanel, new Vector3(.002f, .005f, 0.2858f), 0f).setEase(LeanTweenType.easeInOutSine);
        //LeanTween.scale(cameraUIPanel, new Vector3(1, 1, 1), .5f).setEase(LeanTweenType.easeInOutSine);


    }


    public void hidePanel2()
    {
        //CameraPanel.hidePanel(CameraPanel.itemUIPanel);
    }
    #endregion Select, Scale, Rotate, Hide Panel


    public void hideReturnButtonPlease()
    {
        StartCoroutine(hideReturnButton());
    }

    public IEnumerator waitToSnap2()
    {
        storeParent.gameObject.transform.parent = arCamera.gameObject.transform;
        yield return new WaitForSeconds(.5f);
    
        resetStoreParent();

    }


    public IEnumerator hideReturnButton()
    {
        returnButton.interactable = false;
        yield return new WaitForSeconds(.5f);

        returnButton.interactable = true;

    }


    public void turnOnInteractions()
    {
        stopInteractionsBox.transform.position = new Vector3(0, 0, 2);
    }

    public void stopInteractionsNow()
    {
        StartCoroutine(stopInteractions());
    }

    public IEnumerator stopInteractions()
    {
        stopInteractionsBox.transform.position = new Vector3(0, 0, 0.744f);
        yield return new WaitForSeconds(.5f);
        turnOnInteractions();
    }


    public void resetStoreParent()
    {
        LeanTween.rotateLocal(storeParent.gameObject, new Vector3(0, 0, 0), .1f).setEase(LeanTweenType.easeInOutSine);
        LeanTween.moveLocal(storeParent.gameObject, new Vector3(0, 0, 0), .1f).setEase(LeanTweenType.easeInOutSine);
        //Debug.Log("SCALE");
        LeanTween.scale(storeParent.gameObject, new Vector3(1f, 1f, 1f), .1f).setEase(LeanTweenType.easeInOutSine);
    }

    #endregion RESET ITEMS

    #region ITEM PAGE SLIDER

    public void slidePageHolder(int _change)
    {
        //resetAll();
        switch (_change)
        {
            case -1:
                //mainMenuScroller.SetActive(false);
                hidePanel2();
                uiPagePanel.transform.localPosition = new Vector3(-350f, -4000f, 0);
                LeanTween.moveLocal(mainMenuPagePanel.transform.gameObject, new Vector3(0, -1150, 0), 1.5f).setEase(LeanTweenType.easeInOutSine);
                //mainMenuPagePanel.transform.localPosition = new Vector3(-28.8032f, -1121, 0);
                //transform.gameObject.SetActive(false);
                LeanTween.moveLocal(mainMenuScroller, new Vector3(-.04f, 0.15f, 0.147f), 1.5f).setEase(LeanTweenType.easeInOutSine);
                LeanTween.moveLocal(pageRef, new Vector3(1, 0, 0), 1.75f).setEase(LeanTweenType.easeInOutSine);
                returnBox.SetActive(false);
                returnButton.enabled = false;
                changePageTo0();
                //burgerPages[1].transform.gameObject.SetActive(false);
                //returnButtonParent.SetActive(false);
                restartButton.SetActive(false);

                LeanTween.moveLocal(returnButtonParent, new Vector3(32, -450, 0), 1.75f).setEase(LeanTweenType.easeInOutSine);

       
                restartMain.SetActive(true);
                //scaleDownItems();
                topTitle.text = "CUISINE";
                LeanTween.moveLocal(stopInteractionsBox, new Vector3(0, 0, -1), 0f).setEase(LeanTweenType.easeInOutSine);
            

                break;

            case 0:
                //scaleUpItems();
           
                transform.gameObject.SetActive(true);
                //burgerPages[1].transform.gameObject.SetActive(false);
                LeanTween.moveLocal(mainMenuScroller, new Vector3(-1, 0, 0), 1.5f).setEase(LeanTweenType.easeInOutSine);
                LeanTween.moveLocal(burgerPages[1], new Vector3(1, 0, 0), 1.75f).setEase(LeanTweenType.easeInOutSine);
                LeanTween.moveLocal(burgerPages[0], new Vector3(0, 0, 0), 1.75f).setEase(LeanTweenType.easeInOutSine);
                mainMenuPagePanel.transform.localPosition = new Vector3(-350, 4000, 0f);
                LeanTween.moveLocal(stopInteractionsBox, new Vector3(0, 0, -1), 0f).setEase(LeanTweenType.easeInOutSine);
                topTitle.text = "BURGERS";
                lastarrow.gameObject.SetActive(true);

                break;


            case 1:
                burgerPages[1].transform.gameObject.SetActive(true);
                nextButton.gameObject.LeanAlpha(0,0);
                LeanTween.moveLocal(burgerPages[0], new Vector3(-1, 0, 0), 1.75f).setEase(LeanTweenType.easeInOutSine);
                LeanTween.moveLocal(burgerPages[1], new Vector3(0, 0, 0), 1.75f).setEase(LeanTweenType.easeInOutSine);
                mainMenuPagePanel.transform.localPosition = new Vector3(-350, 4000, 1.5f);
                LeanTween.moveLocal(stopInteractionsBox, new Vector3(0, 0, -1), 0f).setEase(LeanTweenType.easeInOutSine);

                lastarrow.gameObject.SetActive(false);
                //topTitle.text = "FLAME-GRILLED BURGERS";
                break;

            default:
                return;

        }

    }
    #endregion ITEM PAGE SLIDER

    #region Page Selector
    public void changePageTo0()
    {
        currentPage = 0;
    }

    public void changePage(int _change)
    {
        currentPage += _change;
        selectPage(currentPage);
        //resetAll();
    }

    public void selectPage(int _index)
    {
       
        if (currentPage == 1)
        {
      
            nextPageText.text = "";
            homeText.text = "PREV";
        }


        if (currentPage == 0)
        {
            pageRef.SetActive(true);
            homeText.text = "MAIN";
            nextPageText.text = "NEXT";

        }

        if (currentPage == burgerPages.Length - 1)
        {


            //nextButton.gameObject.SetActive(false);

        }

        else
        {
            //nextButton.gameObject.SetActive(true);
        }

        nextButton.interactable = (_index != burgerPages.Length - 1);

        for (int i = 0; i < transform.childCount; i++)
        {
            //transform.GetChild(i).gameObject.SetActive(i == _index);

            slidePageHolder(_index);
            //Debug.Log("Selected Page");
        }

        pageNumber.text = currentPage + 1 + "" + "/" + burgerPages.Length + "";
    }
    #endregion Page Selector




}



//itemRefRigidbody.AddRelativeTorque(Vector3.right * -y);
//itemRefRigidbody.AddTorque(direction * rotatorSpeed * Time.fixedDeltaTime);


//float x = direction.x * rotatorSpeed * Time.fixedDeltaTime;
//float y = direction.y * rotatorSpeed * Time.fixedDeltaTime;
//itemRefRigidbody.AddTorque(Vector3.down * y);
//itemRefRigidbody.AddTorque(Vector3.down * x);
//item_Ref.item.transform.Rotate(Vector3.up, -touch.deltaPosition. * 0, touch.deltaPosition.y * mobileRotationSpeed, Space.World);
//item_Ref.item.transform.Rotate(touch.deltaPosition.x * 0, -touch.deltaPosition.y * mobileRotationSpeed * 0, 0, Space.World);
//itemRefRigidbody.AddTorque(direction * rotatorSpeed * Time.fixedDeltaTime);


//float x = direction.x * rotatorSpeed * Time.fixedDeltaTime;
//float y = direction.y * rotatorSpeed * Time.fixedDeltaTime;
//itemRefRigidbody.AddTorque(Vector3.down * y);
//itemRefRigidbody.AddTorque(Vector3.down * x);
//item_Ref.item.transform.Rotate(Vector3.up, -touch.deltaPosition. * 0, touch.deltaPosition.y * mobileRotationSpeed, Space.World);
//item_Ref.item.transform.Rotate(touch.deltaPosition.x * 0, -touch.deltaPosition.y * mobileRotationSpeed * 0, 0, Space.World);



