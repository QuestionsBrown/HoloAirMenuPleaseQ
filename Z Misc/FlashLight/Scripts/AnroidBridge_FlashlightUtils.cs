using UnityEngine;

/// <summary>
/// FlashlightUtils.java类的桥接器
/// </summary>
public class AnroidBridge_FlashlightUtils
{

    static AndroidJavaObject androidFlashlightUtils = null;

    /// <summary>
    /// 初始化
    /// </summary>
	static public void Init()
    {
        if (androidFlashlightUtils == null)
        {
            AndroidJavaClass jcUnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject jcCurrentActivityo = jcUnityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
            androidFlashlightUtils = new AndroidJavaObject("com.unity.mylibrary.FlashlightUtils", jcCurrentActivityo);
        }
    }
    static public void Destroy()
    {
        if (androidFlashlightUtils != null)
        {
            Close();
            androidFlashlightUtils.Dispose();
            androidFlashlightUtils = null;
        }
    }

    /// <summary>
    /// 是否支持闪光灯
    /// </summary>
    /// <returns></returns>
    static public bool IsSupportFlashlight()
    {
        Init();
        bool isSupport = androidFlashlightUtils.Call<bool>("isSupportFlashlight");
        return isSupport;
    }

    /// <summary>
    /// 打开闪光灯
    /// </summary>
    /// <returns>打开成功与否</returns>
    static public bool Open()
    {
        Init();
        bool reulut = androidFlashlightUtils.Call<bool>("open");
        return reulut;
    }

    /// <summary>
    /// 关闭闪光灯
    /// </summary>
    /// <returns>打开成功与否</returns>
    static public void Close()
    {
        if (androidFlashlightUtils !=null)
        {
            androidFlashlightUtils.Call("close");
        }
    }


}