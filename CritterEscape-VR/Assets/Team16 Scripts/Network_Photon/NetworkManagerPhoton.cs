using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

[System.Serializable]
public class DefaultRoom
{
    public string name;
    public int sceneIndex;
    public int maxPlayer;
}
public class NetworkManagerPhoton : MonoBehaviourPunCallbacks
{
    public static NetworkManagerPhoton Instance;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        PhotonNetwork.AutomaticallySyncScene = true;
    }

    private void Start()
    {
        ConnectToServer();
    }


    public List<DefaultRoom> defaultRooms;

    public void ConnectToServer() {
        PhotonNetwork.ConnectUsingSettings();
        Debug.Log("Try to connect to server..."); 
    }

    public override void OnConnectedToMaster() {
        Debug.Log("Connected To Server.");
        base.OnConnectedToMaster();
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("A new player joined the lobby.");
        base.OnJoinedLobby();
        InitializeRoomWithRoomIndex(0); //possibly blocking generating new rooms
    }

    public void InitializeRoomWithRoomIndex(int defaultRoomIndex)
    {
        DefaultRoom roomSettings = defaultRooms[defaultRoomIndex];

        // LOAD SCENE
        PhotonNetwork.LoadLevel(roomSettings.sceneIndex);

        // CREATE THE ROOM
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = (byte)roomSettings.maxPlayer;
        roomOptions.IsVisible = true;
        roomOptions.IsOpen = true;

        PhotonNetwork.JoinOrCreateRoom(roomSettings.name, roomOptions, TypedLobby.Default);
    }
  
    public override void OnJoinedRoom() {
        Debug.Log("Joined a Room.");
        FadeScreen.Instance.FadeIn();
        base.OnJoinedRoom();
    }

    public override void OnPlayerEnteredRoom(Player newPlayer) {
        Debug.Log("A new player joined the room.");
        base.OnPlayerEnteredRoom(newPlayer);
    }
}
