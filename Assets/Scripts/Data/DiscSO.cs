using UnityEngine;

[CreateAssetMenu(fileName = "GameConfig", menuName = "ScriptableObjects/GameData/DiscSO", order = 1)]
public class DiscSO : ScriptableObject
{
    [SerializeField]
    public DiscID type;

    public Material[] materials;
}
