using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game2Gate : MonoBehaviour
{

    public bool isDoorOpened = false;

    public ChestLid[] chestLids;

    public JailDoor[] jailDoors;

    public GameObject exitPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDoorOpened)  //如果Gate还没开过，循环
        {
            foreach (var chest in chestLids) //如果
            {
                if (!chest.IsOpened())
                {
                    return;
                }
            }

            foreach (var door in jailDoors)
            {
                door.OpenJailDoor();
            }

            exitPoint.SetActive(true);

            isDoorOpened = true;
        }
    }
}
