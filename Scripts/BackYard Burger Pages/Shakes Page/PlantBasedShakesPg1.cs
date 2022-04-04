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

//public class PlantBasedShakesPg1 : MonoBehaviour
//{
//    #region ARSettings
//    [Header("ARSettings")]
//    [HideInInspector]
//    [SerializeField] Camera arCamera;
//    [HideInInspector]
//    [SerializeField] private GameObject itemViewingLocation;
//    [HideInInspector]
//    [SerializeField] private GameObject stopInteractionsBox;

//    private float mobileRotationSpeed = 0.4f;
//    private float moveDuration = 5f;
//    private float delay = 0;

//    string hitName;
//    #endregion ARSettings

//    #region Resuable Camera UIPanel
//    [Header("Item UI")]
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
//    ItemRedo strawberry;
//    ItemRedo chocolate;
//    ItemRedo oreo;
//    ItemRedo vanilla;
//    #endregion Items

//    #region Item Details
//    [Header("Stwarberry")]
//    [SerializeField] private GameObject Strawberry;
//    [SerializeField] private GameObject StrawberryOrigin;
//    [SerializeField] private GameObject StrawberryUIPanel;
//    [SerializeField] private string StrawberryTitle;
//    [SerializeField] private string StrawberryDescription;
//    [SerializeField] private string StrawberryPrice;
//    [SerializeField] private Rigidbody StrawberryRigidBody;

//    [Header("Chocloate")]
//    [SerializeField] private GameObject Chocolate;
//    [SerializeField] private GameObject ChocolateOrigin;
//    [SerializeField] private GameObject ChocolateUIPanel;
//    [SerializeField] private string ChocolateTitle;
//    [SerializeField] private string ChocolateDescription;
//    [SerializeField] private string ChocolatePrice;
//    [SerializeField] private Rigidbody ChocolateRigidBody;


//    [Header("Oreo")]
//    [SerializeField] private GameObject Oreo;
//    [SerializeField] private GameObject OreoOrigin;
//    [SerializeField] private GameObject OreoUIPanel;
//    [SerializeField] private string OreoTitle;
//    [SerializeField] private string OreorDescription;
//    [SerializeField] private string OreoPrice;
//    [SerializeField] private Rigidbody OreoRigidBody;

//    [Header("Vanilla")]
//    [SerializeField] private GameObject Vanilla;
//    [SerializeField] private GameObject VanillaOrigin;
//    [SerializeField] private GameObject VanillaUIPanel;
//    [SerializeField] private string VanillaTitle;
//    [SerializeField] private string VanillaDescription;
//    [SerializeField] private string VanillaPrice;
//    [SerializeField] private Rigidbody VanillaRigidBody;

//    private bool isSelcted = false;

//    #endregion Item Details

//    private void Awake()
//    {

//        CameraPanel = new UIPanelGameObject(cameraUIPanel, itemTitle, titleString, itemDescription, descriptionString, itemPrice, priceString);

//        strawberry = new ItemRedo(Strawberry, StrawberryOrigin, StrawberryTitle, StrawberryDescription, StrawberryPrice, itemViewingLocation, moveDuration, delay, stopInteractionsBox, isSelcted, StrawberryRigidBody, StrawberryUIPanel);
//        chocolate = new ItemRedo(Chocolate, ChocolateOrigin, ChocolateTitle, ChocolateDescription, ChocolatePrice, itemViewingLocation, moveDuration, delay, stopInteractionsBox, isSelcted, ChocolateRigidBody, ChocolateUIPanel);
//        oreo = new ItemRedo(Oreo, OreoOrigin, OreoTitle, OreorDescription, OreoPrice, itemViewingLocation, moveDuration, delay, stopInteractionsBox, isSelcted, OreoRigidBody, OreoUIPanel);
//        vanilla = new ItemRedo(Vanilla, VanillaOrigin, VanillaTitle, VanillaDescription, VanillaPrice, itemViewingLocation, moveDuration, delay, stopInteractionsBox, isSelcted, VanillaRigidBody, VanillaUIPanel);
  

//        strawberry.item.SetActive(true);
//        chocolate.item.SetActive(true);
//        oreo.item.SetActive(true);
//        vanilla.item.SetActive(true);


//        LeanTween.scale(strawberry.item, new Vector3(0f, 0f, 0f), 0f).setEase(LeanTweenType.easeInOutSine);
//        LeanTween.scale(chocolate.item, new Vector3(0f, 0f, 0f), 0f).setEase(LeanTweenType.easeInOutSine);
//        LeanTween.scale(oreo.item, new Vector3(0f, 0f, 0f), 0f).setEase(LeanTweenType.easeInOutSine);
//        LeanTween.scale(vanilla.item, new Vector3(0f, 0f, 0f), 0f).setEase(LeanTweenType.easeInOutSine);
  
//    }

//    void Start()
//    {
//        CameraPanel.showPanel(CameraPanel.itemUIPanel);

//        LeanTween.scale(strawberry.item, new Vector3(.2f, .2f, .2f), 3f).setEase(LeanTweenType.easeInOutSine);
//        LeanTween.scale(chocolate.item, new Vector3(0.2f, .2f, 0.2f), 3f).setEase(LeanTweenType.easeInOutSine);
//        LeanTween.scale(oreo.item, new Vector3(.2f, .2f, .2f), 3f).setEase(LeanTweenType.easeInOutSine);
//        LeanTween.scale(vanilla.item, new Vector3(.2f, .2f, .2f), 3f).setEase(LeanTweenType.easeInOutSine);
    
//        //burgers.startRotationTween(burgers.item);
//        //coldFoods.startRotationTween(coldFoods.item);
//        //burgers.startRotationTween(burgers.item);
//        //coldFoods.startRotationTween(coldFoods.item);
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
//                        case "Strawberry":
//                            strawberry.selectItem(strawberry.item, strawberry.itemOrigin, itemViewingLocation, stopInteractionsBox, moveDuration, delay, StrawberryRigidBody);
//                            CameraPanel.showPanel(CameraPanel.itemUIPanel);
//                            CameraPanel.changeItemDetails(itemTitle, strawberry.itemTitleString, itemDescription, strawberry.itemDescriptionString, itemPrice, strawberry.itemPriceString);

//                            chocolate.cancleAllTweens(chocolate.item, chocolate.itemOrigin);
//                            chocolate.dismissItem(chocolate.item, chocolate.itemOrigin, moveDuration / 2, .2f);
//                            oreo.cancleAllTweens(oreo.item, oreo.itemOrigin);
//                            oreo.dismissItem(oreo.item, oreo.itemOrigin, moveDuration / 2, .2f);
//                            vanilla.cancleAllTweens(vanilla.item, vanilla.itemOrigin);
//                            vanilla.dismissItem(vanilla.item, vanilla.itemOrigin, moveDuration / 2, .2f);

//                            break;

//                        case "Choclate":
//                            chocolate.selectItem(chocolate.item, chocolate.itemOrigin, itemViewingLocation, stopInteractionsBox, moveDuration, delay, ChocolateRigidBody);
//                            CameraPanel.showPanel(CameraPanel.itemUIPanel);
//                            CameraPanel.changeItemDetails(itemTitle, chocolate.itemTitleString, itemDescription, chocolate.itemDescriptionString, itemPrice, chocolate.itemPriceString);

//                            strawberry.cancleAllTweens(strawberry.item, strawberry.itemOrigin);
//                            strawberry.dismissItem(strawberry.item, strawberry.itemOrigin, moveDuration / 2, .2f);
//                            oreo.cancleAllTweens(oreo.item, oreo.itemOrigin);
//                            oreo.dismissItem(oreo.item, oreo.itemOrigin, moveDuration / 2, .2f);
//                            vanilla.cancleAllTweens(vanilla.item, vanilla.itemOrigin);
//                            vanilla.dismissItem(vanilla.item, vanilla.itemOrigin, moveDuration / 2, .2f);
       
//                            break;


//                        case "Oreo":
//                            oreo.selectItem(oreo.item, oreo.itemOrigin, itemViewingLocation, stopInteractionsBox, moveDuration, delay, OreoRigidBody);
//                            CameraPanel.showPanel(CameraPanel.itemUIPanel);
//                            CameraPanel.changeItemDetails(itemTitle, oreo.itemTitleString, itemDescription, oreo.itemDescriptionString, itemPrice, oreo.itemPriceString);

//                            chocolate.cancleAllTweens(chocolate.item, chocolate.itemOrigin);
//                            chocolate.dismissItem(chocolate.item, chocolate.itemOrigin, moveDuration, .2f);
//                            strawberry.cancleAllTweens(strawberry.item, strawberry.itemOrigin);
//                            strawberry.dismissItem(strawberry.item, strawberry.itemOrigin, moveDuration / 2, .2f);
//                            vanilla.cancleAllTweens(vanilla.item, vanilla.itemOrigin);
//                            vanilla.dismissItem(vanilla.item, vanilla.itemOrigin, moveDuration / 2, .2f);

//                            break;

//                        case "Vanilla":
//                            vanilla.selectItem(vanilla.item, vanilla.itemOrigin, itemViewingLocation, stopInteractionsBox, moveDuration, delay, VanillaRigidBody);
//                            CameraPanel.showPanel(CameraPanel.itemUIPanel);
//                            CameraPanel.changeItemDetails(itemTitle, vanilla.itemTitleString, itemDescription, vanilla.itemDescriptionString, itemPrice, vanilla.itemPriceString);

//                            oreo.cancleAllTweens(oreo.item, oreo.itemOrigin);
//                            oreo.dismissItem(oreo.item, oreo.itemOrigin, moveDuration / 2, .2f);
//                            chocolate.cancleAllTweens(chocolate.item, chocolate.itemOrigin);
//                            chocolate.dismissItem(chocolate.item, chocolate.itemOrigin, moveDuration, .2f);
//                            strawberry.cancleAllTweens(strawberry.item, strawberry.itemOrigin);
//                            strawberry.dismissItem(strawberry.item, strawberry.itemOrigin, moveDuration / 2, .2f);
    
//                            break;

//                        case "ReturnBox":
//                            resetAll();
//                            strawberry.dismissItem(strawberry.item, strawberry.itemOrigin, moveDuration / 2, .2f);
//                            chocolate.dismissItem(chocolate.item, chocolate.itemOrigin, moveDuration / 2, .2f);
//                            oreo.dismissItem(oreo.item, oreo.itemOrigin, moveDuration / 2, .2f);
//                            vanilla.dismissItem(vanilla.item, vanilla.itemOrigin, moveDuration / 2, .2f);
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
//                        case "Strawberry":
//                            if (strawberry.item.transform.position.z != itemViewingLocation.transform.position.z)
//                            {
//                                return;
//                            }
//                            else
//                            {
//                                strawberry.stopRotationTween(strawberry.item);
//                                strawberry.item.transform.Rotate(touch.deltaPosition.y * mobileRotationSpeed, -touch.deltaPosition.x * mobileRotationSpeed, 0, Space.World);
//                            }
//                            break;

//                        case "Choclate":
//                            if (chocolate.item.transform.position.z != itemViewingLocation.transform.position.z)
//                            {
//                                return;
//                            }
//                            else
//                            {
//                                chocolate.stopRotationTween(chocolate.item);
//                                chocolate.item.transform.Rotate(touch.deltaPosition.y * mobileRotationSpeed, -touch.deltaPosition.x * mobileRotationSpeed, 0, Space.World);
//                            }
//                            break;

//                        case "Oreo":
//                            if (oreo.item.transform.position.z != itemViewingLocation.transform.position.z)
//                            {
//                                return;
//                            }
//                            else
//                            {
//                                oreo.stopRotationTween(oreo.item);
//                                oreo.item.transform.Rotate(touch.deltaPosition.y * mobileRotationSpeed, -touch.deltaPosition.x * mobileRotationSpeed, 0, Space.World);
//                            }
//                            break;

//                        case "Vanilla":
//                            if (vanilla.item.transform.position.z != itemViewingLocation.transform.position.z)
//                            {
//                                return;
//                            }
//                            else
//                            {
//                                vanilla.stopRotationTween(vanilla.item);
//                                vanilla.item.transform.Rotate(touch.deltaPosition.y * mobileRotationSpeed, -touch.deltaPosition.x * mobileRotationSpeed, 0, Space.World);
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
//        strawberry.cancleAllTweens(strawberry.item, strawberry.itemOrigin);
//        chocolate.cancleAllTweens(chocolate.item, chocolate.itemOrigin);
//        oreo.cancleAllTweens(oreo.item, oreo.itemOrigin);
//        vanilla.cancleAllTweens(vanilla.item, vanilla.itemOrigin);
//    }


//    public void hidePanel2()
//    {
//        CameraPanel.hidePanel(CameraPanel.itemUIPanel);
//    }

//}