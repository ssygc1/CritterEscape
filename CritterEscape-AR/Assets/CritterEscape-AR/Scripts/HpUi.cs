using UnityEngine;
using Mirror;

public class HpUi : NetworkBehaviour
{
    public int HP = 3;
    public GameObject[] hps = new GameObject[3];
    public GameObject[] hps2 = new GameObject[3];

    public void decreseHP()
    {
        hps[HP - 1].SetActive(false);
        hps2[HP - 1].SetActive(false);
        HP--;
        
        OVRInput.SetControllerVibration(1, 1, OVRInput.Controller.RTouch);
        OVRInput.SetControllerVibration(1, 1, OVRInput.Controller.LTouch);
        
        if (HP == 0)
        {
            GameObject.Find("NetworkSpawner").GetComponent<SpawnePrefab>().setEnd();
        }
    }

}
