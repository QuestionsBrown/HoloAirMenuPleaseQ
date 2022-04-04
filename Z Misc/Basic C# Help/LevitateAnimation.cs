//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;
//using UnityEngine.XR.ARFoundation;
//using UnityEngine.XR.ARSubsystems;
//using UnityEngine.XR.ARKit;

//class LevitateAnimation : MonoBehaviour
//{


//    // User Inputs
//    public float degreesPerSecond = 15.0f;
//    public float amplitude = 0.5f;
//    public float frequency = 1f;

//    // Position Storage Variables
//    Vector3 posOffset = new Vector3();
//    Vector3 tempPos = new Vector3();

//    // Use this for initialization
//    void Start()
//    {
//        // Store the starting position & rotation of the object
//        posOffset = transform.position;
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        // Spin object around Y-Axis
//        transform.Rotate(new Vector3(0f, Time.deltaTime * degreesPerSecond, 0f), Space.World);

//        // Float up/down with a Sin()
//        tempPos = posOffset;
//        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;

//        transform.position = tempPos;
//    }
//}


    //[SerializeField] Transform artPeice;
    //[SerializeField] private float verticalTime = .35f;
    //[SerializeField] private float verticalSpeed = .35f;

    //private void Start()
    //{
    //    artPeice = this.transform;
    //    startFloatAnimation();
    //}


    //public void startFloatAnimation()
    //{
    //    StopCoroutine(Stop());
    //    StartCoroutine(Rise());
    //}



    //public void stopFloatAnimation()
    //{

    //    //Debug.Log("trying to stop floating animation");
    //    StopCoroutine(Rise());
    //    StartCoroutine(Stop());
    //}



    //IEnumerator Rise()
    //{

    //    float t = verticalTime;
    //    while (t > 0f)
    //    {

    //        artPeice.Translate(artPeice.up * verticalSpeed * Time.deltaTime);
    //        t -= Time.deltaTime;
    //        yield return new WaitForEndOfFrame();
    //    }

    //    StartCoroutine(Fall());
    //}




    //IEnumerator Fall()
    //{

    //    float t = verticalTime;
    //    while (t > 0f)
    //    {

    //        artPeice.Translate(-artPeice.up * verticalSpeed * Time.deltaTime);
    //        t -= Time.deltaTime;
    //        yield return new WaitForEndOfFrame();
    //    }

    //    StartCoroutine(Rise());
    //}


    //IEnumerator Stop()
    //{
    //    float t = verticalTime;
    //    while (t > 0f)
    //    {

    //        artPeice.Translate(-artPeice.up * 0);
    //        t -= Time.deltaTime;
    //        yield return new WaitForEndOfFrame();
    //    }

    //}
//}







