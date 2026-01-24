using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(NetworkManagerUI))]
public class NetworkManagerUIEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector(); // 绘制默认的 Inspector UI

        NetworkManagerUI script = (NetworkManagerUI)target;

        // 绘制按钮并绑定点击事件
        if (GUILayout.Button("Start Host"))
        {
            script.StartHost();
        }

        if (GUILayout.Button("Start Client"))
        {
            script.StartClient();
        }

        if (GUILayout.Button("Start Server"))
        {
            script.StartServer();
        }

    }
}
