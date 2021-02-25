using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    bool AI_enabled = false;

    public Disc newDisc = null;

    private int colSelected = 0;
    private int rowAvailable = 0;

    private AIController AI_Controller;

    private TurnPlayerComponent TurnPlayer => GameManager.Instance.TurnPlayer;
    private BoardManager Board => BoardManager.Instance;
    private Spawner Spawner => Spawner.Instance;


    private void Awake()
    {
        if (AI_enabled)
        {
            AI_Controller = gameObject.AddComponent<AIController>();
        }
    }


    public void Play()
    {
        Init();
    }

    private void Init()
    {
        rowAvailable = 0;
        colSelected = 0;

        if (newDisc == null)
        {
            newDisc = Spawner.NewInstance( ((TurnPlayer.CurrentTurnPlayer == TurnPlayerID.PLAYER_1) ? 
                                            DiscID.RED : DiscID.YELLOW),
                                            BoardManager.DiscInitialPosition);
        }

        if (!Board.IsBoardFull())
        {
            if (!AI_enabled)
            {
                StartCoroutine(PlayerMethodUpdate());
            }
            else
            {
                AI_Controller.Init();
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
                Debug.Log("Cell Available = [" + colSelected + "," +  rowAvailable + "]");


                if (rowAvailable > -1)
                {
                    Board.SetCell(new Vector2(colSelected, rowAvailable),
                                     (PieceID)((int)TurnPlayer.CurrentTurnPlayer));
                    
                    newDisc.Drop(rowAvailable);
                    newDisc = null;

                    //Switch Phase
                    TurnPlayer.EndPhase();
                    StopAllCoroutines();
                }
                    
            }

            yield return null;
        }
    }


}
