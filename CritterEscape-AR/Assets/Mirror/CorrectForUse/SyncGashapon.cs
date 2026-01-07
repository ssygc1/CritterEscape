using Mirror;
using Oculus.Interaction;
using Oculus.Interaction.HandGrab;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyncGashapon : NetworkBehaviour
{
    [SyncVar]
    public bool isInteraciton;
    [SyncVar]
    public Vector3 localPosition;
    [SyncVar]
    public Quaternion localRotation;
    [SyncVar]
    public Vector3 localScale;

    public bool isLocalInteraction;
    public GrabInteractable[] grabInteractables;
    public HandGrabInteractable[] handGrabInteractables;
    public Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        localPosition = transform.localPosition;
        localRotation = transform.localRotation;
        localScale = transform.localScale;
        GetComponent<PointableUnityEventWrapper>().WhenSelect.AddListener(delegate { StartSync(); StartSyncToServer(); });
        GetComponent<PointableUnityEventWrapper>().WhenUnselect.AddListener(delegate { EndSync(); EndSyncToServer(); });
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
        isInteraciton = true;
    }
    [Command(requiresAuthority = false)]
    public void EndSyncToServer()
    {
        isInteraciton = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (isInteraciton && !isLocalInteraction) //�������ڽ���
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
        rigidbody.isKinematic = isInteraciton;
       if(isLocalInteraction)
        {
            SyncData(transform.localPosition, transform.localRotation, transform.localScale);
        }
       else
        {
            if(isServer && !isInteraciton)
            {
                SyncData(transform.localPosition, transform.localRotation, transform.localScale);
            }
            else
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
        transform.localPosition = localPosition;
        transform.localRotation = localRotation;
        transform.localScale = localScale;
    }
}
