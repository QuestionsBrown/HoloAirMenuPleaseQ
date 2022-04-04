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


public class BurgersPg2 : MonoBehaviour
{
    #region ARSettings
    [Header("ARSettings")]
    [SerializeField] Camera arCamera;
    [SerializeField] private GameObject itemViewingLocation;
    [SerializeField] private GameObject stopInteractionsBox;

    [SerializeField] private GameObject restartMain;

    [SerializeField] private GameObject storeParent;

    [SerializeField] private ARSession arSession;

    [SerializeField] private GameObject pageRef;

    private float mobileRotationSpeed = 0.2f;
    private float moveDuration = 3f;
    private float delay = 0;
    [SerializeField] private Rigidbody BlackAndBlueRigidbody;

    string hitName;
    #endregion ARSettings

    #region Resuable Camera UIPanel
    UIPanelGameObject CameraPanel;
    [HideInInspector]
    [SerializeField] private GameObject cameraUIPanel;
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

    #region Items
    ItemRedo blackAndBlue;
    #endregion Items

    #region Item Details
    [Header("Burger 1")]
    [SerializeField] private GameObject Burgers;
    [SerializeField] private GameObject BurgersOrigin;
    [SerializeField] private GameObject BlackandBlueUIPanel;
    [SerializeField] private string BurgersTitle;
    [SerializeField] private string BurgersDescription;
    [SerializeField] private string BurgersPrice;


    [SerializeField] private float rotatorSpeed = 300f;
    bool draggng = false;

    private bool isSelcted = false;

    #endregion Item Details



    [SerializeField] private TextMeshProUGUI itemTitle2D;

    [SerializeField] private TextMeshProUGUI itemDescription2D;

    [SerializeField] private TextMeshProUGUI itemPrice2D;


    [SerializeField] private TextMeshProUGUI textTitle;
    [SerializeField] private CanvasGroup canvasGroup;

    private void Awake()
    {

        //resetAll();
        //selectPage(0);
        CameraPanel = new UIPanelGameObject(cameraUIPanel, itemTitle2D, titleString, itemDescription2D, descriptionString, itemPrice2D, priceString);
        blackAndBlue = new ItemRedo(Burgers, BurgersOrigin, BurgersTitle, BurgersDescription, BurgersPrice, itemViewingLocation, moveDuration, delay, stopInteractionsBox, isSelcted, BlackAndBlueRigidbody, BlackandBlueUIPanel, canvasGroup, textTitle);
        blackAndBlue.item.SetActive(true);
        //LeanTween.scale(blackAndBlue.item, new Vector3(0f, 0f, 0f), 0f).setEase(LeanTweenType.easeInOutSine);
        //arsession.Reset();

    }
    void Start()
    {
        //LeanTween.moveLocal(spotLight, new Vector3(.001f, 0, .022f), moveDuration);
        //CameraPanel.showPanel(CameraPanel.itemUIPanel);
        LeanTween.scale(blackAndBlue.item, new Vector3(1f, 1f, 1f), 3f).setEase(LeanTweenType.easeInOutSine);
        //blackAndBlue.startRotationTween(blackAndBlue.item);

    }



    //turn off update when not active
    void Update()
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

                    switch (hitName)
                    {
                        case "Romeo Mac Burger":
                            //blackAndBlue.selectItem(blackAndBlue.item, blackAndBlue.itemOrigin, itemViewingLocation, stopInteractionsBox, moveDuration, delay, BlackAndBlueRigidbody);
                            selectItem(blackAndBlue, BlackAndBlueRigidbody, BlackandBlueUIPanel);
                            CameraPanel.showPanel(CameraPanel.itemUIPanel);
                            CameraPanel.changeItemDetails(itemTitle, blackAndBlue.itemTitleString, itemDescription, blackAndBlue.itemDescriptionString, itemPrice, blackAndBlue.itemPriceString);
                            break;


                        case "ReturnBox":

                            //blackAndBlue.dismissItem(blackAndBlue.item, blackAndBlue.itemOrigin, 2, 1f);

                            //resetAll();
                            break;

                        default:
                            return;
                    }
                }

                if (touch.phase == TouchPhase.Moved)
                {
                    switch (hitName)
                    {
                           
                        case "Romeo Mac Burger":
                            //Debug.Log("Dragging BlackJack");

                            draggng = true;
                            startRotatingItem(blackAndBlue, touch, BlackAndBlueRigidbody);


                            //if (blackAndBlue.item.transform.position.z != itemViewingLocation.transform.position.z)
                            //{
                            //    return;
                            //}
                            //else
                            //{
                            //    blackAndBlue.stopRotatingItem(blackAndBlue.item);
                            //    blackAndBlue.item.transform.Rotate(touch.deltaPosition.y * mobileRotationSpeed, -touch.deltaPosition.x * mobileRotationSpeed, 0, Space.World);
                            //}
                            break;


                        default:
                            return;
                    }
                }

            }
        }


    }


    public void resetAll()
    {
        //blackAndBlue.gameObject.SetActive(true);
        BlackandBlueUIPanel.SetActive(true);

        //pageRef.SetActive(true);
        CameraPanel.hidePanel(CameraPanel.itemUIPanel);
        blackAndBlue.cancleAllTweens(blackAndBlue.item, blackAndBlue.itemOrigin, blackAndBlue.itemUIPanel);

        if (BlackAndBlueRigidbody.angularVelocity.magnitude > 0)
        {
            BlackAndBlueRigidbody.angularVelocity = Vector3.zero;
        }

        StartCoroutine(waitToSnap());

    }

    public IEnumerator waitToSnap()
    {
        yield return new WaitForSeconds(.5f);
        resetStoreParent();
    }



    public void resetStoreParent()
    {
        LeanTween.rotateLocal(storeParent.gameObject, new Vector3(0, 0, 0), .1f).setEase(LeanTweenType.easeInOutSine);
        LeanTween.moveLocal(storeParent.gameObject, new Vector3(0, 0, 0), .1f).setEase(LeanTweenType.easeInOutSine);
        LeanTween.scale(storeParent.gameObject, new Vector3(1f, 1f, 1f), .1f).setEase(LeanTweenType.easeInOutSine);
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

    public void selectItem(ItemRedo item_Ref, Rigidbody itemRigidbody, GameObject itemUIPanel)
    {
        showPanelPlease();
        storeParent.gameObject.transform.parent = null;
        item_Ref.selectItem(item_Ref.item, item_Ref.itemOrigin, itemViewingLocation, stopInteractionsBox, moveDuration, delay, itemRigidbody, itemUIPanel);
        CameraPanel.changeItemDetails2D(itemTitle2D, item_Ref.itemTitleString, itemDescription2D, item_Ref.itemDescriptionString, itemPrice2D, item_Ref.itemPriceString);
        //CameraPanel.showPanel(CameraPanel.itemUIPanel);
        //CameraPanel.changeItemDetails(itemTitle, item_Ref.itemTitleString, itemDescription, item_Ref.itemDescriptionString, itemPrice, item_Ref.itemPriceString);

    }


    public void showPanelPlease()
    {
        StartCoroutine(showPanelsir());
    }

    public IEnumerator showPanelsir()
    {

        yield return new WaitForSeconds(1.99f);

        LeanTween.moveLocal(cameraUIPanel, new Vector3(-0, .005f, 0.2858f), 0.98f).setEase(LeanTweenType.easeInOutSine);
        LeanTween.scale(cameraUIPanel, new Vector3(1, 1, 1), .8f).setEase(LeanTweenType.easeInOutSine);


    }

}
