 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.ARKit;
using UnityEngine.EventSystems;

public class ItemRedo: MonoBehaviour
{

    #region Item Properties
    //Selected Item
    public GameObject item { get; set; }
    public GameObject itemOrigin { get; set; }
    public GameObject itemViewingLocation { get; set; }
    public GameObject stopInteractionsBox { get; set; }
    public GameObject pageUI { get; set; }
    public Rigidbody rigidBody { get; set; }
    public bool isSelected { get; set; }


    public GameObject itemUIPanel { get; set; }
    public string itemTitleString { get; set; }
    public string itemDescriptionString { get; set; }
    public string itemPriceString { get; set; }

    public CanvasGroup canvasGroupTitle { get; set; }

    public TextMeshProUGUI textTitle { get; set; }

    public bool draggng { get; set; }

    #endregion Item Properties

    #region Item Tween Variables
    LTDescr moveTween1 = null;
    LTDescr moveBackTween1 = null;
    LTDescr rotateTween1 = null;
    LTDescr rotateBackTween1 = null;
    LTDescr stopRotateTween1 = null;

    int moveIDStart1;
    int stopRotateID1;
    int rotateBackIDStart1;
    int rotateIDStart1;
    int moveBackIDStart1;

    public float moveDuration { get; set; }
    public float delay { get; set; }
    bool isrotating1Bool = false;
    bool isFading = false;

    #endregion Item Tween Variables


    public ItemRedo(GameObject item,GameObject itemOrigin,string itemTitleString,string itemDescriptionString,string itemPriceString,GameObject itemViewingLocation,float moveDuration, float delay, GameObject stopInteractionsBox, bool isSelected,Rigidbody rigidBody, GameObject itemUIPanel, CanvasGroup canvasGroup, TextMeshProUGUI titleText)
    { 

        this.item = item;
        this.itemOrigin = itemOrigin;

        this.itemTitleString = itemTitleString;
        this.itemDescriptionString = itemDescriptionString;
        this.itemPriceString = itemPriceString;

        this.itemViewingLocation = itemViewingLocation;
        this.moveDuration = moveDuration;
        this.delay = delay;
        this.stopInteractionsBox = stopInteractionsBox;
        this.isSelected = isSelected;
        this.rigidBody = rigidBody;
        this.isSelected = false;
        this.itemUIPanel = itemUIPanel;
        this.textTitle = titleText;
        this.canvasGroupTitle = canvasGroup;
        //this.pageUI = pageUI;

    }



   public void fadeOutCanvas(GameObject itemUIPanel)
    {



        itemUIPanel.SetActive(false);

        //CameraPanel.itemTitle.text = "";


        //CameraPanel.itemDescription.text = "" +
        //    "" +
        //    "" +
        //    "";
        //CanvasGroup canvasGroup = canvasGroupTitle;

        //TextMeshProUGUI titleText = textTitle;

        //canvasGroup.alpha = 1;

        //LeanTween.alphaCanvas(canvasGroup, 1.0f, 1.0f).setDelay(.5f);

    }



    public void fadeInCanvas(GameObject itemUIPanel)
    {



        itemUIPanel.SetActive(true);
        //CanvasGroup canvasGroup = canvasGroupTitle;

        //TextMeshProUGUI titleText = textTitle;

        //canvasGroup.alpha = 1;

        //LeanTween.alphaCanvas(canvasGroup, 1.0f, 1.0f).setDelay(.5f);

    }



    public void selectItem(GameObject item, GameObject itemOrigin, GameObject itemViewingLocation, GameObject stopInteractionsBox, float moveDuration, float delay, Rigidbody itemRigidBody, GameObject itemUIPanel)
    {

        originCheck(item, itemViewingLocation, itemOrigin, stopInteractionsBox, moveDuration, delay, itemUIPanel);
        middleCheck(item, itemOrigin, itemViewingLocation);
        viewCheck(item, itemViewingLocation, itemRigidBody, itemOrigin);
    }
    private void originCheck(GameObject item, GameObject itemViewingLocation, GameObject itemOrigin, GameObject stopInteractionsBox, float moveDuration, float delay, GameObject itemUIPanel)
    {

        if (isSelected == false)
        {
            //itemUIPanel.transform.parent = null;
            viewItem(item, itemViewingLocation, stopInteractionsBox, moveDuration, delay, itemUIPanel);
        }

        else
        {
            return;
        }
    }
    private void middleCheck(GameObject item, GameObject itemOrigin, GameObject itemViewingLoaction)
    {
        if (isSelected == true)
        {

        }
    }
    private void viewCheck(GameObject item, GameObject itemViewingLocation, Rigidbody itemRigidBody, GameObject itemOrigin)
    {
        if (isSelected == true)
        {
            checkRotate(item, itemRigidBody, itemViewingLocation, itemOrigin);
        }
    }

    public void viewItem(GameObject item, GameObject itemViewingLocation, GameObject stopInteractionsBox, float moveDuration, float delay, GameObject itemUIPanel)
    {

        //LeanTween.scale(itemUIPanel, new Vector3(0f, 0f, 0f), .75f).setEase(LeanTweenType.easeInOutSine);
        fadeOutCanvas(itemUIPanel);
        startRotationTween(item);
        turnOffInteractions();
        initMoveTween(item, itemViewingLocation, moveDuration, delay);
        moveTween1.resume();
        isrotating1Bool = true;
        isSelected = true;
        moveTween1.setOnComplete(turnOnInteractions);

    }


    public void checkRotate(GameObject item, Rigidbody itemRigidBody, GameObject itemViewingLocation, GameObject itemOrigin)
    {


        //if (item_Ref.item.transform.position.z != item_Ref.itemOrigin.transform.position.z && draggng == true)


            if (isrotating1Bool == true && item.transform.position.z == itemViewingLocation.transform.position.z)
        {
            LeanTween.cancel(rotateIDStart1);
            stopRotationTween(item);
            //itemRigidBody.angularVelocity = Vector3.zero;
            Debug.Log("Stop Rotation");
        }

        else if (isrotating1Bool == false && item.transform.position.z != itemOrigin.transform.position.z)
        {
            LeanTween.cancel(stopRotateID1);
            startRotationTween(item);
            Debug.Log("Start Rotation");

        }
    }


    //public void stopRotatingItem(GameObject item)
    //{
    //    if (isrotating1Bool == true)
    //    {
    //        stopRotationTween(item);
    //        isrotating1Bool = false;
    //    }
    //}



    //public void startRotatingItem(GameObject item)
    //{
    //    if (isrotating1Bool == false)
    //    {
    //        startRotationTween(item);
    //        isrotating1Bool = true;
    //    }

    //}


    public void stopRotationTween(GameObject item)
    {
        LeanTween.cancel(rotateIDStart1);
        int stopRotateeID1 = LeanTween.rotateAroundLocal(item, Vector3.up, 0, 0).setEaseInOutSine().setLoopClamp(0).id;
        stopRotateID1 = stopRotateeID1;
        stopRotateTween1 = LeanTween.descr(stopRotateID1);
        stopRotateTween1.resume();
        isrotating1Bool = false;
    }
    public void startRotationTween(GameObject item)
    {
        LeanTween.cancel(rotateIDStart1);
        int rotateID1 = LeanTween.rotateAroundLocal(item, Vector3.up, 360, 12).setLoopClamp(0).setEase(LeanTweenType.easeInOutSine).id;
        rotateIDStart1 = rotateID1;
        rotateTween1 = LeanTween.descr(rotateIDStart1);
        rotateTween1.resume();
        isrotating1Bool = true;
    }


    public void initMoveBackTween(GameObject item, Vector3 itemOrigin, float moveDuration)
    {
        LeanTween.cancel(moveBackIDStart1);
        int resetID1 = LeanTween.move(item, itemOrigin, moveDuration).setEaseInOutSine().id;
        moveBackIDStart1 = resetID1;
        moveBackTween1 = LeanTween.descr(moveBackIDStart1);
        moveBackTween1.pause();
    }
    public void initRotationTween(GameObject item)
    {
        LeanTween.cancel(rotateIDStart1);
        int rotateID1 = LeanTween.rotateAroundLocal(item, Vector3.down, 360, 7).setEase(LeanTweenType.easeInOutSine).setLoopClamp(-1).id;
        rotateIDStart1 = rotateID1;
        rotateTween1 = LeanTween.descr(rotateIDStart1);
        rotateTween1.pause();
    }
    public void initRotateBackTween(GameObject item, float moveDuration)
    {
        LeanTween.cancel(rotateBackIDStart1);
        int BackIDStart1 = LeanTween.rotateLocal(item, new Vector3(0, 0, 0), moveDuration).setEaseInOutBack().id;
        rotateBackTween1 = LeanTween.descr(BackIDStart1);
        rotateBackTween1.pause();
    }


    public void initMoveTween(GameObject item, GameObject itemViewingLocation, float moveDuration, float delay)
    {
        LeanTween.cancel(moveIDStart1);
        int moveID = LeanTween.move(item, itemViewingLocation.transform.position, moveDuration).setEaseInOutQuad().setDelay(delay).id;
        moveIDStart1 = moveID;
        moveTween1 = LeanTween.descr(moveIDStart1);
        moveTween1.pause();
    }


    public void startDraggingItem(ItemRedo item_Ref, Touch touch, Rigidbody itemRefRigidbody)
    {
        if (item_Ref.item.transform.position.z != item_Ref.itemOrigin.transform.position.z && draggng == true)
        {
            item_Ref.stopRotationTween(item_Ref.item);
            float x = Input.GetAxis("Mouse X") * 300 * Time.fixedDeltaTime;
            float y = Input.GetAxis("Mouse Y") * 300 * Time.fixedDeltaTime;
            itemRefRigidbody.AddRelativeTorque(Vector3.down * x);

            return;
        }
    }


    //public void dismissItem(GameObject item, GameObject itemOrigin, float moveDuration, float scale, GameObject itemUIPanel)
    //{
    //    itemUIPanel.SetActive(true);

    //    if (isSelected == true)
    //    {
    //        //itemUIPanel.SetActive(true);
    //        //itemUIPanel.transform.SetParent(item.transform);

    //        //LeanTween.scale(itemUIPanel, new Vector3(1f, 1f, 1f), 0f).setEase(LeanTweenType.easeInOutSine);
    //        turnOffInteractions();
    //        LeanTween.cancel(rotateBackIDStart1);
    //        LeanTween.cancel(moveBackIDStart1);
    //        initMoveBackTween(item, itemOrigin.transform.position, moveDuration);
    //        moveBackTween1.resume();
    //        initRotateBackTween(item, 1.7f);
    //        rotateBackTween1.resume();
    //        LeanTween.scale(item, new Vector3(scale, scale, scale), moveDuration).setEase(LeanTweenType.easeInOutBack);
    //        isrotating1Bool = false;
    //        isSelected = false;
    //        setItemToItemOrigin();
    //        moveBackTween1.setOnComplete(turnOnInteractions);
    //    }

    //    else
    //    {
    //        return;
    //    }

    //}


    public void cancleAllTweens(GameObject item, GameObject itemOrigin, GameObject itemUIPanel)
    {
        LeanTween.cancel(rotateIDStart1);
        LeanTween.cancel(moveIDStart1);
        LeanTween.cancel(moveBackIDStart1);
        LeanTween.cancel(rotateBackIDStart1);
        LeanTween.cancel(stopRotateID1);



        //dismissItem(item, itemOrigin, moveDuration, 1, itemUIPanel);


        initMoveBackTween(item, itemOrigin.transform.position, .5f);
        moveBackTween1.resume();
        initRotateBackTween(item, .5f);
        rotateBackTween1.resume();
        moveBackTween1.setOnComplete(setItemToItemOrigin);
        isSelected = false;
        fadeInCanvas(itemUIPanel);
    }


    public void setItemToItemOrigin()
    {
        item.gameObject.transform.position = itemOrigin.transform.position;
    }


    public void turnOffInteractions()
    {
        stopInteractionsBox.transform.position = new Vector3(0, 0, 0.744f);
    }

    public void turnOnInteractions()
    {
        stopInteractionsBox.transform.position = new Vector3(0, 0, 2);
    }




}




//LeanTween.move(item, new Vector3(itemOrigin.gameObject.transform.position.x, itemOrigin.gameObject.transform.position.y, itemOrigin.gameObject.transform.position.z), .03f).setEase(LeanTweenType.easeInOutSine);
//LeanTween.rotateLocal(item, new Vector3(0, 0, 0), .3f);
//public void dismissItemSauce(GameObject item, GameObject itemOrigin, float moveDuration)
//{
//    if (item.transform.position.z != itemOrigin.gameObject.transform.position.z && item.transform.position != itemViewingLocation.transform.position)
//    {
//        return;
//    }

//    LeanTween.cancel(rotateBackIDStart1);
//    LeanTween.cancel(moveBackIDStart1);
//    initRotationTween(item);
//    initMoveBackTween(item, itemOrigin.gameObject.transform.position, moveDuration);
//    moveBackTween1.resume();
//    initRotateBackTween(item, 1.7f);
//    rotateBackTween1.resume();
//    LeanTween.scale(item, new Vector3(0.1f, 0.1f, 0.1f), moveDuration).setEase(LeanTweenType.easeInOutBack);
//    isrotating1Bool = true;

//}

//public GameObject itemUIPanel { get; set; }
//public UIPanelGameObject itemUIPanelInfo { get; set; }
//public TextMeshPro itemTitle { get; set; }
//public TextMeshPro itemDescription { get; set; }
//public TextMeshPro itemPrice { get; set; }
//public void initMoveTitle(GameObject itemTitle, Vector3 titleViewSpot, float moveDuration)
//{
//    LeanTween.cancel(moveTitleID);
//    int moveID = LeanTween.move(itemTitle, titleViewSpot, moveDuration).setEaseInOutQuad().setDelay(delay).id;
//    moveTitleTween = LeanTween.descr(moveID);
//    moveTitleTween.pause();
//}


//public void initMoveTitleBackTween(GameObject itemTitle, Vector3 titleOrigin, float moveDuration)
//{
//    LeanTween.cancel(moveTitleBackID);
//    int resetID1 = LeanTween.move(itemTitle, titleOrigin, moveDuration).setEaseInOutSine().id;
//    moveTitleBackID = resetID1;
//    moveTitleBackTween = LeanTween.descr(moveTitleBackID);
//    moveTitleBackTween.pause();
//}



//public void initMoveDescription(GameObject itemDescription, Vector3 descriptionViewSpot, float moveDuration)
//{
//    LeanTween.cancel(moveDescriptionID);
//    int moveID = LeanTween.move(itemDescription, descriptionViewSpot, moveDuration).setEaseInOutQuad().setDelay(delay).id;
//    moveDescriptionTween = LeanTween.descr(moveID);
//    moveDescriptionTween.pause();
//}



//public void initMoveDescriptionBackTween(GameObject itemDescription, Vector3 descriptionOrigin, float moveDuration)
//{
//    LeanTween.cancel(moveDescriptionBackID);
//    int resetID1 = LeanTween.move(itemDescription, descriptionOrigin, moveDuration).setEaseInOutSine().id;
//    moveDescriptionBackID = resetID1;
//    moveDescriptionBackTween = LeanTween.descr(moveDescriptionBackID);
//    moveDescriptionBackTween.pause();
//}



//public void initMovePrice(GameObject itemPrice, Vector3 priceViewSpot, float moveDuration)
//{
//    LeanTween.cancel(movePriceID);
//    int moveID = LeanTween.move(itemPrice, priceViewSpot, moveDuration).setEaseInOutQuad().setDelay(delay).id;
//    movePriceTween = LeanTween.descr(moveID);
//    movePriceTween.pause();
//}


//public void initMovePriceBackTween(GameObject itemPrice, Vector3 priceOrigin, float moveDuration)
//{
//    LeanTween.cancel(movePriceBackID);
//    int resetID1 = LeanTween.move(itemPrice, priceOrigin, moveDuration).setEaseInOutSine().id;
//    movePriceBackID = resetID1;
//    movePriceBackTween = LeanTween.descr(movePriceBackID);
//    movePriceBackTween.pause();
//}

//public GameObject itemPanel { get; set; }
//public Color itemColor { get; set; }
//public Renderer itemRenderer { get; set; }
//public TextMeshProUGUI itemName { get; set; }
//public TextMeshProUGUI description { get; set; }
//public TextMeshProUGUI price { get; set; }


//public void initFadeTitle(GameObject itemTitle)
//{
//    LeanTween.cancel(fadeTitleID);
//    int fadeID = LeanTween.alpha(itemTitle, 0, moveDuration).id;
//    fadeTitleTween = LeanTween.descr(fadeID);
//    fadeTitleTween.pause();
//}

//public void initFadeTitle(GameObject itemTitle)
//{
//    int fadeTitleID = LeanTween.alpha(itemTitle, 0, 2f).id;
//    LeanTween.cancel(fadeTitleID);
//    fadeTitleTween = LeanTween.descr(fadeTitleID);
//    fadeTitleTween.pause();

//}


//public void initFadeIn(GameObject itemTitle)
//{
//    isFading = true;
//    float time = 2.0f;
//    float alphaVal = 1.0f;
//    int fadeTitleID = LeanTween.alpha(itemTitle, alphaVal, time).id;
//    LeanTween.cancel(fadeTitleID);
//    fadeTitleTween = LeanTween.descr(fadeTitleID);
//    fadeTitleTween.pause();

//}


//public void setName(TextMeshProUGUI itemName)
//{



//}

//public string setName(TextMeshProUGUI itemName)
//{

//    pageRedo.itemName = itemName;


//    return itemName.text;
//}
//public void initMoveBackTween2(GameObject itemGameObjectLocal2, GameObject itemOrigin_2, float moveDuration)
//{
//    LeanTween.cancel(moveBackIDStart1);
//    int resetID2 = LeanTween.move(itemGameObjectLocal2, itemOrigin_2.transform.position, moveDuration).setEaseInOutSine().id;
//    moveBackIDStart2 = resetID2;
//    moveBackTween2 = LeanTween.descr(moveBackIDStart2);
//    moveBackTween2.pause();
//}


//public void initRotateBackTween2(GameObject itemGameObjectLocal2, float moveDuration)
//{
//    LeanTween.cancel(rotateBackIDStart2);
//    int BackIDStart2 = LeanTween.rotateLocal(itemGameObjectLocal2, new Vector3(0, 0, 0), moveDuration).setEaseInOutBack().id;
//    rotateBackTween2 = LeanTween.descr(BackIDStart2);
//    rotateBackTween2.pause();
//}



//public void localItemDescriptionUpdate()
//{
//    pageTitle.text "Page Title";
//    itemName.text = "name";
//    itemDescription.text = "Descritpion";
//    itemPrice.text = "Price";
//}




//Fields
//[SerializeField] private AssetReferenceGameObject item_1GOReferenceAsset;
//private AsyncOperationHandle<GameObject> handleItem;
//private GameObject itemGameObject;

//Debug.Log("Tapped Item");



//private void Start()
//{

//}

//public ItemRedo()
//{
//}




//public GameObject Item
//{
//    get
//    {
//        return itemGameObjectLocal1;
//    }
//}


//public GameObject ItemOrigin
//{
//    get
//    {
//        return itemOrigin_1;
//    }
//}

//public float MoveDuration
//{
//    get
//    {
//        return moveDuration;
//    }
//}

//public AssetReferenceGameObject AssetReferenceGameObject
//{
//    get
//    {
//        return item_1GOReferenceAsset;
//    }
//}



//public TextMeshProUGUI ItemName
//{
//    get
//    {
//        return itemName;
//    }
//}




//public TextMeshProUGUI ItemDescritpion
//{
//    get
//    {
//        return itemDescription;
//    }
//}

//public TextMeshProUGUI ItemPrice
//{
//    get
//    {

//        return itemPrice;
//    }
//}
//public string itemFBReference
//{
//    get
//    {
//        return itemFBReferenceName;
//    }
//}


//private void Awake()
//{ 

//    getObject();
//    DontDestroyOnLoad(gameObject);
//}



//public void getObject()
//{
//    StartCoroutine(DownloadObject());
//}


//IEnumerator DownloadObject()
//{
//    var downloadObject = Addressables.LoadAssetAsync<GameObject>(item_1GOReferenceAsset);
//    downloadObject.Completed += ObjectDownloadCompleted;
//    yield return null;

//}


//private void ObjectDownloadCompleted(AsyncOperationHandle<GameObject> handleItem) // ref to AysncHandel
//{
//    if (handleItem.Status == AsyncOperationStatus.Succeeded)
//    {
//        GameObject loadedItem = handleItem.Result;
//        itemGameObject = loadedItem;
//        itemGameObject.transform.SetParent(itemOrigin_1.transform);
//        //itemGameObject = Instantiate(loadedItem);
//        Debug.Log("We Downloaded Jaink");
//        //parent object
//        //StartCoroutine(UnloadObject());
//    }
//}


//public IEnumerator UnloadObject()
//{
//    yield return new WaitForSeconds(5);
//    Debug.Log("supposed to unload");
//    //Addressables.UnloadSceneAsync(handle, true)
//    //Addressables.Release(handleItem);
//}
//}




