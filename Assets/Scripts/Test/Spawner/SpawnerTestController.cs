﻿using UnityEngine;
using UnityEngine.UI;

public class SpawnerTestController : MonoBehaviour
{
    public Button RedDiscBtn;
    public Button YellowDiscBtn;

    private Spawner Spawner => Spawner.Instance;

    // Start is called before the first frame update
    void Start()
    {
        RedDiscBtn.onClick.AddListener(() => Spawner.NewInstance(DiscID.RED, Vector3.zero));
        YellowDiscBtn.onClick.AddListener(() => Spawner.NewInstance(DiscID.YELLOW, Vector3.zero));
    }

}
