using UnityEngine;

[RequireComponent(typeof(TurnPhaseManager))]
[RequireComponent(typeof(TurnPlayerManager))]
public class GameManager : Singleton<GameManager>
{

    [Header("Game Stage")]
    [SerializeField]
    private GameStageID currentStage;
    public GameStageID CurrentStage
    {
        get
        {
            return currentStage;
        }
        private set
        {
            currentStage = value;
            OnGameStageChanged();
        }
    }

    private void OnGameStageChanged()
    {
        switch (CurrentStage)
        {
            case GameStageID.MAIN_MENU:
                OnMainMenu();
                break;
            case GameStageID.IN_GAME:
                
                OnInGame();
                break;
            case GameStageID.GAME_OVER:
                OnGameOver();
                break;
        }
    }

    [HideInInspector]
    public TurnPhaseManager TurnPhase => GetComponent<TurnPhaseManager>();
    [HideInInspector]
    public TurnPlayerManager TurnPlayer => GetComponent<TurnPlayerManager>();

    protected override void Init()
    {
        //Assign turns
        CurrentStage = GameStageID.MAIN_MENU;
    }

    public GameStageID NextStage()
    {
        CurrentStage = (CurrentStage == GameStageID.GAME_OVER) ?
            GameStageID.MAIN_MENU : CurrentStage + 1;

        return CurrentStage;
    }

    private void OnMainMenu()
    {
        BoardManager.Instance.CleanBoard();
        //Show Main Menu
        UIManager.Instance.ShowWindow(UIWindowID.MAIN_MENU);
    }

    private void OnInGame()
    {
        //Starts the Game
        UIManager.Instance.ShowWindow(UIWindowID.IN_GAME);
        TurnPhase.Restart();
        TurnPlayer.SetTurnPlayer(TurnPlayerID.PLAYER_1);

    }

    private void OnGameOver()
    {
        //Show the winner
        Debug.Log("Winner : " + TurnPlayer.CurrentTurnPlayer);
        //Show 'Play Again' button
        UIManager.Instance.ShowWindow(UIWindowID.GAME_OVER);
        
    }

}
