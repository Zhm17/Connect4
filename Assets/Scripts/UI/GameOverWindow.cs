
using UnityEngine;
using UnityEngine.UI;
using System;


public class GameOverWindow : UIWindow
{
    UIWindowID WindowID = UIWindowID.GAME_OVER;

    [SerializeField]
    private Button ExitButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    protected override void Init()
    {
        ExitButton.onClick.AddListener(()=> UIManager.Show(UIWindowID.MAIN_MENU));
    }

}
