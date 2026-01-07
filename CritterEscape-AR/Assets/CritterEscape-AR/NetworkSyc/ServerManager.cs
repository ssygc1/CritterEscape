using Mirror;
using Mirror.Discovery;
using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;


public class ServerManager : MonoBehaviour
{
    public readonly Dictionary<long, ServerResponse> discoveredServers = new Dictionary<long, ServerResponse>();
    
    public NetworkDiscovery networkDiscovery;

    float RefreshTime;

    public GameObject[] LinkBtns;
    
    public float RelinkTime;
    public bool isZeke = false;

    public void setZeke()
    {
        isZeke = true;
    }

    #if UNITY_EDITOR
        void OnValidate()
        {
            if (networkDiscovery == null)
            {
                networkDiscovery = GetComponent<NetworkDiscovery>();
                UnityEditor.Events.UnityEventTools.AddPersistentListener(networkDiscovery.OnServerFound, OnDiscoveredServer);
                UnityEditor.Undo.RecordObjects(new Object[] { this, networkDiscovery }, "Set NetworkDiscovery");
            }
        }
#endif

    public void OnDiscoveredServer(ServerResponse info)
    {
        // Note that you can check the versioning to decide if you can connect to the server or not using this method
        discoveredServers[info.serverId] = info;
    }

    public void FindServers() //搜索房间
    {
        print("FindServers");
        discoveredServers.Clear();
        networkDiscovery.StartDiscovery();
    }

    public void StartHost() //创建房间
    {
        discoveredServers.Clear();
        NetworkManager.singleton.StartHost();
        networkDiscovery.AdvertiseServer();
    }

    public void ExitHost() //退出房间
    {
        if (NetworkServer.active && NetworkClient.isConnected) //房主
        {
            NetworkManager.singleton.StopHost();
            networkDiscovery.StopDiscovery();
        }
        else if (NetworkClient.isConnected) //客户端
        {
            NetworkManager.singleton.StopServer();
            networkDiscovery.StopDiscovery();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        FindServers();
    }

    // Update is called once per frame
    void Update()
    {

        RefreshTime += Time.deltaTime;

        if (RefreshTime > 1)
        {
            
            RefreshTime = 0;
        
            for(int i = 0; i < LinkBtns.Length; i++)
            {
                int a = i;

                LinkBtns[i].SetActive(false);
                LinkBtns[i].GetComponent<PointableUnityEventWrapper>().WhenRelease.RemoveAllListeners();
                LinkBtns[i].GetComponent<PointableUnityEventWrapper>().WhenRelease.AddListener(delegate {
                    LinkBtns[a].transform.GetChild(2).GetChild(1).GetComponent<AudioTrigger>().PlayAudio();
                });
            }
            
            int index = 0;
            foreach (ServerResponse info in discoveredServers.Values) 
            {
                LinkBtns[index].GetComponent<PointableUnityEventWrapper>().WhenRelease.AddListener(delegate {
                    Connect(info);
                });
                LinkBtns[index].transform.GetChild(1).GetChild(0).GetChild(1).GetComponent<TextMeshPro>().text = info.EndPoint.Address.ToString();
                LinkBtns[index].SetActive(true);
                index++;
            }
        }

        if (!NetworkManager.singleton.isNetworkActive)
        {
            RelinkTime += Time.deltaTime;
            if (RelinkTime >= 2)
            {
                RelinkTime = 0;
                
                if (isZeke)
                {
                    StartHost();
                }
                else
                {
                    foreach (ServerResponse info in discoveredServers.Values)
                    {
                        Connect(info);
                    }
                }
            }
        }
        
    }
    public void Connect(ServerResponse info)
    {
        networkDiscovery.StopDiscovery();
        NetworkManager.singleton.StartClient(info.uri);
    }
}
