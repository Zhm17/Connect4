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

    private bool dropping = false;

    private GameManager Game => GameManager.Instance;
    private BoardManager Board => BoardManager.Instance;
    private Spawner Spawner => Spawner.Instance;

    private void Awake()
    {
        if (AI_enabled)
        {
            gameObject.AddComponent<AIController>();
        }
    }

    void Start()
    {
        StartPlayer();
    }

    private void StartPlayer()
    {
        if (Game.Turn == turnPlayer)
        {
            if (newDisc == null)
            {
                dropping = false;
                newDisc = Spawner.NewInstance((Game.Turn == Turn.Player1) ? TypeDisc.RED : TypeDisc.YELLOW,
                                                discInitPos);
            }
        }

        if (!AI_enabled)
        {
            StartCoroutine(PlayerMethodUpdate());
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
                        newDisc.transform.position = new Vector3(objectHit.position.x,
                                                                discInitPos.y,
                                                                discInitPos.z);
                    }
                }


                // click the left mouse button to drop the piece into the selected column
                if (Input.GetMouseButtonDown(0)) // mouse button input event
                {
                    //are there cells available?
                    int availableCell = Board.AreCellsAvailable((int)newDisc.transform.position.x);
                    if (availableCell > -1)
                    {
                        dropping = true;
                        newDisc.Drop(availableCell);
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
