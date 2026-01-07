using Mirror;
using Mirror.Discovery;
using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ServerManager))]

public class ServerManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        serializedObject.Update();
        ServerManager serverManager = (ServerManager)target;

        foreach (ServerResponse info in serverManager.discoveredServers.Values) 
        {
            if (GUILayout.Button(info.EndPoint.Address.ToString()))
                serverManager.Connect(info);
        }

        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Refresh"))
            serverManager.FindServers();
        if (GUILayout.Button("Create Room"))
            serverManager.StartHost();
        if (GUILayout.Button("Exit Room"))
            serverManager.ExitHost();

        GUILayout.EndHorizontal();
        serializedObject.ApplyModifiedProperties();
    }
}
