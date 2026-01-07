using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEditor;
using UnityEngine;

public class UILookAtPlayer : MonoBehaviour
{
    private Transform head;

    // Start is called before the first frame update
    void Start()
    {
        XROrigin rig = FindObjectOfType<XROrigin>();
        head = rig.transform.Find("Camera Offset/Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        if (head != null)
        {
            transform.LookAt(new Vector3(head.position.x, transform.position.y, head.position.z));
            transform.forward *= -1;
        }
    }
}
