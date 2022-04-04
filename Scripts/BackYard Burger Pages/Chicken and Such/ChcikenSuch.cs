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

//public class ChcikenSuch : MonoBehaviour
//{


//    #region ARSettings
//    [Header("ARSettings")]
//    //[HideInInspector]
//    [SerializeField] Camera arCamera;
//    //[HideInInspector]
//    [SerializeField] private GameObject itemViewingLocation;
//    //[HideInInspector]
//    [SerializeField] private GameObject stopInteractionsBox;

//    private float mobileRotationSpeed = 0.1f;
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
//    ItemRedo grilledHawiianChicken;
//    //ItemRedo whereArtThouRomeoBurgerDouble;
//    //ItemRedo romeoMacBurger;
//    //ItemRedo tobaccoRoadBurger;
//    //ItemRedo romeoSloppyBurger;
//    //ItemRedo romeoSloppyBurger;


//    private bool isSelcted1 = false;
//    private bool isSelcted2 = false;
//    private bool isSelcted3 = false;
//    private bool isSelcted4 = false;
//    private bool isSelcted5 = false;
//    #endregion Items




//    #region Item Details
//    [Header("Gilled Hawaiian Chicken")]
//    [SerializeField] private GameObject GilledHawaiianChicken;
//    [SerializeField] private GameObject GilledHawaiianChickenOrigin;
//    [SerializeField] private GameObject GilledHawaiianChickenUIPanel;
//    [SerializeField] private string GilledHawaiianChickenTitle;
//    [SerializeField] private string GilledHawaiianChickenDescription;
//    [SerializeField] private string GilledHawaiianChickenPrice;
//    [SerializeField] private Rigidbody GilledHawaiianChickenRigidBody;

//    //[Header("InOutBurger")]
//    //[SerializeField] private GameObject WhhereArtThouRomeoBurgerDouble;
//    //[SerializeField] private GameObject WhhereArtThouRomeoBurgerDoubleOrigin;
//    //[SerializeField] private string WhhereArtThouRomeoBurgerDoubleTitle;
//    //[SerializeField] private string WhhereArtThouRomeoBurgerDoubleDescription;
//    //[SerializeField] private string WhhereArtThouRomeoBurgerDoublePrice;


//    //[Header("French Stack Burger")]
//    //[SerializeField] private GameObject FrenchStackBurger;
//    //[SerializeField] private GameObject FrenchStackBurgerOrigin;
//    //[SerializeField] private string FrenchStackBurgerTitle;
//    //[SerializeField] private string FrenchStackBurgerDescription;
//    //[SerializeField] private string FrenchStackBurgerPrice;

//    //[Header("DoubleDeckerBurger")]
//    //[SerializeField] private GameObject DoubleDeckerBurger;
//    //[SerializeField] private GameObject DoubleDeckerBurgerOrigin;
//    //[SerializeField] private string DoubleDeckerBurgerTitle;
//    //[SerializeField] private string DoubleDeckerBurgerDescription;
//    //[SerializeField] private string DoubleDeckerBurgerPrice;


//    //[Header("Plain Burger")]
//    //[SerializeField] private GameObject PlainBurger;
//    //[SerializeField] private GameObject PlainBurgerOrigin;
//    //[SerializeField] private string PlainBurgerTitle;
//    //[SerializeField] private string PlainBurgerDescription;
//    //[SerializeField] private string PlainBurgerPrice;

//    #endregion Item Details


//    private void Awake()
//    {
//        //selectPage(0);

//        CameraPanel = new UIPanelGameObject(cameraUIPanel, itemTitle, titleString, itemDescription, descriptionString, itemPrice, priceString);

//        grilledHawiianChicken = new ItemRedo(GilledHawaiianChicken, GilledHawaiianChickenOrigin, GilledHawaiianChickenTitle, GilledHawaiianChickenDescription, GilledHawaiianChickenPrice, itemViewingLocation, moveDuration, delay, stopInteractionsBox, isSelcted1, GilledHawaiianChickenRigidBody, GilledHawaiianChickenUIPanel);
//        //whereArtThouRomeoBurgerDouble = new ItemRedo(WhhereArtThouRomeoBurgerDouble, WhhereArtThouRomeoBurgerDoubleOrigin, WhhereArtThouRomeoBurgerDoubleTitle, WhhereArtThouRomeoBurgerDoubleDescription, WhhereArtThouRomeoBurgerDoublePrice, itemViewingLocation, moveDuration, delay, stopInteractionsBox, isSelcted2);
//        //romeoMacBurger = new ItemRedo(FrenchStackBurger, FrenchStackBurgerOrigin, FrenchStackBurgerTitle, FrenchStackBurgerDescription, FrenchStackBurgerPrice, itemViewingLocation, moveDuration, delay, stopInteractionsBox, isSelcted3);
//        //romeoSloppyBurger = new ItemRedo(DoubleDeckerBurger, DoubleDeckerBurgerOrigin, DoubleDeckerBurgerTitle, DoubleDeckerBurgerDescription, DoubleDeckerBurgerPrice, itemViewingLocation, moveDuration, delay, stopInteractionsBox, isSelcted4);
//        //tobaccoRoadBurger = new ItemRedo(PlainBurger, PlainBurgerOrigin, PlainBurgerTitle, PlainBurgerDescription, PlainBurgerPrice, itemViewingLocation, moveDuration, delay, stopInteractionsBox, isSelcted5);

//        grilledHawiianChicken.item.SetActive(true);
//        //whereArtThouRomeoBurgerDouble.item.SetActive(true);
//        //romeoMacBurger.item.SetActive(true);
//        //tobaccoRoadBurger.item.SetActive(true);
//        //romeoSloppyBurger.item.SetActive(true);


//        LeanTween.scale(grilledHawiianChicken.item, new Vector3(0f, 0f, 0f), 0f).setEase(LeanTweenType.easeInOutSine);
//        //LeanTween.scale(whereArtThouRomeoBurgerDouble.item, new Vector3(0f, 0f, 0f), 0f).setEase(LeanTweenType.easeInOutSine);
//        //LeanTween.scale(romeoMacBurger.item, new Vector3(0f, 0f, 0f), 0f).setEase(LeanTweenType.easeInOutSine);
//        //LeanTween.scale(tobaccoRoadBurger.item, new Vector3(0f, 0f, 0f), 0f).setEase(LeanTweenType.easeInOutSine);
//        //LeanTween.scale(romeoSloppyBurger.item, new Vector3(0f, 0f, 0f), 0f).setEase(LeanTweenType.easeInOutSine);
//    }




//    // Start is called before the first frame update
//    void Start()
//    {
//        CameraPanel.showPanel(CameraPanel.itemUIPanel);

//        LeanTween.scale(grilledHawiianChicken.item, new Vector3(1f, 1f, 1f), 3f).setEase(LeanTweenType.easeInOutSine);
//        //LeanTween.scale(whereArtThouRomeoBurgerDouble.item, new Vector3(1f, 1f, 1f), 3f).setEase(LeanTweenType.easeInOutSine);
//        //LeanTween.scale(romeoMacBurger.item, new Vector3(1f, 1f, 1f), 3f).setEase(LeanTweenType.easeInOutSine);
//        //LeanTween.scale(tobaccoRoadBurger.item, new Vector3(1f, 1f, 1f), 3f).setEase(LeanTweenType.easeInOutSine);
//        //LeanTween.scale(romeoSloppyBurger.item, new Vector3(1f, 1f, 1f), 3f).setEase(LeanTweenType.easeInOutSine);

//        //burgers.startRotationTween(burgers.item);
//        //coldFoods.startRotationTween(coldFoods.item);
//        //burgers.startRotationTween(burgers.item);
//        //coldFoods.startRotationTween(coldFoods.item);
//    }

//    // Update is called once per frame
//    void Update()
//    {

//        foreach (Touch touch in Input.touches)
//        {
//            Ray camRay = arCamera.ScreenPointToRay(touch.position);
//            RaycastHit raycastHit;
//            if (Physics.Raycast(camRay, out raycastHit, 10))
//            {

//                hitName = raycastHit.transform.tag;


//                if (Input.touchCount > 0)
//                {
//                    Touch first = Input.GetTouch(0);
//                    if (first.phase == TouchPhase.Stationary)
//                    {

//                        switch (hitName)
//                        {
//                            case "Where Art Thou":
//                                //Application.OpenURL("https://backyardburgers.getbento.com/online-ordering/");
//                                Debug.Log("Double Tap");
//                                break;
//                            default:
//                                return;


//                        }

//                    }
//                }



//                if (touch.phase == TouchPhase.Began)
//                {

//                    if (EventSystem.current.IsPointerOverGameObject())
//                    {
//                        return;
//                    }

//                    switch (hitName)
//                    {
//                        case "grilledHawiianChicken":
//                            grilledHawiianChicken.selectItem(grilledHawiianChicken.item, grilledHawiianChicken.itemOrigin, itemViewingLocation, stopInteractionsBox, moveDuration, delay, GilledHawaiianChickenRigidBody);
//                            CameraPanel.showPanel(CameraPanel.itemUIPanel);
//                            CameraPanel.changeItemDetails(itemTitle, grilledHawiianChicken.itemTitleString, itemDescription, grilledHawiianChicken.itemDescriptionString, itemPrice, grilledHawiianChicken.itemPriceString);

//                            return;

//                        //whereArtThouRomeoBurgerDouble.cancleAllTweens(whereArtThouRomeoBurgerDouble.item, whereArtThouRomeoBurgerDouble.itemOrigin);
//                        //whereArtThouRomeoBurgerDouble.dismissItem(whereArtThouRomeoBurgerDouble.item, whereArtThouRomeoBurgerDouble.itemOrigin.transform.position, moveDuration / 2, 1f);
//                        //romeoMacBurger.cancleAllTweens(romeoMacBurger.item, romeoMacBurger.itemOrigin);
//                        //romeoMacBurger.dismissItem(romeoMacBurger.item, romeoMacBurger.itemOrigin.transform.position, moveDuration / 2, 1f);
//                        //tobaccoRoadBurger.cancleAllTweens(tobaccoRoadBurger.item, tobaccoRoadBurger.itemOrigin);
//                        //tobaccoRoadBurger.dismissItem(tobaccoRoadBurger.item, tobaccoRoadBurger.itemOrigin.transform.position, moveDuration / 2, 1f);
//                        //romeoSloppyBurger.cancleAllTweens(romeoSloppyBurger.item, romeoSloppyBurger.itemOrigin);
//                        //romeoSloppyBurger.dismissItem(romeoSloppyBurger.item, romeoSloppyBurger.itemOrigin.transform.position, moveDuration / 2, 1f);
//                        //break;

//                        //case "Where Art Thou 2":
//                        //    whereArtThouRomeoBurgerDouble.selectItem(whereArtThouRomeoBurgerDouble.item, whereArtThouRomeoBurgerDouble.itemOrigin.transform.position, itemViewingLocation, stopInteractionsBox, moveDuration, delay);
//                        //    CameraPanel.showPanel(CameraPanel.itemUIPanel);
//                        //    CameraPanel.changeItemDetails(itemTitle, whereArtThouRomeoBurgerDouble.itemTitleString, itemDescription, whereArtThouRomeoBurgerDouble.itemDescriptionString, itemPrice, whereArtThouRomeoBurgerDouble.itemPriceString);

//                        //    whereArtThouRomeoBurger.cancleAllTweens(whereArtThouRomeoBurger.item, whereArtThouRomeoBurger.itemOrigin);
//                        //    whereArtThouRomeoBurger.dismissItem(whereArtThouRomeoBurger.item, whereArtThouRomeoBurger.itemOrigin.transform.position, moveDuration / 2, 1f);
//                        //    romeoMacBurger.cancleAllTweens(romeoMacBurger.item, romeoMacBurger.itemOrigin);
//                        //    romeoMacBurger.dismissItem(romeoMacBurger.item, romeoMacBurger.itemOrigin.transform.position, moveDuration / 2, 1f);
//                        //    tobaccoRoadBurger.cancleAllTweens(tobaccoRoadBurger.item, tobaccoRoadBurger.itemOrigin);
//                        //    tobaccoRoadBurger.dismissItem(tobaccoRoadBurger.item, tobaccoRoadBurger.itemOrigin.transform.position, moveDuration / 2, 1f);
//                        //    romeoSloppyBurger.cancleAllTweens(romeoSloppyBurger.item, romeoSloppyBurger.itemOrigin);
//                        //    romeoSloppyBurger.dismissItem(romeoSloppyBurger.item, romeoSloppyBurger.itemOrigin.transform.position, moveDuration / 2, 1f);
//                        //    break;


//                        //case "Romeo Mac Burger":
//                        //    romeoMacBurger.selectItem(romeoMacBurger.item, romeoMacBurger.itemOrigin.transform.position, itemViewingLocation, stopInteractionsBox, moveDuration, delay);
//                        //    CameraPanel.showPanel(CameraPanel.itemUIPanel);
//                        //    CameraPanel.changeItemDetails(itemTitle, romeoMacBurger.itemTitleString, itemDescription, romeoMacBurger.itemDescriptionString, itemPrice, romeoMacBurger.itemPriceString);

//                        //    whereArtThouRomeoBurgerDouble.cancleAllTweens(whereArtThouRomeoBurgerDouble.item, whereArtThouRomeoBurgerDouble.itemOrigin);
//                        //    whereArtThouRomeoBurgerDouble.dismissItem(whereArtThouRomeoBurgerDouble.item, whereArtThouRomeoBurgerDouble.itemOrigin.transform.position, moveDuration, 1f);
//                        //    whereArtThouRomeoBurger.cancleAllTweens(whereArtThouRomeoBurger.item, whereArtThouRomeoBurger.itemOrigin);
//                        //    whereArtThouRomeoBurger.dismissItem(whereArtThouRomeoBurger.item, whereArtThouRomeoBurger.itemOrigin.transform.position, moveDuration / 2, 1f);
//                        //    tobaccoRoadBurger.cancleAllTweens(tobaccoRoadBurger.item, tobaccoRoadBurger.itemOrigin);
//                        //    tobaccoRoadBurger.dismissItem(tobaccoRoadBurger.item, tobaccoRoadBurger.itemOrigin.transform.position, moveDuration / 2, 1f);
//                        //    romeoSloppyBurger.cancleAllTweens(romeoSloppyBurger.item, romeoSloppyBurger.itemOrigin);
//                        //    romeoSloppyBurger.dismissItem(romeoSloppyBurger.item, romeoSloppyBurger.itemOrigin.transform.position, moveDuration / 2, 1f);
//                        //    break;

//                        //case "Tobacco Road Burger":
//                        //    tobaccoRoadBurger.selectItem(tobaccoRoadBurger.item, tobaccoRoadBurger.itemOrigin.transform.position, itemViewingLocation, stopInteractionsBox, moveDuration, delay);
//                        //    CameraPanel.showPanel(CameraPanel.itemUIPanel);
//                        //    CameraPanel.changeItemDetails(itemTitle, tobaccoRoadBurger.itemTitleString, itemDescription, tobaccoRoadBurger.itemDescriptionString, itemPrice, tobaccoRoadBurger.itemPriceString);

//                        //    romeoMacBurger.cancleAllTweens(romeoMacBurger.item, romeoMacBurger.itemOrigin);
//                        //    romeoMacBurger.dismissItem(romeoMacBurger.item, romeoMacBurger.itemOrigin.transform.position, moveDuration / 2, 1f);
//                        //    whereArtThouRomeoBurgerDouble.cancleAllTweens(whereArtThouRomeoBurgerDouble.item, whereArtThouRomeoBurgerDouble.itemOrigin);
//                        //    whereArtThouRomeoBurgerDouble.dismissItem(whereArtThouRomeoBurgerDouble.item, whereArtThouRomeoBurgerDouble.itemOrigin.transform.position, moveDuration, 1f);
//                        //    whereArtThouRomeoBurger.cancleAllTweens(whereArtThouRomeoBurger.item, whereArtThouRomeoBurger.itemOrigin);
//                        //    whereArtThouRomeoBurger.dismissItem(whereArtThouRomeoBurger.item, whereArtThouRomeoBurger.itemOrigin.transform.position, moveDuration / 2, 1f);
//                        //    romeoSloppyBurger.cancleAllTweens(romeoSloppyBurger.item, romeoSloppyBurger.itemOrigin);
//                        //    romeoSloppyBurger.dismissItem(romeoSloppyBurger.item, romeoSloppyBurger.itemOrigin.transform.position, moveDuration / 2, 1f);
//                        //    break;


//                        //case "Romeo Sloppy Joe Burger":
//                        //    romeoSloppyBurger.selectItem(romeoSloppyBurger.item, romeoSloppyBurger.itemOrigin.transform.position, itemViewingLocation, stopInteractionsBox, moveDuration, delay);
//                        //    CameraPanel.showPanel(CameraPanel.itemUIPanel);
//                        //    CameraPanel.changeItemDetails(itemTitle, romeoSloppyBurger.itemTitleString, itemDescription, romeoSloppyBurger.itemDescriptionString, itemPrice, romeoSloppyBurger.itemPriceString);



//                        //    tobaccoRoadBurger.cancleAllTweens(tobaccoRoadBurger.item, tobaccoRoadBurger.itemOrigin);
//                        //    tobaccoRoadBurger.dismissItem(tobaccoRoadBurger.item, tobaccoRoadBurger.itemOrigin.transform.position, moveDuration / 2, 1f);
//                        //    romeoMacBurger.cancleAllTweens(romeoMacBurger.item, romeoMacBurger.itemOrigin);
//                        //    romeoMacBurger.dismissItem(romeoMacBurger.item, romeoMacBurger.itemOrigin.transform.position, moveDuration / 2, 1f);
//                        //    whereArtThouRomeoBurgerDouble.cancleAllTweens(whereArtThouRomeoBurgerDouble.item, whereArtThouRomeoBurgerDouble.itemOrigin);
//                        //    whereArtThouRomeoBurgerDouble.dismissItem(whereArtThouRomeoBurgerDouble.item, whereArtThouRomeoBurgerDouble.itemOrigin.transform.position, moveDuration, 1f);
//                        //    whereArtThouRomeoBurger.cancleAllTweens(whereArtThouRomeoBurger.item, whereArtThouRomeoBurger.itemOrigin);
//                        //    whereArtThouRomeoBurger.dismissItem(whereArtThouRomeoBurger.item, whereArtThouRomeoBurger.itemOrigin.transform.position, moveDuration / 2, 1f);
//                        //    break;

//                        case "ReturnBox":
//                            resetAll();
//                            grilledHawiianChicken.dismissItem(grilledHawiianChicken.item, grilledHawiianChicken.itemOrigin, moveDuration / 2, 1f);
//                            //whereArtThouRomeoBurgerDouble.dismissItem(whereArtThouRomeoBurgerDouble.item, whereArtThouRomeoBurgerDouble.itemOrigin.transform.position, moveDuration / 2, 1f);
//                            //romeoMacBurger.dismissItem(romeoMacBurger.item, romeoMacBurger.itemOrigin.transform.position, moveDuration / 2, 1f);
//                            //tobaccoRoadBurger.dismissItem(tobaccoRoadBurger.item, tobaccoRoadBurger.itemOrigin.transform.position, moveDuration / 2, 1f);
//                            //romeoSloppyBurger.dismissItem(romeoSloppyBurger.item, romeoSloppyBurger.itemOrigin.transform.position, moveDuration / 2, 1f);
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
//                        case "grilledHawiianChicken":
//                            if (grilledHawiianChicken.item.transform.position.z != itemViewingLocation.transform.position.z)
//                            {
//                                return;
//                            }


//                            else
//                            {
//                                grilledHawiianChicken.stopRotationTween(grilledHawiianChicken.item);
//                                grilledHawiianChicken.item.transform.Rotate(touch.deltaPosition.y * mobileRotationSpeed, -touch.deltaPosition.x * mobileRotationSpeed, 0, Space.World);
//                            }
//                            break;

//                        //case "Where Art Thou 2":
//                        //    if (whereArtThouRomeoBurgerDouble.item.transform.position.z != itemViewingLocation.transform.position.z)
//                        //    {
//                        //        return;
//                        //    }
//                        //    else
//                        //    {
//                        //        whereArtThouRomeoBurgerDouble.stopRotatingItem(whereArtThouRomeoBurgerDouble.item);
//                        //        whereArtThouRomeoBurgerDouble.item.transform.Rotate(touch.deltaPosition.y * mobileRotationSpeed, -touch.deltaPosition.x * mobileRotationSpeed, 0, Space.World);
//                        //    }
//                        //    break;

//                        //case "Romeo Mac Burger":
//                        //    if (romeoMacBurger.item.transform.position.z != itemViewingLocation.transform.position.z)
//                        //    {
//                        //        return;
//                        //    }
//                        //    else
//                        //    {
//                        //        romeoMacBurger.stopRotatingItem(romeoMacBurger.item);
//                        //        romeoMacBurger.item.transform.Rotate(touch.deltaPosition.y * mobileRotationSpeed, -touch.deltaPosition.x * mobileRotationSpeed, 0, Space.World);
//                        //    }
//                        //    break;

//                        //case "Tobacco Road Burger":
//                        //    if (tobaccoRoadBurger.item.transform.position.z != itemViewingLocation.transform.position.z)
//                        //    {
//                        //        return;
//                        //    }
//                        //    else
//                        //    {
//                        //        tobaccoRoadBurger.stopRotatingItem(tobaccoRoadBurger.item);
//                        //        tobaccoRoadBurger.item.transform.Rotate(touch.deltaPosition.y * mobileRotationSpeed, -touch.deltaPosition.x * mobileRotationSpeed, 0, Space.World);
//                        //    }
//                        //    break;


//                        //case "Romeo Sloppy Joe Burger":
//                        //    if (romeoSloppyBurger.item.transform.position.z != itemViewingLocation.transform.position.z)
//                        //    {
//                        //        return;
//                        //    }
//                        //    else
//                        //    {
//                        //        romeoSloppyBurger.stopRotatingItem(romeoSloppyBurger.item);
//                        //        romeoSloppyBurger.item.transform.Rotate(touch.deltaPosition.y * mobileRotationSpeed, -touch.deltaPosition.x * mobileRotationSpeed, 0, Space.World);
//                        //    }
//                        //    break;
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
//        grilledHawiianChicken.cancleAllTweens(grilledHawiianChicken.item, grilledHawiianChicken.itemOrigin);
//        grilledHawiianChicken.item.gameObject.transform.position = GilledHawaiianChickenOrigin.gameObject.transform.position;
//        //lemonade.cancleAllTweens(lemonade.item, lemonade.itemOrigin);
//        //strawberrylemonade.cancleAllTweens(strawberrylemonade.item, strawberrylemonade.itemOrigin);
//        //water.cancleAllTweens(water.item, water.itemOrigin);
//    }


//    public void hidePanel2()
//    {
//        CameraPanel.hidePanel(CameraPanel.itemUIPanel);
//    }






//}











