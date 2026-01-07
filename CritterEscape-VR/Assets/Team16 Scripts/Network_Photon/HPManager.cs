using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HPManager : MonoBehaviour
{
    private static int healthPointStatic;
    //public int totalHealthPoint = 3;
    public GameObject[] healthPointUi;

    // Update is called once per frame
    void Update()
    {
        enableOrDisableGO(false);
        showObjectsDependingHP();
        
    }

    void OnEnable() {
        enableOrDisableGO(true);
        healthPointStatic = healthPointUi.Length;
        //Debug.Log(healthPointStatic);
    }

    public static void decreaseHealthPoint() {
        healthPointStatic--;
        checkCurrentHpStatus();
    }
    
    public int getHealthPointStatic() {
        return healthPointStatic;
    }
    
    protected virtual void showObjectsDependingHP() {
        for (int i = 0; i < healthPointStatic; i++) {
            healthPointUi[i].SetActive(true);
        }
    }

    protected virtual void enableOrDisableGO(bool activeness) {
        foreach (GameObject gmob in healthPointUi) {
            gmob.SetActive(activeness);
        }
    }

    private static void checkCurrentHpStatus() {
        if (healthPointStatic <= 0 && PhotonNetwork.IsMasterClient) {
            resetScene();
        }
    }

    private static void resetScene() {
        //string currentSceneName = SceneManager.GetActiveScene().name;
        //SceneManager.LoadScene("currentSceneName");
        SceneManager.LoadScene("Story_BadEnd");
        return;
        //TODO: Scene transition
        Debug.LogError("No HP, reset this scene");

        if (!PhotonNetwork.IsMasterClient) 
        {
            Debug.LogError("I am client, not master, I can't trans");
            return;
            
        }


        SceneTransitionManager sceneTransition = FindAnyObjectByType<SceneTransitionManager>();
        if (sceneTransition != null)
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            Debug.LogError("I am master, let's go to scene" +  currentSceneIndex);
            sceneTransition.GoToSecneNetwork(currentSceneIndex);
        }
    }
}
