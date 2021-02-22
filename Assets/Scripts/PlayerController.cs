using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    public TurnPlayerID Turn;
    [SerializeField]
    bool AI_enabled = false;

    private Disc newDisc = null;

    private int colSelected = 0;
    private int rowAvailable = 0;

    private bool dropping = false;

    private AIController AI_Controller;

    private TurnPlayerManager TurnPlayerInst => GameManager.Instance.TurnPlayer;
    private TurnPhaseManager TurnPhaseInst => GameManager.Instance.TurnPhase;
    private BoardManager Board => BoardManager.Instance;
    private Spawner Spawner => Spawner.Instance;


    private void Awake()
    {
        if (AI_enabled)
        {
            AI_Controller = gameObject.AddComponent<AIController>();
        }
    }


    void Start()
    {
        Init();
    }


    private void Init()
    {
        rowAvailable = 0;
        colSelected = 0;

        if (TurnPlayerInst.CurrentTurnPlayer == Turn)
        {
            if (newDisc == null)
            {
                dropping = false;
                newDisc = Spawner.NewInstance( ((TurnPlayerInst.CurrentTurnPlayer == TurnPlayerID.PLAYER_1) ? 
                                                DiscID.RED : DiscID.YELLOW),
                                                BoardManager.DiscInitialPosition);
            }
        }

        if (!Board.IsBoardFull())
        {
            if (!AI_enabled)
            {
                StartCoroutine(PlayerMethodUpdate());
            }
            else
            {
                AI_Controller.Init(newDisc);
            }
        } 
        else
        {
            //TODO Game Manager set a Draw
        }
    }


    // Update is called once per frame
    IEnumerator PlayerMethodUpdate()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);


        while (true)
        {
            if (!dropping)
            {
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit))
                {
                    Transform objectHit = hit.transform;

                    if (objectHit.CompareTag("ColumnSelection"))
                    {
                        colSelected = (int) objectHit.position.x;
                        newDisc.transform.position = new Vector3(colSelected,
                                                                BoardManager.DiscInitialPosition.y,
                                                                BoardManager.DiscInitialPosition.z);
                    }
                }


                // click the left mouse button to drop the piece into the selected column
                if (Input.GetMouseButtonDown(0)) // mouse button input event
                {
                    //are there cells available?
                    rowAvailable = Board.AreCellsAvailable((int)newDisc.transform.position.x);
                    if (rowAvailable > -1)
                    {
                        dropping = true;
                        Board.SetCell(Board.Grid[rowAvailable,colSelected], PieceID.P1);
                        newDisc.Drop(rowAvailable);
                        StopAllCoroutines();
                    }
                    
                }
                else
                {
                    dropping = false;
                }
            }

            yield return null;
        }
    }


}
