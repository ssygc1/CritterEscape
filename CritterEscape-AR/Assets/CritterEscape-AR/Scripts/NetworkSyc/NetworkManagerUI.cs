using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class NetworkManagerUI : MonoBehaviour
{
    public NetworkManager manager;
    public Button hostButton, clientButton, serverButton, stopButton;
    public InputField ipInputField ;

    void Start()
    {
        // 绑定按钮事件
        hostButton.onClick.AddListener(StartHost);
        clientButton.onClick.AddListener(StartClient);
        serverButton.onClick.AddListener(StartServer);
        stopButton.onClick.AddListener(StopNetwork);
    }

    void Update()
    {
        UpdateStatus();
    }

    public void StartHost()
    {
        manager.StartHost();
    }

    public void StartClient()
    {
        manager.networkAddress = "localhost";
        manager.StartClient();
    }

    public void StartServer()
    {
        manager.StartServer();
    }

    public void StopNetwork()
    {
        if (NetworkServer.active && NetworkClient.isConnected)
            manager.StopHost();
        else if (NetworkClient.isConnected)
            manager.StopClient();
        else if (NetworkServer.active)
            manager.StopServer();
    }

    void UpdateStatus()
    {
    }
}
