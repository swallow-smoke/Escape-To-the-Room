using System.Collections.Generic;
using Managers;
using UnityEngine;

namespace Managers
{
    public class TotalManager : MonoBehaviour
    {
        [SerializeField] private List<ManagerBase> managers = new List<ManagerBase>();

        private void Awake()
        {
            foreach (var manager in managers)
            {
                manager.Initialize();
            }
            
            foreach (var manager in managers)
            {
                Debug.Log(manager);
            }
        }
    }
}