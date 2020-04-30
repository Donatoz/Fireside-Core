using System;

namespace Fireside_Core.Database
{
    [Serializable]
    public struct StatInfo
    {
        public string Name;
        public int Value;

        public StatInfo(string name, int value)
        {
            Name = name;
            Value = value;
        }
    }
}