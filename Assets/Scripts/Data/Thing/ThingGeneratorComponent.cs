using System;
using UnityEngine;

namespace Scripts.Data
{
    [Serializable]
    public struct ThingGeneratorComponent
    {
        public Transform parent;
        public int sizeX;
        public int sizeZ;
        public GameObject thingPrefab;
    }
}

