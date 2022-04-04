using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothRotate : MonoBehaviour
{

    [SerializeField] Camera arCamera;
    public float PCRotationSpeed = 10f;
    public float MobileRotationSpeed = 0.4f;



    void Update()
    {
        // get the user touch input
        foreach (Touch touch in Input.touches)
        {
            Debug.Log("Touching at: " + touch.position);
            Ray camRay = arCamera.ScreenPointToRay(touch.position);
            RaycastHit raycastHit;
            if (Physics.Raycast(camRay, out raycastHit, 10))
            {
                if (touch.phase == TouchPhase.Began)
                {
                    //Debug.Log("Touch phase began at: " + touch.position);
                }
                else if (touch.phase == TouchPhase.Moved)
                {
                    Debug.Log("Touch phase Moved");
                    transform.Rotate(touch.deltaPosition.y * MobileRotationSpeed,
                        -touch.deltaPosition.x * MobileRotationSpeed, 0, Space.World);
                }
                else if (touch.phase == TouchPhase.Ended)
                {
                    //Debug.Log("Touch phase Ended");
                }
            }
        }
    }


    //[SerializeField] float rotationSpeed;
    //private void OnMouseDrag()
    //{
    //    Debug.Log("trying to rotate");
    //    float rotX = Input.GetAxis("Mouse X") * rotationSpeed * Mathf.Deg2Rad;
    //    float rotY = Input.GetAxis("Mouse Y") * rotationSpeed * Mathf.Deg2Rad;
    //    transform.Rotate(Vector3.up, -rotX);
    //    transform.Rotate(Vector3.right, rotY);

    //}


    ////Drag the camera object here
    //public Camera cam;

    //void OnMouseDrag()
    //{
    //    float rotX = Input.GetAxis("Mouse X") * PCRotationSpeed;
    //    float rotY = Input.GetAxis("Mouse Y") * PCRotationSpeed;

    //    Vector3 right = Vector3.Cross(cam.transform.up, transform.position - cam.transform.position);
    //    Vector3 up = Vector3.Cross(transform.position - cam.transform.position, right);
    //    transform.rotation = Quaternion.AngleAxis(-rotX, up) * transform.rotation;
    //    transform.rotation = Quaternion.AngleAxis(rotY, right) * transform.rotation;
    //}

}



//public class SmoothRotate : MonoBehaviour
//{
//    public float PCRotationSpeed = 10f;
//    public float MobileRotationSpeed = 0.4f;
//    //Drag the camera object here
//    public Camera cam;

//    void OnMouseDrag()
//    {
//        float rotX = Input.GetAxis("Mouse X") * PCRotationSpeed;
//        float rotY = Input.GetAxis("Mouse Y") * PCRotationSpeed;

//        Vector3 right = Vector3.Cross(cam.transform.up, transform.position - cam.transform.position);
//        Vector3 up = Vector3.Cross(transform.position - cam.transform.position, right);
//        transform.rotation = Quaternion.AngleAxis(-rotX, up) * transform.rotation;
//        transform.rotation = Quaternion.AngleAxis(rotY, right) * transform.rotation;
//    }

//    void Update()
//    {
//        // get the user touch input
//        foreach (Touch touch in Input.touches)
//        {
//            Debug.Log("Touching at: " + touch.position);
//            Ray camRay = cam.ScreenPointToRay(touch.position);
//            RaycastHit raycastHit;
//            if (Physics.Raycast(camRay, out raycastHit, 10))
//            {
//                if (touch.phase == TouchPhase.Began)
//                {
//                    Debug.Log("Touch phase began at: " + touch.position);
//                }
//                else if (touch.phase == TouchPhase.Moved)
//                {
//                    Debug.Log("Touch phase Moved");
//                    transform.Rotate(touch.deltaPosition.y * MobileRotationSpeed,
//                        -touch.deltaPosition.x * MobileRotationSpeed, 0, Space.World);
//                }
//                else if (touch.phase == TouchPhase.Ended)
//                {
//                    Debug.Log("Touch phase Ended");
//                }
//            }
//        }
//    }
//}


//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
////using DG.Tweening;
//using UnityEngine.UI;
//using UnityEngine.XR.ARFoundation;
//using UnityEngine.XR.ARSubsystems;
//using UnityEngine.XR.ARKit;
//using UnityEngine.EventSystems;
//using GG.Infrastructure.Utils.Swipe;

//public class SmoothRotate : MonoBehaviour
//    {
//        [SerializeField] private LayerMask targetLayer;
//        [SerializeField] private float rotationRate = 0.30f;
//        [SerializeField] private bool xRotation;
//        [SerializeField] private bool yRotation;
//        [SerializeField] private bool invertX;
//        [SerializeField] private bool invertY;
//        [SerializeField] private bool touchAnywhere;
//        private float m_previousX;
//        private float m_previousY;
//        private Camera m_camera;
//        private bool m_rotating = false;

//        private void Awake()
//        {
//            m_camera = Camera.main;
//        }

//        private void Update()
//        {
//            if (!touchAnywhere)
//            {
//                //No need to check if already rotating
//                if (!m_rotating)
//                {
//                    RaycastHit hit;
//                    Ray ray = m_camera.ScreenPointToRay(Input.mousePosition);
//                    if (!Physics.Raycast(ray, out hit, 1000, targetLayer))
//                    {
//                        return;
//                    }
//                }
//            }

//            if (Input.GetMouseButtonDown(0))
//            {
//                m_rotating = true;
//                m_previousX = Input.mousePosition.x;
//                m_previousY = Input.mousePosition.y;
//            }
//            // get the user touch input
//            if (Input.GetMouseButton(0))
//            {
//                var touch = Input.mousePosition;
//                var deltaX = -(Input.mousePosition.y - m_previousY) * rotationRate;
//                var deltaY = -(Input.mousePosition.x - m_previousX) * rotationRate;
//                if (!yRotation) deltaX = 0;
//                if (!xRotation) deltaY = 0;
//                if (invertX) deltaY *= -1;
//                if (invertY) deltaX *= -1;
//                transform.Rotate(deltaX, deltaY, 0, Space.World);

//                m_previousX = Input.mousePosition.x;
//                m_previousY = Input.mousePosition.y;
//            }
//            if (Input.GetMouseButtonUp(0))
//                m_rotating = false;
//        }
//    }






//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class SmoothRotate : MonoBehaviour
//{


//    Vector3 prevPos = Vector3.zero;
//    Vector3 posDelta = Vector3.zero;

//    private void Update()
//    {
//        if (Input.GetMouseButton(0))
//        {

//            posDelta = Input.mousePosition - prevPos;

//            transform.Rotate(transform.up, -Vector3.Dot(posDelta, Camera.main.transform.right), Space.World);
//            //        if (Vector3.Dot(transform.up, Vector3.up) >= 0)
//            //        {
//            //            transform.Rotate(transform.up, -Vector3.Dot(posDelta, Camera.main.transform.right), Space.World);

//            //        }

//            //        else
//            //        {
//            //            transform.Rotate(transform.up, Vector3.Dot(posDelta, Camera.main.transform.right), Space.World);

//            //        }

//            //        transform.Rotate(Camera.main.transform.right, Vector3.Dot(posDelta, Camera.main.transform.up), Space.World);
//            //    }


//            //    prevPos = Input.mousePosition;
//            //}




//        }
//    }
//}


//    [SerializeField] float rotX;

//    [SerializeField] float rotY;
//    bool dragging;


//    Rigidbody rb;


//    void Start()
//    {
//        rb = GetComponent<Rigidbody>();
//    }

//    private void OnMouseDrag()
//    {
//        dragging = true;
//    }

//    // Update is called once per frame
//    void Update()
//    {



//        if (Input.GetMouseButtonUp(0))
//        {
//            Debug.Log("tryna rotate");
//            dragging = true;
//            float x = Input.GetAxis("Mouse X") * rotationSpeed;
//            float y = Input.GetAxis("Mouse Y") * rotationSpeed;

//        }
//        else {
//            dragging = false;

//        }

//    }

//    private void FixedUpdate2()
//    {
//        if (dragging)
//        {


//            rb.AddTorque(rotY, -rotX, 0);

//        }
//    }
//}

//private void FixedUpdate()
//{
//    if (dragging)
//    {
//        float x = Input.GetAxis("Mouse X") * rotationSpeed;
//        float y = Input.GetAxis("Mouse Y") * rotationSpeed;


//        transform.Rotate(Vector3.down, x);
//        transform.Rotate(Vector3.down, y);
//    }
//}
