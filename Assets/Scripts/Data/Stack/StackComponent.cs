using System;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Data
{
    [Serializable]
    public struct StackComponent
    {
        public Transform stackParent;
        public int maxCount;
        public List<OneThingData> thingsInStack;
        public float radius;
    }
}

