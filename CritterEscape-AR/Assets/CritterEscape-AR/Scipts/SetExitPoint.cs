using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class SetExitPoint : NetworkBehaviour
{
    public GameObject enterPoint;
    public GameObject exitPoint;
    private SpawnePrefab spawnePrefab;

    private int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        if (isServer)
        {
            spawnePrefab = GameObject.Find("NetworkSpawner").GetComponent<SpawnePrefab>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(enterPoint.GetComponent<TestTrigger>().zekeEnter && enterPoint.GetComponent<TestTrigger>().yukiEnter)
            enterPoint.SetActive(false);
        
        if (exitPoint.GetComponent<TestTrigger>().zekeEnter && exitPoint.GetComponent<TestTrigger>().yukiEnter && count == 0)
        {
            if (spawnePrefab != null)
            {
                spawnePrefab.setSpawn();
            }

            count = 1;
        } // 防止重复执行
    }
}
