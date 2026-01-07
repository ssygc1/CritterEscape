using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Photon.Pun;

public class ExitPoint : MonoBehaviour
{
    [SerializeField]
    private UnityEvent onEnterExitPoint;

    private PhotonView photonView;

    private void Start()
    {
        photonView = GetComponent<PhotonView>();
    }

//#if !UNITY_EDITOR

//    private void OnTriggerEnter(Collider other)
//    {
//        if (other.CompareTag("Player"))
//        {
//            onEnterExitPoint?.Invoke();
//        }
//    }

//#else

    private int yuki = 0;
    private int zeke = 0;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (PhotonNetwork.IsMasterClient)
            {
                ZekeEnterNetwork();
            }
            else
            {
                YukiEnterNetwork();
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (PhotonNetwork.IsMasterClient)
            {
                ZekeExitNetwork();
            }
            else
            {
                YukiExitNetwork();
            }
        }
    }

    [PunRPC]
    public void ZekeEnterRPC()
    {
        zeke = 1;
        if (yuki + zeke == 2)
        {
            if (PhotonNetwork.IsMasterClient)
            {
                onEnterExitPoint?.Invoke();
            }
            
        }
    }

    [PunRPC]
    public void YukiEnterRPC()
    {
        yuki = 1;
        if (yuki + zeke == 2)
        {
            if (PhotonNetwork.IsMasterClient)
            {
                onEnterExitPoint?.Invoke();
            }
        }
    }

    [PunRPC]
    public void ZekeExitRPC()
    {
        zeke = 0;
    }

    [PunRPC]
    public void YukiExitRPC()
    {
        yuki = 0;
    }

    public void ZekeEnterNetwork()
    {
        photonView.RPC("ZekeEnterRPC", RpcTarget.All);
    }

    public void YukiEnterNetwork()
    {
        photonView.RPC("YukiEnterRPC", RpcTarget.All);
    }

    public void ZekeExitNetwork()
    {
        photonView.RPC("ZekeExitRPC", RpcTarget.All);
    }

    public void YukiExitNetwork()
    {
        photonView.RPC("YukiExitRPC", RpcTarget.All);
    }
//#endif
}


