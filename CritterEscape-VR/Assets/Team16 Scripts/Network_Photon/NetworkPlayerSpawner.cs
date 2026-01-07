using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Unity.XR.CoreUtils;
using UnityEngine.SceneManagement;

public enum PlayerRole{
    None,
    Zeke,
    Yuki
}

public class NetworkPlayerSpawner : MonoBehaviourPunCallbacks
{
    public static NetworkPlayerSpawner Instance;
    public static PlayerRole playerRole = PlayerRole.None;


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public static int getPlayerRoleInt() {
        if (playerRole == PlayerRole.Zeke) {
            return 1;
        }
        return 2;
    }

    void AssignPlayerRole()
    {
        if (playerRole == PlayerRole.None)
        {
            playerRole = PhotonNetwork.CurrentRoom.PlayerCount == 1 ? PlayerRole.Zeke : PlayerRole.Yuki;
            Debug.Log("You are assinged as " +  playerRole.ToString() + " .");
        }
    }

    private GameObject spawnedPlayerPrefab;

    void SpawnPlayer()
    {
        XROrigin rig = FindObjectOfType<XROrigin>();

        // Default position is set as XR Orgin's position
        Vector3 spawnPoint = rig.transform.position;
        string prefabName = null;

        if (SpawnPointManager.Instance != null)
        {
            int index = playerRole == PlayerRole.Zeke ? 0 : 1;
            prefabName = playerRole == PlayerRole.Zeke ? "Network Player Zeke" : "Network Player Yuki";
            if (index < SpawnPointManager.Instance.spawnPoints.Length)
            {
                spawnPoint = SpawnPointManager.Instance.spawnPoints[index].position;
            }
        }
        rig.transform.position = spawnPoint;

        spawnedPlayerPrefab = PhotonNetwork.Instantiate(prefabName, spawnPoint, Quaternion.identity);
    }

    
    public override void OnJoinedRoom(){
        base.OnJoinedRoom();
        AssignPlayerRole();
        SpawnPlayer();
        //spawnedPlayerPrefab = PhotonNetwork.Instantiate("Network Player", transform.position, transform.rotation); 
    }

    public override void OnLeftRoom(){
        base.OnLeftRoom();
        PhotonNetwork.Destroy(spawnedPlayerPrefab);
    }

    public override void OnEnable()
    {
        base.OnEnable();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public override void OnDisable()
    {
        base.OnDisable();
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (PhotonNetwork.IsConnectedAndReady)
        {
            AssignPlayerRole();
            SpawnPlayer(); // ����������ɺ�ʵ�������
        }
    }
}
