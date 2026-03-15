using System.Collections.Generic;
using Managers;
using Managers.Base;
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
            
            DontDestroyOnLoad(gameObject);
        }
    }
}