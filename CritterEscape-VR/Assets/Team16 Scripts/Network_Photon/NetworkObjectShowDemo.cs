using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkObjectShowDemo : MonoBehaviour
{
    public GameObject object1;
    public GameObject object2;
    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        if (NetworkPlayerSpawner.getPlayerRoleInt() == 1) {
            //Zeke
            object1.SetActive(false);
            object2.SetActive(true);
        }
        else {
            //Yuki (or None)
            object2.SetActive(false);
            object1.SetActive(true);
        }
    }
}
