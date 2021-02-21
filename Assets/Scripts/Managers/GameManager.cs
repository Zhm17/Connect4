using UnityEngine;

public class GameManager : Singleton<GameManager>
{

    [SerializeField]
    private Turn turn;
    public Turn Turn
    {
        get
        {
            return turn;
        }
    }


    [SerializeField]
    private GamePhase phase;
    public GamePhase Phase
    {
        get
        {
            return phase;
        }
    }

    
    [Header("Players")]
    [SerializeField]
    private PlayerController P1;
    [SerializeField]
    private PlayerController P2;


    [Header("Game Over")]
    [SerializeField]
    private bool gameOver = false;
    public bool GameOver
    {
        get
        {
            return gameOver;
        }
    }


    protected override void Init()
    {
        //Assign turns
        P1.turnPlayer = Turn.Player1;
        P2.turnPlayer = Turn.Player2;

        turn = Turn.Player1;
        phase = GamePhase.START;
       
    }

}
