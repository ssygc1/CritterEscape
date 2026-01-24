using System.Collections;
using System.Collections.Generic;
using Telepathy;
using UnityEngine;

public class CheckHost : MonoBehaviour
{
    public ServerManager server;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("MRPlayer [connId=0]"))
        {
            server.setZeke();
        }
    }
}
