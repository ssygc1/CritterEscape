using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class OwnedByZeke : MonoBehaviour
{
    private PhotonView photonView;
    private bool isMine = false;
    // Start is called before the first frame update
    void Start()
    {
        if ( photonView == null )
        {
            photonView = GetComponent<PhotonView>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isMine && NetworkPlayerSpawner.getPlayerRoleInt() == 1 && !photonView.IsMine)
        {
            photonView.RequestOwnership();
            isMine = true;
        }
    }
}
