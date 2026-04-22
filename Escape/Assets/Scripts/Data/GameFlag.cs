using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "GameFlags", menuName = "Data/GameFlags")]
    public class GameFlag : ScriptableObject
    {
        private Dictionary<string, bool> _flags = new Dictionary<string, bool>();

        public bool GetFlag(string name)
        {
            return _flags.TryGetValue(name, out var value) && value;
        }

        public void SetFlag(string name, bool value)
        {
            _flags[name] = value;
        }

        public List<KeyValuePair<string, bool>> GetFlagInList()
        {
            return new List<KeyValuePair<string, bool>>(_flags);
        }
    }
}