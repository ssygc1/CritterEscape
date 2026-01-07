using Mirror;
using UnityEngine;

public class TestTrigger : NetworkBehaviour
{
    public bool zekeEnter = false;
    
    public bool yukiEnter = false;
    
    public bool isCompleted = false;

    private int count = 0;
    private SpawnePrefab spawnePrefab;

    public void setCompleted()
    {
        isCompleted = true;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("My") && isCompleted)
        {
            Debug.Log("Player entered the trigger!");
            if (isServer)
            {
                ZekeEnter();
            }
            else
            {
                YukiEnter();
            }
        }
    }
  

    void Start()
    {
        if (isServer)
        {
            spawnePrefab = GameObject.Find("NetworkSpawner").GetComponent<SpawnePrefab>();
        }
    }
    
    private void Update()
    {
        if (isServer && count == 0 && zekeEnter && yukiEnter)
        {
            if (spawnePrefab != null)
            {
                spawnePrefab.setSpawn();
            }
            count = 1;
        }
    }

    public void SetSpawn()
    {
        spawnePrefab.setSpawn();
    }

    [Command(requiresAuthority = false)]
    public void ZekeEnter()
    {
        ZekeEnterRpc();
    }
    
    [Command(requiresAuthority = false)]
    public void YukiEnter()
    {
        YukiEnterRpc();
    }

    [ClientRpc]
    public void ZekeEnterRpc()
    {
        zekeEnter = true;
    }

    [ClientRpc]
    public void YukiEnterRpc()
    {
        yukiEnter = true;
    }
}
