using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PressSwitch : MonoBehaviour
{
    
    public UnityEvent OnPressSwitch;
    public UnityEvent OnLeaveSwitch;

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    OnPressSwitch?.Invoke();
        //}

        //if (Input.GetKeyDown(KeyCode.B))
        //{
        //    OnLeaveSwitch?.Invoke();
        //}
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnPressSwitch?.Invoke();
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnLeaveSwitch?.Invoke();
        }

    }
}
