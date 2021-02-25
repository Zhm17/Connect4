using System.Collections;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class AIController : MonoBehaviour
{
    private Disc newDisc = null;
    BoardManager Board => BoardManager.Instance;
    private TurnPlayerManager TurnPlayer => GameManager.Instance.TurnPlayer;

    public void Init() {

        newDisc = GetComponent<PlayerController>().newDisc;

        if (newDisc == null)
        {
            Debug.LogError("Disc is not found...!!");
            return;
        }

        StartCoroutine(AIMethodUpdate());
    }

    IEnumerator AIMethodUpdate()
    {
        while (true)
        {
            //Random selection
            int colSelected = Random.Range(0, BoardManager.Columns);
            int rowAvailable = Board.AreCellsAvailable(colSelected);

            Debug.Log("Cell Available = [" + colSelected + "," + rowAvailable + "]");

            newDisc.transform.position= new Vector3(colSelected, 
                                                    newDisc.transform.position.y, 
                                                    newDisc.transform.position.z);

            if (rowAvailable > -1)
            {
                Board.SetCell(new Vector2(colSelected, rowAvailable), 
                                (PieceID)((int)TurnPlayer.CurrentTurnPlayer));

                yield return new WaitForSeconds(1.5f);
                newDisc.Drop(rowAvailable);
                GetComponent<PlayerController>().newDisc = newDisc = null;

                //Switch Phase
                TurnPlayer.EndPhase();
                StopAllCoroutines();
            }

            yield return null;
        }
    }
}
