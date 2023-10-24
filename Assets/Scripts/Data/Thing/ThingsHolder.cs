using System;
using System.Collections.Generic;

namespace Scripts.Data
{
    [Serializable]
    public struct ThingsHolder
    {
        public List<OneThingData> things;
        public bool[,] isCreate;
    }
}