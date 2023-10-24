using System;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Data
{
    [Serializable]
    public struct DropComponent
    {
        public Transform dropParent;
        public List<OneThingData> thingsInDrop;
        public float radius;
    }
}

