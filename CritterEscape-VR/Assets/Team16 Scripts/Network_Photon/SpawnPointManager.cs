using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointManager : MonoBehaviour
{
    public static SpawnPointManager Instance;

    public Transform[] spawnPoints;

    void Awake()
    {
        Instance = this;
    }
}
