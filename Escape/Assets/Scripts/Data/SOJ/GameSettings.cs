using UnityEngine;

namespace Data.SOJ
{
    [CreateAssetMenu(fileName = "GameSettings", menuName = "Data/GameSettings"), 
     System.Serializable]
    public class GameSettings : ScriptableObject
    {
        [Header("Game Set")]
        public int Volume = 50;
        public int GUIRatio = 1;
        
        [Header("Key Mapping")]
        public KeyCode Forward = KeyCode.W;
        public KeyCode Back = KeyCode.S;
        public KeyCode Left = KeyCode.A;
        public KeyCode Right = KeyCode.D;
        public KeyCode Interaction = KeyCode.E;
        public KeyCode Escape = KeyCode.Escape;
    }
}