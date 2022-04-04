using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SmoothRotater : MonoBehaviour
{


    [SerializeField] private float rotatorSpeed = 10f;
     Rigidbody classicRigidBody;

    bool draggng = false;
    // Start is called before the first frame update
    void Start()
    {

        classicRigidBody = GetComponent<Rigidbody>();


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp (0))
        {
            draggng = false;
        }
    }



    private void OnMouseDrag()
    {
        draggng = true;
    }

    private void FixedUpdate()
    {


        if (draggng)
        {
            float x = Input.GetAxis("Mouse X") * rotatorSpeed * Time.fixedDeltaTime;
            float y = Input.GetAxis("Mouse Y") * rotatorSpeed * Time.fixedDeltaTime;

            classicRigidBody.AddTorque(Vector3.down * x);
            classicRigidBody.AddTorque(Vector3.down * y);
        }
    }



    //draggng = true;


    //float x = Input.GetAxis("Mouse X") * rotatorSpeed * Time.fixedDeltaTime;
    //float y = Input.GetAxis("Mouse Y") * rotatorSpeed * Time.fixedDeltaTime;

    //classicRigidBody.AddTorque(Vector3.down * x);
    //classicRigidBody.AddTorque(Vector3.down * y);
}



public class RotatorHoe : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    [SerializeField] float force = 10f;

    Rigidbody rb;
    bool isDragging = false;
    Vector3 direction;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void OnBeginDrag(PointerEventData pointerEventData)
    {
        isDragging = true;
    }

    public void OnEndDrag(PointerEventData pointerEventData)
    {
        isDragging = false;
    }

    public void OnDrag(PointerEventData pointerEventData)
    {
        direction = new Vector3(Input.GetAxis("Mouse Y"), -Input.GetAxis("Mouse X"), 0f);
    }

    void FixedUpdate()
    {
        if (isDragging)
        {
            rb.AddTorque(direction * force * Time.fixedDeltaTime);
        }
    }
}

