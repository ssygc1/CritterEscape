using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TinyGiantStudio.Text;
using Photon.Pun;
public class CrystalLight : MonoBehaviour
{
    [SerializeField]
    private bool isLid = false;

    [SerializeField]
    private ParticleSystem particle;

    public Modular3DText dText;
    public string originalNumber;
    public string doubledNumber;

    private PhotonView photonView;

    private void Start()
    {
        if (photonView == null)
        {
            photonView = GetComponent<PhotonView>();
        }
    }

    public void TurnOnCrystalNetwork()
    {
        photonView.RPC("TurnOnCrystalRPC", RpcTarget.All);
    }

    public void TurnOffCrystalNetwork()
    {
        photonView.RPC("TurnOffCrystalRPC", RpcTarget.All);
    }

    [PunRPC]
    public void TurnOnCrystalRPC()
    {
        isLid = true;
        UpdateLocalCrystalEffect();
    }

    [PunRPC]
    public void TurnOffCrystalRPC()
    {
        isLid = false;
        UpdateLocalCrystalEffect();
    }

    private void UpdateLocalCrystalEffect()
    {
        if (isLid)
        {
            particle.Play();
            dText.Text = doubledNumber;
        } else
        {
            particle.Stop();
            dText.Text = originalNumber;
        }
    }

    public bool IsLid()
    {
        return isLid;
    }
}
