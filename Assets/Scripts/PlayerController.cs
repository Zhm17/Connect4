using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameManager Game => GameManager.Instance;
    [SerializeField]
    public Turn turnPlayer;
    [SerializeField]
    bool AI_enabled = false;

    private void Awake()
    {
        if (AI_enabled)
        {
            gameObject.AddComponent<AIController>();
        }
    }

    private void StartPlayer()
    {
        if (!AI_enabled)
        {
            StartCoroutine(MethodUpdate());
        }
    }

    // Update is called once per frame
    IEnumerator MethodUpdate()
    {
        while (Game.Turn == turnPlayer && Game.Phase == GamePhase.START)
        {


            yield return null;
        }
        
        StopAllCoroutines();
    }
}
