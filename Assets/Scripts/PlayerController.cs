using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    public Turn turnPlayer;
    [SerializeField]
    bool AI_enabled = false;

    [SerializeField]
    private Vector3 discInitPos = new Vector3(0,6f,-0.11f);

    private Disc newDisc = null;

    private int colSelected = 0;
    private int rowAvailable = 0;

    private bool dropping = false;


    private AIController AI_Controller;

    private GameManager Game => GameManager.Instance;
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

        if (Game.Turn == turnPlayer)
        {
            if (newDisc == null)
            {
                dropping = false;
                newDisc = Spawner.NewInstance((Game.Turn == Turn.Player1) ? TypeDisc.RED : TypeDisc.YELLOW,
                                                discInitPos);
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
                                                                discInitPos.y,
                                                                discInitPos.z);
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
                        Board.SetCell(Board.Grid[rowAvailable,colSelected], Piece.P1);
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
