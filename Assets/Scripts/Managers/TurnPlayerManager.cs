using UnityEngine;
public class TurnPlayerManager : MonoBehaviour
{

    [Header("Players")]
    [SerializeField]
    private PlayerController P1;
    [SerializeField]
    private PlayerController P2;

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
        switch (currentTurnPlayer)
        {
            case TurnPlayerID.PLAYER_1:
                break;
            case TurnPlayerID.PLAYER_2:
                break;
        }
    }

    void Start()
    {
        //Assign turns
        P1.Turn = TurnPlayerID.PLAYER_1;
        P2.Turn = TurnPlayerID.PLAYER_2;

        currentTurnPlayer = TurnPlayerID.PLAYER_1;
    }

    public TurnPlayerID NextPlayer()
    {
        currentTurnPlayer = (CurrentTurnPlayer == TurnPlayerID.PLAYER_2) ?
            TurnPlayerID.PLAYER_1 : currentTurnPlayer + 1;

        return currentTurnPlayer;
    }
}
