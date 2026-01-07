
using Mirror;
using UnityEngine;

public class Game2 : NetworkBehaviour
{
    public GameObject obj;
    private int count = 0;
    private SpawnePrefab spawnePrefab;

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
        if (!isServer) return; 
        
        if (obj.transform.GetComponent<Cauldron>().isCompleted && (GameObject.Find("Exit Point").GetComponent<TestTrigger>().zekeEnter) && (GameObject.Find("Exit Point").GetComponent<TestTrigger>().yukiEnter) && count ==0 )
        {
            Debug.Log("Game2 finish");
            
            if (spawnePrefab != null)
            {
                spawnePrefab.setSpawn();
            }

            count = 1; // 防止重复执行
        }
    }
    
    
}
