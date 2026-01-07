using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class RotatePlateNetwork : MonoBehaviour
{
    [SerializeField]
    private RotatePlate rotatePlateLocal;

    [SerializeField]
    private PhotonView photonView;

    private void Start()
    {
        if (rotatePlateLocal == null)
        {
            rotatePlateLocal = GetComponent<RotatePlate>();
        }

        if (photonView == null)
        {
            photonView = GetComponent<PhotonView>();
        }
    }

    [PunRPC]
    public void ConfirmSelectionRPC()
    {
        rotatePlateLocal.ConfirmSelection();
    }

    [PunRPC]
    public void RotateLeftRPC()
    {
        rotatePlateLocal.RotateLeft();
    }

    [PunRPC]
    public void RotateRightRPC()
    {
        rotatePlateLocal.RotateRight();
    }

    public void ConfirmSelectionNetwork()
    {
        photonView.RPC("ConfirmSelectionRPC", RpcTarget.All);
    }

    public void RotateLeftNetwork()
    {
        photonView.RPC("RotateLeftRPC", RpcTarget.All);
    }

    public void RotateRightNetwork()
    {
        photonView.RPC("RotateRightRPC", RpcTarget.All);
    }
}
