using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGame1LockTrigger : MonoBehaviour
{
    public MiniGame1Door door;
    public bool isUsed = false;

    public PressSwitch pressSwitch;

    private PhotonView photonView;

    private void OnTriggerEnter(Collider other)
    {
        if (!isUsed)
        {
            door.LockDoorRPC();
            UseTriggerNetwork();
        }
        isUsed = true;
    }

    [PunRPC]
    public void UseTriggerRPC()
    {
        isUsed = true;
        pressSwitch.enabled = false;
    }

    public void UseTriggerNetwork()
    {
        photonView.RPC("UseTriggerRPC", RpcTarget.All);
    }
}
