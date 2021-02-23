using UnityEngine;
using UnityEngine.UI;

public class MainMenuWindow : UIWindow
{
    [SerializeField]
    private Button StartButton;

    protected override void Init()
    {
        ID = UIWindowID.MAIN_MENU;

        StartButton.onClick.AddListener(() => GameManager.Instance.NextStage());
    }

}
