using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class Game2Manager : MonoBehaviour
{
    public static Game2Manager Instance;
    private void Awake()
    {
        Instance = this;
    }

    public int maxHealthPoint = 3;

    public int healthPoint = 3;

    public void takeOneDamage()
    {
        healthPoint--;

        //TODO Take Damage Effect

        if (healthPoint <= 0)
        {
            RestartGame2();
            
        }
    }

    public void RestartGame2()
    {
        if (NetworkPlayerSpawner.playerRole == PlayerRole.Zeke)
        {
            //Todo using scene transition manager
            //PhotonNetwork.LoadLevel(3); //3 is the scene index of Game2 scene
        }
        
    }
}
