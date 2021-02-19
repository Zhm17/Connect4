using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public Turn Turn { 
        get { return m_Turn;} 
        set { m_Turn = value; } 
    }
    [SerializeField]
    private Turn m_Turn;

    public GamePhase Phase { 
        get { return m_Phase; } 
        set { m_Phase = value; } 
    }
    [SerializeField]
    private GamePhase m_Phase;

    [SerializeField]
    private bool m_gameOverFlag = false;

    [SerializeField]
    PlayerController P1;
    [SerializeField]
    PlayerController P2;



    private void Awake()
    {
        Init();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Init()
    {
        Turn = Turn.Player2;
        Phase = GamePhase.START;

        //Assign turns
        P1.turnPlayer = Turn.Player1;
        P2.turnPlayer = Turn.Player2;
    }

}
