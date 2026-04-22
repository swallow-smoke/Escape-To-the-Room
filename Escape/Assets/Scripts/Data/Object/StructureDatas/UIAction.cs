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

        
        public override void Execute(GameObject own)
        {
            // var ui = UIManager.Instance.GetUI(ownName);

            // switch (type)
            // {
              //  case ActionType.Toggle:
                //default: 
                  //  UIManager.Instance.ToggleUI(ui); 
                    //break;
            //}
        }
    }
    
    public enum ActionType
    {
        Toggle,
        Functionable
    }
}