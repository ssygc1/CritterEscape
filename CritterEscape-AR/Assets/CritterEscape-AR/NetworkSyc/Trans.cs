using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Trans : NetworkBehaviour
{
    public bool isTrans = false;
    private int currentSceneIndex;
    private AsyncOperation sceneLoadOperation; // This will be used to track loading progress

    // Start is called before the first frame update
    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        print("Trans Start: " + currentSceneIndex);
        
        /*
        int totalScenes = SceneManager.sceneCountInBuildSettings;
        print("totalScenes: " + totalScenes);
        for (int i = 0; i < totalScenes; i++)
        {
            print("Scene " + i + ": " + SceneManager.GetSceneByBuildIndex(i).name);
        }*/

        // Hide all linkBtn
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("linkBtn");
        foreach (GameObject gameObject in gameObjects)
        {
            gameObject.SetActive(false);
        }
    }

    void Update()
    {
        print("trans Update");
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (isTrans && isServer)
        {
            CmdLoadNextScene();
            isTrans = false;
        }

        // Hide all linkBtn
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("linkBtn");
        foreach (GameObject gameObject in gameObjects)
        {
            gameObject.SetActive(false);
        }

        // Check if the scene is still loading
        if (sceneLoadOperation != null && !sceneLoadOperation.isDone)
        {
            Debug.Log("Loading progress: " + (sceneLoadOperation.progress * 100f) + "%");
        }
    }

    // Command to be called by the server to load the next scene
    public void CmdLoadNextScene()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        print("CmdLoadNextScene: " + currentSceneIndex);
        int sceneIndex = currentSceneIndex + 1;
        RpcLoadNextScene(sceneIndex);
    }

    // RPC that is called to load the scene on all clients
    [ClientRpc]
    public void RpcLoadNextScene(int sceneIndex)
    {
        Debug.Log("RpcLoadNextScene: " + sceneIndex);

        // Use LoadSceneAsync to load the next scene asynchronously
        sceneLoadOperation = SceneManager.LoadSceneAsync(sceneIndex);

        // You cazn also track when the scene has finished loading
        sceneLoadOperation.completed += (AsyncOperation op) => 
        {
            Debug.Log("Scene " + sceneIndex + " loaded successfully.");
        };
    }
}
