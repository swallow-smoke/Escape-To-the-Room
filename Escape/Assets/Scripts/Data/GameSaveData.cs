using System;
using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    [System.Serializable]
    public class TileData
    {
        public Vector3Int position;
        public string tileName;
    }

    [System.Serializable]
    public class GameSaveData
    {
        public int slotId = 0;
        public string saveTime = "";
        public List<FlagData> gameFlags = new List<FlagData>();
        public List<TileData> tileDatas = new List<TileData>();
        public Vector3 playerPosition = Vector3.zero;
        public List<int> inventoryIds = new List<int>();
    }

    [System.Serializable]
    public class FlagData
    {
        public string key = "";
        public bool value = false;
    }
}
