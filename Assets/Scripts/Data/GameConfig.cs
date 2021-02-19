using UnityEngine;

[CreateAssetMenu(fileName = "GameConfig", menuName = "ScriptableObjects/GameConfig", order = 1)]
public class GameConfig : ScriptableObject
{
    [Header("SO Properties")]
    public DiscSO RedDisc;
    public DiscSO YellowDisc;

    //Prefab
    [Header("Prefab")]
    public Disc Disc;
}
