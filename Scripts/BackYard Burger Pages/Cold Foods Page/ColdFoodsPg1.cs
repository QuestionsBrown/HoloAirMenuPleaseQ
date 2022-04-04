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


public class ColdFoodsPg1 : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private GameObject uiPagePanel;
    [SerializeField] private Button previousButton;
    [SerializeField] private TextMeshProUGUI homeText;
    [SerializeField] private TextMeshProUGUI pageNumber;
    [SerializeField] private TextMeshProUGUI topTitle;

    [SerializeField] private Button returnButton;
    [Header("Pages")]
    [SerializeField] private GameObject[] catgeoryPages;

    [Header("Main Menu")]
    [SerializeField] private GameObject mainMenuScroller;
    [SerializeField] private GameObject mainPagePanel;
    [SerializeField] private GameObject topTitleGO;

    [SerializeField] private int currentPage = 0;

    [SerializeField] ARSession arSession;

    [SerializeField] private Rigidbody kaleSaladrigidBody;
    [SerializeField] private Rigidbody kaleWrapRigidBody;

    [SerializeField] private float rotatorSpeed = 300f;
    bool draggng = false;

    [SerializeField] private GameObject pageRef;
    [SerializeField] private GameObject returnButtonParent;
    [SerializeField] private GameObject restartButton;


    [SerializeField] private GameObject restartMain;
    //[SerializeField] Camera arCamera;

    #region ARSettings
    //[HideInInspector]
    [SerializeField] ARSession arsession;
    //[HideInInspector]
    [SerializeField] Camera arCamera;
    [HideInInspector]
    [SerializeField] private float mobileRotationSpeed = 0.4f;
    [HideInInspector]
    [SerializeField] private float moveDuration = .5f;
    [HideInInspector]
    [SerializeField] private float delay = 0;
    //[HideInInspector]
    [SerializeField] private GameObject returnBox;
    //[HideInInspector]
    [SerializeField] private GameObject itemViewingLocation;
    [SerializeField] private GameObject itemViewingSmall;
    //[HideInInspector]
    [SerializeField] private GameObject stopInteractionsBox;
    //[HideInInspector]
    [SerializeField] private GameObject spotLight;

    [SerializeField] private GameObject storeParent;





    [SerializeField] private TextMeshProUGUI itemTitle2D;

    [SerializeField] private TextMeshProUGUI itemDescription2D;

    [SerializeField] private TextMeshProUGUI itemPrice2D;


    Vector3 direction;

    private int currentIndex;
    string hitName;
    #endregion ARSettings

    #region Resuable Camera UIPanel
    UIPanelGameObject CameraPanel;
    //[HideInInspector]
    [SerializeField] private GameObject cameraUIPanel;
    //[HideInInspector]
    [SerializeField] private TextMeshPro itemTitle;
    //[HideInInspector]
    [SerializeField] private TextMeshPro itemDescription;
    //[HideInInspector]
    [SerializeField] private TextMeshPro itemPrice;
    private string titleString;
    private string descriptionString;
    private string priceString;
    #endregion  Resuable Camera UIPanel

    #region Items
    ItemRedo kaleSalad;
    ItemRedo kaleWrap;
    #endregion Items

    #region Item Details

    [Header("Kale Salad")]
    [SerializeField] private GameObject KaleSalad;
    [SerializeField] private GameObject KaleSaladOrigin;
    [SerializeField] private GameObject KaleSaladUIPanel;
    [SerializeField] private string KaleSaladTitle;
    [SerializeField] private string KaleSaladDescription;
    [SerializeField] private string KaleSaladPrice;
    [SerializeField] private Rigidbody KaleSaladRigidBody;

    [Header("Kale Wrap")]
    [SerializeField] private GameObject KaleWrap;
    [SerializeField] private GameObject KaleWrapOrigin;
    [SerializeField] private GameObject KaleWrapUIPanel;
    [SerializeField] private string KaleWrapTitle;
    [SerializeField] private string KaleWrapDescription;
    [SerializeField] private string KaleWrapPrice;
    [SerializeField] private Rigidbody KaleWrapRigidBody;




    private bool isSelcted1 = false;
    private bool isSelcted2 = false;


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
        //selectPage(0);
        transform.gameObject.SetActive(true);
        initItems();
        setAllItemsActive(kaleSalad, kaleWrap);
        //scaleDownItems(kaleSalad, kaleWrap);

    }

    private void initItems()
    {
        CameraPanel = new UIPanelGameObject(cameraUIPanel, itemTitle2D, titleString, itemDescription2D, descriptionString, itemPrice2D, priceString);

        kaleSalad = new ItemRedo(KaleSalad, KaleSaladOrigin, KaleSaladTitle, KaleSaladDescription, KaleSaladPrice, itemViewingLocation, moveDuration, delay, stopInteractionsBox, isSelcted1, KaleSaladRigidBody, KaleSaladUIPanel, canvasGroup, textTitle);
        kaleWrap = new ItemRedo(KaleWrap, KaleWrapOrigin, KaleWrapTitle, KaleWrapDescription, KaleWrapPrice, itemViewingLocation, moveDuration, delay, stopInteractionsBox, isSelcted2, KaleWrapRigidBody, KaleWrapUIPanel, canvasGroup, textTitle);

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
    }

    public void scaleDownItems(ItemRedo item_Ref, ItemRedo item_Ref2)

    {
        LeanTween.scale(item_Ref.item, new Vector3(0f, 0f, 0f), 0f).setEase(LeanTweenType.easeInOutSine);
        LeanTween.scale(item_Ref2.item, new Vector3(0f, 0f, 0f), 0f).setEase(LeanTweenType.easeInOutSine);
    }

    public void setAllItemsActive(ItemRedo item_Ref, ItemRedo item_Ref2)
    {
        item_Ref.item.SetActive(true);
        item_Ref2.item.SetActive(true);
    }


    void Start()
    {

        LeanTween.moveLocal(spotLight, new Vector3(.001f, 0, .022f), moveDuration);
        //CameraPanel.showPanel(CameraPanel.itemUIPanel);

        LeanTween.scale(kaleSalad.item, new Vector3(1f, 1f, 1f), 3f).setEase(LeanTweenType.easeInOutSine);
        LeanTween.scale(kaleWrap.item, new Vector3(1f, 1f, 1f), 3f).setEase(LeanTweenType.easeInOutSine);


        //kaleSalad.startRotationTween(kaleSalad.item);
        //kaleWrap.startRotationTween(kaleWrap.item);

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
                        Debug.Log("OVER UI");
                        return;

                    }

                    else if (!isOverUI)
                    {

                        switch (hitName)
                        {
                            case "Kale Wrap":
                                selectItem(kaleWrap, kaleSalad, KaleWrapRigidBody, KaleWrapUIPanel);


                                break;

                            case "Kale Salad":
                                //Debug.Log("Dragging Salad");
                                selectItem(kaleSalad, kaleWrap, KaleSaladRigidBody, KaleSaladUIPanel);
                                break;


                            //case "ReturnBox":
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
                        case "Kale Salad":

                            draggng = true;

                            startRotatingItem(kaleSalad, touch, kaleSaladrigidBody);

                            break;

                        case "Kale Wrap":


                            draggng = true;

                            startRotatingItem(kaleWrap, touch, kaleWrapRigidBody);


                            break;



                        default:
                            return;
                    }
                }

                
            }

        }
    }


    public void selectItem(ItemRedo item_Ref, ItemRedo item_Ref2, Rigidbody itemRigidbody, GameObject itemUIPanel)
    {

        storeParent.gameObject.transform.parent = null;
        item_Ref.selectItem(item_Ref.item, item_Ref.itemOrigin, itemViewingLocation, stopInteractionsBox, moveDuration, delay, itemRigidbody, itemUIPanel);
        showPanelPlease();
        CameraPanel.showPanel(CameraPanel.itemUIPanel);
        CameraPanel.changeItemDetails2D(itemTitle2D, item_Ref.itemTitleString, itemDescription2D, item_Ref.itemDescriptionString, itemPrice2D, item_Ref.itemPriceString);
        item_Ref2.cancleAllTweens(item_Ref2.item, item_Ref2.itemOrigin, item_Ref2.itemUIPanel);
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
        //Debug.Log("RESET COLD FOODS");
        //Debug.Log("RESET ALL COLD FOODS");
        //StartCoroutine(hideReturnButton());
        CameraPanel.hidePanel(CameraPanel.itemUIPanel);
        kaleSalad.cancleAllTweens(kaleSalad.item, kaleSalad.itemOrigin, kaleSalad.itemUIPanel);
        kaleWrap.cancleAllTweens(kaleWrap.item, kaleWrap.itemOrigin, kaleWrap.itemUIPanel);
        StartCoroutine(waitToSnap());



        if (kaleSaladrigidBody.angularVelocity.magnitude > 0)
        {
            kaleSaladrigidBody.angularVelocity = Vector3.zero;
        }

        if (kaleWrapRigidBody.angularVelocity.magnitude > 0)
        {
            kaleWrapRigidBody.angularVelocity = Vector3.zero;
        }


    }




    public void hidePanel2()
    {
        CameraPanel.hidePanel(CameraPanel.itemUIPanel);
    }

    public void hideUIPanel()
    {
        CameraPanel.hidePanel(CameraPanel.itemUIPanel);
    }


    public IEnumerator waitToSnap()
    {
        storeParent.gameObject.transform.parent = arCamera.gameObject.transform;
        yield return new WaitForSeconds(.5f);
    
        resetStoreParent();

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

    public void resetStoreParent()
    {
        LeanTween.rotateLocal(storeParent.gameObject, new Vector3(0, 0, 0), .1f).setEase(LeanTweenType.easeInOutSine);
        LeanTween.moveLocal(storeParent.gameObject, new Vector3(0, 0, 0), .1f).setEase(LeanTweenType.easeInOutSine);
        LeanTween.scale(storeParent.gameObject, new Vector3(1, 1, 1f), .1f).setEase(LeanTweenType.easeInOutSine);
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

            homeText.text = "MAIN MENU";
        }


        //previousButton.interactable = (_index != );

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
                uiPagePanel.transform.localPosition = new Vector3(-350f, -4000f, 0);///
                //mainPagePanel.transform.position = new Vector3(0, 100, 1.5f);
                LeanTween.moveLocal(mainPagePanel, new Vector3(0, -1150, 0), 1.5f).setEase(LeanTweenType.easeInOutSine);
                //transform.gameObject.SetActive(false);
                LeanTween.moveLocal(pageRef, new Vector3(-1.128f, 0f, 0), 1.75f).setEase(LeanTweenType.easeInOutSine);
                LeanTween.moveLocal(mainMenuScroller, new Vector3(-.04f, 0.15f, 0.147f), 1.5f).setEase(LeanTweenType.easeInOutSine);

                returnBox.SetActive(false);
                returnButton.enabled = false;
                //changePageTo0();
                resetAll();
                //scaleDownItems();
                topTitle.text = "CUISINE";

                LeanTween.moveLocal(returnButtonParent, new Vector3(32, -450, 0), 1.75f).setEase(LeanTweenType.easeInOutSine);

                //returnButtonParent.SetActive(false);
                restartButton.SetActive(false);

                restartMain.SetActive(true);
                break;

            case 0:
                changePageTo0();

                //LeanTween.moveLocal(uiPagePanel, new Vector3(-28, -1121, 0), 1.75f).setEase(LeanTweenType.easeInOutSine);
                LeanTween.moveLocal(pageRef, new Vector3(0, 0f, 0), 1.75f).setEase(LeanTweenType.easeInOutSine);

                //LeanTween.moveLocal(catgeoryPages[0], new Vector3(0, 0, 0), 1.75f).setEase(LeanTweenType.easeInOutSine);
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


    public void showPanelPlease()
    {
        StartCoroutine(showPanelsir());
    }

    public IEnumerator showPanelsir()
    {

        yield return new WaitForSeconds(2.35f);

        LeanTween.moveLocal(cameraUIPanel, new Vector3(-0, .005f, 0.2858f), 0.98f).setEase(LeanTweenType.easeInOutSine);
        LeanTween.scale(cameraUIPanel, new Vector3(1, 1, 1), .8f).setEase(LeanTweenType.easeInOutSine);


    }

}


