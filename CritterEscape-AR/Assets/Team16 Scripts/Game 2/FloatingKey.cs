using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingKey : MonoBehaviour
{
    public float rotationSpeed = 100f; // 钥匙旋转速度
    public float riseSpeed = 1f; // 钥匙上升速度
    public float targetHeight = 2f; // 钥匙上升的目标高度
    public int blinkTimes = 5; // 钥匙闪烁次数
    public float blinkDuration = 0.1f; // 每次闪烁的持续时间
    public MeshRenderer keyRenderer;

    private bool isRising = false; // 是否开始上升

    // 调用这个函数来开始钥匙的动作
    public void StartKeyActions()
    {
        isRising = true;
    }

    void Update()
    {
        if (isRising)
        {
            // 让钥匙旋转
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.World);

            // 让钥匙上升
            float newYPosition = transform.position.y + riseSpeed * Time.deltaTime;
            transform.position = new Vector3(transform.position.x, newYPosition, transform.position.z);

            // 检查是否达到指定高度
            if (transform.position.y >= targetHeight)
            {
                isRising = false; // 停止上升和旋转
                StartCoroutine(BlinkAndDisappear()); // 开始闪烁并消失
            }
        }
    }

    IEnumerator BlinkAndDisappear()
    {
        for (int i = 0; i < blinkTimes * 2; i++)
        {
            keyRenderer.enabled = !keyRenderer.enabled; // 切换渲染器的可见性
            yield return new WaitForSeconds(blinkDuration);
        }

        keyRenderer.enabled = true;
        Destroy(gameObject); // 销毁钥匙对象
    }
}
