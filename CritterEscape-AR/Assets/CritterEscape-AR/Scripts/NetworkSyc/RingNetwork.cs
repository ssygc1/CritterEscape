using Mirror;
using UnityEngine;

public class RingNetwork : NetworkBehaviour
{
    [SerializeField]
    private RotatePlate rotatePlateLocal;

    private void Start()
    {
        if (rotatePlateLocal == null)
        {
            rotatePlateLocal = GetComponent<RotatePlate>();
        }
    }

    [Command(requiresAuthority = false)]
    public void ConfirmSelectionServer()
    {
        ConfirmSelectionClientRpc();
    }

    [Command(requiresAuthority = false)]
    public void RotateLeftServer()
    {
        RotateLeftClientRpc();
    }

    [Command(requiresAuthority = false)]
    public void RotateRightServer()
    {
        RotateRightClientRpc();
    }

    [ClientRpc] // Runs on all clients
    public void ConfirmSelectionClientRpc()
    {
        rotatePlateLocal.ConfirmSelection();
    }

    [ClientRpc] 
    public void RotateLeftClientRpc()
    {
        rotatePlateLocal.RotateLeft();
    }

    [ClientRpc] 
    public void RotateRightClientRpc()
    {
        rotatePlateLocal.RotateRight();
    }

    public void ConfirmSelectionNetwork()
    {
        if (isServer)
            ConfirmSelectionClientRpc();
        else
            ConfirmSelectionServer();
    }

    public void RotateLeftNetwork()
    {
        if (isServer)
            RotateLeftClientRpc();
        else
            RotateLeftServer();
    }

    public void RotateRightNetwork()
    {
        if (isServer)
            RotateRightClientRpc();
        else
            RotateRightServer();
    }
}
