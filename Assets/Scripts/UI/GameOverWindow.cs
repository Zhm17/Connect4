
using UnityEngine;
using UnityEngine.UI;


public class GameOverWindow : UIWindow
{
    [SerializeField]
    private Text WinnerText;

    [SerializeField]
    private Button ExitButton;


    protected override void Init()
    {
        ID = UIWindowID.GAME_OVER;

        ExitButton.onClick.AddListener(()=>
            GameManager.Instance.NextStage());
    }

    public override void Show(UIWindowID id)
    {
        base.Show(id);

        WinnerText.text = GameManager.Instance.TurnPlayer.CurrentTurnPlayer.ToString();
    }

}
