using UnityEngine;

public class Spawner : Singleton<Spawner>
{
    [SerializeField]
    private GameObject prefab;

    protected override void Init()
    {
        prefab = Config.Game.Disc.gameObject;
    }

    /// <summary>
    /// Creating new instance of prefab.
    /// </summary>
    /// <returns>New instance of prefab.</returns>
    public Disc NewInstance(DiscID type, Vector3 position)
    {
        //Instantiate and set position
        Disc newDisc = Instantiate(prefab, position, Quaternion.identity, this.transform).GetComponent<Disc>();

        newDisc.Type = type;
        newDisc.UpdateColor();

        return newDisc;
    }

    public void Clean()
    {
        foreach (Disc d in transform.GetComponentsInChildren<Disc>(true))
        {
            Destroy(d.gameObject);
        }
    }
}
