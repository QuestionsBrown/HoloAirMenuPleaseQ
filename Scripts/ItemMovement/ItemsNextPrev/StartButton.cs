using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.ARKit;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class StartButton : MonoBehaviour
{

    //[SerializeField] Camera arCamera ;

    [SerializeField] GameObject storeParent;

    [SerializeField] GameObject cameraSnapper;

    [SerializeField] GameObject arCam;

    [SerializeField] ARSession arSession;


    //[SerializeField] GameObject[] categoryScrollers;

    //[SerializeField] GameObject cameraPoint;




    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Collider[] hitColiders = Physics.OverlapSphere(cameraPoint.gameObject.transform.position, 0f);        


        //if (hitColiders.Length > 0 )
        //{

        //}

    }


    public void resetButtonFix()
    {
        arSession.Reset();
        //arSession.transform.rotation = storeParent.gameObject.transform.rotation;

        waitToSnap();
        //storeParent.gameObject.transform.position = new Vector3(arCam.gameObject.transform.position.x, arCam.gameObject.transform.position.y, 0);
        ////storeParent.gameObject.transform.rotation = arCamera.gameObject.transform.rotation;
        //storeParent.gameObject.transform.parent = null;

        //cameraSnapper.gameObject.transform.parent = arCam.gameObject.transform;
        //cameraSnapper.gameObject.transform.rotation = arCam.gameObject.transform.rotation;
        ////cameraSnapper.gameObject.transform.position = arCam.gameObject.transform.position;

        //cameraSnapper.gameObject.transform.parent = null;



        //storeParent.gameObject.transform.parent = cameraSnapper.gameObject.transform;
        //storeParent.gameObject.transform.rotation = cameraSnapper.gameObject.transform.rotation;
        //storeParent.gameObject.transform.parent = null;



        ////storeParent.gameObject.transform.parent = arCam.gameObject.transform;
        ///

        //if (arCamera.gameObject.transform.rotation.x >)
        //storeParent.gameObject.transform.LookAt(storeParent.gameObject.transform.position - arCamera.gameObject.transform.position);
        //storeParent.LeanMoveLocal(arCamera.gameObject, new Vector3(arCamera.transform.position.x - 0.5, arCamera.transform.position.y, arCamera.transform.position.z + 1f);
        //storeParent.gameObject.transform.position = new Vector3 (arCamera.gameObject.transform.position.x, arCamera.gameObject.transform.position.y, -.3f);
        //reparent gameopjects
        //storeParent.gameObject
        //parent reparent gamebject to cmamer


        //arSession.Reset();




    }


    public IEnumerator waitToSnap()
    {

        yield return new WaitForSeconds(1);

        storeParent.gameObject.transform.parent = arCam.gameObject.transform;

    }
}
