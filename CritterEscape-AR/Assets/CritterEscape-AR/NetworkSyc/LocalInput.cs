using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalInput : MonoBehaviour
{
    public static LocalInput instance;
    private void Awake()
    {
        instance = this;
    }
    
    public Transform Head, LeftHand, RightHand; 
    public Transform RootHead, RootLeftHand, RootRightHand; 
    public SkinnedMeshRenderer LeftHandMesh, RightHandMesh;

    private void Update()
    {
        RootHead.position = Head.position;
        RootHead.rotation = Head.rotation;
        RootLeftHand.position = LeftHand.position;
        RootLeftHand.rotation = LeftHand.rotation;
        RootRightHand.position = RightHand.position;
        RootRightHand.rotation = RightHand.rotation;
    }
}
