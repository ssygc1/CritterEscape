using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Mirror; 

public class EndSildeShow : NetworkBehaviour
{
    public GameObject[] slideshowObjects; // 幻灯片物体数组
    public float showingDuration = 5f; // 每个物体显示的时间
    [SyncVar]
    private int currentIndex = 0; // 当前显示的幻灯片索引
    private float lastChangeTime = 0f; // 上次切换幻灯片的时间

    private int count = 0;
    
    [SyncVar]
    public bool isFinished = false;

    // Start is called before the first frame update
    void Start()
    {
        if (slideshowObjects.Length == 0)
        {
            return;
        }

        // 隐藏所有幻灯片对象
        HideAllObjects();


        if (isServer)
            ShowCurrentObject();

    }

    // Update is called once per frame
    void Update()
    {
        print("story Update");
        // 只在服务器端处理幻灯片切换
        if (isServer && GameObject.FindGameObjectsWithTag("Player").Length == 2 && !isFinished)
        {
            // 计算距离上次切换的时间
            float timeSinceLastChange = Time.time - lastChangeTime;

            // 如果到了显示下一个幻灯片的时间
            if (timeSinceLastChange >= showingDuration)
            {
                // 显示下一个幻灯片
                print("ShowNextObject");
                ShowNextObject();
            }
        }
    }

    // 隐藏所有物体
    private void HideAllObjects()
    {
        foreach (GameObject obj in slideshowObjects)
        {
            obj.SetActive(false);
        }
    }

    // 显示当前物体
    private void ShowCurrentObject()
    {
        if (currentIndex < slideshowObjects.Length)
        {
            slideshowObjects[currentIndex].SetActive(true);
            lastChangeTime = Time.time;

            // 通知客户端同步幻灯片的显示
            RpcShowCurrentObject(currentIndex);
        }
    }

    // 显示下一个物体
    private void ShowNextObject()
    {
        // 如果当前物体是最后一个，则重置为第一个
        currentIndex++;

        if (currentIndex >= slideshowObjects.Length && isServer && count == 0)
        {
            //GameObject.Find("NetworkSpawner").GetComponent<SpawnePrefab>().setSpawn();
            isFinished = true;
            count = 1;
        }

        HideAllObjects();
        ShowCurrentObject();
    }

    // 客户端RPC函数：在客户端显示当前幻灯片
    [ClientRpc]
    private void RpcShowCurrentObject(int index)
    {
        // 只在客户端执行
        if (!isServer)
        {
            HideAllObjects();
            slideshowObjects[index].SetActive(true);
        }
    }
}
