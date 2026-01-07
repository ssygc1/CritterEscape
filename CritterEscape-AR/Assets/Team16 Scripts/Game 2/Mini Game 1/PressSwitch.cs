using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PressSwitch : MonoBehaviour
{
    public UnityEvent OnPressSwitch;
    public UnityEvent OnLeaveSwitch;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("My"))
        {
            OnPressSwitch?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("My"))
        {
            OnLeaveSwitch?.Invoke();
        }

    }
}
