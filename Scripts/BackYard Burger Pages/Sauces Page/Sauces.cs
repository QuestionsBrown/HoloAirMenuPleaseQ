

//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.AddressableAssets;
//using UnityEngine.ResourceManagement.AsyncOperations;
//using UnityEngine.ResourceManagement.ResourceProviders;
//using UnityEngine.SceneManagement;
//using TMPro;
//using UnityEngine.XR.ARFoundation;
//using UnityEngine.XR.ARSubsystems;
//using UnityEngine.XR.ARKit;
//using UnityEngine.EventSystems;
//using UnityEngine.UI;

//public class Sauces : MonoBehaviour
//{
//    #region ARSettings
//    [Header("ARSettings")]
//    //[HideInInspector]
//    [SerializeField] Camera arCamera;
//    //[HideInInspector]
//    [SerializeField] private GameObject itemViewingLocation;
//    //[HideInInspector]
//    [SerializeField] private GameObject stopInteractionsBox;

//    private float mobileRotationSpeed = 0.4f;
//    private float moveDuration = 5f;
//    private float delay = 0;

//    string hitName;
//    #endregion ARSettings

//    #region Resuable Camera UIPanel
//    [Header("Item UI")]
//    UIPanelGameObject CameraPanel;
//    //[HideInInspector]
//    [SerializeField] private GameObject cameraUIPanel;
//    //[HideInInspector]
//    [SerializeField] private TextMeshPro itemTitle;
//    //[HideInInspector]
//    [SerializeField] private TextMeshPro itemDescription;
//    //[HideInInspector]
//    [SerializeField] private TextMeshPro itemPrice;
//    private string titleString;
//    private string descriptionString;
//    private string priceString;
//    #endregion  Resuable Camera UIPanel

//    #region Items
//    ItemRedo houseSauce;
//    ItemRedo onionAioli;
//    ItemRedo ranch;
//    ItemRedo sirachaAioli;
//    #endregion Items

//    #region Item Details

//    [Header("House Sauce")]
//    [SerializeField] private GameObject HouseSauce;
//    [SerializeField] private GameObject HouseSauceOrigin;
//    [SerializeField] private GameObject HouseSauceUIPanel;
//    [SerializeField] private string HouseSauceTitle;
//    [SerializeField] private string HouseSauceDescription;
//    [SerializeField] private string HouseSauceSaladPrice;
//    [SerializeField] private Rigidbody HouseSauceRigidBody;

//    [Header("Onion Aioli")]
//    [SerializeField] private GameObject OnionAioli;
//    [SerializeField] private GameObject OnionAioliOrigin;
//    [SerializeField] private GameObject OnionAioliUIPanel;
//    [SerializeField] private string OnionAioliTitle;
//    [SerializeField] private string OnionAioliDescription;
//    [SerializeField] private string OnionAioliPrice;
//    [SerializeField] private Rigidbody OnionAioliRigidBody;


//    [Header("Ranch")]
//    [SerializeField] private GameObject Ranch;
//    [SerializeField] private GameObject RanchOrigin;
//    [SerializeField] private GameObject RanchUIPanel;
//    [SerializeField] private string RanchTitle;
//    [SerializeField] private string RanchDescription;
//    [SerializeField] private string RanchPrice;
//    [SerializeField] private Rigidbody RanchRigidBody;


//    [Header("Chili Cheese Fries")]
//    [SerializeField] private GameObject SirachaAioli;
//    [SerializeField] private GameObject SirachaAioliOrigin;
//    [SerializeField] private GameObject SirachaAioliUIPanel;
//    [SerializeField] private string SirachaAioliTitle;
//    [SerializeField] private string SirachaAioliDescription;
//    [SerializeField] private string SirachaAioliPrice;
//    [SerializeField] private Rigidbody SirachaAioliRigidBody;


//    private bool isSelcted = false;

//    #endregion Item Details

//    private void Awake()
//    {

//        CameraPanel = new UIPanelGameObject(cameraUIPanel, itemTitle, titleString, itemDescription, descriptionString, itemPrice, priceString);

//        houseSauce = new ItemRedo(HouseSauce, HouseSauceOrigin, HouseSauceTitle, HouseSauceDescription, HouseSauceSaladPrice, itemViewingLocation, moveDuration, delay, stopInteractionsBox, isSelcted, HouseSauceRigidBody, HouseSauceUIPanel);
//        onionAioli = new ItemRedo(OnionAioli, OnionAioliOrigin, OnionAioliTitle, OnionAioliDescription, OnionAioliPrice, itemViewingLocation, moveDuration, delay, stopInteractionsBox, isSelcted, OnionAioliRigidBody, OnionAioliUIPanel);
//        ranch = new ItemRedo(Ranch, RanchOrigin, RanchTitle, RanchDescription, RanchPrice, itemViewingLocation, moveDuration, delay, stopInteractionsBox, isSelcted, RanchRigidBody, RanchUIPanel);
//        sirachaAioli = new ItemRedo(SirachaAioli, SirachaAioliOrigin, SirachaAioliTitle, SirachaAioliDescription, SirachaAioliPrice, itemViewingLocation, moveDuration, delay, stopInteractionsBox, isSelcted, SirachaAioliRigidBody, SirachaAioliUIPanel);

//        houseSauce.item.SetActive(true);
//        onionAioli.item.SetActive(true);
//        ranch.item.SetActive(true);
//        sirachaAioli.item.SetActive(true);


//        LeanTween.scale(houseSauce.item, new Vector3(0f, 0f, 0f), 0f).setEase(LeanTweenType.easeInOutSine);
//        LeanTween.scale(onionAioli.item, new Vector3(0f, 0f, 0f), 0f).setEase(LeanTweenType.easeInOutSine);
//        LeanTween.scale(ranch.item, new Vector3(0f, 0f, 0f), 0f).setEase(LeanTweenType.easeInOutSine);
//        LeanTween.scale(sirachaAioli.item, new Vector3(0f, 0f, 0f), 0f).setEase(LeanTweenType.easeInOutSine);

//    }

//    void Start()
//    {
//        CameraPanel.showPanel(CameraPanel.itemUIPanel);

//        LeanTween.scale(houseSauce.item, new Vector3(1f, 1f, 1f), 3f).setEase(LeanTweenType.easeInOutSine);
//        LeanTween.scale(onionAioli.item, new Vector3(1f, 1f, 1f), 3f).setEase(LeanTweenType.easeInOutSine);
//        LeanTween.scale(sirachaAioli.item, new Vector3(1f, 1f, 1f), 3f).setEase(LeanTweenType.easeInOutSine);
//        LeanTween.scale(ranch.item, new Vector3(1f, 1f, 1f), 3f).setEase(LeanTweenType.easeInOutSine);

//    }


//    //turn off update when not active
//    void Update()
//    {

//        foreach (Touch touch in Input.touches)
//        {
//            Ray camRay = arCamera.ScreenPointToRay(touch.position);
//            RaycastHit raycastHit;
//            if (Physics.Raycast(camRay, out raycastHit, 10))
//            {

//                hitName = raycastHit.transform.tag;

//                if (touch.phase == TouchPhase.Began)
//                {

//                    if (EventSystem.current.IsPointerOverGameObject())
//                    {
//                        return;
//                    }

//                    switch (hitName)
//                    {
        

//                        case "House Sauce":
//                            houseSauce.selectItem(houseSauce.item, houseSauce.itemOrigin, itemViewingLocation, stopInteractionsBox, moveDuration, delay, HouseSauceRigidBody);
//                            CameraPanel.showPanel(CameraPanel.itemUIPanel);
//                            CameraPanel.changeItemDetails(itemTitle, houseSauce.itemTitleString, itemDescription, houseSauce.itemDescriptionString, itemPrice, houseSauce.itemPriceString);

//                            onionAioli.cancleAllTweens(onionAioli.item, onionAioli.itemOrigin);
//                            onionAioli.dismissItem(onionAioli.item, onionAioli.itemOrigin, moveDuration / 2, 1);
//                            ranch.cancleAllTweens(ranch.item, ranch.itemOrigin);
//                            ranch.dismissItem(ranch.item, ranch.itemOrigin, moveDuration / 2, 1);
//                            sirachaAioli.cancleAllTweens(sirachaAioli.item, sirachaAioli.itemOrigin);
//                            sirachaAioli.dismissItem(sirachaAioli.item, sirachaAioli.itemOrigin, moveDuration / 2, 1);
//                            break;

//                        case "Onion Aioli":
//                            onionAioli.selectItem(onionAioli.item, onionAioli.itemOrigin, itemViewingLocation, stopInteractionsBox, moveDuration, delay, OnionAioliRigidBody);
//                            CameraPanel.showPanel(CameraPanel.itemUIPanel);
//                            CameraPanel.changeItemDetails(itemTitle, onionAioli.itemTitleString, itemDescription, onionAioli.itemDescriptionString, itemPrice, onionAioli.itemPriceString);


//                            houseSauce.cancleAllTweens(houseSauce.item, houseSauce.itemOrigin);
//                            houseSauce.dismissItem(houseSauce.item, houseSauce.itemOrigin, moveDuration / 2, 1f);
//                            ranch.cancleAllTweens(ranch.item, ranch.itemOrigin);
//                            ranch.dismissItem(ranch.item, ranch.itemOrigin, moveDuration / 2, 1);
//                            sirachaAioli.cancleAllTweens(sirachaAioli.item, sirachaAioli.itemOrigin);
//                            sirachaAioli.dismissItem(sirachaAioli.item, sirachaAioli.itemOrigin, moveDuration / 2, 1);

//                            break;


//                        case "Ranch":
//                            ranch.selectItem(ranch.item, ranch.itemOrigin, itemViewingLocation, stopInteractionsBox, moveDuration, delay, RanchRigidBody);
//                            CameraPanel.showPanel(CameraPanel.itemUIPanel);
//                            CameraPanel.changeItemDetails(itemTitle, ranch.itemTitleString, itemDescription, ranch.itemDescriptionString, itemPrice, ranch.itemPriceString);


//                            houseSauce.cancleAllTweens(houseSauce.item, houseSauce.itemOrigin);
//                            houseSauce.dismissItem(houseSauce.item, houseSauce.itemOrigin, moveDuration / 2, 1);
//                            onionAioli.cancleAllTweens(onionAioli.item, onionAioli.itemOrigin);
//                            onionAioli.dismissItem(onionAioli.item, onionAioli.itemOrigin, moveDuration / 2, 1);
//                            sirachaAioli.cancleAllTweens(sirachaAioli.item, sirachaAioli.itemOrigin);
//                            sirachaAioli.dismissItem(sirachaAioli.item, sirachaAioli.itemOrigin, moveDuration / 2, 1);

//                            break;

//                        case "Siracha Aioli":
//                            sirachaAioli.selectItem(sirachaAioli.item, sirachaAioli.itemOrigin, itemViewingLocation, stopInteractionsBox, moveDuration, delay, SirachaAioliRigidBody);
//                            CameraPanel.showPanel(CameraPanel.itemUIPanel);
//                            CameraPanel.changeItemDetails(itemTitle, sirachaAioli.itemTitleString, itemDescription, sirachaAioli.itemDescriptionString, itemPrice, sirachaAioli.itemPriceString);


//                            houseSauce.cancleAllTweens(houseSauce.item, houseSauce.itemOrigin);
//                            houseSauce.dismissItem(houseSauce.item, houseSauce.itemOrigin, moveDuration / 2, 1);
//                            onionAioli.cancleAllTweens(onionAioli.item, onionAioli.itemOrigin);
//                            onionAioli.dismissItem(onionAioli.item, onionAioli.itemOrigin, moveDuration / 2, 1);
//                            ranch.cancleAllTweens(ranch.item, ranch.itemOrigin);
//                            ranch.dismissItem(ranch.item, ranch.itemOrigin, moveDuration / 2, 1);

//                            break;


//                        case "ReturnBox":

//                            houseSauce.cancleAllTweens(houseSauce.item, houseSauce.itemOrigin);
//                            houseSauce.dismissItem(houseSauce.item, houseSauce.itemOrigin, moveDuration / 2, 1);
//                            onionAioli.cancleAllTweens(onionAioli.item, onionAioli.itemOrigin);
//                            onionAioli.dismissItem(onionAioli.item, onionAioli.itemOrigin, moveDuration / 2, 1);
//                            ranch.cancleAllTweens(ranch.item, ranch.itemOrigin);
//                            ranch.dismissItem(ranch.item, ranch.itemOrigin, moveDuration / 2, 1);
//                            sirachaAioli.cancleAllTweens(sirachaAioli.item, sirachaAioli.itemOrigin);
//                            sirachaAioli.dismissItem(sirachaAioli.item, sirachaAioli.itemOrigin, moveDuration / 2, 1);


//                            CameraPanel.hidePanel(CameraPanel.itemUIPanel);
//                            break;

//                        default:
//                            return;
//                    }
//                }

//                if (touch.phase == TouchPhase.Moved)
//                {
//                    switch (hitName)
//                    {


//                        case "House Sauce":
//                            if (houseSauce.item.transform.position.z != itemViewingLocation.transform.position.z)
//                            {
//                                return;
//                            }
//                            else
//                            {
//                                houseSauce.stopRotationTween(houseSauce.item);
//                                houseSauce.item.transform.Rotate(touch.deltaPosition.y * mobileRotationSpeed, -touch.deltaPosition.x * mobileRotationSpeed, 0, Space.World);
//                            }
//                            break;

//                        case "Onion Aioli":
//                            if (onionAioli.item.transform.position.z != itemViewingLocation.transform.position.z)
//                            {
//                                return;
//                            }
//                            else
//                            {
//                                onionAioli.stopRotationTween(onionAioli.item);
//                                onionAioli.item.transform.Rotate(touch.deltaPosition.y * mobileRotationSpeed, -touch.deltaPosition.x * mobileRotationSpeed, 0, Space.World);
//                            }
//                            break;



//                        case "Ranch":
//                            if (ranch.item.transform.position.z != itemViewingLocation.transform.position.z)
//                            {
//                                return;
//                            }
//                            else
//                            {
//                                ranch.stopRotationTween(ranch.item);
//                                ranch.item.transform.Rotate(touch.deltaPosition.y * mobileRotationSpeed, -touch.deltaPosition.x * mobileRotationSpeed, 0, Space.World);
//                            }
//                            break;


//                        case "Siracha Aioli":
//                            if (sirachaAioli.item.transform.position.z != itemViewingLocation.transform.position.z)
//                            {
//                                return;
//                            }
//                            else
//                            {
//                                sirachaAioli.stopRotationTween(sirachaAioli.item);
//                                sirachaAioli.item.transform.Rotate(touch.deltaPosition.y * mobileRotationSpeed, -touch.deltaPosition.x * mobileRotationSpeed, 0, Space.World);
//                            }
//                            break;

//                        default:
//                            return;
//                    }
//                }

//            }
//        }

//    }


//    public void resetAll()
//    {
//        CameraPanel.hidePanel(CameraPanel.itemUIPanel);


//        houseSauce.cancleAllTweens(houseSauce.item, houseSauce.itemOrigin);


//        onionAioli.cancleAllTweens(onionAioli.item, onionAioli.itemOrigin);

//        ranch.cancleAllTweens(ranch.item, ranch.itemOrigin);


//        sirachaAioli.cancleAllTweens(sirachaAioli.item, sirachaAioli.itemOrigin);

//    }


//    public void hidePanel2()
//    {
//        CameraPanel.hidePanel(CameraPanel.itemUIPanel);
//    }

//    public void hideUIPanel()
//    {
//        CameraPanel.hidePanel(CameraPanel.itemUIPanel);
//    }
//}
