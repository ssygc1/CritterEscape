using Meta.XR.BuildingBlocks;
using Oculus.Interaction.Input;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
public class AnchorManager : MonoBehaviour
{
    public SpatialAnchorCoreBuildingBlock _spatialAnchorCore;
    public GameObject AnchorPrefab;
    public Transform RightHandIndexTip;
    public Hand rightHand;
    public bool isPinch;
    public TextMeshPro ShowInfo;//��ʾ��Ŀǰ��ê�����״��
    public List<OVRSpatialAnchor> Anchors = new List<OVRSpatialAnchor>();//�洢��ǰ��ê��
    public bool isFakeAnchor;
    public Transform fakeAnchor1, fakeAnchor2;
    public void SpawnSpatialAnchor(Vector3 position, Quaternion rotation)
    {
        _spatialAnchorCore.InstantiateSpatialAnchor(AnchorPrefab, position, rotation);
    }

     void SpawnSpatialAnchor()
    {
        SpawnSpatialAnchor(RightHandIndexTip.position, RightHandIndexTip.rotation);
    }

     void LoadAnchorsFromDefaultLocalStorage()
    {
        var uuids = GetAnchorAnchorUuidFromLocalStorage();
        if (uuids == null) return;
        _spatialAnchorCore.LoadAndInstantiateAnchors(AnchorPrefab, uuids);
    }
    void GetLoadAnchors(List<OVRSpatialAnchor> anchors)
    {
        Anchors = anchors;
    }
    private List<Guid> _uuids = new List<Guid>();

    private const string NumUuidsPlayerPref = "numUuids";

    internal List<Guid> GetAnchorAnchorUuidFromLocalStorage()
    {
        // Get number of saved anchor uuids
        if (!PlayerPrefs.HasKey(NumUuidsPlayerPref))
        {
            Reset();
            Debug.Log($"[{nameof(SpatialAnchorLocalStorageManagerBuildingBlock)}] Anchor not found.");
            return null;
        }

        // Load unbounded anchors
        _uuids.Clear();
        var playerUuidCount = PlayerPrefs.GetInt(NumUuidsPlayerPref);
        for (int i = 0; i < playerUuidCount; ++i)
        {
            var uuidKey = "uuid" + i;
            if (!PlayerPrefs.HasKey(uuidKey))
                continue;

            var currentUuid = PlayerPrefs.GetString(uuidKey);
            _uuids.Add(new Guid(currentUuid));
        }

        return _uuids;
    }

    public void Reset()
    {
        PlayerPrefs.SetInt(NumUuidsPlayerPref, 0);
    }

    internal void SaveAnchorUuidToLocalStorage(OVRSpatialAnchor anchor, OVRSpatialAnchor.OperationResult result)
    {
        if (result != OVRSpatialAnchor.OperationResult.Success)
        {
            return;
        }
        Anchors.Add(anchor);
        if (!PlayerPrefs.HasKey(NumUuidsPlayerPref))
        {
            PlayerPrefs.SetInt(NumUuidsPlayerPref, 0);
        }

        int playerNumUuids = PlayerPrefs.GetInt(NumUuidsPlayerPref);//��ȡNumUuidsPlayerPref��¼����������ʼ��0�����Ե�һ��ê��洢�ڱ��ص����ƾ���uuid0��
                                                                    //��¼֮��NumUuidsPlayerPref���һ�����Եڶ���ê���ڱ��ص����ƾ���uuid1
        PlayerPrefs.SetString("uuid" + playerNumUuids, anchor.Uuid.ToString());
        PlayerPrefs.SetInt(NumUuidsPlayerPref, ++playerNumUuids);
    }

    internal void RemoveAnchorFromLocalStorage(OVRSpatialAnchor anchor, OVRSpatialAnchor.OperationResult result)
    {
        var uuid = anchor.Uuid;
        if (result == OVRSpatialAnchor.OperationResult.Failure)
            return;
        Anchors.Clear();//���õ�ʱ�򣬽���¼ê���ListҲ���
        var playerUuidCount = PlayerPrefs.GetInt(NumUuidsPlayerPref, 0);
        for (int i = 0; i < playerUuidCount; i++)
        {
            var key = "uuid" + i;
            var value = PlayerPrefs.GetString(key, "");
            if (value.Equals(uuid.ToString()))
            {
                var lastKey = "uuid" + (playerUuidCount - 1);
                var lastValue = PlayerPrefs.GetString(lastKey);
                PlayerPrefs.SetString(key, lastValue);
                PlayerPrefs.DeleteKey(lastKey);

                playerUuidCount--;
                if (playerUuidCount < 0) playerUuidCount = 0;
                PlayerPrefs.SetInt(NumUuidsPlayerPref, playerUuidCount);
                break;
            }
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        _spatialAnchorCore.OnAnchorCreateCompleted.AddListener(SaveAnchorUuidToLocalStorage);
        _spatialAnchorCore.OnAnchorEraseCompleted.AddListener(RemoveAnchorFromLocalStorage);
        _spatialAnchorCore.OnAnchorsLoadCompleted.AddListener(GetLoadAnchors);//����ê��ɹ����¼һ�µ�list��
        LoadAnchorsFromDefaultLocalStorage();//��ʼʱ����ê��
    }
    
    public void ResetAnchor()
    {
        _spatialAnchorCore.EraseAllAnchors();//��������ê��
    }
    public Transform Root;
    Vector3 Anchor1Pos, Anchor2Pos;
    // Update is called once per frame
    void Update()
    {
        if(Anchors.Count==0)
            ShowInfo.text = "No Find Anchor";
        if (Anchors.Count == 1)
            ShowInfo.text = "Only One Anchor";
        if (Anchors.Count == 2)
            ShowInfo.text = "Anchor Complete";
        if (Anchors.Count >2 )
            ShowInfo.text = "Anchor Overflow";

        //ê�㴴��֮����Ҫ�ж��ĸ���ê��1���ĸ���ê��2
        if(Anchors.Count == 2)
        {
            if (Anchors[0].Uuid.ToString()==PlayerPrefs.GetString("uuid0"))//ͨ��UUID�뱾�ش洢��UUID���жԱ� ��ê��1��ê��2��λ�û�ȡ��
            {
                Anchor1Pos = Anchors[0].gameObject.transform.position;
                Anchor2Pos = Anchors[1].gameObject.transform.position;
            }
            //���Anchor[0]����ê�㣬���ж�һ��Anchor[1]�ǲ���,����ֱ��else����Ϊ�������������ǵĿ���
            if (Anchors[1].Uuid.ToString() == PlayerPrefs.GetString("uuid0"))//ͨ��UUID�뱾�ش洢��UUID���жԱ� ��ê��1��ê��2��λ�û�ȡ��
            {
                Anchor2Pos = Anchors[0].gameObject.transform.position;
                Anchor1Pos = Anchors[1].gameObject.transform.position;
            }
        }
        if(isFakeAnchor)
        {
            Anchor1Pos = fakeAnchor1.position;
            Anchor2Pos = fakeAnchor2.position;
        }
        //ê���λ�û�ȡ��֮�󣬾�Ҫȥ����root������
        //������root��λ��
        Root.position = new Vector3(Anchor1Pos.x, 0, Anchor1Pos.z);
        //Ȼ����root����ת�ǣ���Ҫ����ê��1��ê��2�ķ�������
        Vector3 direction = new Vector3(Anchor2Pos.x, 0, Anchor2Pos.z) - new Vector3(Anchor1Pos.x, 0, Anchor1Pos.z);
        //Ȼ����Ҫ����������תΪ��ת���õ���Ԫ��
        Quaternion rotation = Quaternion.Euler(0, 0, 0);
        if(direction!=Vector3.zero)
        {
            rotation = Quaternion.LookRotation(direction);
        }
        //Quaternion rotation = Quaternion.LookRotation(direction);
        Quaternion adjustRot = Quaternion.Euler(0, -90, 0);
        Root.rotation = rotation * adjustRot;
        if (rightHand.GetIndexFingerIsPinching() && Anchors.Count<2)//��ê����������2��ʱ����������ê��Ĺ���
        {
            if (!isPinch)
            {
                isPinch = true;

                SpawnSpatialAnchor();//����һ��ê��
            }
        }
        else
            isPinch = false;
    }
}
