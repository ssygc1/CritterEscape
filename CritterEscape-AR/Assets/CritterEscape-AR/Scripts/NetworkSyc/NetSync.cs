using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NetSync
{
    [System.Serializable]
    public class SyncTransform
    {
        public Vector3 localPosition = new Vector3();
        public Quaternion localRotation = new Quaternion();
        public Vector3 localScale = new Vector3();

        public string SyncObjectToServer(Transform Obj)
        {
            if (Obj == null)
                return "";
            localPosition = Obj.localPosition;
            localRotation = Obj.localRotation;
            localScale = Obj.localScale;
            string jsondata = JsonUtility.ToJson(this);
            return jsondata;
        }

        public void SyncObjectToLocal(Transform Obj, string jsondata)
        {
            SyncTransform syncTransform = JsonUtility.FromJson<SyncTransform>(jsondata);
            localPosition = syncTransform.localPosition;
            localRotation = syncTransform.localRotation;
            localScale = syncTransform.localScale;

            Obj.localPosition = localPosition;
            Obj.localRotation = localRotation;
            Obj.localScale = localScale;
        }

        public void SyncObjectToLocal(Transform Obj)
        {
            Obj.localPosition = localPosition;
            Obj.localRotation = localRotation;
            Obj.localScale = localScale;
        }

    }
}
