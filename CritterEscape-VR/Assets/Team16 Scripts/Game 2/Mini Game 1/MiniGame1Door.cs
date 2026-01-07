using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class MiniGame1Door : MonoBehaviour
{
    [SerializeField]
    private float openAngle;

    [SerializeField] 
    private float closeAngle;

    [SerializeField]
    private float openDuration = 1f;

    [SerializeField]
    private bool isOpening = false;

    [SerializeField]
    private bool isLocked = false;

    private PhotonView photonView;

    private void Start()
    {
        if (photonView == null)
        {
            photonView = GetComponent<PhotonView>();
        }
    }

    private void Update()
    {
        //if (input.getkeydown(keycode.a))
        //{
        //    opendoor();
        //}

        //if (input.getkeydown(keycode.b))
        //{
        //    closedoor();
        //}

        //if (input.getkeydown(keycode.c))
        //{
        //    lockdoor();
        //}
    }

    public void UnlockDoorNetwork()
    {
        photonView.RPC("UnlockDoorRPC", RpcTarget.All);
    }

    public void LockDoorNetwork()
    {
        photonView.RPC("LockDoorRPC", RpcTarget.All);
    }

    public void OpenDoorNetwork()
    {
        photonView.RPC("OpenDoorRPC", RpcTarget.All);
    }

    public void CloseDoorNetwork()
    {
        photonView.RPC("CloseDoorRPC", RpcTarget.All);
    }

    [PunRPC]
    public void UnlockDoorRPC()
    {
        isLocked = false;
        OpenDoorNetwork();
    }

    [PunRPC]
    public void LockDoorRPC()
    {
        CloseDoorNetwork();
        isLocked = true;
    }

    [PunRPC]
    public void OpenDoorRPC()
    {
        if (!isLocked)
        {
            isOpening = true;
            StartCoroutine(OpenDoorRoutine(openAngle));
        }
        
    }

    [PunRPC]
    public void CloseDoorRPC()
    {
        if (!isLocked)
        {
            isOpening = false;
            StartCoroutine(OpenDoorRoutine(closeAngle));
        }
    }

    private IEnumerator OpenDoorRoutine(float targetAngle)
    {
        bool originalState = isOpening;
        float startTime = Time.time;
        Vector3 startRotation = transform.localEulerAngles;
        Vector3 endRotation = new Vector3(startRotation.x, targetAngle, startRotation.z);

        while (Time.time < startTime + openDuration && (originalState == isOpening))
        {
            float t = (Time.time - startTime) / openDuration;

            transform.localEulerAngles = new Vector3(startRotation.x,
                Mathf.LerpAngle(startRotation.y, endRotation.y, t), startRotation.z);
            yield return null;
        }

        if (originalState == isOpening)
        {
            transform.localEulerAngles = endRotation;
        }
        
    }
}
