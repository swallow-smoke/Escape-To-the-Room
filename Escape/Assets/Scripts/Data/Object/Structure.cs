using System.Collections.Generic;
using Data.Object.Interface;
using Data.SOJ;
using UnityEngine;

namespace Data.Object
{
    public class Structure : MonoBehaviour, ISelectable
    {
        [SerializeField] public List<StructureData> actionData;

        public void OnSelect()
        {
            foreach (var action in actionData)
            {
                action.Execute(gameObject);
            }
        }
    }
}