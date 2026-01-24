using UnityEngine;
using UnityEngine.Events;
using Mirror;

public class Check : NetworkBehaviour
{
    public GameObject[] objectsToMatch = new GameObject[4];
    public GameObject[] correctLocation = new GameObject[4];
    public GameObject winningStateObject;

    public bool isWinningState = false;
    public UnityEvent onAnswerCorrect;
    public UnityEvent onAnswerIncorrect;

    // Start is called before the first frame update
    void Start()
    {
        winningStateObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //winningStateObject.SetActive(false);
        isThisWinningState();
        //Debug.Log(RePositionOnCollision.getAttatchedBricks());
        
        print(areTheyInWinningState(objectsToMatch[1], correctLocation[1]));
    }

    protected void switchToWinnedState()
    {
        winningStateObject.SetActive(true);
        Debug.Log("Cube Answer correct!");
        isWinningState = true;
        //RpcAnswerCorrect();
    }

    /*
    [ClientRpc]
    public void RpcAnswerCorrect()
    {
        onAnswerCorrect.Invoke();
    }*/
    
    private void isThisWinningState()
    {
        int i = 0;
        for (i = 0; i < 4; i++)
        {
            if (!areTheyInWinningState(objectsToMatch[i], correctLocation[i]))
            {
                break;
            }
        }

        Debug.Log("i == " + i);

        if (i == 4)
        {
            switchToWinnedState();
        }

    }

    public void callWinningState()
    {
        isThisWinningState();
    }

    private bool areTheyInWinningState(GameObject object1, GameObject object2)
    {
        if (!isThisCloseEnough(object1, object2))
        {
            return false;
        }
        if (!areTwoRotationsSimilar(object1, object2))
        {
            return false;
        }
        return true;
    }

    private bool isThisCloseEnough(GameObject object1, GameObject object2)
    {
        //Debug.Log("Distance is " + Vector3.Distance(object1.transform.position, object2.transform.position));
        return (Vector3.Distance(object1.transform.position, object2.transform.position) < 0.2);
    }

    private bool areTwoRotationsSimilar(GameObject object1, GameObject object2)
    {
        float value = (object1.transform.rotation.eulerAngles.z - object2.transform.rotation.eulerAngles.z);
        return (-2 < value && value < 2);
    }
    
}

