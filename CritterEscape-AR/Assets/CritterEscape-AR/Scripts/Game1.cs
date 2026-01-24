using UnityEngine;
using Mirror;
using UnityEngine.Events;

public class Game1 : NetworkBehaviour
{
    public GameObject[] doors = new GameObject[2];
    public UnityEvent isGame1Finished;
    
    void Update()
    {
        if (doors[0].GetComponent<JailDoor>().isOpen && doors[1].GetComponent<JailDoor>().isOpen)
        {
            isGame1Finished.Invoke();
        }
    }
}
