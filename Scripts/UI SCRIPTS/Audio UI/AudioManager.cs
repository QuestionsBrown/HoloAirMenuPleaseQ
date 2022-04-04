using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{


    [SerializeField] private AudioSource audioSource;

    [SerializeField] private AudioClip[] musicClips;

    [SerializeField] private Button[] songButtons;

    [SerializeField] private GameObject pause;
    [SerializeField] private GameObject play;


    public int currentSong = 0;


[SerializeField] private TextMeshProUGUI musicTitle;
    //[SerializeField] private TextMeshProUGUI musicArtist;

    // Start is called before the first frame update
    void Start()
    {
        currentSong = 0;
        start0();
    }

    // Update is called once per frame
    void Update()
    {

    }

   


    public void PlayMusic()
    {
        play.SetActive(false);
        pause.SetActive(true);
        audioSource.Play();
    }

    public void PauseMusic()
    {
        pause.SetActive(false);
        play.SetActive(true);
        Debug.Log("PAUSE MUSIC BITCH");
        audioSource.Pause();
    }


    public void nextButton()
    {

        currentSong++;

        switch (currentSong)
        {

            case 1:
                {
                    start1();
                }
                break;

            case 2:
                {
                    start2();
                }
                break;

            case 3:
                {
                    start3();
                }

                break;
            case 4:
                {
                    start4();
                }
                break;

            case 5:
                {
                    start0();
                }
                break;

            default: return;
        }
    }


    public void start0()
    {
        musicTitle.text = "UBER - INTEGRAL BOY!";

        audioSource.clip = musicClips[0];
        audioSource.Play();

        currentSong = 0;
    }

    public void start1()
    {
        musicTitle.text = "EQUILIBRIUM - MAX MAIKON";
 
        audioSource.clip = musicClips[1];
        audioSource.Play();
    }

    public void start2()
    {
        musicTitle.text = "SCHENECTADY - INTEGRAL BOY!";
  
        audioSource.clip = musicClips[2];
        audioSource.Play();
    }

    public void start3()
    {
        musicTitle.text = "HUNTINGTON BEACH - INTERGALBOY!!";
        audioSource.clip = musicClips[3];
        audioSource.Play();
    }

    public void start4()
    {
        musicTitle.text = "HAPPY TRAVEL - QB";
        audioSource.clip = musicClips[4];
        audioSource.Play();
    }
}
