using UnityEngine;

public class AddEventCameraToCanvas : MonoBehaviour
{
    public Camera customCamera;  

    void Update()
    {
        Canvas[] canvases = FindObjectsOfType<Canvas>();

        foreach (Canvas canvas in canvases)
        {
            if (canvas != null)
            {
                // 如果指定了 customCamera，就使用它
                if (customCamera != null)
                {
                    canvas.worldCamera = customCamera;
                }
                // 否则使用主摄像机
                else if (Camera.main != null)
                {
                    canvas.worldCamera = Camera.main;
                }
            }
        }
    }
}
