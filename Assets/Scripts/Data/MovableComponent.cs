using System;
using UnityEngine;

namespace Scripts.Data
{
    [Serializable]
    public struct MovableComponent
    {
        public Transform transform;
        public Vector3 direction;
        public float speed;
    }
}

