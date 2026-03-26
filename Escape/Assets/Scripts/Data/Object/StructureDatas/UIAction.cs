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
        /// 이름으로 딕셔너리에서 찾는건데
        /// 난 더 개선할 여지를 찾지 못하겟어 살려줘
        /// UI에 있는 특정 함수를 실행하는건데 왜 구현을 못할까
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