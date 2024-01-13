using System;
using UnityEngine.Serialization;

namespace Models
{
    [Serializable]
    public class GameRole
    {
        public byte Role;
        public uint PlayerNetId;
    }
}