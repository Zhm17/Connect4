using UnityEngine;

public class Disc : MonoBehaviour
{
    [SerializeField]
    public TypeDisc type;
    
    public void UpdateColor()
    {
        switch (type)
        {
            case TypeDisc.RED:
                SetColor(Config.Game.RedDisc.materials);
                break;
            case TypeDisc.YELLOW:
                SetColor(Config.Game.YellowDisc.materials);
                break;
        }
    }

    private void SetColor(Material[] mat)
    {
        GetComponent<Renderer>().materials = mat;
    }
}
