using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using TMPro;

public class VideoPlayerSucka : MonoBehaviour
{

    public VideoClip[] videoClips;
    private VideoPlayer videoPlayer;
    private int videoClipIndex;
    [SerializeField] private TextMeshProUGUI onBoardTitle;

    public Button[] buttons;


    private void Awake()
    {
        buttons[0].image.color = Color.white;
        videoPlayer = GetComponent<VideoPlayer>();
    }

    public void startClip0()
    {
        onBoardTitle.text = "TAP A CATEGORY TO BROWSE";
        videoPlayer.clip = videoClips[0];
        buttons[0].image.color = Color.black;
        videoPlayer.Play();
    }

    public void startClip1()
    {
        onBoardTitle.text = "TAP AN ITEM TO SELECT";
        videoPlayer.clip = videoClips[1];
        buttons[1].image.color = Color.white;
        videoPlayer.Play();
    }



    public void startClip2()
    {
        onBoardTitle.text = "TAP AN ITEM TO START AND STOP SPIN";
        videoPlayer.clip = videoClips[2];
        buttons[2].image.color = Color.white;
        videoPlayer.Play();
    }

    public void startClip3()
    {
        onBoardTitle.text = "TAP AWAY FROM ITEM TO DISMISS";
        videoPlayer.clip = videoClips[3];
        buttons[3].image.color = Color.white;
        videoPlayer.Play();
    }


    public void startClip4()
    {
        onBoardTitle.text = "DRAG FINGER TO ROTATE SELECTED ITEM";
        videoPlayer.clip = videoClips[4];
        buttons[4].image.color = Color.white;
        videoPlayer.Play();
    }


    public void startClip5()
    {
        onBoardTitle.text = "HOLD TAP TO START ORDER";
        videoPlayer.clip = videoClips[5];
        buttons[5].image.color = Color.white;
        videoPlayer.Play();
    }


    public void startClip6()
    {
        onBoardTitle.text = "PINCH SELECTED ITEM TO SCALE";
        videoPlayer.clip = videoClips[6];
        buttons[6].image.color = Color.white;
        videoPlayer.Play();
    }

    public void startClip7()
    {
        onBoardTitle.text = "SWIPE LEFT AND RIGHT FOR NEXT AND PREV PAGE";
        videoPlayer.clip = videoClips[7];
        buttons[7].image.color = Color.white;
        videoPlayer.Play();
    }




    public void stopAllVideos()
    {

    }
}
