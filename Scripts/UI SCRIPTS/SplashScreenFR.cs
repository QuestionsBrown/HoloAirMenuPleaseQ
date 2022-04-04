using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;


public class SplashScreenFR : MonoBehaviour
{

    public static SplashScreenFR Instance;

    public Image splashLogo;

    public Image backround;

    public Image LoadImage;


    public GameObject LoaderCanvas;

    public Image progressBar;



    private void Awake()
    {
        splashLogo.canvasRenderer.SetAlpha(0.0f);


        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {

            Destroy(gameObject);
        }
    }

    void Start()
    {
        StartCoroutine(fadeInOut());
       
    }

    public IEnumerator fadeIn()
    {
        yield return new WaitForSeconds(0.4f);
        splashLogo.CrossFadeAlpha(1, 2, false); 
    }

    public IEnumerator fadeInLoadImage()
    {
        yield return new WaitForSeconds(0.4f);
        splashLogo.CrossFadeAlpha(1, 2, false);
    }

    public IEnumerator fadeOut()
    {
        yield return new WaitForSeconds(2);
        splashLogo.CrossFadeAlpha(0, 2, false);
        //backround.CrossFadeAlpha(0, 3, false);

    }


    public async void loadAppBabe(string SceneName)
    {
        var scene = SceneManager.LoadSceneAsync(SceneName);


        scene.allowSceneActivation = false;
        LoaderCanvas.SetActive(true);


        do
        {

           
          progressBar.fillAmount = scene.progress;
        } while (scene.progress < 0.9f);

        scene.allowSceneActivation = true;


    




        //LoaderUtility.Initialize();
        //SceneManager.LoadScene("ArtScene", LoadSceneMode.Single);
        //LoaderUtility.Deinitialize();
    }

    public void loadApp()
    {
        LoaderUtility.Initialize();
        SceneManager.LoadScene("ArtScene", LoadSceneMode.Single);
        //LoaderUtility.Deinitialize();
    }

    public IEnumerator fadeInOut()
    {
        StartCoroutine(fadeIn());
        StartCoroutine(fadeOut());
        yield return new WaitForSeconds(3.9f);
        loadApp();
    }


}
