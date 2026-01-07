using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGame1Manager : MonoBehaviour
{
    public static MiniGame1Manager Instance;
    public Potion[] potions;
    public Cauldron cauldron;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (Instance != null)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                RestartMiniGame1();
            }
        }
    }

    public void RestartMiniGame1()
    {
        foreach (var item in potions)
        {
            item.ResetPotion();
        }
        cauldron.ResetCauldron();
    }
}
