using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class ChestLid : NetworkBehaviour
{
    [SerializeField]
    private float openAngle = -70f;

    [SerializeField]
    private float openDuration = 2f;

    public FloatingKey key;

    public bool isOpened = false;

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Escape))
    //    {
    //        OpenLid();
    //    }
    //}
    [Command(requiresAuthority = false)]
    public void OpenLid()
    {
        OpenLidRPC();
    }
    
    [ClientRpc]
    public void OpenLidRPC()
    {
        isOpened = true;
        StartCoroutine(OpenLidRoutine());
    }
    
    private IEnumerator OpenLidRoutine()
    {
        float startTime = Time.time;
        Vector3 startRotation = transform.localEulerAngles;
        Vector3 endRotation = new Vector3(openAngle, startRotation.y, startRotation.z);

        while(Time.time < startTime + openDuration)
        {
            float t = (Time.time - startTime) / openDuration;

            transform.localEulerAngles = new Vector3(Mathf.LerpAngle(startRotation.x, endRotation.x, t),
                startRotation.y, startRotation.z);
            yield return null;
        }
        transform.localEulerAngles = endRotation;

        key.StartKeyActions();
    }

    public bool IsOpened()
    {
        return isOpened;
    }
}
