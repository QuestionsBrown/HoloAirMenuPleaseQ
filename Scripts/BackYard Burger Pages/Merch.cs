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


public class Merch : MonoBehaviour
{
    #region ARSettings
    [Header("ARSettings")]
    //[HideInInspector]
    [SerializeField] Camera arCamera;
    //[HideInInspector]
    [SerializeField] private GameObject itemViewingLocation;
    [SerializeField] private GameObject itemViewingLocation2;
    //[HideInInspector]
    [SerializeField] private GameObject stopInteractionsBox;



    [SerializeField] private Button returnButton;
    [SerializeField] private GameObject pageRef;
    [SerializeField] private GameObject returnButtonParent;
    [SerializeField] private GameObject restartButton;
    [SerializeField] private GameObject restartMain;

    //[SerializeField] private GameObject sauceViewingLocation;

    private float mobileRotationSpeed = 0.4f;
    private float moveDuration = 1.99f;
    private float delay = 0;

    [SerializeField] private float rotatorSpeed = 300f;
    bool draggng = false;

    string hitName;
    #endregion ARSettings

    #region Resuable Camera UIPanel
    UIPanelGameObject CameraPanel;
    //[HideInInspector]
    [SerializeField] private GameObject cameraUIPanel;
    ////[HideInInspector]
    //[SerializeField] private TextMeshPro itemTitle;
    ////[HideInInspector]
    //[SerializeField] private TextMeshPro itemDescription;
    ////[HideInInspector]
    //[SerializeField] private TextMeshPro itemPrice;
    private string titleString;
    private string descriptionString;
    private string priceString;
    #endregion  Resuable Camera UIPanel

    #region Items
    ItemRedo freshCutFries;
    ItemRedo tatorTots;
    ItemRedo chiliCheeseFries;
    #endregion Items

    #region Item Details

    [Header("Fresh Cut Fries")]
    [SerializeField] private GameObject FreshCutFries;
    [SerializeField] private GameObject FreshCutFriesOrigin;
    [SerializeField] private GameObject FreshCutFriesUIPanel;
    [SerializeField] private string FreshCutFriesTitle;
    [SerializeField] private string FreshCutFriesDescription;
    [SerializeField] private string FreshCutFriesPrice;
    [SerializeField] private Rigidbody FreshCutFriesRigidBody;

    [Header("Tator Tots")]
    [SerializeField] private GameObject TatorTots;
    [SerializeField] private GameObject TatorTotsOrigin;
    [SerializeField] private GameObject TatorTotsUIPanel;
    [SerializeField] private string TatorTotsTitle;
    [SerializeField] private string TatorTotsDescription;
    [SerializeField] private string TatorTotsPrice;
    [SerializeField] private Rigidbody TatorTotsRigidBody;


    [Header("Chili Cheese Fries")]
    [SerializeField] private GameObject ChiliCheeseFries;
    [SerializeField] private GameObject ChiliCheeseFriesOrigin;
    [SerializeField] private GameObject ChiliCheeseFriesUIPanel;
    [SerializeField] private string ChiliCheeseFriesTitle;
    [SerializeField] private string ChiliCheeseFriesDescription;
    [SerializeField] private string ChiliCheeseFriesPrice;
    [SerializeField] private Rigidbody ChiliCheeseFriesRigidBody;
    [SerializeField] private GameObject storeParent;


    private bool isSelcted = false;
    private bool isSelcted2 = false;
    private bool isSelcted3 = false;

    [SerializeField] private GameObject[] catgeoryPages;

    [SerializeField] private int currentPage = 0;

    [SerializeField] private TextMeshProUGUI homeText;
    [SerializeField] private Button previousButton;
    [SerializeField] private TextMeshProUGUI pageNumber;
    [SerializeField] private TextMeshProUGUI topTilte;

    [SerializeField] private GameObject uiPagePanel;
    [SerializeField] private GameObject mainPagePanel;
    [SerializeField] private GameObject returnBox;
    //[SerializeField] private GameObject returnButton;

    [SerializeField] private GameObject mainMenuScroller;


    [SerializeField] private TextMeshProUGUI textTitle;
    [SerializeField] private CanvasGroup canvasGroup;

    Vector3 direction;


    [SerializeField] private TextMeshProUGUI itemTitle2D;

    [SerializeField] private TextMeshProUGUI itemDescription2D;

    [SerializeField] private TextMeshProUGUI itemPrice2D;

    #endregion Item Details


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

    private void Awake()
    {
        transform.gameObject.SetActive(true);
        initItems();
        setAllItemsActive(freshCutFries, chiliCheeseFries, tatorTots);
        //scaleDownItems(tatorTots, chiliCheeseFries, freshCutFries);
    }


    private void initItems()
    {

        CameraPanel = new UIPanelGameObject(cameraUIPanel, itemTitle2D, titleString, itemDescription2D, descriptionString, itemPrice2D, priceString);
        freshCutFries = new ItemRedo(FreshCutFries, FreshCutFriesOrigin, FreshCutFriesTitle, FreshCutFriesDescription, FreshCutFriesPrice, itemViewingLocation2, moveDuration, delay, stopInteractionsBox, isSelcted, FreshCutFriesRigidBody, FreshCutFriesUIPanel, canvasGroup, textTitle);
        tatorTots = new ItemRedo(TatorTots, TatorTotsOrigin, TatorTotsTitle, TatorTotsDescription, TatorTotsPrice, itemViewingLocation2, moveDuration, delay, stopInteractionsBox, isSelcted2, TatorTotsRigidBody, TatorTotsUIPanel, canvasGroup, textTitle);
        chiliCheeseFries = new ItemRedo(ChiliCheeseFries, ChiliCheeseFriesOrigin, ChiliCheeseFriesTitle, ChiliCheeseFriesDescription, ChiliCheeseFriesPrice, itemViewingLocation2, moveDuration, delay, stopInteractionsBox, isSelcted3, ChiliCheeseFriesRigidBody, ChiliCheeseFriesUIPanel, canvasGroup, textTitle);
    }



    public void startRotatingAllItems(ItemRedo item_Ref, ItemRedo item_Ref2, ItemRedo itemRef_3)
    {
        item_Ref.startRotationTween(item_Ref.item);
        item_Ref2.startRotationTween(item_Ref2.item);
        itemRef_3.startRotationTween(itemRef_3.item);
    }

    public void scaleUpItems(ItemRedo item_Ref, ItemRedo item_Ref2, ItemRedo itemRef_3)
    {
        LeanTween.scale(item_Ref.item, new Vector3(1f, 1f, 1f), 3f).setEase(LeanTweenType.easeInOutSine);
        LeanTween.scale(item_Ref2.item, new Vector3(1f, 1f, 1f), 3f).setEase(LeanTweenType.easeInOutSine);
        LeanTween.scale(itemRef_3.item, new Vector3(1f, 1f, 1f), 3f).setEase(LeanTweenType.easeInOutSine);

    }

    public void scaleDownItems(ItemRedo item_Ref, ItemRedo item_Ref2, ItemRedo item_Ref3)

    {
        LeanTween.scale(item_Ref.item, new Vector3(0f, 0f, 0f), 0f).setEase(LeanTweenType.easeInOutSine);
        LeanTween.scale(item_Ref2.item, new Vector3(0f, 0f, 0f), 0f).setEase(LeanTweenType.easeInOutSine);
        LeanTween.scale(item_Ref3.item, new Vector3(0f, 0f, 0f), 0f).setEase(LeanTweenType.easeInOutSine);

    }

    public void setAllItemsActive(ItemRedo item_Ref, ItemRedo item_Ref2, ItemRedo item_Ref3)
    {
        item_Ref.item.SetActive(true);
        item_Ref2.item.SetActive(true);
        item_Ref3.item.SetActive(true);

    }

    void Start()
    {
        //LeanTween.moveLocal(spotLight, new Vector3(.001f, 0, .022f), moveDuration);
        //CameraPanel.showPanel(CameraPanel.itemUIPanel);

        //LeanTween.scale(freshCutFries.item, new Vector3(1f, 1f, 1f), 3f).setEase(LeanTweenType.easeInOutSine);
        //LeanTween.scale(tatorTots.item, new Vector3(1f, 1f, 1f), 3f).setEase(LeanTweenType.easeInOutSine);
        //LeanTween.scale(chiliCheeseFries.item, new Vector3(1f, 1f, 1f), 3f).setEase(LeanTweenType.easeInOutSine);
    }



    //turn off update when not active
    void FixedUpdate()
    {

        foreach (Touch touch in Input.touches)
        {
            Ray camRay = arCamera.ScreenPointToRay(touch.position);
            RaycastHit raycastHit;
            if (Physics.Raycast(camRay, out raycastHit, 10))
            {

                hitName = raycastHit.transform.tag;



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
                        //Debug.Log("OVER UI");
                        return;

                    }


                    else if (!isOverUI)
                    {
                        switch (hitName)
                        {
                            case "TestArt":

                                selectItem(freshCutFries, tatorTots, chiliCheeseFries, FreshCutFriesRigidBody, FreshCutFriesUIPanel);

                                break;

                            case "TestArt2":
                                selectItem(tatorTots, freshCutFries, chiliCheeseFries, TatorTotsRigidBody, TatorTotsUIPanel);

                                break;


                            case "TestArt3":
                                selectBigItem(chiliCheeseFries, tatorTots, freshCutFries, ChiliCheeseFriesRigidBody, ChiliCheeseFriesUIPanel);

                                break;

                            //case "ReturnBox":
                            //    //resetAll()
                            //    CameraPanel.hidePanel(CameraPanel.itemUIPanel);
                            //break;

                            default:
                                return;
                        }
                    }
                }


                else if (touch.phase == TouchPhase.Moved)
                {
                    switch (hitName)
                    {
                        case "TestArt":

                            draggng = true;
                            //startRotatingItem(freshCutFries, touch, FreshCutFriesRigidBody);
                            startRotatingSecretItem(freshCutFries, touch, FreshCutFriesRigidBody);

                            break;

                        case "TestArt2":
                            draggng = true;
                            //startRotatingItem(tatorTots, touch, TatorTotsRigidBody);
                            startRotatingSecretItem(tatorTots, touch, TatorTotsRigidBody);

                            break;



                        case "TestArt3":
                            draggng = true;
                            startRotatingSecretItem(chiliCheeseFries, touch, ChiliCheeseFriesRigidBody);

                            //startRotatingItem(chiliCheeseFries, touch, ChiliCheeseFriesRigidBody);
                            break;



                        default:
                            return;
                    }
                }

            }
        }

    }



    public void selectItem(ItemRedo item_Ref, ItemRedo item_Ref2, ItemRedo item_Ref3, Rigidbody itemRigidbody, GameObject itemUIPanel)
    {
        storeParent.gameObject.transform.parent = null;
        item_Ref.selectItem(item_Ref.item, item_Ref.itemOrigin, itemViewingLocation2, stopInteractionsBox, moveDuration, delay, itemRigidbody, itemUIPanel);


        //CameraPanel.showPanel(CameraPanel.itemUIPanel);


        CameraPanel.changeItemDetails2D(itemTitle2D, item_Ref.itemTitleString, itemDescription2D, item_Ref.itemDescriptionString, itemPrice2D, item_Ref.itemPriceString);


        item_Ref2.cancleAllTweens(item_Ref2.item, item_Ref2.itemOrigin, item_Ref2.itemUIPanel);
        item_Ref3.cancleAllTweens(item_Ref3.item, item_Ref3.itemOrigin, item_Ref3.itemUIPanel);

    }

    public void selectBigItem(ItemRedo item_Ref, ItemRedo item_Ref2, ItemRedo item_Ref3, Rigidbody itemRigidbody, GameObject itemUIPanel)
    {
        storeParent.gameObject.transform.parent = null;
        item_Ref.selectItem(item_Ref.item, item_Ref.itemOrigin, itemViewingLocation, stopInteractionsBox, moveDuration, delay, itemRigidbody, itemUIPanel);


        //CameraPanel.showPanel(CameraPanel.itemUIPanel);


        CameraPanel.changeItemDetails2D(itemTitle2D, item_Ref.itemTitleString, itemDescription2D, item_Ref.itemDescriptionString, itemPrice2D, item_Ref.itemPriceString);


        item_Ref2.cancleAllTweens(item_Ref2.item, item_Ref2.itemOrigin, item_Ref2.itemUIPanel);
        item_Ref3.cancleAllTweens(item_Ref3.item, item_Ref3.itemOrigin, item_Ref3.itemUIPanel);

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
            //itemRefRigidbody.AddRelativeTorque(Vector3.right * y);
            return;
        }
    }



    public void resetAll()
    {




        CameraPanel.hidePanel(CameraPanel.itemUIPanel);
        freshCutFries.cancleAllTweens(freshCutFries.item, freshCutFries.itemOrigin, freshCutFries.itemUIPanel);
        tatorTots.cancleAllTweens(tatorTots.item, tatorTots.itemOrigin, tatorTots.itemUIPanel);
        chiliCheeseFries.cancleAllTweens(chiliCheeseFries.item, chiliCheeseFries.itemOrigin, chiliCheeseFries.itemUIPanel);
        StartCoroutine(waitToSnap());

        if (FreshCutFriesRigidBody.angularVelocity.magnitude > 0)
        {
            FreshCutFriesRigidBody.angularVelocity = Vector3.zero;
        }

        if (TatorTotsRigidBody.angularVelocity.magnitude > 0)
        {
            TatorTotsRigidBody.angularVelocity = Vector3.zero;
        }

        if (ChiliCheeseFriesRigidBody.angularVelocity.magnitude > 0)
        {
            ChiliCheeseFriesRigidBody.angularVelocity = Vector3.zero;
        }

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


    //public void hidePanel2()
    //{
    //    CameraPanel.hidePanel(CameraPanel.itemUIPanel);
    //}

    //public void hideUIPanel()
    //{
    //    CameraPanel.hidePanel(CameraPanel.itemUIPanel);
    //}


    public void changePage(int _change)
    {
        currentPage += _change;
        selectPage(currentPage);
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
            //transform.GetChild(i).gameObject.SetActive(i == _index);
            StartCoroutine(waitToUnhuded(_index, i));
            slidePageHolder(_index);

        }

        pageNumber.text = currentPage + 1 + "" + "/" + catgeoryPages.Length + "";
    }

    public void changePageTo0()
    {
        currentPage = 0;
    }


    public void slidePageHolder(int _change)
    {

        switch (_change)
        {
            case -1:
                changePageTo0();
                uiPagePanel.transform.localPosition = new Vector3(-350f, -4000f, 0);
                LeanTween.moveLocal(mainPagePanel.transform.gameObject, new Vector3(0, -1150, 0), 0).setEase(LeanTweenType.easeInOutSine);
                //transform.gameObject.SetActive(false);
                LeanTween.moveLocal(pageRef, new Vector3(2.022f, -0.602f, 0.243f), 1.75f).setEase(LeanTweenType.easeInOutSine);
                LeanTween.moveLocal(mainMenuScroller, new Vector3(-.04f, 0.15f, 0.147f), 1.5f).setEase(LeanTweenType.easeInOutSine);
                returnBox.SetActive(false);
                returnButtonParent.SetActive(false);
                returnButton.enabled = false;
                restartButton.SetActive(false);
                restartMain.SetActive(true);
                //changePageTo0();
                resetAll();
                //scaleDownItems();
                topTilte.text = "FASHION";
                LeanTween.moveLocal(returnButtonParent, new Vector3(32, -450, 0), 1.75f).setEase(LeanTweenType.easeInOutSine);

                break;

            case 0:
                LeanTween.moveLocal(catgeoryPages[0], new Vector3(0, -.33f, 0), 0).setEase(LeanTweenType.easeInOutSine);
                mainPagePanel.transform.localPosition = new Vector3(-350, -4000, 1.5f);

                waitToSnap();
                break;

            default:
                return;

        }

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


    public void hideReturnButtonPlease()
    {
        StartCoroutine(hideReturnButton());
    }

    public IEnumerator hideReturnButton()
    {
        returnButton.interactable = false;
        yield return new WaitForSeconds(.5f);

        returnButton.interactable = true;

    }


    public IEnumerator waitToUnhuded(int _index, int i)
    {

        yield return new WaitForSeconds(1f);

        transform.GetChild(i).gameObject.SetActive(i == _index);
    }

}


