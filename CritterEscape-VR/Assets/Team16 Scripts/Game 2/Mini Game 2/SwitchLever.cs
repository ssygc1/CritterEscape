using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SwitchLever : MonoBehaviour
{
    [SerializeField]
    private float turnOnAngle = -35f;

    [SerializeField]
    private float turnOffAngle = 35f;

    [SerializeField]
    private float animateDuration = 1.0f;

    [SerializeField]
    private bool isTurnOn = false;

    [SerializeField]
    private UnityEvent onToggleSwitchLever;

    public void ToggleSwitchLever()
    {
        if (isTurnOn)
        {
            isTurnOn = false;
            StartCoroutine(turnOffLeverRoutine());
        }
        else
        {
            isTurnOn=true;
            StartCoroutine(turnOnLeverRoutine());
        }

        onToggleSwitchLever?.Invoke();
    }

    private IEnumerator turnOnLeverRoutine()
    {
        float startTime = Time.time;
        Vector3 startRotation = transform.localEulerAngles;
        Vector3 endRotation = new Vector3(turnOnAngle, startRotation.y, startRotation.z);

        while (Time.time < startTime + animateDuration)
        {
            float t = (Time.time - startTime) / animateDuration;

            transform.localEulerAngles = new Vector3(Mathf.LerpAngle(startRotation.x, endRotation.x, t),
                startRotation.y, startRotation.z);
            yield return null;
        }
        transform.localEulerAngles = endRotation;
    }

    private IEnumerator turnOffLeverRoutine()
    {
        float startTime = Time.time;
        Vector3 startRotation = transform.localEulerAngles;
        Vector3 endRotation = new Vector3(turnOffAngle, startRotation.y, startRotation.z);

        while (Time.time < startTime + animateDuration)
        {
            float t = (Time.time - startTime) / animateDuration;

            transform.localEulerAngles = new Vector3(Mathf.LerpAngle(startRotation.x, endRotation.x, t),
                startRotation.y, startRotation.z);
            yield return null;
        }
        transform.localEulerAngles = endRotation;
    }
}
