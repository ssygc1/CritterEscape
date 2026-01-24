using System;
using UnityEngine;
using Oculus.Interaction; // Oculus Interaction SDK
using Oculus.Interaction.Input;

public class OpenPanelOnPalmUp : MonoBehaviour
{
    public GameObject panel1;
    public GameObject panel2;
    public Transform hand;
    public bool isInGame = false;
    public GameObject[] objs;

    public void SetInGame()
    {
        isInGame = true;
    }
    public void onBotton1()
    {
        if (!isInGame)
        {
            panel1.transform.position = hand.transform.position + new Vector3(0, 0.1f, 0.1f);
            panel1.transform.LookAt(Camera.main.transform);
            panel1.transform.Rotate(0, 180f, 0);
            panel1.SetActive(true);
        }
    }

    private void Update()
    {
        if (isInGame)
        {
            foreach (GameObject obj in objs)
            {
                obj.SetActive(false);
            }
        }
    }

    public void onBotton2()
    {
        panel2.transform.position = hand.transform.position + new Vector3(-0.1f, 0.1f, 0.18f);
        panel2.transform.LookAt(Camera.main.transform);
        panel2.transform.Rotate(0, 180f, 0);
        panel2.SetActive(true);
    }

    public void offBotton()
    {
        panel1.SetActive(false);
        panel2.SetActive(false);
    }
}
