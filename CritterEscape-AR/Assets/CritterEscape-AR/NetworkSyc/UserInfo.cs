using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInfo : MonoBehaviour
{
    public static UserInfo instance;
    public string PlayerNameHost;
    public string PlayerNameClient;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        PlayerNameHost = "Zeke";
        PlayerNameClient = "Yuki";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
