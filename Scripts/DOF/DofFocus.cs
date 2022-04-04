using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

[RequireComponent(typeof(Camera))]
public class DofFocus : MonoBehaviour
{
    private Camera cameraMain;
    public VolumeProfile postFxProfile;
    private DepthOfField dof;
    private MinFloatParameter dofDistanceParametar;

    private Ray ray;
    private RaycastHit hit;
    private Vector3 viewportCenter;
    public LayerMask mask;
    private bool isHit = false;

    public float defaultDistance = 5f;
    public float minDistance = 0.5f;
    private float hitDistance;
    public float focusSpeed = 2f;
    public int updateFrequency = 2;

    private Transform thisTransform;

    private void Awake()
    {
        thisTransform = transform;
    }

    private void Start()
    {
        postFxProfile.TryGet<DepthOfField>(out dof);
        dofDistanceParametar = dof.focusDistance;
        viewportCenter = new Vector3(0.5f, 0.5f, 0);
        cameraMain = GetComponent<Camera>();
    }

    private void Update()
    {
        if (Time.frameCount % updateFrequency == 0)
        {
            //ray = cameraMain.ViewportPointToRay(viewportCenter);


            ray = new Ray(transform.position, transform.forward * 0.5f);
            isHit = false;

            if (Physics.Raycast(ray, out hit, 0.7f))

            //if (Physics.Raycast(ray, out hit, defaultDistance - 0.1f, mask))
            {
                isHit = true;

                hitDistance = Vector3.Distance(transform.position, hit.point);

            }


            else
            {
                if (hitDistance < 0.7f)
                {
                    hitDistance++;
                }
            }

            setFocus();
        }

    }



        //hitDistance = hit.distance;
        //        if (hitDistance < minDistance)
        //        {
        //            hitDistance = minDistance;
        //        }
        //        dofDistanceParametar.value = Mathf.Lerp(dofDistanceParametar.value, hitDistance, focusSpeed);
        //    }
        //    else
        //    {
        //        // isHit = false;
        //        if (dofDistanceParametar.value < defaultDistance)
        //        {
        //            dofDistanceParametar.value = Mathf.Lerp(dofDistanceParametar.value, defaultDistance, focusSpeed);
        //        }
        //    }

        //    setFocus();
    //}
    //}

    //private void OnDrawGizmos()
    //{
    //    if (isHit)
    //    {
    //        Gizmos.DrawSphere(hit.point, 0.1f);
    //        Debug.DrawRay(thisTransform.position, thisTransform.forward * hitDistance);
    //    }
    //    else
    //    {
    //        Debug.DrawRay(thisTransform.position, thisTransform.forward * 1000f);
    //    }
    //}



    void setFocus()
    {

        dof.focusDistance.value = hitDistance;
    }

}





////[RequireComponent(typeof(Camera))]
//public class DofFocus : MonoBehaviour
//{



//    Ray raycast;

//    RaycastHit hit;


//    bool isHit;
//    float hitDistance;

//    public PostProcessVolume volume;

//    DepthOfField depthOfField;


//    private void Start()
//    {
//        volume.profile.TryGetSettings(out depthOfField);
//    }

//    public void Update()
//    {
//        raycast = new Ray(transform.position, transform.forward * 0.5f);

//        isHit = false;

//        if (Physics.Raycast(raycast, out hit, 0.5f))

//        {
//            isHit = true;
//            hitDistance = Vector3.Distance(transform.position, hit.point);
//        }





//        else
//        {
//            if (hitDistance < 0.5f)
//            {
//                hitDistance++;
//            }
//        }


//        setFocus();
//    }

//    void setFocus()
//    {

//        depthOfField.focusDistance.value = hitDistance;
//    }


//    private void OnDrawGizmos()
//    {
//        if (isHit)
//        {
//            Gizmos.DrawSphere(hit.point, 0.1f);

//            Debug.DrawRay(transform.position, transform.forward * Vector3.Distance(transform.position, hit.point));
//        }

//        else
//        {

//            Debug.DrawRay(transform.position, transform.forward * .05f);

//        }
//    }


//}
