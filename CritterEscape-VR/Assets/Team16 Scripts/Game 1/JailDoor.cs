using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JailDoor : MonoBehaviour
{
    [SerializeField]
    private float openAngle;

    [SerializeField]
    private float openDuration = 2f;

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Escape))
        //{
        //    OpenJailDoor();
        //}
    }

    public void OpenJailDoor()
    {
        StartCoroutine(OpenJailDoorRoutine());
    }

    private IEnumerator OpenJailDoorRoutine()
    {
        float startTime = Time.time;
        Vector3 startRotation = transform.localEulerAngles;
        Vector3 endRotation = new Vector3(startRotation.x, openAngle, startRotation.z);

        while (Time.time < startTime + openDuration)
        {
            float t = (Time.time - startTime) / openDuration;

            transform.localEulerAngles = new Vector3(startRotation.x,
                Mathf.LerpAngle(startRotation.y, endRotation.y, t), startRotation.z);
            yield return null;
        }
        transform.localEulerAngles = endRotation;
    }
}
