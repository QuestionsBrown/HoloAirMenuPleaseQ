using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;


public class LoadAddressableScene : MonoBehaviour
{



    [SerializeField] private AssetReference prefabTest;
    [SerializeField] private AsyncOperationHandle<GameObject> handle2;
    [SerializeField] private GameObject emptyArtHolder;



    //[SerializeField] private string TestArtAddressableName;
    //[SerializeField] private AssetReference _scene;
    //[SerializeField] private AsyncOperationHandle<SceneInstance> handle;
    //private List<AssetReference> _references = new List<AssetReference>();
    //public DownloadStatusProgress downloadProgress;
    //public GameObject uiGameObject;
    //long DownloadSize = 0;





    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        StartCoroutine(DownloadObject());
        //Addressables.InstantiateAsync(TestArtAddressableName, originBox.transform);
        //StartCoroutine(DownloadScene());

    }

    IEnumerator DownloadObject()
    {
        var downloadObject = Addressables.LoadAssetAsync<GameObject>(prefabTest);
        downloadObject.Completed += ObjectDownloadCompleted;
        yield return null;

    }


    private void ObjectDownloadCompleted(AsyncOperationHandle<GameObject> _handle2) // ref to AysncHandel
    {
        if (_handle2.Status == AsyncOperationStatus.Succeeded)
        {
            GameObject loadedItem = _handle2.Result;
            emptyArtHolder = Instantiate(loadedItem);
            Debug.Log("We Downloaded Jaink");
            StartCoroutine(UnloadObject());
        }
    }


    private IEnumerator UnloadObject()
    {

        yield return new WaitForSeconds(5);
        Debug.Log("supposed to unload");
        //Addressables.UnloadSceneAsync(handle, true)
        //Addressables.Release(_handle2);


    }


    //public void instatiateRightWayWithScripts()

    //{
    //    Addressables.InstantiateAsync(TestArtAddressableName, emptyArtHolder.transform);

    //}


    //IEnumerator DownloadScene()
    //{
    //    var downloadScene = Addressables.LoadSceneAsync(_scene, LoadSceneMode.Additive);
    //    downloadScene.Completed += SceneDownloadCompleted;

    //    yield return null;

    //}





    //private void SceneDownloadCompleted(AsyncOperationHandle<SceneInstance> _handle) // ref to AysncHandel
    //{

    //    if (_handle.Status == AsyncOperationStatus.Succeeded)
    //    {
    //        Debug.Log("We Downloaded Jaink");
    //        handle = _handle;
    //        StartCoroutine(UnloadScene());
    //    }

    //}




    //private IEnumerator UnloadScene()
    //{

    //    yield return new WaitForSeconds(30);

    //    Addressables.UnloadSceneAsync(handle, true).Completed += op =>
    //    {

    //        if (op.Status == AsyncOperationStatus.Succeeded)
    //        {
    //            //pop up screen test here
    //            Debug.Log("We Unloaded That Jaink");
    //        }
    //    };
    //}









    // Update is called once per frame
    void Update()
    {
        
    }
}
