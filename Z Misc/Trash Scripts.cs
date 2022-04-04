
//private void dismissArtLocal1(GameObject gameObject, Vector3 vector3)
//{
//    cancelAllTweens1();
//    initMoveBackTween1(gameObject, vector3, 0);
//    moveBackTween1.resume();
//    gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
//    //artViewingLocation.transform.eulerAngles = new Vector3(0, 0, 0);
//    //rotateTween.pause();

//    //gameObject.transform.SetParent(null);
//    //StartCoroutine(routine: disableColider1(gameObject, 0));
//}



//public void moveItem(GameObject gameObject, Vector3 vector3, float moveDuration)
//{
//    initMoveTween1(gameObject, vector3, moveDuration);
//    initRotationTween1(gameObject);
//    moveTween1.resume();
//    rotateTween.resume();


//    //initMoveBackTween1(artPeice1, artOriginssss1.transform.position, 0);
//    //moveBackTween1.resume();
//    //rotatStatus = true;
//    //gameObject.transform.SetParent(artViewingLocation.transform);
//    //dismissArtLocal1(artPeice1, artOriginssss1.transform.position);
//    //cancelTweens1();
//    //Debug.Log("Start Animation Move Forward With Delay");

//}


//public void StartAnimationn2(GameObject gameObject2, GameObject artOrigin2, GameObject gameObject1, GameObject artOrigin1)
//{
//    if (gameObject2.transform.position.z != artOrigin2.transform.position.z)
//    {
//        dismissArtLocal2(gameObject2, artOrigin2.transform.position);
//        //artViewingLocation.transform.eulerAngles = new Vector3(0, 0, 0);
//    }

//    else
//    {
//        moveItem(gameObject2, artViewingLocation.transform.position, moveDuration);
//        //dismissArtLocal1(gameObject1, artOrigin1.transform.position);
//    }
//}

//private IEnumerator viewArt1(GameObject gameObject, Vector3 vector3, float moveDuration, float waitTime)
//{

//    initMoveTween1(gameObject, vector3, moveDuration);
//    //initRotationTween(gameObject);
//    yield return new WaitForSeconds(waitTime / 2);
//    moveTween1.resume();
//    rotateTween.resume();


//    //cancelAllTweens2();

//    //initMoveBackTween2(artPeice2, artOriginssss2.transform.position, 0);
//    //moveBackTween2.resume();

//    //rotatStatus = true;

//    //gameObject.transform.SetParent(artViewingLocation.transform);

//    //dismissArtLocal2(artPeice2, artOriginssss2.transform.position);
//    //Debug.Log("Start Animation Move Forward With Delay & Move ");

//}


//public void dismissArtLocalAll()
//{
//    artPeice1.transform.SetParent(null);
//    cancelTweens1();
//    initMoveBackTween1(artPeice1, artOriginssss1.transform.position, 0);
//    resetTween1.resume();
//    rotateTween.pause();
//    artPeice1.transform.eulerAngles = new Vector3(0, 0, 0);

//    artPeice2.transform.SetParent(null);
//    cancelTweens2();
//    initMoveBackTween2(artPeice2, artOriginssss2.transform.position, 0);
//    resetTween2.resume();
//    rotateTween.pause();
//    artPeice2.transform.eulerAngles = new Vector3(0, 0, 0);
//    //StartCoroutine(routine: disableColider1(gameObject, 0));

//    Debug.Log("Swipe Detected");
//}



//void initStopRotationTween(GameObject gameobject)
//{
//    //int resetRotationID1 = LeanTween.rotateZ(gameobject, speed, time).setEaseInOutSine().setLoopClamp(1).id;
//    int resetRotationID2 = LeanTween.rotateAround(gameobject, Vector3.up, 360, 10).setEaseInOutSine().setLoopClamp(-1).id;
//    //int resetRotationID2 = LeanTween.rotateAroundLocal(gameobject, Vector3.up, 360, 10).setEaseInOutSine().id;
//    resetRotationIDStart2 = resetRotationID2;
//    rotateTween = LeanTween.descr(resetRotationIDStart2);
//    rotateTween.pause();
//}



//void initStopRotationTween2(GameObject gameobject)
//{
//    //int resetRotationID1 = LeanTween.rotateZ(gameobject, speed, time).setEaseInOutSine().setLoopClamp(1).id;
//    int resetRotationID2 = LeanTween.rotateAround(gameobject, Vector3.up, 360, 10).setEaseInOutSine().setLoopClamp(-1).id;
//    //int resetRotationID2 = LeanTween.rotateAroundLocal(gameobject, Vector3.up, 360, 10).setEaseInOutSine().id;
//    resetRotationIDStart2 = resetRotationID2;
//    rotateTween = LeanTween.descr(resetRotationIDStart2);
//    rotateTween.pause();
//}



//public void disableColider1(GameObject gameobject, float waitTime)
//{
//    colider1.enabled = false;

//}

//public void enableColider1(GameObject gameobject, float waitTime)
//{
//    colider1.enabled = true;
//}


//public void disableColider2(GameObject gameobject, float waitTime)
//{
//    colider2.enabled = false;
//}

//public void enableColider2(GameObject gameobject, float waitTime)
//{
//    colider2.enabled = true;
//}


//void initFadeIn1(GameObject gameObject, float alpha, float duration)
//{
//    int fadeID1 = LeanTween.alpha(gameObject, alpha, duration).id;
//    fadeTween1 = LeanTween.descr(fadeInIDStart1);
//    fadeTween1.pause();
//}



//void initFadeOut1(GameObject gameObject, float alpha, float duration)
//{
//    int fadeOutID1 = LeanTween.alpha(gameObject, alpha, duration).id;
//    fadeOutTween1 = LeanTween.descr(fadeOutIDStart1);
//    fadeOutTween1.pause();
//}





//private IEnumerator resetARSessionLater(float waitTime)
//{
//    //isRunningMoveBackRoutine = true;
//    yield return new WaitForSeconds(waitTime);
//    arsession.Reset();
//    Debug.Log("Arsession Restarted Late");
//}

//private IEnumerator showUIAfterAnimation(float waitTime)
//{
//    yield return new WaitForSeconds(waitTime);
//    //canvasGroup.alpha = 1;
//    //resetUICanvasGroup.alpha = 1;
//    //hideAllUICanvasGroup.alpha = 1;
//    Debug.Log("Show UI");
//}


//private IEnumerator hideUIAfterAnimation(float waitTime)
//{
//    yield return new WaitForSeconds(waitTime);
//    //canvasGroup.alpha = 0;
//    //resetUICanvasGroup.alpha = 0;
//    //hideAllUICanvasGroup.alpha = 0;
//    Debug.Log("Hide UI");
//}



//public void hideResetUI()
//{
//    //canvasGroup.alpha = 0;
//    //resetUICanvasGroup.alpha = 0;
//    //hideAllUICanvasGroup.alpha = 0;
//}



//public void showResetUI()
//{
//    StartCoroutine(routine: showUIAfterAnimation(waitToUnhideDealy));
//    //canvasGroup.alpha = 1;
//    //resetUICanvasGroup.alpha = 1;
//    //hideAllUICanvasGroup.alpha = 1;
//}

//Bootleg Update Rotate
//if (rotatStatus == true)

//{
//    Debug.Log("Rotate you little hoe rotate");
//    artViewingLocation.transform.Rotate(Vector3.up, rotationspeed * Time.deltaTime);
//    artViewingLocation.transform.Rotate(Vector3.up, rotationspeed * Time.deltaTime);

//}


//if (rotatStatus == true)

//    artPeice.transform.Rotate(Vector3.up, rotationspeed * Time.deltaTime);
//else artPeice.transform.Rotate(Vector3.up, 0 * Time.deltaTime);

// //[SerializeField] private ScriptableGOData soGameObject;

//[SerializeField] private int itemPrice;



//public void startRotate()
//{
//    if (rotatStatus == false)
//    {
//        rotatStatus = true;
//    }
//    else
//    {
//        rotatStatus = false;
//    }

//}

//public void stopRotate()
//{
//    if (rotatStatus == true)
//    {
//        rotatStatus = false;

//    }

//    else
//    {
//        rotatStatus = true;
//    }
//}



//void startRotateTween()
//{
//    rotateTween.resume();
//}

//void stopRotateTween()
//{
//    rotateTween.pause();
//}

//void cancelMoveToTween1()
//{
//    LeanTween.cancel(moveIDStart1);
//}


//void cancelMoveBackTween1()
//{
//    LeanTween.cancel(resetIDStart1);
//}

//void cancelRotateTween1()
//{
//    LeanTween.cancel(rotateIDStart1);
//}


//void cancelMoveToTween2()
//{
//    LeanTween.cancel(moveIDStart2);
//}


//void cancelMoveBackTween2()
//{
//    LeanTween.cancel(resetIDStart2);
//}

//void cancelRotateTween2()
//{
//    LeanTween.cancel(rotateIDStart2);
//}



//void cancelMoveToTween3()
//{
//    LeanTween.cancel(moveIDStart3);
//}


//void cancelMoveBackTween3()
//{
//    LeanTween.cancel(resetIDStart3);
//}

//void cancelRotateTween3()
//{
//    LeanTween.cancel(rotateIDStart3);
//}


//private IEnumerator dismissArtLocalRoutine1(GameObject gameObject, Vector3 vector3, float speed, float waitTime)
//{
//    //isRunningMoveRoutine = true;
//    cancelTweens1();
//    initMoveBackTween1(gameObject, vector3, 0);
//    //initRotateTween(artPeice, -180, speed);
//    yield return new WaitForSeconds(0);
//    resetTween1.resume();
//    //rotateTween.resume();
//    //Debug.Log("Start Animation Move Back With Delay");
//}

//private IEnumerator dismissArtLocalRoutine2(GameObject gameObject, Vector3 vector3, float speed, float waitTime)
//{
//    //isRunningMoveRoutine = true;
//    cancelTweens2();
//    initMoveBackTween2(gameObject, vector3, 0);
//    //initRotateTween(artPeice, -180, speed);
//    yield return new WaitForSeconds(0);
//    resetTween2.resume();
//    //rotateTween.resume();
//    //Debug.Log("Start Animation Move Back With Delay");
//}


//private IEnumerator dismissArtLocalRoutine3(GameObject gameObject, Vector3 vector3, float speed, float waitTime)
//{
//    //isRunningMoveRoutine = true;


//    cancelTweens3();
//    initMoveBackTween3(gameObject, vector3, 0);
//    //initRotateTween(artPeice, -180, speed);
//    yield return new WaitForSeconds(0);
//    resetTween3.resume();
//    //rotateTween.resume();
//    //Debug.Log("Start Animation Move Back With Delay");
//}


//private IEnumerator moveBackAllRoutine1(float waitTime)
//{
//    cancelTweens1();
//    //isRunningMoveRoutine = true;
//    initMoveBackTween2(artPeice2, artOriginssss2.transform.position, moveDuration);
//    initMoveBackTween3(artPeice3, artOriginssss3.transform.position, moveDuration);
//    //initRotateTween(artPeice, -180, speed);
//    yield return new WaitForSeconds(waitTime);
//    resetTween2.resume();
//    resetTween3.resume();
//    //rotateTween.resume();
//    //Debug.Log("Start Animation With Delay");
//}




//private IEnumerator moveBackAllRoutine2(GameObject gameObject1, GameObject artOrigin1, GameObject gameObject3, GameObject artOrigin3, float moveDuration, float waitTime)
//{
//    cancelTweens2();
//    //isRunningMoveRoutine = true;
//    initMoveBackTween1(gameObject1, artOrigin1.transform.position, moveDuration);
//    initMoveBackTween3(gameObject3, artOrigin3.transform.position, moveDuration);
//    //initRotateTween(artPeice, -180, speed);
//    yield return new WaitForSeconds(waitTime);
//    resetTween1.resume();
//    resetTween3.resume();
//    //rotateTween.resume();
//    //Debug.Log("Start Animation With Delay");
//}




//private IEnumerator moveBackAllRoutine3(GameObject gameObject1, GameObject artOrigin1, GameObject gameObject2, GameObject artOrigin2, float moveDuration, float waitTime)
//{

//    cancelTweens3();
//    //isRunningMoveRoutine = true;
//    initMoveBackTween1(gameObject1, artOrigin1.transform.position, moveDuration);
//    initMoveBackTween2(gameObject2, artOrigin2.transform.position, moveDuration);
//    //initRotateTween(artPeice, -180, speed);
//    yield return new WaitForSeconds(waitTime);
//    resetTween1.resume();
//    resetTween2.resume();
//    //rotateTween.resume();
//    //Debug.Log("Start Animation With Delay");
//}



//void art1PressedResetAll()
//{
//    moveBack2();
//    moveBack3();

//}

//void art2PressedResetAll()
//{
//    moveBack1();
//    moveBack3();
//}

//void art3PressedResetAll()
//{
//    moveBack1();
//    moveBack2();

//}


//void moveBack1()
//{
//    artPeice1.transform.position = artOriginssss1.transform.position;
//    artPeice1.LeanRotateY(-180, 0);
//    artPeice1.transform.LookAt(arCamera.transform);
//}

//void moveBack2()
//{

//    artPeice2.transform.position = artOriginssss2.transform.position;
//    artPeice2.LeanRotateY(-180, 0);
//    artPeice2.transform.LookAt(arCamera.transform);
//}
//void moveBack3()
//{
//    artPeice3.transform.position = artOriginssss3.transform.position;
//    artPeice3.LeanRotateY(-180, 0);
//    artPeice3.transform.LookAt(arCamera.transform);
//}







//void initPingPongtween()
//{
//    int pingPongID = LeanTween.moveLocalY(artPeice, .028f, -.05f).setDelay(1f).setEaseInOutQuad().setLoopPingPong().id;
//    pingPongIDStart = pingPongID;
//    pingPongTween = LeanTween.descr(pingPongIDStart);
//    pingPongTween.pause();
//}


//hideResetUI();
//isRunningMoveRoutine = true;
//showResetUI();

//LTDescr pingPongTween = null;
//int pingPongIDStart;



//void initResetRotationTween1(GameObject gameobject, float angle, float speed)
//{
//    int resetRotationID1 = LeanTween.rotateY(gameobject, -180, speed).setEaseInOutSine().id;
//    //int resetRotationID2 = LeanTween.rotate(artPeice, rotateVector3, moveDuration / 5).id;
//    resetRotationIDStart1 = resetRotationID1;
//    resetRotationTween1 = LeanTween.descr(resetRotationIDStart1);
//    resetRotationTween1.pause();
//}

//void initResetRotationTween2(GameObject gameobject, float angle, float speed)
//{
//    int resetRotationID2 = LeanTween.rotateY(gameobject, -180, speed).setEaseInOutSine().id;
//    //int resetRotationID2 = LeanTween.rotate(artPeice, rotateVector3, moveDuration / 5).id;
//    resetRotationIDStart2 = resetRotationID2;
//    resetRotationTween2 = LeanTween.descr(resetRotationIDStart2);
//    resetRotationTween2.pause();
//}


//void initResetRotationTween3(GameObject gameobject, float angle, float speed)
//{
//    int resetRotationID3 = LeanTween.rotateY(gameobject, -180, speed).setEaseInOutSine().id;
//    //int resetRotationID2 = LeanTween.rotate(artPeice, rotateVector3, moveDuration / 5).id;
//    resetRotationIDStart3 = resetRotationID3;
//    resetRotationTween3 = LeanTween.descr(resetRotationIDStart3);
//    resetRotationTween3.pause();
//}


//void initRotationTween1(GameObject gameobject, float angle, float speed)
//{
//    int resetRotationID1 = LeanTween.rotateY(gameobject, 180, speed).setEaseInOutSine().id;
//    //int resetRotationID2 = LeanTween.rotate(artPeice, rotateVector3, moveDuration / 5).id;
//    RotationIDStart1 = RotationID1;
//    RotationTween1 = LeanTween.descr(RotationIDStart1);
//    RotationTween1.pause();
//}

//void initRotationTween2(GameObject gameobject, float angle, float speed)
//{
//    int RotationID2 = LeanTween.rotateY(gameobject, 180, speed).setEaseInOutSine().id;
//    //int resetRotationID2 = LeanTween.rotate(artPeice, rotateVector3, moveDuration / 5).id;
//   RotationIDStart2 = RotationID2;
//    RotationTween2 = LeanTween.descr(RotationIDStart2);
//    RotationTween2.pause();
//}


//void initRotationTween3(GameObject gameobject, float angle, float speed)
//{
//    int resetRotationID3 = LeanTween.rotateY(gameobject, 180, speed).setEaseInOutSine().id;
//    //int resetRotationID2 = LeanTween.rotate(artPeice, rotateVector3, moveDuration / 5).id;
//    RotationIDStart3 = resetRotationID3;
//    RotationTween3 = LeanTween.descr(RotationIDStart3);
//    RotationTween3.pause();

//COROUTINE BOOLS
//bool isRunningMoveRoutine1 = false;
//bool isRunningMoveBackRoutine1 = false;
//bool isRunningMoveRoutine2 = false;
//bool isRunningMoveBackRoutine2 = false;
//bool isRunningMoveRoutine3 = false;
//bool isRunningMoveBackRoutine3 = false;

//FOREACH Handel Return ALL If Needed
//[SerializeField]
//private List<GameObject> items = new List<GameObject>();



//SO EVENTS
//[SerializeField] GameEvent _onArtAnimation1;
//[SerializeField] GameEvent _onArtAnimation2;
//[SerializeField] GameEvent _onArtAnimation3;
//[SerializeField] GameEvent _onResetArtPos1;
//[SerializeField] GameEvent _onResetArtPos2;
//[SerializeField] GameEvent _onResetArtPos3;


//UI
//[SerializeField] private CanvasGroup canvasGroup;
//[SerializeField] private CanvasGroup resetUICanvasGroup;
//[SerializeField] private CanvasGroup hideAllUICanvasGroup;
//}






//}

