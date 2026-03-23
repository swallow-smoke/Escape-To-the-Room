using System;
using System.Collections.Generic;
using Managers;
using UI.AutoBinder;
using UnityEngine;

namespace UI
{
    public abstract class UIBase : MonoBehaviour, IUIProvider
    {
        protected virtual void Start()
        {
            UIManager.Instance.Register(this);
            UIBinder.Bind(this, this);
        }

        public object GetUIElement(string name, Type type)
        {
            var child = transform.Find(name);
            return child != null ? child.GetComponent(type) : null;
        }

        private Dictionary<Type, UnityEngine.Object[]> _objects =
            new Dictionary<Type, UnityEngine.Object[]>();

        protected void Bind<T>(Type type) where T : UnityEngine.Object
        {
            string[] names = Enum.GetNames(type);
            UnityEngine.Object[] objects = new UnityEngine.Object[names.Length];

            for (int i = 0; i < names.Length; i++)
            {
                objects[i] = transform.Find(names[i]).GetComponent<T>();
            }

            _objects.Add(typeof(T), objects);
        }

        protected T Get<T>(int index) where T : UnityEngine.Object
        {
            return _objects[typeof(T)][index] as T;
        }
    }
}