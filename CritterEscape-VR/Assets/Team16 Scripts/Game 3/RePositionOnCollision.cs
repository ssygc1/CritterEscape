using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RePositionOnCollision : MonoBehaviour
{

    public GameObject[] targetObject;

    private float zAxisSaver;
    private static int attatchedBricks = 0;

    void Update() {
        //decideToDecreaseHP();
    }

    public static int getAttatchedBricks() {
        return attatchedBricks;
    }

    protected void OnTriggerEnter(Collider other) {
        zAxisSaver = other.gameObject.transform.rotation.eulerAngles.z;
        //Debug.Log(other.transform.rotation.z + " and " + zAxisSaver);
        foreach (GameObject target in targetObject) {
            if (other.gameObject == target) {
            AttachToArea(target);
            }
        }
    }

    protected void OnTriggerExit(Collider other) {
        foreach (GameObject target in targetObject) {
            if (other.gameObject == target) {
                aBrickLeft();
            }
        }
    }
    private void AttachToArea(GameObject target) {
        target.transform.position = transform.position;
        
        //Debug.Log(targetObject.transform.rotation.y);
        
        //target.transform.rotation = new Rotation(0, -180, zAxisSaver);
        target.transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, zAxisSaver);
        aBrickEntered();
        //targetObject.transform.Rotate(-(targetObject.transform.rotation.x), -(targetObject.transform.rotation.y), 0);
    }

    private void aBrickEntered() {
        attatchedBricks++;
        //decideToDecreaseHP();
    }
    private void aBrickLeft() {
        attatchedBricks--;
    }

    public void decideToDecreaseHP() {
        if (attatchedBricks == 4) {
            CheckWinningState checkWinningState = FindObjectOfType<CheckWinningState>();
            checkWinningState.callWinningState();
        }
    }
}
