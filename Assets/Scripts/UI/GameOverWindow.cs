
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
            GameManager.Instance.NextStage());
    }

}
