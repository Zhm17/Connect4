using UnityEngine;
using UnityEngine.UI;

public class MainMenuWindow : UIWindow
{
    UIWindowID WindowID = UIWindowID.MAIN_MENU;

    [SerializeField]
    private Button StartButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    protected override void Init()
    {
        StartButton.onClick.AddListener(()=>UIManager.Show(UIWindowID.IN_GAME));
    }

}
