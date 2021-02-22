using System.Collections;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class AIController : MonoBehaviour
{

    private Disc newDisc = null;
    BoardManager Board => BoardManager.Instance;

    public void Init(Disc disc) {

        if (disc == null)
        {
            Debug.LogError("Disc is not found...!!");
            return;
        }

        newDisc = disc;

        StartCoroutine(AIMethodUpdate());
    }

    IEnumerator AIMethodUpdate()
    {
        while (true)
        {
            int colSelected = Random.Range(0, BoardManager.Columns);
            int rowAvailable = Board.AreCellsAvailable(colSelected);

            if (rowAvailable > -1)
            {
                Board.SetCell(Board.Grid[rowAvailable, colSelected], Piece.P2);

                yield return new WaitForSeconds(2f);
                newDisc.Drop(rowAvailable);
                StopAllCoroutines();
            }

            yield return null;
        }
    }
}
