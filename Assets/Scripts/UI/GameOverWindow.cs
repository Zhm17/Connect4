
using UnityEngine;
using UnityEngine.UI;


public class GameOverWindow : UIWindow
{
    [SerializeField]
    private Button ExitButton;

    protected override void Init()
    {
        ID = UIWindowID.GAME_OVER;

        ExitButton.onClick.AddListener(()=> 
        UIManager.Instance.ShowWindow(UIWindowID.MAIN_MENU));
    }

}
