﻿using UnityEngine;
using DG.Tweening;

public class Disc : MonoBehaviour
{
    [SerializeField]
    private TypeDisc type;
    public TypeDisc Type
    {
        get
        {
            return type;
        }
        set
        {
            type = value;
        }
    }

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

    public void Drop(int cellYPosition)
    {
        //Set Z positon to zero
        transform.position = new Vector3(transform.position.x,
                                        transform.position.y,
                                        0f);

        //Start the animation to the bottom
        transform.DOMoveY(cellYPosition, 0.5f).OnComplete(OnBottom);
    }

    private void OnBottom()
    {
        //TODO Change Game Phase 
    }
}
