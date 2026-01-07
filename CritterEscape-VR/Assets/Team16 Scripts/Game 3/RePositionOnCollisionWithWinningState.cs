using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RePositionOnCollisionWithWinningState : MonoBehaviour
{
    public int whichIndex;
    public GameObject winningStateObject;
    public GameObject[] targetObject;

    private int winningIndicateIndex = 0;

    void Start() {
        winningStateObject.SetActive(false);
    }

    void Update() {
        if (winningIndicateIndex == 4) {
            winningAction();
        }
        if (winningIndicateIndex != 0) {
            Debug.Log(winningIndicateIndex);
        }
    }
    
    void OnTriggerEnter(Collider other) {
        foreach (GameObject target in targetObject) {
            if (other.gameObject == target) {
            AttachToArea(target);
            }
        }
        if (other == targetObject[whichIndex]) {
            addWinningState();
        }
    }

    void OnTriggerExit(Collider other) {
        if (other == targetObject[whichIndex]) {
            minusWinningState();
        }
    }

    private void AttachToArea(GameObject target) {
        target.transform.position = transform.position;
        
        //Debug.Log(targetObject.transform.rotation.y);
        
        target.transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, target.transform.rotation.z);
        //targetObject.transform.Rotate(-(targetObject.transform.rotation.x), -(targetObject.transform.rotation.y), 0);
    }

    private void addWinningState() {
        winningIndicateIndex++;
    }

    private void minusWinningState() {
        winningIndicateIndex--;
    }

    private void winningAction() {
        winningStateObject.SetActive(true);
    }
}
