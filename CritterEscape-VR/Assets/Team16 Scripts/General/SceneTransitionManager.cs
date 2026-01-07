using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class SceneTransitionManager : MonoBehaviour
{
    public FadeScreen fadeScreen;
    public PhotonView photonView;

    public void FadeOutNetwork()
    {
        photonView.RPC("FadeOutRPC", RpcTarget.All);
    }

    [PunRPC]
    public void FadeOutRPC()
    {
        StartCoroutine(FadeOutRoutine());
    }



    IEnumerator FadeOutRoutine()
    {
        fadeScreen.FadeOut();
        yield return null;
    }

    public IEnumerator GoToSceneRoutine(int sceneIndex)
    {
        if (PhotonNetwork.IsMasterClient)
        {
            FadeOutNetwork();
            yield return new WaitForSeconds(fadeScreen.fadeDuration);

            PhotonNetwork.LoadLevel(sceneIndex);
        }
    }

    [PunRPC]
    public void GoToSceneRPC(int sceneIndex)
    {
        StartCoroutine(GoToSceneRoutine(sceneIndex));
    }


    public void GoToSecneNetwork(int sceneIndex)
    {
        photonView.RPC("GoToSceneRPC", RpcTarget.MasterClient, sceneIndex);
        //StartCoroutine(GoToSceneNetworkRoutine(sceneIndex));
    }
}
