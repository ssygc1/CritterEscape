using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NewBehaviourScript : MonoBehaviour
{
    public bool isPoke = false;

    public UnityEvent isPokeEvent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isPoke)
        {
            isPokeEvent.Invoke();
            isPoke = false;
        }
    }
}
