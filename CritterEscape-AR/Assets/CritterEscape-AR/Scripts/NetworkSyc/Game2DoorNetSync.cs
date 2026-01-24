using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;
using UnityEngine.Events;


public class MiniGame1Door : NetworkBehaviour  // Inherit from NetworkBehaviour instead of MonoBehaviour
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
    private bool isLocked = true;

    public UnityEvent isOpen;
    public UnityEvent isClosed;

    [Command(requiresAuthority = false)]
    public void UnlockDoorRPC()
    {
        UnlockDoor();
    }
    
    [ClientRpc]
    public void UnlockDoor()
    {
        isLocked = false;
        OpenDoor(); // Open the door when unlocked
    }
    
    public void OpenDoor()
    {
        if (!isLocked)
        {
            isOpening = true;
            isOpen.Invoke();
            StartCoroutine(OpenDoorRoutine(openAngle)); 
        }
    }
    
    [Command(requiresAuthority = false)]
    public void CloseDoorRPC()
    {
        CloseDoor();
    }

    [ClientRpc]
    public void CloseDoor()
    {
        if (!isLocked)
        {
            isOpening = false;
            isClosed.Invoke();
            StartCoroutine(OpenDoorRoutine(closeAngle)); 
            isLocked = true;
        }
    }

    // Coroutine to animate door opening/closing
    private IEnumerator OpenDoorRoutine(float targetAngle)
    {
        bool originalState = isOpening;
        float startTime = Time.time;
        Vector3 startRotation = transform.localEulerAngles;
        Vector3 endRotation = new Vector3(startRotation.x, targetAngle, startRotation.z);

        while (Time.time < startTime + openDuration && (originalState == isOpening))
        {
            float t = (Time.time - startTime) / openDuration;
            transform.localEulerAngles = new Vector3(startRotation.x, Mathf.LerpAngle(startRotation.y, endRotation.y, t), startRotation.z);
            yield return null;
        }

        if (originalState == isOpening)
        {
            transform.localEulerAngles = endRotation; // Final door position
        }
    }
}
