using Mirror;
using NetSync;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HandAnimSync : NetworkBehaviour
{
    //�����ֲ��Ķ�����������Ҫ�õ�������ֵ�ģ�͵������ؽڣ��Լ�����������������˵���ģ�͵Ķ��������Լ��ĳ�������ʾ������
    public SkinnedMeshRenderer skinnedMesh;
    public List<Transform> handJoint = new List<Transform>();
    public List<Transform> localHandJoint = new List<Transform>();
    public enum HandDir
    {
        Left,Right
    }
    public HandDir handDir = HandDir.Left;
   
    [System.Serializable]
    public class HandData
    {
        public SyncTransform[] syncJointData;
    }

    public HandData handData = new HandData();

    [SyncVar]
    public string handDataJson = "";

    // Start is called before the first frame update
    void Start()
    {
        if(isLocalPlayer)
        {
            if(handDir == HandDir.Left)
            {
                foreach (Transform obj in LocalInput.instance.LeftHandMesh.bones)
                    localHandJoint.Add(obj);
            }
            if (handDir == HandDir.Right)
            {
                foreach (Transform obj in LocalInput.instance.RightHandMesh.bones)
                    localHandJoint.Add(obj);
            }
        }
        foreach (Transform obj in skinnedMesh.bones)
                handJoint.Add(obj);
        handData.syncJointData = new SyncTransform[handJoint.Count];

    }

    // Update is called once per frame
    void Update()
    {
        if(isLocalPlayer)
        {
            for(int i = 0;i< localHandJoint.Count;i++)
            {
                if (handData.syncJointData[i] == null)
                    handData.syncJointData[i] = new SyncTransform();
                else
                handData.syncJointData[i].SyncObjectToServer(localHandJoint[i]);
            }
            handDataJson = JsonUtility.ToJson(handData); 
        }
        else
        {
            handData = JsonUtility.FromJson<HandData>(handDataJson);
            if(handData!=null)
            {
                if(handData.syncJointData!=null)
                {
                    for(int i = 0;i<handData.syncJointData.Length;i++)
                    {
                        if (handData.syncJointData[i] != null)
                            handData.syncJointData[i].SyncObjectToLocal(handJoint[i]);
                    }
                }
            }
        }
    }
}
