using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Test : MonoBehaviour
{
    public bool isSet = false;
    public UnityEvent unityEvent;
    private int count = 0;

    // Update is called once per frame
    void Update()
    {
        if (isSet && count == 0)
        {
            //GameObject.Find("Ring Network Left").GetComponent<RingNetwork>().RotateLeftNetwork();
            isSet = false;
            unityEvent.Invoke();
            
        }

    }
}
