using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.Events;

public class CheckGame3Answer : NetworkBehaviour
{
    public GameObject winningStateObject;

    public UnityEvent winEvent;
    public UnityEvent loseEvent;

    [Command(requiresAuthority = false)]
    public void CheckAnswer()
    {
        CheckAnswerClientRpc();
    }

    [ClientRpc]
    public void CheckAnswerClientRpc()
    {
        if (winningStateObject.activeSelf)
        {

            winEvent.Invoke();
        }
        else
        {
            loseEvent.Invoke();
        }
    }
}
