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
                //Show Main Menu
                break;
            case GameStageID.IN_GAME:
                //Starts the Game
                break;
            case GameStageID.GAME_OVER:
                //Show the winner
                //Show 'Play Again'/'Exit' button
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

}
