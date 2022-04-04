using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class Easy_flashlight : MonoBehaviour
{
#if UNITY_IOS && !UNITY_EDITOR
    [DllImport("__Internal")]
    static extern void _EnableFlashlight(bool enable);

    [DllImport("__Internal")]
    static extern void _SetFlashlightLevel(float val);

    [DllImport("__Internal")]
    static extern bool _DeviceHasFlashlight();
#endif

    void Start()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        AnroidBridge_FlashlightUtils.Init();
#endif
    }

    //open flashlight
    public static void open_flashlight()
    {
#if UNITY_IOS && !UNITY_EDITOR
        _EnableFlashlight(true);
#endif

#if UNITY_ANDROID && !UNITY_EDITOR
        AnroidBridge_FlashlightUtils.Open();
#endif
    }

    //close flashlight
    public static void close_flashlight()
    {
#if UNITY_IOS && !UNITY_EDITOR
        _EnableFlashlight(false);
#endif

#if UNITY_ANDROID && !UNITY_EDITOR
        AnroidBridge_FlashlightUtils.Close();
#endif
    }

    //Does device have flashlight
    public static bool does_device_have_flashlight()
    {

#if UNITY_IOS && !UNITY_EDITOR
       return  _DeviceHasFlashlight();
#endif

#if UNITY_ANDROID && !UNITY_EDITOR
        return AnroidBridge_FlashlightUtils.IsSupportFlashlight();
#endif

        return false;
    }

    //set flashlight brightness（only works on IOS）, 1>Value>0
    public static void set_flashlight_level(float value)
    {
#if UNITY_IOS && !UNITY_EDITOR
       _SetFlashlightLevel(value);
#endif
    }


}
