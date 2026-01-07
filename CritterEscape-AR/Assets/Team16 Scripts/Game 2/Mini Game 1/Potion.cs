using System;
using UnityEngine;
using UnityEngine.Events;

public class Potion : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Value of potion")]
    public int value;
    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.localPosition;
    }

    public void resetPotion()
    {
        transform.localPosition = startPosition;
        transform.localRotation = Quaternion.identity;
    }
}