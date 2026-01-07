using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkShowDifferentObjects : MonoBehaviour
{

    public GameObject[] zekeCanSee;
    public GameObject[] yukiCanSee;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        decideObjectVisibility();
    }

    private void decideObjectVisibility() {
        if (NetworkPlayerSpawner.getPlayerRoleInt() == 1) {
            //Zeke
            foreach (GameObject zekeObject in zekeCanSee) {
                zekeObject.SetActive(true);
            }
            foreach (GameObject zekeNoSee in yukiCanSee) {
                zekeNoSee.SetActive(false);
            }
        }
        else {
            //Yuki (or None)
            foreach (GameObject yukiNoSee in zekeCanSee) {
                yukiNoSee.SetActive(false);
            }
            foreach (GameObject yukiObject in yukiCanSee) {
                yukiObject.SetActive(true);
            }
        }
    }
}
