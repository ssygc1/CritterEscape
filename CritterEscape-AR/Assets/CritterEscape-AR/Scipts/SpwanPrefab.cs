using Mirror;
using UnityEngine;
using UnityEngine.Events;

public class SpawnePrefab : NetworkBehaviour
{
    public GameObject[] prefab;

    [SyncVar]
    public int index = 0;

    public bool isSpawn = false;

    public bool isReload = false;
    
    public bool isTesting = false;

    public Transform root;
    
    [SyncVar]
    public int currentGameLevel = 1;
    
    public UnityEvent OnStartGame;
    
    private int count = 0;

    void Start()
    {
        OnStartGame.Invoke();
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("PreCheck"))
        {
            obj.SetActive(false);
        }
    }
    
    public void setTesting()
    {
        isTesting = true;
        print("is testing");
    }

    public void setNotTesting()
    {
        isTesting = false;
        print("is no testing");
    }
    
    public void setSpawn()
    {
        isSpawn = true;
    }

    public void setReload()
    {
        isReload = true;
    }
    
    private void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Player").Length == 2 && count == 0)
        {
            setSpawn();
            count = 1;
        }
        
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Prefab"))
        {
            obj.transform.SetParent(root);
            obj.transform.localPosition = Vector3.zero;
            obj.transform.localEulerAngles = Vector3.zero;
        }

        if (isSpawn && isServer && (GameObject.FindGameObjectsWithTag("Player").Length == 2 || isTesting))
        { 
            if(index != 0)
            {
                CmdDestroyObject(index - 1);
                CmdSpawnObject(Vector3.zero, index);
                
                isSpawn = false;
            }
            else
            {
                CmdSpawnObject(Vector3.zero, 0);
                isSpawn = false;
            }
            print("index = "+ index);
            index++;
        }
        
        
        if(isServer && isReload && !isSpawn && (GameObject.FindGameObjectsWithTag("Player").Length == 2  || isTesting))
        {
            CmdDestroyObject(index - 1);
            CmdSpawnObject(Vector3.zero, index - 1);
            isReload = false;
        }

    }

    [Command(requiresAuthority = false)]
    public void CmdSpawnObject(Vector3 position, int i)
    {
        if (i == 1)
        {
            currentGameLevel = 1;
        }

        if (i == 3)
        {
            currentGameLevel = 2;
        }
        
        if (i == 5)
        {
            currentGameLevel = 3;
        }
        
        GameObject spawnedObject = Instantiate(prefab[i], position, Quaternion.identity);
        spawnedObject.transform.SetParent(root, true);
        Debug.Log("ssss" + prefab[i]);
        NetworkServer.Spawn(spawnedObject);
    }
    
    
    [Command(requiresAuthority = false)]
    public void CmdDestroyObject(int i)
    {
        string name = prefab[i].name + "(Clone)";
        GameObject obj = GameObject.Find(name);

        if(obj != null)
            NetworkServer.Destroy(obj);
    }

    
    [Command(requiresAuthority = false)]
    public void setEnd()
    {
        if (isServer)
        {
            CmdDestroyObject(index - 1);
            
            OVRInput.SetControllerVibration(1, 0.5f, OVRInput.Controller.RTouch);
            OVRInput.SetControllerVibration(1, 0.5f, OVRInput.Controller.LTouch);
            
            if(currentGameLevel == 1)
                CmdSpawnObject(Vector3.zero, 9);
            if (currentGameLevel == 2)
                CmdSpawnObject(Vector3.zero, 8);
                
            if(currentGameLevel == 3)
                CmdSpawnObject(Vector3.zero, 7);
        }
    }

    [Command(requiresAuthority = false)]
    public void restartGame()
    {
        if (isServer)
        {
            if (index != 0)
            {
                for (int i = 0; i < prefab.Length; i++)
                {
                    CmdDestroyObject(i);
                }
            }
            else
            {
                return;
            }

            index = 0;
            currentGameLevel = 1;
        }
    }
}
