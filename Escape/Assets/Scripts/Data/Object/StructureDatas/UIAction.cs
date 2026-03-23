using System;
using Data.SOJ;
using Managers;
using Unity.VisualScripting;
using UnityEngine;

namespace Data.Object.StructureDatas
{
    [CreateAssetMenu(fileName = "UIAction", menuName = "StructureDatas/UIAction")]
    public class UIAction : StructureData
    {
        [SerializeField] public string ownName;
        [SerializeField] public ActionType type;
        
        /// <summary>
        /// 어떻게 더 개선해야할지 모르겠다 허허
        /// </summary>
        /// <param name="own"></param>
        public override void Execute(GameObject own)
        {
            var ui = UIManager.Instance.GetUIByName(ownName);

            if (ui != null)
            {
                UIManager.Instance.ToggleUI(ui);
            }
        }
    }
    
    public enum ActionType
    {
        Toggle,
        Functionable
    }
}