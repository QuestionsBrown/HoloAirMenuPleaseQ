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


public class MiscItems : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI itemTitle2D;

    [SerializeField] private TextMeshProUGUI itemDescription2D;

    [SerializeField] private TextMeshProUGUI itemPrice2D;



    [SerializeField] private TextMeshProUGUI textTitle;

    [SerializeField] private CanvasGroup canvasGroup;

    #region ARSettings
    [Header("ARSettings")]
    //[HideInInspector]
    [SerializeField] Camera arCamera;
    //[HideInInspector]
    [SerializeField] private GameObject itemViewingLocation;
    
    //[HideInInspector]
    [SerializeField] private GameObject stopInteractionsBox;
    //[HideInInspector]
    [SerializeField] private GameObject storeParent;
    //[HideInInspector]
    [SerializeField] private Button returnButton;
    [SerializeField] private GameObject returnButtonParent;
    [SerializeField] private GameObject restartParent;
    [SerializeField] private GameObject restartMain;

    //[HideInInspector]
    [SerializeField] private GameObject returnBox;

    [SerializeField] public float rotatorSpeed = 100f;
    bool draggng = false;

    Vector3 direction;



    [SerializeField] private float mobileRotationSpeed = 0.085f;
    [SerializeField] private float moveDuration = 1.99f;
    private float delay = 0;
    string hitName;
    #endregion ARSettings

    #region Resuable Camera UIPanel
    [Header("Details Panel")]
    UIPanelGameObject CameraPanel;
    [SerializeField] private GameObject cameraUIPanel;
    private string titleString;
    private string descriptionString;
    private string priceString;
    #endregion  Resuable Camera UIPanel

    #region Item Details 
    [SerializeField] private GameObject[] miscPages;

    ItemRedo alexander1010;
    ItemRedo freakanature;
    ItemRedo diablo;
    //ItemRedo blackJack;
    //ItemRedo blackAndBlue;

    [SerializeField] private GameObject pageRef;

    [SerializeField] private GameObject FREAKANATUREPanel;
    //[SerializeField] private GameObject BlackJackUIPanel;
    [SerializeField] private GameObject ALEXANDER1010UIPanel;
    [SerializeField] private GameObject DIABLOUIPanel;
    //[SerializeField] private GameObject BlackAndBlueUIPanel;


    [Header("Classic")]
    [SerializeField] private GameObject Alexander1010;
    [SerializeField] private GameObject Alexander1010Origin;
    [SerializeField] private string Alexander1010Titlte;
    [SerializeField] private string Alexander1010Description;
    [SerializeField] private string Alexander1010Price;
    [SerializeField] private Rigidbody Alexander1010RigidBody;

    [Header("Bacon CHedder")]
    [SerializeField] private GameObject FREAKANATURE;
    [SerializeField] private GameObject FREAKANATUREOrigin;
    [SerializeField] private string FREAKANATURETitle;
    [SerializeField] private string FREAKANATUREDescription;
    [SerializeField] private string FREAKANATUREPrice;
    [SerializeField] private Rigidbody FREAKANATURERigidBody;



    [Header("Mushroom Swiss")]
    [SerializeField] private GameObject DIABLO;
    [SerializeField] private GameObject DIABLOOrigin;
    [SerializeField] private string DIABLOitle;
    [SerializeField] private string DIABLODescription;
    [SerializeField] private string DIABLOPrice;
    [SerializeField] private Rigidbody DIABLORigidBody;

    //[Header("Black and Blue")]
    //[SerializeField] private GameObject BlackAndBlue;
    //[SerializeField] private GameObject BlackAndBlueOrigin;
    //[SerializeField] private string BlackAndBlueTitle;
    //[SerializeField] private string BlackAndBlueDescription;
    //[SerializeField] private string BlackAndBluePrice;
    //[SerializeField] private Rigidbody BlackAndBlueRigidbody;


    //[Header("Black Jack")]
    //[SerializeField] private GameObject BlackJack;
    //[SerializeField] private GameObject BlackJackOrigin;
    //[SerializeField] private string BlackJackTitle;
    //[SerializeField] private string BlackJackDescription;
    //[SerializeField] private string BlackJackPrice;
    //[SerializeField] private Rigidbody BlackJackRigidBody;


    private bool isSelcted1 = false;
    private bool isSelcted2 = false;
    private bool isSelcted3 = false;
    //private bool isSelcted4 = false;
    //private bool isSelcted5 = false;
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
        alexander1010 = new ItemRedo(Alexander1010, Alexander1010Origin, Alexander1010Titlte, Alexander1010Description, Alexander1010Price, itemViewingLocation, moveDuration, delay, stopInteractionsBox, isSelcted1, Alexander1010RigidBody, ALEXANDER1010UIPanel , canvasGroup, textTitle);
        freakanature = new ItemRedo(FREAKANATURE, FREAKANATUREOrigin, FREAKANATURETitle, FREAKANATUREDescription, FREAKANATUREPrice, itemViewingLocation, moveDuration, delay, stopInteractionsBox, isSelcted2, FREAKANATURERigidBody, FREAKANATUREPanel , canvasGroup, textTitle);
        diablo = new ItemRedo(DIABLO, DIABLOOrigin, DIABLOitle, DIABLODescription, DIABLOPrice, itemViewingLocation, moveDuration, delay, stopInteractionsBox, isSelcted3, DIABLORigidBody, DIABLOUIPanel, canvasGroup, textTitle);
        //blackJack = new ItemRedo(BlackJack, BlackJackOrigin, BlackJackTitle, BlackJackDescription, BlackJackPrice, itemViewingLocation, moveDuration, delay, stopInteractionsBox, isSelcted5, BlackJackRigidBody, BlackJackUIPanel, canvasGroup, textTitle);
        //blackAndBlue = new ItemRedo(BlackAndBlue, BlackAndBlueOrigin, BlackAndBlueTitle, BlackAndBlueDescription, BlackAndBluePrice, itemViewingLocation, moveDuration, delay, stopInteractionsBox, isSelcted4, BlackAndBlueRigidbody, BlackAndBlueUIPanel, canvasGroup, textTitle);

    }

    private void Awake()
    {
        transform.gameObject.SetActive(true);
        selectPage(0);
        initItems();
        setAllItemsActive(alexander1010, diablo, freakanature);
        //scaleDownItems(classic, mushroomSwiss, baconChedder);
    }

    void Start()
    {
        CameraPanel.showPanel(CameraPanel.itemUIPanel);
        //scaleUpItems(classic, mushroomSwiss, baconChedder);
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
                            case "Weed":

                                //selectItem(baconChedder, classic, mushroomSwiss, blackAndBlue, BlackAndBlueRigidbody, BlackAndBlueUIPanel);

                                break;

                            case "alexander":
                                selectItem(alexander1010, freakanature, diablo, Alexander1010RigidBody, ALEXANDER1010UIPanel );
                                break;

                            case "diablo":
                                selectItem(diablo , alexander1010, freakanature, FREAKANATURERigidBody, DIABLOUIPanel);
                                break;

                            case "freak":
                                selectItem(freakanature, diablo, alexander1010, DIABLORigidBody, FREAKANATUREPanel);
                                break;

                            //case "ReturnBox":
                            //    Debug.Log("return all");
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
                        case "Weed":

                            draggng = true;
                            //startRotatingItem(blackJack, touch, BlackJackRigidBody);
                            break;

                        case "alexander":
                            draggng = true;
                            startRotatingSecretItem(alexander1010, touch, Alexander1010RigidBody);
                 
                            break;

                        case "diablo":
                            draggng = true;
                            startRotatingItem(diablo, touch, DIABLORigidBody);
                 
                            break;

                        case "freak":
                            draggng = true;
                            startRotatingItem(freakanature, touch, FREAKANATURERigidBody);
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
    public void selectItem(ItemRedo item_Ref, ItemRedo item_Ref2, ItemRedo itemRef_3, Rigidbody itemRigidbody, GameObject uiPanel)
    {
        storeParent.gameObject.transform.parent = null;
        item_Ref.selectItem(item_Ref.item, item_Ref.itemOrigin, itemViewingLocation, stopInteractionsBox, moveDuration, delay, itemRigidbody, uiPanel);
        //CameraPanel.showPanel(CameraPanel.itemUIPanel);
        CameraPanel.changeItemDetails2D(itemTitle2D, item_Ref.itemTitleString, itemDescription2D, item_Ref.itemDescriptionString, itemPrice2D, item_Ref.itemPriceString);
        item_Ref2.cancleAllTweens(item_Ref2.item, item_Ref2.itemOrigin, item_Ref2.itemUIPanel);
        itemRef_3.cancleAllTweens(itemRef_3.item, itemRef_3.itemOrigin, itemRef_3.itemUIPanel);


    }

    public void startRotatingItem(ItemRedo item_Ref, Touch touch, Rigidbody itemRefRigidbody)
    {
        if (item_Ref.item.transform.position.z != item_Ref.itemOrigin.transform.position.z && draggng == true)
        {
            item_Ref.stopRotationTween(item_Ref.item);
            float x = Input.GetAxis("Mouse X") * rotatorSpeed * Time.fixedDeltaTime;
            float y = Input.GetAxis("Mouse Y") * rotatorSpeed * Time.fixedDeltaTime;
            itemRefRigidbody.AddRelativeTorque(Vector3.down * x);

            return;
        }
        //else { }
    }



    public void startRotatingSecretItem(ItemRedo item_Ref, Touch touch, Rigidbody itemRefRigidbody)
    {


        if (item_Ref.item.transform.position.z != item_Ref.itemOrigin.transform.position.z && draggng == true)
        {
            item_Ref.stopRotationTween(item_Ref.item);
            float x = Input.GetAxis("Mouse X") * rotatorSpeed * Time.fixedDeltaTime;
            float y = Input.GetAxis("Mouse Y") * rotatorSpeed * Time.fixedDeltaTime;
            itemRefRigidbody.AddRelativeTorque(Vector3.down * x);
            itemRefRigidbody.AddRelativeTorque(Vector3.right * y);

            return;
        }
        //else { }

    }


    public void startRotatingAllItems(ItemRedo item_Ref, ItemRedo item_Ref2, ItemRedo itemRef_3, ItemRedo itemRef4)
    {
        item_Ref.startRotationTween(item_Ref.item);
        item_Ref2.startRotationTween(item_Ref2.item);
        itemRef_3.startRotationTween(itemRef_3.item);
        itemRef4.startRotationTween(itemRef4.item);
    }

    public void scaleUpItems(ItemRedo item_Ref, ItemRedo item_Ref2, ItemRedo itemRef_3)
    {
        LeanTween.scale(item_Ref.item, new Vector3(1f, 1f, 1f), 3f).setEase(LeanTweenType.easeInOutSine);
        LeanTween.scale(item_Ref2.item, new Vector3(1f, 1f, 1f), 3f).setEase(LeanTweenType.easeInOutSine);
        LeanTween.scale(itemRef_3.item, new Vector3(1f, 1f, 1f), 3f).setEase(LeanTweenType.easeInOutSine);
    }

    public void scaleDownItems(ItemRedo item_Ref, ItemRedo item_Ref2, ItemRedo itemRef_3)

    {
        LeanTween.scale(item_Ref.item, new Vector3(0f, 0f, 0f), 0f).setEase(LeanTweenType.easeInOutSine);
        LeanTween.scale(item_Ref2.item, new Vector3(0f, 0f, 0f), 0f).setEase(LeanTweenType.easeInOutSine);
        LeanTween.scale(itemRef_3.item, new Vector3(0f, 0f, 0f), 0f).setEase(LeanTweenType.easeInOutSine);
    }

    public void setAllItemsActive(ItemRedo item_Ref, ItemRedo item_Ref2, ItemRedo itemRef_3)
    {
        item_Ref.item.SetActive(true);
        item_Ref2.item.SetActive(true);
        itemRef_3.item.SetActive(true);
    }


    #region RESET ITEMS
    public void resetAll()
    {

        //LeanTween.moveLocal(stopInteractionsBox, new Vector3(0, 0, -1), 0f).setEase(LeanTweenType.easeInOutSine);
        CameraPanel.hidePanel(CameraPanel.itemUIPanel);
        alexander1010.cancleAllTweens(alexander1010.item, alexander1010.itemOrigin, alexander1010.itemUIPanel);
        freakanature.cancleAllTweens(freakanature.item, freakanature.itemOrigin, freakanature.itemUIPanel);
        diablo.cancleAllTweens(diablo.item, diablo.itemOrigin, diablo.itemUIPanel);
        //blackJack.cancleAllTweens(blackJack.item, blackJack.itemOrigin, blackJack.itemUIPanel);
        StartCoroutine(waitToSnap());


        if (FREAKANATURERigidBody.angularVelocity.magnitude > 0)
        {
            FREAKANATURERigidBody.angularVelocity = Vector3.zero;
        }

        if (Alexander1010RigidBody.angularVelocity.magnitude > 0)
        {
            Alexander1010RigidBody.angularVelocity = Vector3.zero;
        }

        //if (BlackJackRigidBody.angularVelocity.magnitude > 0)
        //{
        //    BlackJackRigidBody.angularVelocity = Vector3.zero;
        //}

        if (DIABLORigidBody.angularVelocity.magnitude > 0)
        {
            DIABLORigidBody.angularVelocity = Vector3.zero;
        }

    }


    public void hidePanel2()
    {
        CameraPanel.hidePanel(CameraPanel.itemUIPanel);
    }
    #endregion Select, Scale, Rotate, Hide Panel


    public void hideReturnButtonPlease()
    {
        StartCoroutine(hideReturnButton());
    }

    public IEnumerator waitToSnap()
    {
        storeParent.gameObject.transform.parent = arCamera.gameObject.transform;
        yield return new WaitForSeconds(.5f);

        resetStoreParent();

    }

    public void resetStoreParent()
    {
        LeanTween.rotateLocal(storeParent.gameObject, new Vector3(0, 0, 0), .1f).setEase(LeanTweenType.easeInOutSine);
        LeanTween.moveLocal(storeParent.gameObject, new Vector3(0, 0, 0), .1f).setEase(LeanTweenType.easeInOutSine);
        LeanTween.scale(storeParent.gameObject, new Vector3(1, 1, 1f), .1f).setEase(LeanTweenType.easeInOutSine);
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


    //public void resetStoreParent()
    //{
    //    LeanTween.rotateLocal(storeParent.gameObject, new Vector3(0, 0, 0), .1f).setEase(LeanTweenType.easeInOutSine);
    //    LeanTween.moveLocal(storeParent.gameObject, new Vector3(0, 0, 0), .1f).setEase(LeanTweenType.easeInOutSine);
    //    //Debug.Log("SCALE");
    //    LeanTween.scale(storeParent.gameObject, new Vector3(1f, 1f, 1f), .1f).setEase(LeanTweenType.easeInOutSine);
    //}

    #endregion RESET ITEMS

    #region ITEM PAGE SLIDER

    public void slidePageHolder(int _change)
    {
        //resetAll();
        switch (_change)
        {
            case -1:
                changePageTo0();
                uiPagePanel.transform.localPosition = new Vector3(-350f, -4000f, 0);
                //mainMenuPagePanel.transform.localPosition = new Vector3(-350, -1131.84f, 1.5f);
                LeanTween.moveLocal(mainMenuPagePanel.transform.gameObject, new Vector3(0, -1150, 0), 0).setEase(LeanTweenType.easeInOutSine);

                //transform.gameObject.SetActive(false);
                LeanTween.moveLocal(mainMenuScroller, new Vector3(-.04f, 0.15f, 0.147f), 1.5f).setEase(LeanTweenType.easeInOutSine);
                LeanTween.moveLocal(pageRef, new Vector3(2, 0, 0), 1.75f).setEase(LeanTweenType.easeInOutSine);
                returnBox.SetActive(false);
                //returnButton.enabled = false;
                //returnButtonParent.SetActive(false);
                restartParent.SetActive(false);

                LeanTween.moveLocal(returnButtonParent, new Vector3(32,-450, 0), 1.75f).setEase(LeanTweenType.easeInOutSine);
                //changePageTo0();
                resetAll();
                //scaleDownItems();
                topTitle.text = "ART";
                restartMain.SetActive(true);
                //LeanTween.moveLocal(stopInteractionsBox, new Vector3(0, 0, -1), 0f).setEase(LeanTweenType.easeInOutSine);

                break;

            case 0:
                //scaleUpItems();

                //transform.gameObject.SetActive(true);
                //LeanTween.moveLocal(miscPages[1], new Vector3(0, 0, 0), 1.75f).setEase(LeanTweenType.easeInOutSine);
                //LeanTween.moveLocal(miscPages[0], new Vector3(-1, 0, 0), 1.75f).setEase(LeanTweenType.easeInOutSine);
                //mainMenuPagePanel.transform.localPosition = new Vector3(-350, 4000, 0f);
                mainMenuPagePanel.transform.localPosition = new Vector3(-350, -4000, 1.5f);
                LeanTween.moveLocal(miscPages[0], new Vector3(0.027f, -0.63f, 0.221f), 1.5f).setEase(LeanTweenType.easeInOutSine);
                LeanTween.moveLocal(stopInteractionsBox, new Vector3(0, 0, -1), 0f).setEase(LeanTweenType.easeInOutSine);
                waitToSnap();

                break;

            //case 1:
            //    LeanTween.moveLocal(burgerPages[0], new Vector3(-1, 0, 0), 1.75f).setEase(LeanTweenType.easeInOutSine);
            //    LeanTween.moveLocal(burgerPages[1], new Vector3(0, 0, 0), 1.75f).setEase(LeanTweenType.easeInOutSine);
            //    mainMenuPagePanel.transform.localPosition = new Vector3(-350, 4000, 1.5f);
            //    LeanTween.moveLocal(stopInteractionsBox, new Vector3(0, 0, -1), 0f).setEase(LeanTweenType.easeInOutSine);
            //    //topTitle.text = "FLAME-GRILLED BURGERS";
            //break;

            default:
                return;

        }

    }
    #endregion ITEM PAGE SLIDER

 
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


    private void selectPage(int _index)
    {

        if (currentPage == 0)
        {

            homeText.text = "MAIN";
        }


        //previousButton.interactable = (_index != -100);

        for (int i = 0; i < transform.childCount; i++)
        {

            StartCoroutine(waitToUnhuded(_index, i));
            //transform.GetChild(i).gameObject.SetActive(i == _index);
            slidePageHolder(_index);

        }

        pageNumber.text = currentPage + 1 + "" + "/" + miscPages.Length + "";


    }


    public IEnumerator waitToUnhuded(int _index, int i)
    {

        yield return new WaitForSeconds(1f);

        transform.GetChild(i).gameObject.SetActive(i == _index);
    }




    //previousButton.interactable = (_index != -100);

    //    //nextButton.interactable = (_index != burgerPages.Length - 1);

    //    for (int i = 0; i < transform.childCount; i++)
    //    {
    //        //transform.GetChild(i).gameObject.SetActive(i == _index);

    //        slidePageHolder(_index);
    //        //Debug.Log("Selected Page");
    //    }

    //    pageNumber.text = currentPage + 1 + "" + "/" + miscPages.Length + "";
    //}
    //#endregion Page Selector

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



