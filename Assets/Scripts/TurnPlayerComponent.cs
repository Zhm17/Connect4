using UnityEngine;

public class TurnPlayerComponent : MonoBehaviour
{
    [SerializeField]
    private TurnPlayerID currentTurnPlayer = TurnPlayerID.PLAYER_1;
    public TurnPlayerID CurrentTurnPlayer
    {
        get
        {
            return currentTurnPlayer;
        }
        private set
        {
            currentTurnPlayer = value;
            OnTurnPlayerChanged();
        }
    }

    private void OnTurnPlayerChanged()
    {
        TurnPhase.Restart();

        switch (currentTurnPlayer)
        {
            case TurnPlayerID.PLAYER_1:
                Players[0].Play();
                break;
            case TurnPlayerID.PLAYER_2:
                Players[1].Play();
                break;
        }
    }

    [Header("Players")]
    [SerializeField]
    private PlayerController[] Players;

    TurnPhaseComponent TurnPhase => GameManager.Instance.TurnPhase;

    public void SetTurnPlayer(TurnPlayerID id)
    {
        CurrentTurnPlayer = id;
        Debug.Log(" --------------- TURN : " + CurrentTurnPlayer);
    }

    private void NextPlayer()
    {
        CurrentTurnPlayer = (CurrentTurnPlayer == TurnPlayerID.PLAYER_2) ?
            TurnPlayerID.PLAYER_1 : CurrentTurnPlayer + 1;

        Debug.Log(" --------------- TURN : " + CurrentTurnPlayer);
    }

    /// <summary>
    /// Switch Phase
    /// </summary>
    public void EndPhase()
    {
        if(TurnPhase.CurrentTurnPhase == TurnPhaseID.EVALUATION)
        {
            EndTurn();
            return;
        }

        TurnPhase.Next();
    }

    /// <summary>
    /// Switch Player
    /// </summary>
    private void EndTurn()
    {
        NextPlayer();
    }
}
