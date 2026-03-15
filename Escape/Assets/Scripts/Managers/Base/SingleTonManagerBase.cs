using UnityEngine;

namespace Managers.Base
{
    public abstract class SingletonManagerBase<T> : ManagerBase where T : MonoBehaviour
    {
        public static T Instance;

        protected virtual void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this as T;
        }
    }
}