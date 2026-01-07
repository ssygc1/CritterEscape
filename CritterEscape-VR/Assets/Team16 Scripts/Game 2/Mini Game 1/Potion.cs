using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Value of potion")]
    public int value;

    private Vector3 originalPosition;
    private Quaternion originalRotation;

    
    void Start()
    {
        originalPosition = transform.position;
        originalRotation = transform.rotation;
    }

    public void ResetPotion()
    {
        transform.position = originalPosition;
        transform.rotation = originalRotation;
    }
}
