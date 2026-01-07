using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.Events;

public class CheckWinningState : MonoBehaviour
{
    public GameObject[] objectsToMatch = new GameObject[4];
    public GameObject[] correctLocation = new GameObject[4];
    public GameObject winningStateObject;
    private PhotonView photonView;
    public UnityEvent onAnswerCorrect;
    public UnityEvent onAnswerIncorrect;
    // Start is called before the first frame update
    void Start()
    {
        if (photonView == null)
        {
            photonView = GetComponent<PhotonView>();
        }

        winningStateObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //winningStateObject.SetActive(false);
        //isThisWinningState();
        //Debug.Log(RePositionOnCollision.getAttatchedBricks());
    }

    protected void switchToWinnedState() {
        //winningStateObject.SetActive(true);
        Debug.Log("Cube Answer correct!"); 
        WinNetwork();
    }

    [PunRPC]
    public void WinRPC()
    {
        onAnswerCorrect?.Invoke();
    }

    public void WinNetwork()
    {
        photonView.RPC("WinRPC", RpcTarget.MasterClient);
    }

    private void isThisWinningState() {
        int i = 0;
        for (i = 0; i < 4; i++) {
            if (!areTheyInWinningState(objectsToMatch[i], correctLocation[i])) {
                break;
            }
        }
        //Debug.Log("i == " + i);
        if (i == 4) {
            switchToWinnedState();
        }
        else {
            loseHpNetwork();
        }
    }

    public void callWinningState() {
        isThisWinningState();
    }

    private bool areTheyInWinningState(GameObject object1, GameObject object2) {
        if (!isThisCloseEnough(object1, object2)) {
            return false;
        }
        if (!areTwoRotationsSimilar(object1, object2)) {
            return false;
        }
        return true;
    }

    private bool isThisCloseEnough(GameObject object1, GameObject object2) {
        //Debug.Log("Distance is " + Vector3.Distance(object1.transform.position, object2.transform.position));
        return (Vector3.Distance(object1.transform.position, object2.transform.position) < 0.5);
    }

    private bool areTwoRotationsSimilar(GameObject object1, GameObject object2) {
        float value = (object1.transform.rotation.eulerAngles.z - object2.transform.rotation.eulerAngles.z);
        return (-1 < value && value < 1);
    }

    [PunRPC]
    public void loseHpRPC() {
        HPManager.decreaseHealthPoint();
        onAnswerIncorrect?.Invoke();
        //Debug.Log("Wrong answer!");
    }

    public void loseHpNetwork()
    {
        photonView.RPC("loseHpRPC", RpcTarget.All);
    }
}
