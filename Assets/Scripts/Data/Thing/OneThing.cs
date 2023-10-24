using System;
using UnityEngine;

namespace Scripts.Data
{
    public class OneThing : MonoBehaviour
    {
        public OneThingData data;

        public void Initiate(int x, int z)
        {
            data.transform = this.transform;
            data.x = x;
            data.z = z;
            data.isDroped = false;
            transform.position = new Vector3(x, 1, z);
        }
    }
    [Serializable]
    public struct OneThingData
    {
        public Transform transform;
        public int x;
        public int z;
        public bool isDroped;
    }
}

