using Unity.VisualScripting;
using UnityEngine;

namespace Managers
{
    public abstract class ManagerBase : MonoBehaviour
    {
        public virtual void Initialize()
        {
            Debug.Log($"{GetType().Name} Initialized");
        }
    }
}