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
                //Start Player Control
                break;
            case TurnPhaseID.DROP:
                //Drop animation
                break;
            case TurnPhaseID.EVALUATION:
                //Search for a Winner
                break;
        }
    }

    void Start()
    {        
        currentTurnPhase = TurnPhaseID.START;
    }

    public TurnPhaseID NextTurnPhase()
    {
        CurrentTurnPhase = (CurrentTurnPhase == TurnPhaseID.EVALUATION)?
            TurnPhaseID.START : CurrentTurnPhase + 1;

        return CurrentTurnPhase; 
    }
}
