using UnityEngine;

public class TurnPhaseManager: MonoBehaviour
{
   
    [SerializeField]
    private TurnPhaseID currentTurnPhase;
    public TurnPhaseID CurrentTurnPhase
    {
        get
        {
            return currentTurnPhase;
        }

        private set
        {
            currentTurnPhase = value;
            OnTurnPhaseChanged();
        }
    }

    private void OnTurnPhaseChanged()
    {
        switch (currentTurnPhase)
        {
            case TurnPhaseID.START:
                OnStart();
                break;
            case TurnPhaseID.DROP:
                OnDrop();
                break;
            case TurnPhaseID.EVALUATION:
                OnEvaluation();
                break;
        }
    }

    TurnPlayerManager TurnPlayer => GameManager.Instance.TurnPlayer;

/*    void Start()
    {        
        currentTurnPhase = TurnPhaseID.START;
    }*/

    public void SetTurnPhase(TurnPhaseID id)
    {
        CurrentTurnPhase = id;
    }

    public TurnPhaseID Next()
    {
        CurrentTurnPhase = (CurrentTurnPhase == TurnPhaseID.EVALUATION)?
            TurnPhaseID.START : CurrentTurnPhase + 1;

        return CurrentTurnPhase; 
    }

    /// <summary>
    /// Sets the current Phase to START id
    /// </summary>
    /// <returns></returns>
    public TurnPhaseID Restart()
    {
        SetTurnPhase(TurnPhaseID.START);
        return CurrentTurnPhase;
    }

    private void OnStart()
    {
        Debug.Log("PHASE : START");
    }

    private void OnDrop()
    {
        Debug.Log("PHASE : DROP");
    }

    private void OnEvaluation()
    {
        Debug.Log("PHASE : EVALUATION");
        //Search for a Winner
        bool winner = 
            BoardManager.Instance.LookForAPattern((PieceID)((int) TurnPlayer.CurrentTurnPlayer));
        
        if (winner)
        {
            //Game Over 
            GameManager.Instance.NextStage();
        } else
        {
            //Switch player and restart turn player phase
            TurnPlayer.EndPhase();
        }
    }
}
