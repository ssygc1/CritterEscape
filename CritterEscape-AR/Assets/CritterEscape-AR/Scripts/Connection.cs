using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using TMPro; // Correct namespace for UI components

public class Connection : NetworkBehaviour
{
    public TMP_Text text;  // Reference to the UI Text component

    // Update is called once per frame
    void Update()
    {
        // Check if there are no connections to the server
        if (NetworkServer.connections.Count == 0)
        {
            text.text = "No connection";  
        }

        if (NetworkServer.connections.Count == 1)
        {
            text.text = "The Room created!";
        }

        if (NetworkServer.connections.Count == 2)
        {
            text.text = "Yuki is joining!";
        }

        if(!isServer)
        {
            text.text = "Join Zeke's room!";
        }
    }
}
