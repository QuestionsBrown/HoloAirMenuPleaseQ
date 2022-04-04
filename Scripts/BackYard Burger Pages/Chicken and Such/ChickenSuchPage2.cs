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

//public class ChickenSuchPage2 : MonoBehaviour
//{
//    #region ARSettings
//    [Header("ARSettings")]
//    //[HideInInspector]
//    [SerializeField] Camera arCamera;
//    //[HideInInspector]
//    [SerializeField] private GameObject itemViewingLocation;
//    //[HideInInspector]
//    [SerializeField] private GameObject stopInteractionsBox;

//    private float mobileRotationSpeed = 0.2f;
//    private float moveDuration = 5f;
//    private float delay = 0;

//    string hitName;
//    #endregion ARSettings

//    #region Resuable Camera UIPanel
//    UIPanelGameObject CameraPanel;
//    [HideInInspector]
//    [SerializeField] private GameObject cameraUIPanel;
//    [HideInInspector]
//    [SerializeField] private TextMeshPro itemTitle;
//    [HideInInspector]
//    [SerializeField] private TextMeshPro itemDescription;
//    [HideInInspector]
//    [SerializeField] private TextMeshPro itemPrice;
//    private string titleString;
//    private string descriptionString;
//    private string priceString;
//    #endregion  Resuable Camera UIPanel

//    #region Items
//    ItemRedo burgers;
//    #endregion Items

//    #region Item Details
//    [Header("Hot Dog")]
//    [SerializeField] private GameObject Burgers;
//    [SerializeField] private GameObject BurgersOrigin;
//    [SerializeField] private GameObject BurgersUIPanel;
//    [SerializeField] private string BurgersTitle;
//    [SerializeField] private string BurgersDescription;
//    [SerializeField] private string BurgersPrice;
//    [SerializeField] private Rigidbody GilledHawaiianChickenRigidBody;


//    private bool isSelcted = false;

//    #endregion Item Details

//    private void Awake()
//    {
//        //selectPage(0);
//        CameraPanel = new UIPanelGameObject(cameraUIPanel, itemTitle, titleString, itemDescription, descriptionString, itemPrice, priceString);
//        burgers = new ItemRedo(Burgers, BurgersOrigin, BurgersTitle, BurgersDescription, BurgersPrice, itemViewingLocation, moveDuration, delay, stopInteractionsBox, isSelcted, GilledHawaiianChickenRigidBody, BurgersUIPanel);
//        burgers.item.SetActive(true);
//        LeanTween.scale(burgers.item, new Vector3(0f, 0f, 0f), 0f).setEase(LeanTweenType.easeInOutSine);
//        //arsession.Reset();

//    }
//    void Start()
//    {
//        //LeanTween.moveLocal(spotLight, new Vector3(.001f, 0, .022f), moveDuration);
//        CameraPanel.showPanel(CameraPanel.itemUIPanel);
//        LeanTween.scale(burgers.item, new Vector3(1f, 1f, 1f), 3f).setEase(LeanTweenType.easeInOutSine);
//        burgers.startRotationTween(burgers.item);

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
//                        case "Hot Dog":
//                            burgers.selectItem(burgers.item, burgers.itemOrigin, itemViewingLocation, stopInteractionsBox, moveDuration, delay, GilledHawaiianChickenRigidBody);
//                            CameraPanel.showPanel(CameraPanel.itemUIPanel);
//                            CameraPanel.changeItemDetails(itemTitle, burgers.itemTitleString, itemDescription, burgers.itemDescriptionString, itemPrice, burgers.itemPriceString);
//                            break;


//                        case "ReturnBox":
//                            burgers.cancleAllTweens(burgers.item, burgers.itemOrigin);
//                            burgers.dismissItem(burgers.item, burgers.itemOrigin, moveDuration / 2, 1f);
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
//                        case "Hot Dog":
//                            if (burgers.item.transform.position.z != itemViewingLocation.transform.position.z)
//                            {
//                                return;
//                            }
//                            else
//                            {
//                                burgers.stopRotationTween(burgers.item);
//                                burgers.item.transform.Rotate(touch.deltaPosition.y * mobileRotationSpeed, -touch.deltaPosition.x * mobileRotationSpeed, 0, Space.World);
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
//        burgers.cancleAllTweens(burgers.item, burgers.itemOrigin);
//    }


//    public void hidePanel2()
//    {
//        CameraPanel.hidePanel(CameraPanel.itemUIPanel);
//    }

//    //public void hideUIPanel()
//    //{
//    //    CameraPanel.hidePanel(CameraPanel.itemUIPanel);
//    //}

//}
