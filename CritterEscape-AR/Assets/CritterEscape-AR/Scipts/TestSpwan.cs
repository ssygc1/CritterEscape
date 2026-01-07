using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpwan : MonoBehaviour
{
    public Transform hand;
    public GameObject prefab;
    public void spwan()
    {
        GameObject obj = Instantiate(prefab);
        obj.transform.position = hand.transform.position + new Vector3(-0.1f, 0.1f, -0.1f);
    }
}
