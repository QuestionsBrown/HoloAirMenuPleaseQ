using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.ARKit;
using UnityEngine.EventSystems;
using TMPro;
using System;
//using GG.Infrastructure.Utils.Swipe;


public class StartAnimation : MonoBehaviour
{


    //AR CAM & SESSION
    [SerializeField] ARSession arsession;
    [SerializeField] Camera arCamera;

    //ART/CONTAINERS/POSITIONS
    [SerializeField] private GameObject item_1;
    [SerializeField] private GameObject item_2;


    //ORIGIN POSITIONS
    [SerializeField] private GameObject itemOrigin_1;
    [SerializeField] private GameObject itemOrigin_2;
    [SerializeField] private GameObject artViewingLocation;
    [SerializeField] private GameObject returnBox;


    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] private TextMeshProUGUI itemDescription;
    [SerializeField] private TextMeshProUGUI itemPrice;


    [SerializeField] private TextMeshProUGUI pageTitle;
    [SerializeField] private TextMeshProUGUI veganCaption;
    [SerializeField] private TextMeshProUGUI onBoardingDirections;

    //TWEENS
    LTDescr moveTween1 = null;
    LTDescr moveTween2 = null;
    LTDescr moveBackTween1 = null;
    LTDescr moveBackTween2 = null;
    LTDescr rotateTween1 = null;
    LTDescr rotateTween2 = null;
    LTDescr rotateBackTween1 = null;
    LTDescr rotateBackTween2 = null;
    LTDescr stopRotateTween1 = null;
    LTDescr stopRotateTween2 = null;


    //TWEEN IDS
    int moveIDStart1;
    int stopRotateID1;
    int rotateBackIDStart1;
    int rotateIDStart1;
    int moveBackIDStart1;
    int moveIDStart2;
    int moveBackIDStart2;
    int rotateIDStart2;
    int rotateBackIDStart2;
    int stopRotateID2;




    //TWEEN TWEAKS
    [SerializeField] private float moveDuration;
    [SerializeField] private float delay;
    [SerializeField] private float MobileRotationSpeed = 0.4f;


    //RayCast String
    string hitName;

    //SWIPE PLUGIN
    //[SerializeField] private SwipeListener swipeListner;

    //TOUCH CONTROLS
    bool isrotating1Bool = false;
    bool isrotating2Bool = false;

    bool panelIsHidden = true;


    private void Awake()
    {
        //download item details fromfb
        hideAllItems(item_1, item_2);
        hidePanel();


    }

    void Start()
    {
        unhideAllItems(item_1, item_2);
        initRotationTween1(item_1);
        rotateTween1.resume();

        initRotationTween2(item_2);
        rotateTween2.resume();

        //set item detail references as downlaoded values right off bat and parent stuff 
        //LeanTween.scale(itemPanel, new Vector3(1f, 1f, 1f), 3f).setEase(LeanTweenType.easeInOutSine);
    }


    void Update()
    {
        // get the user touch input
        foreach (Touch touch in Input.touches)
        {
            Ray camRay = arCamera.ScreenPointToRay(touch.position);
            RaycastHit raycastHit;
            if (Physics.Raycast(camRay, out raycastHit, 10))
            {
                hideOnboarding();
                hitName = raycastHit.transform.tag;

                if (touch.phase == TouchPhase.Began)
                {
                    switch (hitName)
                    {
                        case "TestArt":
                            selectItem_1(item_1, itemOrigin_1, item_2, itemOrigin_2);

                            break;

                        case "TestArt2":
                            selectItem_2(item_2, itemOrigin_2, item_1, itemOrigin_1);
                            break;

                        case "ReturnBox":
                            dismissItem_2(item_2, itemOrigin_2.transform.position, moveDuration);
                            dismissItem_1(item_1, itemOrigin_1.transform.position, moveDuration);
                            break;

                        default:
                            return;
                    }
                }

                 if (touch.phase == TouchPhase.Moved)
                {
                  
                    switch (hitName)
                    {
                        case "TestArt":

                            if (item_1.transform.position.z == artViewingLocation.transform.position.z)
                            {
                                return;
                            }
                            else
                            {
                                stopRotatingItem_1(item_1);
                                item_1.transform.Rotate(touch.deltaPosition.y * MobileRotationSpeed, -touch.deltaPosition.x * MobileRotationSpeed, 0, Space.World);
                            }
                            break;

                        case "TestArt2":

                            if (item_2.transform.position.z == artViewingLocation.transform.position.z)
                            {
                                return;
                            }
                            else 
                            {
                                stopRotatingItem_2(item_2);
                                item_2.transform.Rotate(touch.deltaPosition.y * MobileRotationSpeed, -touch.deltaPosition.x * MobileRotationSpeed, 0, Space.World);
                            }
                            break;
                        default:
                            return;
                    }
                }

            }
        }
    }



    //SELECT ITEM
    public void selectItem_1(GameObject gameObject1, GameObject artOrigin1, GameObject gameObject2, GameObject itemOrigin2)
    {
        originCheck1(gameObject1, artOrigin1, gameObject2, itemOrigin2);
        middleCheck1(gameObject1, artOrigin1);
        viewCheck1(gameObject1);

    }

    public void selectItem_2(GameObject gameObject2, GameObject artOrigin2, GameObject gameObject1, GameObject itemOrigin1)
    {
        originCheck2(gameObject2, artOrigin2, gameObject1, itemOrigin1);
        middleCheck2(gameObject2, artOrigin2);
        viewCheck2(gameObject2);
    }



    //ORIGIN VECTOR3 CHECK
    private void originCheck1(GameObject gameObject1, GameObject artOrigin1, GameObject gameObject2, GameObject itemOrigin2)
    {
        if (gameObject1.transform.position.z == artOrigin1.transform.position.z)
        {
            dismissItem_2(gameObject2, itemOrigin2.transform.position, moveDuration);
            viewItem_1(gameObject1, artViewingLocation.transform.position, moveDuration, delay);
        }

    }

    private void originCheck2(GameObject gameObject2, GameObject artOrigin2, GameObject gameObject1, GameObject itemOrigin1)
    {
        if (gameObject2.transform.position.z == artOrigin2.transform.position.z)
        {
            dismissItem_1(gameObject1, itemOrigin1.transform.position, moveDuration);
            viewItem_2(gameObject2, artViewingLocation.transform.position, moveDuration, delay);
        }
    }


    //MIDDLE VECTOR3 CHECK
    private void middleCheck1(GameObject gameObject1, GameObject artOrigin1)
    {
        Debug.Log("Middle Check");
        if (gameObject1.transform.position.z != artOrigin1.transform.position.z && gameObject1.transform.position != artViewingLocation.transform.position)
        {

        }
    }
    private void middleCheck2(GameObject gameObject2, GameObject artOrigin2)
    {
        if (gameObject2.transform.position.z != artOrigin2.transform.position.z && gameObject2.transform.position != artViewingLocation.transform.position)
        {

        }
    }


    //VIEW VECTOR3 CHECK
    private void viewCheck1(GameObject gameObject1)
    {
        if (gameObject1.transform.position.z == artViewingLocation.transform.position.z)
        { 
            checkRotate1(gameObject1);
        }
    }

    private void viewCheck2(GameObject gameObject2)
    {
        if (gameObject2.transform.position.z == artViewingLocation.transform.position.z)
        {
            checkRotate2(gameObject2);
        }
    }


    //MOVE ITEMS FUNCTION
    public void viewItem_1(GameObject gameObject1, Vector3 vector3, float moveDuration, float delay)
    {
        pageTitle.text = "Entres";
        itemName.text = "Honey Glaze Pork Kabak";
        itemDescription.text = "pork ribeye, homemade honey glaze";
        itemPrice.text = "$25 Per";

        initMoveTween1(gameObject1, vector3, moveDuration, delay);
        moveTween1.resume();
        initRotationTween1(gameObject1);
        rotateTween1.resume();
        isrotating1Bool = true;
    }

    public void viewItem_2(GameObject gameObject2, Vector3 vector3, float moveDuration, float delay)
    {

        pageTitle.text = "Pastries";
        itemName.text = "Sweet Carolina Cheeseckae";
        itemDescription.text = "starwberry vanilla cheeskcake, whiped creme, plumb toppings ";
        itemPrice.text = "$15";

        initMoveTween2(gameObject2, vector3, moveDuration, delay);
        moveTween2.resume();
        initRotationTween2(gameObject2);
        rotateTween2.resume();
        isrotating2Bool = true;
    }


    //DISMISS ITEMS FUNCTION
    public void dismissItem_1(GameObject gameObject1, Vector3 itemOrigin1, float moveDuration)
    {
        hidePanel();
        LeanTween.cancel(moveIDStart1);
        LeanTween.cancel(rotateBackIDStart1);
        initRotationTween1(gameObject1);
        initMoveBackTween1(gameObject1, itemOrigin1, moveDuration);
        moveBackTween1.resume();
        initRotateBackTween1(gameObject1, moveDuration);
        rotateBackTween1.resume();
        LeanTween.scale(gameObject1, new Vector3(0.2f, 0.2f, 0.2f), moveDuration).setEase(LeanTweenType.easeInOutBack);


    }


    public void dismissItem_2(GameObject gameObject2, Vector3 vector3, float moveDuration)
    {
        hidePanel();
        LeanTween.cancel(moveIDStart2);
        LeanTween.cancel(rotateBackIDStart2);
        initRotationTween2(gameObject2);
        rotateTween2.pause();
        initMoveBackTween2(gameObject2, vector3, moveDuration);
        moveBackTween2.resume();
        initRotateBackTween2(gameObject2, moveDuration);
        rotateBackTween2.resume();
        LeanTween.scale(gameObject2, new Vector3(0.2f, 0.2f, 0.2f), moveDuration).setEase(LeanTweenType.easeInOutBack);
    }



        //START ROTATE FUNCTION
        public void checkRotate1(GameObject gameObject1)
    {
        if (isrotating1Bool == false)
        {
            initRotationTween1(gameObject1);
            rotateTween1.resume();
            isrotating1Bool = true;
        }

        else if (isrotating1Bool == true)
        {
            stopRotatingItem_1(gameObject1);
        }
    }

    public void checkRotate2(GameObject gameObject2)
    {
        if (isrotating2Bool == false)
        {
            initRotationTween2(gameObject2);
            rotateTween2.resume();
            isrotating2Bool = true;
        }

        else if (isrotating2Bool == true)
        {
            stopRotatingItem_2(gameObject2);
        }
    }

    //STOP ROTATE FUNCTION
    public void stopRotatingItem_1(GameObject gameobject1)
    {
        if (isrotating1Bool == true)
        {
            stopRotationTween1(gameobject1);

            isrotating1Bool = false;
        }
        else isrotating1Bool = true;
    }


    //STOP ROTATE FUNCTION
    public void stopRotatingItem_2(GameObject gameobject2)
    {
        if (isrotating2Bool == true)
        {
            stopRotationTween2(gameobject2);

            isrotating2Bool = false;
        }
        else isrotating2Bool = true;
    }



    //INIT MOVE TWEENS
    private void initMoveTween1(GameObject gameobject1, Vector3 vector3, float speed, float delay)
    {
        LeanTween.cancel(moveIDStart1);
        int moveID = LeanTween.move(gameobject1, vector3, speed).setEaseInOutQuad().setDelay(delay).id;
        moveIDStart1 = moveID;
        moveTween1 = LeanTween.descr(moveIDStart1);
        moveTween1.pause();
    }

    private void initMoveTween2(GameObject gameobject2, Vector3 vector3, float speed, float delay)
    {
        LeanTween.cancel(moveIDStart2);
        int moveID2 = LeanTween.move(gameobject2, vector3, speed).setEaseInOutSine().setDelay(delay).id;
        moveIDStart2 = moveID2;
        moveTween2 = LeanTween.descr(moveIDStart2);
        moveTween2.pause();
    }


    //INIT MOVEBACK TWEENs
    private void initMoveBackTween1(GameObject gameobject1, Vector3 vector3, float speed)
    {
        LeanTween.cancel(moveBackIDStart1);
        int resetID1 = LeanTween.move(gameobject1, vector3, speed).setEaseInOutSine().id;
        moveBackIDStart1 = resetID1;
        moveBackTween1 = LeanTween.descr(moveBackIDStart1);
        moveBackTween1.pause();
    }

    private void initMoveBackTween2(GameObject gameobject2, Vector3 vector3, float speed)
    {
        LeanTween.cancel(moveBackIDStart2);
        int resetID2 = LeanTween.move(gameobject2, vector3, speed).setEaseInOutSine().id;
        moveBackIDStart2 = resetID2;
        moveBackTween2 = LeanTween.descr(moveBackIDStart2);
        moveBackTween2.pause();
    }


    private void initRotateBackTween1(GameObject gameObject1, float moveDuration)
    {
        LeanTween.cancel(rotateBackIDStart1);
        int BackIDStart1 = LeanTween.rotateLocal(gameObject1, new Vector3(0, 0, 0), moveDuration).setEaseInOutBack().id;
        rotateBackTween1 = LeanTween.descr(BackIDStart1);
        rotateBackTween1.pause();
    }

    private void initRotateBackTween2(GameObject gameObject2, float moveDuration)
    {
        LeanTween.cancel(rotateBackIDStart2);
        int BackIDStart2 = LeanTween.rotateLocal(gameObject2, new Vector3(0, 0, 0), moveDuration).setEaseInOutBack().id;
        rotateBackTween2 = LeanTween.descr(BackIDStart2);
        rotateBackTween2.pause();
    }



    //INIT ROTATE TWEENS
    private void initRotationTween1(GameObject gameobject1)
    {
        LeanTween.cancel(rotateIDStart1);
        int rotateID1 = LeanTween.rotateAround(gameobject1, Vector3.up, 360, 10).setLoopClamp(-1).id;
        rotateIDStart1 = rotateID1;
        rotateTween1 = LeanTween.descr(rotateIDStart1);
        rotateTween1.pause();
    }
    private void initRotationTween2(GameObject gameobject2)
    {
        LeanTween.cancel(rotateIDStart2);
        int resetRotationID2 = LeanTween.rotateAround(gameobject2, Vector3.up, 360, 10).setLoopClamp(-1).id;
        rotateIDStart2 = resetRotationID2;
        rotateTween2 = LeanTween.descr(rotateIDStart2);
        rotateTween2.pause();
    }


    private void stopRotationTween1(GameObject gameobject1)
    {
        LeanTween.cancel(rotateIDStart1);
        int stopRotateeID1 = LeanTween.rotateAround(gameobject1, Vector3.up, 0, 0).setEaseInOutSine().setLoopClamp(0).id;
        stopRotateID1 = stopRotateeID1;
        stopRotateTween1 = LeanTween.descr(stopRotateID1);
        stopRotateTween1.resume();
    }


    //INIT STOP ROTATE TWEENS
    private void stopRotationTween2(GameObject gameobject2)
    {
        LeanTween.cancel(rotateIDStart2);
        int stopRotateeID2 = LeanTween.rotateAround(gameobject2, Vector3.up, 0, 0).setEaseInOutSine().setLoopClamp(0).id;
        stopRotateID2 = stopRotateeID2;
        stopRotateTween2 = LeanTween.descr(stopRotateID2);
        stopRotateTween2.resume();
    }

    public void hideAllItems(GameObject gameObject1, GameObject gameObject2)
    {
        LeanTween.scale(gameObject1, new Vector3(0f, 0f, 0f), 0f).setEase(LeanTweenType.easeInOutSine);
        LeanTween.scale(gameObject2, new Vector3(0f, 0f, 0f), 0f).setEase(LeanTweenType.easeInOutSine);
}


    public void unhideAllItems(GameObject gameObject1, GameObject gameObject2)
    {
        LeanTween.scale(gameObject1, new Vector3(.2f, .2f, .2f), 4f).setEase(LeanTweenType.easeInOutSine);
        LeanTween.scale(gameObject2, new Vector3(.2f, .2f, .2f), 4f).setEase(LeanTweenType.easeInOutSine);
    }



    public void hidePanel()
    {
        itemName.text = "";
        itemDescription.text = " ";
        itemPrice.text = "";
    }


    public void hideOnboarding()
    {
        onBoardingDirections.text = "";

    }


    public void resetARSession(float waitTime)
    {
        arsession.Reset();
        Debug.Log("Arsession Restarted Late");
    }
}








//public void hidePanel()
//{
//    itemName.text = "";
//    itemDescription.text = " ";
//    itemPrice.text = "";

//    //if (panelIsHidden == false)
//    //{
//    //    LeanTween.scale(itemPanel, new Vector3(0f, 0f, 0f), 0.35f).setEase(LeanTweenType.easeInOutSine);
//    //    panelIsHidden = true;
//    //}
//    //else if (panelIsHidden == true)
//    //{
//    //    panelIsHidden = true;
//    //}
//}

//public void panelCheck()
//{
//    if (panelIsHidden == true)
//    {
//        LeanTween.scale(itemPanel, new Vector3(1f, 1f, 1f), 0.35f).setEase(LeanTweenType.easeInOutSine);
//        panelIsHidden = false;
//    }
//    else if (panelIsHidden == false)
//    {
//        hidePanel();
//    }
//}


//go in start
//posOffset = transform.position;


//go in update
//startFloatAnimation1(item_1);
//float y = Mathf.PingPong(Time.time * floatSpeed, 1) * 0.06f - 0.03f;
//item_1.transform.position = new Vector3(item_1.transform.position.x, y, item_2.transform.position.z);


//item_1.transform.Rotate(new Vector3(0f, Time.deltaTime * degreesPerSecond, 0f), Space.World);

// Float up/down with a Sin()
//tempPos = posOffset;
//tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;

//item_1.transform.transform.position = tempPos;
//LEVITATE TWEAKS
//public float degreesPerSecond = 10.0f;
//public float amplitude = 0.1f;
//public float frequency = 0.1f;

// Position Storage Variables
//Vector3 posOffset = new Vector3();
//Vector3 tempPos = new Vector3();


//NEW TOUCH NOT SWIPE
//[SerializeField] private float verticalTime = .6f;
//[SerializeField] private float verticalSpeed = .08f;

//public void startFloatAnimation1(GameObject gameObject1)
//{
//    StopCoroutine(Stop1(gameObject1));
//    StartCoroutine(Rise1(gameObject1));
//}

//public void stopFloatAnimation1(GameObject gameObject1)
//{
//    StopCoroutine(Rise1(gameObject1));
//    StartCoroutine(Stop1(gameObject1));
//}

//IEnumerator Rise1(GameObject gameObject1)
//{
//    float t = verticalTime;
//    while (t > 0f)
//    {
//        gameObject1.transform.Translate(gameObject1.transform.up * verticalSpeed * Time.deltaTime);
//        t -= Time.deltaTime;
//        yield return new WaitForEndOfFrame();
//    }
//    StartCoroutine(Fall1(gameObject1));
//}

//IEnumerator Fall1(GameObject gameObject1)
//{
//    float t = verticalTime;
//    while (t > 0f)
//    { 
//        gameObject1.transform.Translate(-gameObject1.transform.up * verticalSpeed * Time.deltaTime);
//        t -= Time.deltaTime;
//        yield return new WaitForEndOfFrame();
//    }
//    StartCoroutine(Rise1(gameObject1));
//}


//IEnumerator Stop1(GameObject gameObject1)
//{
//    float t = verticalTime;
//    while (t > 0f)
//    {
//        gameObject1.transform.Translate(-gameObject1.transform.up * 0);
//        t -= Time.deltaTime;
//        yield return new WaitForEndOfFrame();
//    }
//}


//ON SWIPE UP
//private void OnEnable()
//{
//    swipeListner.OnSwipe.AddListener(OnSwipe);
//}

//private void OnSwipe(string swipe)
//{
//    switch (swipe)
//    {

//        case "Up":
//            dismissItem_2(item_1, itemOrigin_1.transform.position, moveDuration);
//            dismissItem_1(item_2, itemOrigin_2.transform.position, moveDuration);
//            Debug.Log("Swipe Dismiss");
//            break;


//    }
//}

//private void OnDisable()
//{
//    swipeListner.OnSwipe.RemoveListener(OnSwipe);
//}



























//else if (touch.phase == TouchPhase.Ended && raycastHit.collider == null)
//{
//    Debug.Log("Touched Nothing");

//}







// if (gameObject1.transform.position.z == artViewingLocation.transform.position.z)
//{
//    //show firebase stats panel if shown hide
//    Debug.Log("At View Location Show Stats?");
//    return;

//}


// else if (gameObject1.transform.position.z == artOrigin1.transform.position.z)
//{
//    dismissItem_2(gameObject2, artOrigin2.transform.position, moveDuration);
//    viewItem_1(gameObject1, artViewingLocation.transform.position, moveDuration, delay);
//    Debug.Log("Move To View From Origin!");
//    return;
//}

//else if (gameObject1.transform.position.z != artOrigin1.transform.position.z && gameObject1.transform.position != artViewingLocation.transform.position)
//{
//    //dismissItem_1(gameObject1, artOrigin1.transform.position, moveDuration);
//    Debug.Log("In Middle Show Stats?");
//    return;
//} 

//void cancelMoveTo_1()
//{
//    LeanTween.cancel(moveIDStart1);

//}

//void pauseRotation_1()
//{
//    LeanTween.pause(rotateIDStart1);
//}


//void startRotation_1()
//{
//    LeanTween.resume(rotateIDStart1);
//}

//void cancelMoveTo_2()
//{
//    LeanTween.cancel(moveIDStart2);

//}


//void cancelMoveFrom_1()
//{
//    LeanTween.cancel(moveIDStart1);

//}

//void cancelMoveFrom_2()
//{
//    LeanTween.cancel(moveIDStart2);

//}

//void pauseMoveTo_1()
//{
//    LeanTween.pause(rotateIDStart1);
//}


//void pauseMoveTo_2()
//{
//    LeanTween.pause(rotateIDStart2);
//}

//void pauseRotation_2()
//{
//    LeanTween.pause(rotateIDStart2);
//}






//    //CANCEL ALL TWEENS
//    void cancelAllTweens1()
//{
//    LeanTween.cancel(moveIDStart1);
//    LeanTween.cancel(moveBackIDStart1);
//    LeanTween.cancel(rotateIDStart1);
//}


//void cancelAllTweens2()
//{
//    LeanTween.cancel(moveIDStart2);
//    LeanTween.cancel(moveBackIDStart2);
//    LeanTween.cancel(rotateIDStart2);
//}




////COLIDERS
//[SerializeField] Collider colider1;
//[SerializeField] Collider colider2;


//MORE TWEENS
//LTDescr resetRotationTween1 = null;
//LTDescr resetRotationTween2 = null;
//LTDescr fadeTween1 = null;
//LTDescr fadeTween2 = null;
//LTDescr fadeTween3 = null;
//LTDescr fadeOutTween1 = null;
//LTDescr fadeOutTween2 = null;
//LTDescr fadeOutTween3 = null;



//MORE TWEEN IDS
//int resetRotationIDStart1;
//int resetRotationIDStart2;

//int fadeInIDStart1;
//int fadeInIDStart2;

//int fadeOutIDStart1;
//int fadeOutIDStart2;

//ROTATION TWEAKS
//public float rotationspeed;
//public bool rotatStatus = false;
//public float rotatationAngel = 360;

////DragRotationTweaks
//public float dragRotationSpeed;
//public float dragRotationDamping;
//public float rotationVelocity;
//public bool _dragged;
//public float waitToUnhideDealy;


//void cancelTween1Move()
//{
//    LeanTween.cancel(moveIDStart1);
//}

//void cancelTween1Reset()
//{
//    LeanTween.cancel(resetIDStart1);
//}

//void cancelTween1Rotate()
//{
//    LeanTween.cancel(rotateIDStart1);
//}


//void cancelTweens2Move()
//{
//    LeanTween.cancel(moveIDStart2);
//}

//void cancelTweens2Reset()
//{
//    LeanTween.cancel(resetIDStart2);
//}

//void cancelTweens2Rotate()
//{
//    LeanTween.cancel(rotateIDStart2);
//}

//public void OnBeginDrag(PointerEventData eventData)
//{
//    throw new System.NotImplementedException();
//}

//public void OnDrag(PointerEventData eventData)
//{
//    throw new System.NotImplementedException();
//}

//public void OnEndDrag(PointerEventData eventData)
//{
//    throw new System.NotImplementedException();
//}

//public void OnScroll(PointerEventData eventData)
//{
//    throw new System.NotImplementedException();
//}





//Debug.Log("Touch phase began at: " + touch.position);
//}
//else if (touch.phase == TouchPhase.Moved)
//{
//    //Debug.Log("Touch phase Moved");
//    //transform.Rotate(touch.deltaPosition.y * MobileRotationSpeed,
//    //    -touch.deltaPosition.x * MobileRotationSpeed, 0, Space.World);
//}
//else if (touch.phase == TouchPhase.Ended)
//{
//    Debug.Log("Touch phase Ended");







//    void Update()
//    {
//        if (Input.GetMouseButtonDown(0))
//        {

//            Ray ray = arCamera.ScreenPointToRay(Input.mousePosition);
//    RaycastHit hit;
//            if (Physics.Raycast(ray, out hit))
//            {
//                hitName = hit.transform.tag;

//                switch (hitName)
//                {
//                    case "TestArt":
//                        selectItem_1(item_1, itemOrigin_1, item_2, itemOrigin_2);
//                        break;

//                    case "TestArt2":
//                        selectItem_2(item_2, itemOrigin_2, item_1, itemOrigin_1);
//                        break;
//                    default:
//                        return;
//                }
//            }

//            else if (hit.collider == null)
//{

//    dismissItem_2(item_1, itemOrigin_1.transform.position, moveDuration);
//    dismissItem_1(item_2, itemOrigin_2.transform.position, moveDuration);
//}

//            }

//        }






