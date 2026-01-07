using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Photon.Pun;

public class GoldenCrystal : MonoBehaviour
{
    [SerializeField]
    private CrystalLight[] crystalLights;

    [SerializeField]
    private bool[] answerList;

    public ParticleSystem particle;

    public UnityEvent onCrystalCorrect;
    public UnityEvent onCrystalIncorrect;
    private PhotonView photonView;

    private void Start()
    {
        if (photonView == null)
        {
            photonView = GetComponent<PhotonView>();
        }
    }
    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.C))
        //{
        //    Confirm();
        //}
    }

    public void ConfirmNetwork()
    {
        photonView.RPC("ConfirmRPC", RpcTarget.All);
    }

    [PunRPC]
    public void ConfirmRPC()
    {
        for(int i = 0; i < crystalLights.Length; i++)
        {
            if (crystalLights[i].IsLid() != answerList[i])
            {
                onCrystalIncorrect.Invoke();
                return;
            }
        }

        LidUpGoldenCrystal();
        onCrystalCorrect?.Invoke();
    }

    public void LidUpGoldenCrystal()
    {
        particle.Play();
    }
}
