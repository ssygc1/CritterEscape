using UnityEngine;

public class KeepCapsuleVertical : MonoBehaviour
{
    void Update()
    {
        // ???????????
        Vector3 currentRotation = transform.rotation.eulerAngles;
        
        transform.rotation = Quaternion.Euler(0f, currentRotation.y, 0f);
    }
}
