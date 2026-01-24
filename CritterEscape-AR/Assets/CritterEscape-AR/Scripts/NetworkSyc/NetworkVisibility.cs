using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class NetworkVisibility : NetworkBehaviour
{
    public GameObject[] zekeCanSee;
    public GameObject[] yukiCanSee;

    void Start()
    {
        DecideObjectVisibility();
    }

    private void DecideObjectVisibility()
    {
        if (isServer) 
        {
            // Zeke
            foreach (GameObject obj in zekeCanSee) obj.SetActive(true);
            foreach (GameObject obj in yukiCanSee) obj.SetActive(false);
        }
        else 
        {
            // Yuki (or None)
            foreach (GameObject obj in zekeCanSee) obj.SetActive(false);
            foreach (GameObject obj in yukiCanSee) obj.SetActive(true);
        }
    }
}
