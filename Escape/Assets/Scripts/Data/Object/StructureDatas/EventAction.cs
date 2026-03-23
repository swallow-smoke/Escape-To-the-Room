using System;
using Data.Object.Interface;
using Data.SOJ;
using Managers;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Data.Object.StructureDatas
{
    [CreateAssetMenu(fileName = "EventAction", menuName = "StructureDatas/EventAction")]
    public class EventAction : StructureData
    {
        [SerializeField] public string ownName;
        
        public override void Execute(GameObject own) {}
    }
}