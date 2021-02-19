using UnityEngine;

public class Spawner : Singleton<Spawner>
{
    private GameObject prefab;

    void Start()
    {
        prefab = Config.Game.Disc.gameObject;
    }

    /// <summary>
    /// Creating new instance of prefab.
    /// </summary>
    /// <returns>New instance of prefab.</returns>
    public Disc NewInstance(TypeDisc type, Vector3 position)
    {
        //Instantiate and set position
        Disc newDisc = Instantiate(prefab, position, Quaternion.identity, this.transform).GetComponent<Disc>();

        newDisc.type = type;
        newDisc.UpdateColor();

        return newDisc;
    }
}
