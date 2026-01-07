using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using TMPro;
using UnityEngine.UI;
using NetSync;

public class MRPlayer : NetworkBehaviour
{
    [SyncVar]
    public string PlayerName;

    [SyncVar]
    public bool isMaster;
    public TextMeshPro nameText;
    public uint PlayerID;
    public Transform Head, LeftHand, RightHand;
    public Transform NamePlate;

    public SyncTransform HeadData = new SyncTransform();
    public SyncTransform LeftHandData = new SyncTransform();
    public SyncTransform RightHandData = new SyncTransform();

    [SyncVar]
    public string HeadDataJson = "";
    [SyncVar]
    public string LeftHandDataJson = "";
    [SyncVar]
    public string RightHandDataJson = "";

    public Material[] Mat = new Material[2];

    void Start()
    {

        if (isLocalPlayer)
        {
            if (isServer)
            {
                //Debug.Log("1111");
                isMaster = true;
                PlayerName = UserInfo.instance.PlayerNameHost;


                GameObject.Find("OVRHands").transform.GetChild(2).GetChild(0).GetChild(0).GetChild(1).gameObject.GetComponent<SkinnedMeshRenderer>().material = Mat[0];
                GameObject.Find("OVRHands").transform.GetChild(3).GetChild(0).GetChild(0).GetChild(1).gameObject.GetComponent<SkinnedMeshRenderer>().material = Mat[0];
                GameObject.Find("OVRControllerDrivenHands").transform.GetChild(2).GetChild(0).GetChild(0).GetChild(1).gameObject.GetComponent<SkinnedMeshRenderer>().material = Mat[0];
                GameObject.Find("OVRControllerDrivenHands").transform.GetChild(3).GetChild(0).GetChild(0).GetChild(1).gameObject.GetComponent<SkinnedMeshRenderer>().material = Mat[0];
            }
            else
            {
                //Debug.Log("2222");
                isMaster = false;

                PlayerName = UserInfo.instance.PlayerNameClient;


                GameObject.Find("OVRHands").transform.GetChild(2).GetChild(0).GetChild(0).GetChild(1).gameObject.GetComponent<SkinnedMeshRenderer>().material = Mat[1];
                GameObject.Find("OVRHands").transform.GetChild(3).GetChild(0).GetChild(0).GetChild(1).gameObject.GetComponent<SkinnedMeshRenderer>().material = Mat[1];
                GameObject.Find("OVRControllerDrivenHands").transform.GetChild(2).GetChild(0).GetChild(0).GetChild(1).gameObject.GetComponent<SkinnedMeshRenderer>().material = Mat[1];
                GameObject.Find("OVRControllerDrivenHands").transform.GetChild(3).GetChild(0).GetChild(0).GetChild(1).gameObject.GetComponent<SkinnedMeshRenderer>().material = Mat[1];
            }

            Head.gameObject.SetActive(false);
            Head.GetChild(0).GetChild(0).gameObject.SetActive(false);
            Head.GetChild(0).GetChild(1).gameObject.SetActive(false);

            LeftHand.GetChild(0).gameObject.SetActive(false);
            RightHand.GetChild(0).gameObject.SetActive(false);

            NamePlate.gameObject.SetActive(false);
        }
        else
        {
            if (isMaster)
            {
                Head.gameObject.SetActive(true);
                //Debug.Log("3333");
                this.gameObject.transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
                this.gameObject.transform.GetChild(0).GetChild(1).gameObject.SetActive(false);
                LeftHand.GetChild(0).GetChild(1).GetComponent<SkinnedMeshRenderer>().material = Mat[0];
                RightHand.GetChild(0).GetChild(1).GetComponent<SkinnedMeshRenderer>().material = Mat[0];
            }
            else
            {
                //Debug.Log("4444");
                Head.gameObject.SetActive(true);
                this.gameObject.transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
                this.gameObject.transform.GetChild(0).GetChild(1).gameObject.SetActive(true);
                LeftHand.GetChild(0).GetChild(1).GetComponent<SkinnedMeshRenderer>().material = Mat[1];
                RightHand.GetChild(0).GetChild(1).GetComponent<SkinnedMeshRenderer>().material = Mat[1];
                //LeftHand.GetChild(0).GetChild(1).GetComponent<SkinnedMeshRenderer>().material = Mat[1];
                //RightHand.GetChild(0).GetChild(1).GetComponent<SkinnedMeshRenderer>().material = Mat[1];
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        print("MRPlayer Update");
        //PlayerID = GetComponent<NetworkIdentity>().netId;
        nameText.text = PlayerName;
        if (isLocalPlayer)
        {
            if (isServer)
            {
                //Debug.Log("1111");
                isMaster = true;
                PlayerName = UserInfo.instance.PlayerNameHost;


                GameObject.Find("OVRHands").transform.GetChild(2).GetChild(0).GetChild(0).GetChild(1).gameObject.GetComponent<SkinnedMeshRenderer>().material = Mat[0];
                GameObject.Find("OVRHands").transform.GetChild(3).GetChild(0).GetChild(0).GetChild(1).gameObject.GetComponent<SkinnedMeshRenderer>().material = Mat[0];
                GameObject.Find("OVRControllerDrivenHands").transform.GetChild(2).GetChild(0).GetChild(0).GetChild(1).gameObject.GetComponent<SkinnedMeshRenderer>().material = Mat[0];
                GameObject.Find("OVRControllerDrivenHands").transform.GetChild(3).GetChild(0).GetChild(0).GetChild(1).gameObject.GetComponent<SkinnedMeshRenderer>().material = Mat[0];
            }
            else
            {
                //Debug.Log("2222");
                isMaster = false;

                PlayerName = UserInfo.instance.PlayerNameClient;


                GameObject.Find("OVRHands").transform.GetChild(2).GetChild(0).GetChild(0).GetChild(1).gameObject.GetComponent<SkinnedMeshRenderer>().material = Mat[1];
                GameObject.Find("OVRHands").transform.GetChild(3).GetChild(0).GetChild(0).GetChild(1).gameObject.GetComponent<SkinnedMeshRenderer>().material = Mat[1];
                GameObject.Find("OVRControllerDrivenHands").transform.GetChild(2).GetChild(0).GetChild(0).GetChild(1).gameObject.GetComponent<SkinnedMeshRenderer>().material = Mat[1];
                GameObject.Find("OVRControllerDrivenHands").transform.GetChild(3).GetChild(0).GetChild(0).GetChild(1).gameObject.GetComponent<SkinnedMeshRenderer>().material = Mat[1];
            }

            Head.gameObject.SetActive(false);
            Head.GetChild(0).GetChild(0).gameObject.SetActive(false);
            Head.GetChild(0).GetChild(1).gameObject.SetActive(false);

            LeftHand.GetChild(0).gameObject.SetActive(false);
            RightHand.GetChild(0).gameObject.SetActive(false);

            NamePlate.gameObject.SetActive(false);
        }
        else
        {
            if (isMaster)
            {
                Head.gameObject.SetActive(true);
                //Debug.Log("3333");
                this.gameObject.transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
                this.gameObject.transform.GetChild(0).GetChild(1).gameObject.SetActive(false);
                LeftHand.GetChild(0).GetChild(1).GetComponent<SkinnedMeshRenderer>().material = Mat[0];
                RightHand.GetChild(0).GetChild(1).GetComponent<SkinnedMeshRenderer>().material = Mat[0];
            }
            else
            {
                //Debug.Log("4444");
                Head.gameObject.SetActive(true);
                this.gameObject.transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
                this.gameObject.transform.GetChild(0).GetChild(1).gameObject.SetActive(true);
                LeftHand.GetChild(0).GetChild(1).GetComponent<SkinnedMeshRenderer>().material = Mat[1];
                RightHand.GetChild(0).GetChild(1).GetComponent<SkinnedMeshRenderer>().material = Mat[1];
                //LeftHand.GetChild(0).GetChild(1).GetComponent<SkinnedMeshRenderer>().material = Mat[1];
                //RightHand.GetChild(0).GetChild(1).GetComponent<SkinnedMeshRenderer>().material = Mat[1];
            }

        }

        if (isLocalPlayer)
        {
            HeadDataJson = HeadData.SyncObjectToServer(LocalInput.instance.RootHead);
            LeftHandDataJson = LeftHandData.SyncObjectToServer(LocalInput.instance.RootLeftHand);
            RightHandDataJson = RightHandData.SyncObjectToServer(LocalInput.instance.RootRightHand);
        }
        else
        {
            if (string.IsNullOrEmpty(HeadDataJson) == false)
                HeadData.SyncObjectToLocal(Head, HeadDataJson);

            if (string.IsNullOrEmpty(LeftHandDataJson) == false)
                LeftHandData.SyncObjectToLocal(LeftHand, LeftHandDataJson);

            if (string.IsNullOrEmpty(RightHandDataJson) == false)
                RightHandData.SyncObjectToLocal(RightHand, RightHandDataJson);

            NamePlate.transform.position = Head.position + new Vector3(0, 0.7f, 0);
            Vector3 direction = LocalInput.instance.Head.position - NamePlate.position;
            direction.y = 0f;

            Quaternion rotation = Quaternion.Euler(0, 0, 0);
            if (direction != Vector3.zero)
            {
                rotation = Quaternion.LookRotation(direction);
            }
            NamePlate.rotation = Quaternion.Euler(0f, rotation.eulerAngles.y + 180, 0f);
        }
    }
}
