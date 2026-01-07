using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.Events;

public class Cauldron : MonoBehaviour
{
    [Header("Values")]
    [Tooltip("Target value of pot")]
    [SerializeField]
    public int targetValue;

   
    [Tooltip("Current value of the pot")]
    [SerializeField]
    private int currentValue = 0;

    [Tooltip("Chest lid to open")]

    public UnityEvent onPotionsCorrect;
    public UnityEvent onPotionsIncorrect;
    private PhotonView photonView;

    private void Start()
    {
        if (photonView == null)
        {
            photonView = GetComponent<PhotonView>();
        }
    }

    public void AddBottleValueToPot(int value)
    {
        currentValue += value;

        if (currentValue >= targetValue)
        {
            ConfirmNetwork();
        }
    }

    public void ResetCauldron()
    {
        currentValue = 0;
    }

    [PunRPC]
    public void ConfirmRPC()
    {
        if (currentValue == targetValue)
        {
            Debug.Log("Potion成功到达目标值");
            onPotionsCorrect?.Invoke();

        }
        else if (currentValue > targetValue)
        {
            Debug.Log("Potion超过目标值");
            onPotionsIncorrect?.Invoke();
            MiniGame1Manager.Instance.RestartMiniGame1();

        }
    }

    public void ConfirmNetwork()
    {
        photonView.RPC("ConfirmRPC", RpcTarget.All);
    }

    /*
     virtual protected void onWrongAnswer() {
        
    }
     */
}
