//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.SceneManagement;

//public class SplashScreen : MonoBehaviour
//{

//    public GameEvent onSplashAwake;
//    public CanvasGroup canvasGroup;
//    public float duration;
//    private bool mFaded = false;



//    private void Awake()
//    {

//    }

//    // Start is called before the first frame update
//    void Start()
//    {

//        canvasGroup = GetComponent<CanvasGroup>();


//        onSplashAwake.Invoke();
//        Fade();
//    }


//    public void Fade()
//    {

//        Debug.Log("Should Be Fading In Now");;
//        StartCoroutine(doFade(canvasGroup, canvasGroup.alpha, mFaded ? 1: 0));
//        mFaded = !mFaded;
//    }


//    public IEnumerator doFade(CanvasGroup canvasGroup, float start, float end)
//    {

//        float counter = 0f;

//        while (counter < duration)
//        {
//            counter += Time.deltaTime;
//            canvasGroup.alpha = Mathf.Lerp(end, start, counter / duration);
//            yield return null;
//        }
//    }

//}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashScreen: MonoBehaviour
{



    private void Start()
    {
        FadeIn();
    }

    public CanvasGroup uiElement;

    public void FadeIn()
    {
        StartCoroutine(FadeCanvasGroup(uiElement, uiElement.alpha, 1, 2.75f));
    }

    public void FadeOut()
    {
        StartCoroutine(FadeCanvasGroup(uiElement, uiElement.alpha, 0, .5f));
    }

    public IEnumerator FadeCanvasGroup(CanvasGroup cg, float start, float end, float lerpTime = 1)
    {
        float _timeStartedLerping = Time.time;
        float timeSinceStarted = Time.time - _timeStartedLerping;
        float percentageComplete = timeSinceStarted / lerpTime;

        while (true)
        {
            timeSinceStarted = Time.time - _timeStartedLerping;
            percentageComplete = timeSinceStarted / lerpTime;

            float currentValue = Mathf.Lerp(start, end, percentageComplete);

            cg.alpha = currentValue;

            if (percentageComplete >= 1) break;

            yield return new WaitForFixedUpdate();
        }

        print("done");
    }
}
