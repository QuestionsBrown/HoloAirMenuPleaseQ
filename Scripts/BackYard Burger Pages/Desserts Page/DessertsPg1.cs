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



public class DessertsPg1 : MonoBehaviour
{

    #region ARSettings
    [Header("ARSettings")]
    [SerializeField] Camera arCamera;
    [SerializeField] private GameObject storeParent;
    [SerializeField] private GameObject mainMenuScroller;
    [SerializeField] private GameObject itemViewingLocation;
    [SerializeField] private GameObject stopInteractionsBox;
    [SerializeField] private GameObject pageRef;
    [SerializeField] private GameObject restartButton;
    [SerializeField] private GameObject restartMain;
    [SerializeField] private Button returnButton;
    [SerializeField] private GameObject returnButtonParent;

  

    UIPanelGameObject CameraPanel;
    [SerializeField] private GameObject cameraUIPanel;
    [SerializeField] private TextMeshProUGUI textTitle;
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private TextMeshProUGUI itemTitle2D;
    [SerializeField] private TextMeshProUGUI itemDescription2D;
    [SerializeField] private TextMeshProUGUI itemPrice2D;



    [SerializeField] private TextMeshProUGUI homeText;
    [SerializeField] private Button previousButton;
    [SerializeField] private TextMeshProUGUI pageNumber;
    [SerializeField] private TextMeshProUGUI topTilte;

    [SerializeField] private GameObject uiPagePanel;
    [SerializeField] private GameObject mainPagePanel;
    [SerializeField] private GameObject returnBox;


    [SerializeField] private GameObject[] catgeoryPages;

    [SerializeField] private int currentPage = 0;

    private string titleString;
    private string descriptionString;
    private string priceString;


    [SerializeField] private float rotatorSpeed = 300f;
    private float mobileRotationSpeed = 0.4f;
    private float moveDuration = 1.99f;
    private float delay = 0;
    bool draggng = false;
    string hitName;

    private bool isSelcted = false;
    private bool isSelcted2 = false;
    #endregion ARSettings




    #region Items
    ItemRedo chocloateChipCookie;
    ItemRedo oatmealCookie;
    #endregion Items


    #region Item Details
    [Header("Chocolate Chip Cookie")]
    [SerializeField] private GameObject ChocloateChipCookie;
    [SerializeField] private GameObject chocloateChipCookieOrigin;
    [SerializeField] private GameObject chocloateChipCookieUIPanel;
    [SerializeField] private string chocloateChipCookieTitle;
    [SerializeField] private string chocloateChipCookieDescription;
    [SerializeField] private string chocloateChipCookiePrice;
    [SerializeField] private Rigidbody chocloateChipCookieRigidBody;

    [Header("Snicker Doodle Cookie")]
    [SerializeField] private GameObject SnickerDoodleCookie;
    [SerializeField] private GameObject SnickerDoodleCookieOrigin;
    [SerializeField] private GameObject SnickerDoodleCookieUIPanel;
    [SerializeField] private string SnickerDoodleCookieTitle;
    [SerializeField] private string SnickerDoodleCookieDescription;
    [SerializeField] private string SnickerDoodleCookiePrice;
    [SerializeField] private Rigidbody SnickerDoodleCookieRigidBody;
    #endregion Item Details


    private void Awake()
    {
        transform.gameObject.SetActive(true);
        initItems();
        setAllItemsActive(chocloateChipCookie, oatmealCookie);
        //scaleUpItems(chocloateChipCookie, oatmealCookie);
        //scaleDownItems(chocloateChipCookie, oatmealCookie);
    }

   private void initItems()

    {
        CameraPanel = new UIPanelGameObject(cameraUIPanel, itemTitle2D, titleString, itemDescription2D, descriptionString, itemPrice2D, priceString);
        chocloateChipCookie = new ItemRedo(ChocloateChipCookie, chocloateChipCookieOrigin, chocloateChipCookieTitle, chocloateChipCookieDescription, chocloateChipCookiePrice, itemViewingLocation, moveDuration, delay, stopInteractionsBox, isSelcted, chocloateChipCookieRigidBody, chocloateChipCookieUIPanel, canvasGroup, textTitle);
        oatmealCookie = new ItemRedo(SnickerDoodleCookie, SnickerDoodleCookieOrigin, SnickerDoodleCookieTitle, SnickerDoodleCookieDescription, SnickerDoodleCookiePrice, itemViewingLocation, moveDuration, delay, stopInteractionsBox, isSelcted2, SnickerDoodleCookieRigidBody, SnickerDoodleCookieUIPanel, canvasGroup, textTitle);
    }

    public void startRotatingAllItems(ItemRedo item_Ref, ItemRedo item_Ref2)
    {
        item_Ref.startRotationTween(item_Ref.item);
        item_Ref2.startRotationTween(item_Ref2.item);
    }

    public void scaleUpItems(ItemRedo item_Ref, ItemRedo item_Ref2)
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

        //CameraPanel.showPanel(CameraPanel.itemUIPanel);
        //LeanTween.scale(chocloateChipCookie.item, new Vector3(1f, 1f, 1f), 3f).setEase(LeanTweenType.easeInOutSine);
        //LeanTween.scale(oatmealCookie.item, new Vector3(1f, 1f, 1f), 3f).setEase(LeanTweenType.easeInOutSine);


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
                        //Debug.Log("OVER UI");
                        return;

                    }

                    else if (!isOverUI)
                    {
                        switch (hitName)
                        {
                            case "Chocolate Chip Cookie":

                                selectItem(chocloateChipCookie, oatmealCookie, chocloateChipCookieRigidBody, chocloateChipCookieUIPanel);

                                //Debug.Log("WTF PLEASE LETS FINISH");

                                break;

                            case "Oatmeal Cookie":
                                //Debug.Log("WTF PLEASE LETS FINISH");
                                selectItem(oatmealCookie, chocloateChipCookie, SnickerDoodleCookieRigidBody, SnickerDoodleCookieUIPanel);
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
                        case "Chocolate Chip Cookie":

                            draggng = true;
                            startRotatingItem(chocloateChipCookie, touch, chocloateChipCookieRigidBody);
                            break;

                        case "Oatmeal Cookie":
                            draggng = true;
                            startRotatingItem(oatmealCookie, touch, SnickerDoodleCookieRigidBody);
                            break;



                        default:
                            return;
                    }
                }

                }
            }

        }
    

    public void selectItem(ItemRedo item_Ref, ItemRedo item_Ref2, Rigidbody itemRigidbody, GameObject uiPanel)
    {
        storeParent.gameObject.transform.parent = null;
        item_Ref.selectItem(item_Ref.item, item_Ref.itemOrigin, itemViewingLocation, stopInteractionsBox, moveDuration, delay, itemRigidbody, uiPanel);
        //CameraPanel.showPanel(CameraPanel.itemUIPanel);
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
     
        CameraPanel.hidePanel(CameraPanel.itemUIPanel);
        chocloateChipCookie.cancleAllTweens(chocloateChipCookie.item, chocloateChipCookie.itemOrigin, chocloateChipCookie.itemUIPanel);
        oatmealCookie.cancleAllTweens(oatmealCookie.item, oatmealCookie.itemOrigin, oatmealCookie.itemUIPanel);

        StartCoroutine(waitToSnap());

        if (chocloateChipCookieRigidBody.angularVelocity.magnitude > 0)
        {
            chocloateChipCookieRigidBody.angularVelocity = Vector3.zero;
        }

        if (SnickerDoodleCookieRigidBody.angularVelocity.magnitude > 0)
        {
            SnickerDoodleCookieRigidBody.angularVelocity = Vector3.zero;
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
                LeanTween.moveLocal(mainPagePanel.transform.gameObject, new Vector3(0, -1150, 0), 0).setEase(LeanTweenType.easeInOutSine);
                LeanTween.moveLocal(pageRef, new Vector3(-1, 0f, 0), 1.75f).setEase(LeanTweenType.easeInOutSine);
                //transform.gameObject.SetActive(false);
                LeanTween.moveLocal(mainMenuScroller, new Vector3(-.04f, 0.15f, 0.147f), 1.5f).setEase(LeanTweenType.easeInOutSine);
                //LeanTween.moveLocal(catgeoryPages[0], new Vector3(-1.209f, -0.63f, 0.221f), 1.5f).setEase(LeanTweenType.easeInOutSine);
                returnBox.SetActive(false);
                LeanTween.moveLocal(returnButtonParent, new Vector3(32, -450, 0), 1.75f).setEase(LeanTweenType.easeInOutSine);
                //returnButtonParent.SetActive(false);
                restartButton.SetActive(false);
                restartMain.SetActive(true);
                changePageTo0();
                resetAll();
                //scaleDownItems();
                topTilte.text = "MAIN";
                break;

            case 0:
                LeanTween.moveLocal(catgeoryPages[0], new Vector3(0.027f, -0.63f, 0.221f), 1.5f).setEase(LeanTweenType.easeInOutSine);
                mainPagePanel.transform.localPosition = new Vector3(-350, -4000, 1.5f);
                waitToSnap();
                returnButtonParent.SetActive(false);
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

}