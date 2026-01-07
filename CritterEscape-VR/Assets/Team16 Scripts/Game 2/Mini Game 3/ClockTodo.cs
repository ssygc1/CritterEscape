using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Content.Interaction;

public class ClockTodo : MonoBehaviour, IPunObservable
{
    [SerializeField]
    private XRKnob HourWheel;

    [SerializeField]
    private XRKnob MinuteWheel;

    [SerializeField]
    private Transform HourHand;

    [SerializeField]
    private Transform MinuteHand;

    [SerializeField]
    private float targetMinuteAngle = 0f;

    [SerializeField]
    private float targetHourAngle = 90f;

    public float tolerance = 5f;

    [SerializeField]
    private UnityEvent onClockCorrent;
    public UnityEvent onClockIncorrect;

    private PhotonView photonView;

    private void Start()
    {
        if (photonView == null)
        {
            photonView = GetComponent<PhotonView>();
        }
    }

    void Update()
    {
        HourHand.rotation = Quaternion.Euler(0, 270, HourWheel.value * 180);
        MinuteHand.rotation = Quaternion.Euler(0, 270, MinuteWheel.value * 180);
    }
    
    private bool CheckAnswer()
    {
        float currentHourAngle = HourHand.eulerAngles.z;
        float currentMinuteAngle = MinuteHand.eulerAngles.z;


        if (currentHourAngle > 180)
        {
            currentHourAngle -= 360;
        }
        if (currentMinuteAngle > 180)
        {
            currentMinuteAngle -= 360;
        }

        if (currentHourAngle < 0)
        {
            currentHourAngle += 360;
        }
        if (currentMinuteAngle < 0)
        {
            currentMinuteAngle += 360;
        }


        if (currentHourAngle >= targetHourAngle - tolerance && currentHourAngle <= targetHourAngle + tolerance
                && currentMinuteAngle >= targetMinuteAngle - tolerance && currentMinuteAngle <= targetMinuteAngle + tolerance)
        {
            Debug.Log("Angle is true " + currentHourAngle + " " + currentMinuteAngle);
            return true;
        }
        else
        {
            Debug.Log("Angle is false" + currentHourAngle + " " + currentMinuteAngle);
            Debug.Log(targetHourAngle - tolerance);
            Debug.Log(targetHourAngle + tolerance);
            Debug.Log(targetMinuteAngle - tolerance);
            Debug.Log(targetMinuteAngle + tolerance);
            return false;
        }
    }

    [PunRPC]
    public void ConfirmRPC()
    {
        if (CheckAnswer())
        {
            onClockCorrent?.Invoke();
        }
        else
        {
            onClockIncorrect?.Invoke();
        }
    }

    public void ConfirmNetwork()
    {
        photonView.RPC("ConfirmRPC", RpcTarget.All);
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            //photonView.RequestOwnership(); // TODO may delete
            stream.SendNext(HourWheel.value);
            stream.SendNext(MinuteWheel.value);
        }
        else
        {
            HourWheel.value = (float)stream.ReceiveNext();
            MinuteWheel.value = (float)stream.ReceiveNext();
        }
    }

    public void TakeOverOwnership()
    {
        photonView.RequestOwnership();
    }
}
