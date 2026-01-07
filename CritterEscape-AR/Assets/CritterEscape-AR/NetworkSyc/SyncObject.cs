using Mirror;
using Oculus.Interaction;
using Oculus.Interaction.HandGrab;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyncObject : NetworkBehaviour
{
    [SyncVar]
    public bool isInteraction;
    [SyncVar]
    public Vector3 localPosition;
    [SyncVar]
    public Quaternion localRotation;
    [SyncVar]
    public Vector3 localScale;

    public bool isLocalInteraction;
    public GrabInteractable[] grabInteractables;
    public HandGrabInteractable[] handGrabInteractables;
    // Start is called before the first frame update
    void Start()
    {
        localPosition = transform.parent.localPosition;
        localRotation = transform.parent.localRotation;
        localScale = transform.parent.localScale;
    }
    public void StartSync()
    {
        isLocalInteraction = true;
    }
    public void EndSync()
    {
        isLocalInteraction = false;
    }
    [Command(requiresAuthority = false)]
    public void StartSyncToServer()
    {
        isInteraction = true;
    }
    [Command(requiresAuthority = false)]
    public void EndSyncToServer()
    {
        isInteraction = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (isInteraction && !isLocalInteraction) 
        {
            for (int i = 0; i < grabInteractables.Length; i++)
            {
                grabInteractables[i].enabled = false;
            }
            for (int i = 0; i < handGrabInteractables.Length; i++)
            {
                handGrabInteractables[i].enabled = false;
            }
        }
        else
        {
            for (int i = 0; i < grabInteractables.Length; i++)
            {
                grabInteractables[i].enabled = true;
            }
            for (int i = 0; i < handGrabInteractables.Length; i++)
            {
                handGrabInteractables[i].enabled = true;
            }
        }
       if(isLocalInteraction)
        {
            SyncData(transform.parent.localPosition, transform.parent.localRotation, transform.parent.localScale);
        }
       else
        {
            SyncToObject();
        }
    }
    
    [Command(requiresAuthority = false)]
    void SyncData(Vector3 pos,Quaternion rot,Vector3 scale)
    {
        localPosition = pos;
        localRotation = rot;
        localScale = scale;
    }
    void SyncToObject()
    {
        transform.parent.localPosition = localPosition;
        transform.parent.localRotation = localRotation;
        transform.parent.localScale = localScale;
    }
}
