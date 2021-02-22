using System;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    public delegate void ShowWindow(UIWindowID id);
    public static ShowWindow Show;

    protected override void Init()
    {

    }

}
