

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

public class BeveragesPg1 : MonoBehaviour
{

    [SerializeField] private Button returnButton;
    [SerializeField] private GameObject pageRef;
    [SerializeField] private GameObject returnButtonParent;

    #region ARSettings
    [Header("ARSettings")]
    //[HideInInspector]
    [SerializeField] Camera arCamera;
    //[HideInInspector]
    [SerializeField] private GameObject itemViewingLocation;
    //[HideInInspector]
    [SerializeField] private GameObject stopInteractionsBox;

    [SerializeField] private GameObject restartsButton;

    [SerializeField] private GameObject restartMain;

    private float mobileRotationSpeed = 0.4f;
    private float moveDuration = 1.99f;
    private float delay = 0;
    [SerializeField] private float rotatorSpeed = 300f;
    bool draggng = false;

    string hitName;
    #endregion ARSettings

    #region Resuable Camera UIPanel
    [Header("Item UI")]
    UIPanelGameObject CameraPanel;
    //[HideInInspector]
    [SerializeField] private GameObject cameraUIPanel;
    //[HideInInspector]
    [SerializeField] private TextMeshPro itemTitle;
    //[HideInInspector]
    [SerializeField] private TextMeshPro itemDescription;
    //[HideInInspector]
    [SerializeField] private TextMeshPro itemPrice;



    [SerializeField] private TextMeshProUGUI itemTitle2D;

    [SerializeField] private TextMeshProUGUI itemDescription2D;

    [SerializeField] private TextMeshProUGUI itemPrice2D;


    private string titleString;
    private string descriptionString;
    private string priceString;
    #endregion  Resuable Camera UIPanel

    #region Items
    ItemRedo tea;
    ItemRedo lemonade;
    ItemRedo strawberrylemonade;
    ItemRedo water;
    #endregion Items

    #region Item Details
    [Header("Tea")]
    [SerializeField] private GameObject Tea;
    [SerializeField] private GameObject TeaOrigin;
    [SerializeField] private GameObject TeaUIPanel;
    [SerializeField] private string TeaTitle;
    [SerializeField] private string TeaDescription;
    [SerializeField] private string TeaPrice;
    [SerializeField] private Rigidbody TeaRigidBody;

    [Header("Lemonade")]
    [SerializeField] private GameObject Lemonade;
    [SerializeField] private GameObject LemonadeUIPanel;
    [SerializeField] private GameObject LemonadeOrigin;
    [SerializeField] private string LemonadeTitle;
    [SerializeField] private string LemonadeDescription;
    [SerializeField] private string LemonadePrice;
    [SerializeField] private Rigidbody LemonadeRigidBody;


    [Header("Strawberry Lemoade")]
    [SerializeField] private GameObject StrawberryLemonade;
    [SerializeField] private GameObject StrawberryLemonadePanel;
    [SerializeField] private GameObject StrawberryLemonadeOrigin;
    [SerializeField] private string StrawberryLemonadeTitle;
    [SerializeField] private string StrawberryLemonadeDescription;
    [SerializeField] private string StrawberryLemonadePrice;
    [SerializeField] private Rigidbody StrawberryLemonadeRigidBody;

    [Header("Water")]
    [SerializeField] private GameObject Water;
    [SerializeField] private GameObject WaterPanel;
    [SerializeField] private GameObject WaterOrigin;
    [SerializeField] private string WaterTitle;
    [SerializeField] private string WaterDescription;
    [SerializeField] private string WaterPrice;
    [SerializeField] private Rigidbody WaterRigidBody;


    Vector3 direction;

    [SerializeField] private GameObject storeParent;


    private bool isSelcted = false;
    private bool isSelcted2 = false;
    private bool isSelcted3 = false;
    private bool isSelcted4 = false;

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
        setAllItemsActive(tea, lemonade, strawberrylemonade, water);
        //scaleDownItems(tea, lemonade, strawberrylemonade, water);
    }




    private void initItems()
    {
        CameraPanel = new UIPanelGameObject(cameraUIPanel, itemTitle2D, titleString, itemDescription2D, descriptionString, itemPrice2D, priceString);
        tea = new ItemRedo(Tea, TeaOrigin, TeaTitle, TeaDescription, TeaPrice, itemViewingLocation, moveDuration, delay, stopInteractionsBox, isSelcted, TeaRigidBody, TeaUIPanel, canvasGroup, textTitle);
        lemonade = new ItemRedo(Lemonade, LemonadeOrigin, LemonadeTitle, LemonadeDescription, LemonadePrice, itemViewingLocation, moveDuration, delay, stopInteractionsBox, isSelcted2, LemonadeRigidBody, LemonadeUIPanel, canvasGroup, textTitle);
        strawberrylemonade = new ItemRedo(StrawberryLemonade, StrawberryLemonadeOrigin, StrawberryLemonadeTitle, StrawberryLemonadeDescription, StrawberryLemonadePrice, itemViewingLocation, moveDuration, delay, stopInteractionsBox, isSelcted3, StrawberryLemonadeRigidBody, StrawberryLemonadePanel, canvasGroup, textTitle);
        water = new ItemRedo(Water, WaterOrigin, WaterTitle, WaterDescription, WaterPrice, itemViewingLocation, moveDuration, delay, stopInteractionsBox, isSelcted4, WaterRigidBody, WaterPanel, canvasGroup, textTitle);
    }

    public void startRotatingAllItems(ItemRedo item_Ref, ItemRedo item_Ref2, ItemRedo itemRef_3, ItemRedo itemRef_4)
    {
        item_Ref.startRotationTween(item_Ref.item);
        item_Ref2.startRotationTween(item_Ref2.item);
        itemRef_3.startRotationTween(itemRef_3.item);
        itemRef_4.startRotationTween(itemRef_4.item);
    }

    public void scaleUpItems(ItemRedo item_Ref, ItemRedo item_Ref2, ItemRedo itemRef_3, ItemRedo itemRef_4)
    {
        LeanTween.scale(item_Ref.item, new Vector3(1f, 1f, 1f), 3f).setEase(LeanTweenType.easeInOutSine);
        LeanTween.scale(item_Ref2.item, new Vector3(1f, 1f, 1f), 3f).setEase(LeanTweenType.easeInOutSine);
        LeanTween.scale(itemRef_3.item, new Vector3(1f, 1f, 1f), 3f).setEase(LeanTweenType.easeInOutSine);
        LeanTween.scale(itemRef_4.item, new Vector3(1f, 1f, 1f), 3f).setEase(LeanTweenType.easeInOutSine);
    }

    public void scaleDownItems(ItemRedo item_Ref, ItemRedo item_Ref2, ItemRedo item_Ref3, ItemRedo item_Ref4)

    {
        LeanTween.scale(item_Ref.item, new Vector3(0f, 0f, 0f), 0f).setEase(LeanTweenType.easeInOutSine);
        LeanTween.scale(item_Ref2.item, new Vector3(0f, 0f, 0f), 0f).setEase(LeanTweenType.easeInOutSine);
        LeanTween.scale(item_Ref3.item, new Vector3(0f, 0f, 0f), 0f).setEase(LeanTweenType.easeInOutSine);
        LeanTween.scale(item_Ref4.item, new Vector3(0f, 0f, 0f), 0f).setEase(LeanTweenType.easeInOutSine);
    }

    public void setAllItemsActive(ItemRedo item_Ref, ItemRedo item_Ref2, ItemRedo item_Ref3, ItemRedo item_Ref4)
    {
        item_Ref.item.SetActive(true);
        item_Ref2.item.SetActive(true);
        item_Ref3.item.SetActive(true);
        item_Ref4.item.SetActive(true);
    }

    void Start()
    {
        //CameraPanel.showPanel(CameraPanel.itemUIPanel);

        //LeanTween.scale(tea.item, new Vector3(1f, 1f, 1f), 3f).setEase(LeanTweenType.easeInOutSine);
        //LeanTween.scale(lemonade.item, new Vector3(1f, 1f, 1f), 3f).setEase(LeanTweenType.easeInOutSine);
        //LeanTween.scale(strawberrylemonade.item, new Vector3(1f, 1f, 1f), 3f).setEase(LeanTweenType.easeInOutSine);
        //LeanTween.scale(water.item, new Vector3(1f, 1f, 1f), 3f).setEase(LeanTweenType.easeInOutSine);

        //burgers.startRotationTween(burgers.item);
        //coldFoods.startRotationTween(coldFoods.item);
        //burgers.startRotationTween(burgers.item);
        //coldFoods.startRotationTween(coldFoods.item);
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
                            case "Tea":
                                selectItem(tea, water, lemonade, strawberrylemonade, TeaRigidBody, TeaUIPanel);
                                break;

                            case "Lemonade":
                                selectItem(lemonade, water, tea, strawberrylemonade, LemonadeRigidBody, LemonadeUIPanel);

                                break;


                            case "Strawberry Lemonade":
                                selectItem(strawberrylemonade, water, tea, lemonade, StrawberryLemonadeRigidBody, StrawberryLemonadePanel);

                                break;

                            case "Water":
                                selectItem(water, strawberrylemonade, tea, lemonade, WaterRigidBody, WaterPanel);
                                break;

                            //case "ReturnBox":
                            //    resetAll();
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
                        case "Tea":
                            draggng = true;
                            startRotatingItem(tea, touch, TeaRigidBody);
                            break;

                        case "Lemonade":
                            draggng = true;
                            startRotatingItem(lemonade, touch, LemonadeRigidBody);
                            break;

                        case "Strawberry Lemonade":
                            draggng = true;
                            startRotatingItem(strawberrylemonade, touch, StrawberryLemonadeRigidBody);
                            break;

                        case "Water":
                            draggng = true;
                            startRotatingItem(water, touch, WaterRigidBody);
                            break;

                        default:
                            return;
                    }
                }

                }
            }

        }
    

    public void selectItem(ItemRedo item_Ref, ItemRedo item_Ref2, ItemRedo item_Ref3, ItemRedo item_Ref4, Rigidbody itemRigidbody, GameObject uiPanel)
    {
        storeParent.gameObject.transform.parent = null;
        item_Ref.selectItem(item_Ref.item, item_Ref.itemOrigin, itemViewingLocation, stopInteractionsBox, moveDuration, delay, itemRigidbody, uiPanel);
        CameraPanel.showPanel(CameraPanel.itemUIPanel);
        CameraPanel.changeItemDetails2D(itemTitle2D, item_Ref.itemTitleString, itemDescription2D, item_Ref.itemDescriptionString, itemPrice2D, item_Ref.itemPriceString);
        item_Ref2.cancleAllTweens(item_Ref2.item, item_Ref2.itemOrigin, item_Ref2.itemUIPanel);
        item_Ref3.cancleAllTweens(item_Ref3.item, item_Ref3.itemOrigin, item_Ref3.itemUIPanel);
        item_Ref4.cancleAllTweens(item_Ref4.item, item_Ref4.itemOrigin, item_Ref4.itemUIPanel);

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


    public void resetAll()
    {
        CameraPanel.hidePanel(CameraPanel.itemUIPanel);
        tea.cancleAllTweens(tea.item, tea.itemOrigin, tea.itemUIPanel);
        water.cancleAllTweens(water.item, water.itemOrigin, water.itemUIPanel);
        strawberrylemonade.cancleAllTweens(strawberrylemonade.item, strawberrylemonade.itemOrigin, strawberrylemonade.itemUIPanel);
        lemonade.cancleAllTweens(lemonade.item, lemonade.itemOrigin, lemonade.itemUIPanel);
        StartCoroutine(waitToSnap());

        if (TeaRigidBody.angularVelocity.magnitude > 0)
        {
            TeaRigidBody.angularVelocity = Vector3.zero;
        }

        if (LemonadeRigidBody.angularVelocity.magnitude > 0)
        {
            LemonadeRigidBody.angularVelocity = Vector3.zero;
        }

        if (StrawberryLemonadeRigidBody.angularVelocity.magnitude > 0)
        {
            StrawberryLemonadeRigidBody.angularVelocity = Vector3.zero;
        }

        if (WaterRigidBody.angularVelocity.magnitude > 0)
        {
            WaterRigidBody.angularVelocity = Vector3.zero;
        }
    }

    public void resetSlide()
    {
        CameraPanel.hidePanel(CameraPanel.itemUIPanel);
        tea.cancleAllTweens(tea.item, tea.itemOrigin, tea.itemUIPanel);
        water.cancleAllTweens(water.item, water.itemOrigin, water.itemUIPanel);
        strawberrylemonade.cancleAllTweens(strawberrylemonade.item, strawberrylemonade.itemOrigin, strawberrylemonade.itemUIPanel);
        lemonade.cancleAllTweens(lemonade.item, lemonade.itemOrigin, lemonade.itemUIPanel);
        StartCoroutine(waitToSnap());
        StartCoroutine(waitToSnapSlide());

        if (TeaRigidBody.angularVelocity.magnitude > 0)
        {
            TeaRigidBody.angularVelocity = Vector3.zero;
        }

        if (LemonadeRigidBody.angularVelocity.magnitude > 0)
        {
            LemonadeRigidBody.angularVelocity = Vector3.zero;
        }

        if (StrawberryLemonadeRigidBody.angularVelocity.magnitude > 0)
        {
            StrawberryLemonadeRigidBody.angularVelocity = Vector3.zero;
        }

        if (WaterRigidBody.angularVelocity.magnitude > 0)
        {
            WaterRigidBody.angularVelocity = Vector3.zero;
        }
    }

    public IEnumerator waitToSnap()
    {
        storeParent.gameObject.transform.parent = arCamera.gameObject.transform;
        yield return new WaitForSeconds(.5f);
        resetStoreParent();
    }

    public IEnumerator waitToSnapSlide()
    {
        storeParent.gameObject.transform.parent = arCamera.gameObject.transform;
        yield return new WaitForSeconds(0f);
        resetStoreParent();

    }

    public void resetStoreParent()
    {
        LeanTween.rotateLocal(storeParent.gameObject, new Vector3(0, 0, 0), .1f).setEase(LeanTweenType.easeInOutSine);
        LeanTween.moveLocal(storeParent.gameObject, new Vector3(0, 0, 0), .1f).setEase(LeanTweenType.easeInOutSine);
        LeanTween.scale(storeParent.gameObject, new Vector3(1, 1, 1f), .1f).setEase(LeanTweenType.easeInOutSine);
    }


    public void hidePanel2()
    {
        CameraPanel.hidePanel(CameraPanel.itemUIPanel);
    }

    public void hideUIPanel()
    {
        CameraPanel.hidePanel(CameraPanel.itemUIPanel);
    }


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
                //mainPagePanel.transform.localPosition = new Vector3(-350, -1131.84f, 1.5f);
                //transform.gameObject.SetActive(false);
                LeanTween.moveLocal(mainPagePanel.transform.gameObject, new Vector3(0, -1150, 0), 0).setEase(LeanTweenType.easeInOutSine);

                LeanTween.moveLocal(pageRef, new Vector3(1, 0f, 0), 1.75f).setEase(LeanTweenType.easeInOutSine);
                LeanTween.moveLocal(mainMenuScroller, new Vector3(-.04f, 0.15f, 0.147f), 1.5f).setEase(LeanTweenType.easeInOutSine);
                returnBox.SetActive(false);
                returnButtonParent.SetActive(false);
                restartsButton.SetActive(false);
                LeanTween.moveLocal(returnButtonParent, new Vector3(32, -450, 0), 1.75f).setEase(LeanTweenType.easeInOutSine);
                restartMain.SetActive(true);
                //changePageTo0();
                //resetAll();
                resetSlide();
                //scaleDownItems();
                topTilte.text = "MAIN";
                break;

            case 0:
                LeanTween.moveLocal(catgeoryPages[0], new Vector3(0, -.33f, 0), 0).setEase(LeanTweenType.easeInOutSine);
                mainPagePanel.transform.localPosition = new Vector3(-350, -4000, 1.5f);
                returnButtonParent.SetActive(false);
                waitToSnapSlide();

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

    //public void resetAll()
    //{
    //    CameraPanel.hidePanel(CameraPanel.itemUIPanel);
    //    tea.cancleAllTweens(tea.item, tea.itemOrigin);
    //    lemonade.cancleAllTweens(lemonade.item, lemonade.itemOrigin);
    //    strawberrylemonade.cancleAllTweens(strawberrylemonade.item, strawberrylemonade.itemOrigin);
    //    water.cancleAllTweens(water.item, water.itemOrigin);
    //}


    //public void hidePanel2()
    //{
    //    CameraPanel.hidePanel(CameraPanel.itemUIPanel);
    //}

}