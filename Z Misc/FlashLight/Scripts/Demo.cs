using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace EasyGameStudio.easy_flashlight
{
    public class Demo : MonoBehaviour
    {
        public bool isOn;
        public GameObject game_obj_on_btn;
        public GameObject game_obj_off_btn;

        public void on_flashlight_on_btn()
        {

            if (isOn == false)
            {
                Easy_flashlight.open_flashlight();
                isOn = true;
                Debug.Log("FlashlightON");
            }

            else if (isOn == true)
            {
                Easy_flashlight.close_flashlight();
                isOn = false;
                Debug.Log("FlashlightOFF");
            }


            //this.game_obj_off_btn.SetActive(true);
            //this.game_obj_on_btn.SetActive(false);

        

        }

        public void on_flashlight_off_btn()
        {
            //this.game_obj_off_btn.SetActive(false);
            //this.game_obj_on_btn.SetActive(true);

           
        }
    }



}
