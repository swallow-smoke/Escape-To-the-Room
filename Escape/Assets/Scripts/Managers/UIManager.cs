using System;
using System.Collections.Generic;
using Managers.Base;
using UI;
using UI.AutoBinder;
using UnityEngine;

namespace Managers
{
    public class UIManager : SingletonManagerBase<UIManager>, IUIProvider
    {
        [SerializeField] public UIDatas uis;

        private Dictionary<Type, UIBase> UILists = new Dictionary<Type, UIBase>();

        public override void Initialize()
        {
            base.Initialize();

            UILists = new Dictionary<Type, UIBase>();

            foreach (var data in uis.guiDatas)
            {
                if (data.ui == null || data.type == null)
                {
                    Debug.LogWarning("UIData에 null 있음");
                    continue;
                }

                UILists[data.type] = data.ui;
                data.ui.gameObject.SetActive(false);
            }
        }

        public void ToggleUI<T>() where T : UIBase
        {
            var ui = GetUI<T>();
            if (ui == null)
            {
                Debug.LogWarning($"{typeof(T)} UI 없음");
                return;
            }

            ui.gameObject.SetActive(!ui.gameObject.activeSelf);
        }

        public void ToggleUI(UIBase ui)
        {
            if (ui == null)
            {
                Debug.LogWarning("UI가 null임");
                return;
            }

            ui.gameObject.SetActive(!ui.gameObject.activeSelf);
        }

        // 🔥 안전한 Get
        public T GetUI<T>() where T : UIBase
        {
            if (UILists.TryGetValue(typeof(T), out var ui))
                return ui as T;

            return null;
        }

        public UIBase GetUI(Type type)
        {
            if (type == null) return null;

            UILists.TryGetValue(type, out var ui);
            return ui;
        }

        public void Register(UIBase ui)
        {
            if (ui == null) return;

            UILists[ui.GetType()] = ui;
        }

        public UIBase GetUIByName(string name)
        {
            foreach (var pair in UILists)
            {
                if (pair.Value.name == name)
                    return pair.Value;
            }

            return null;
        }

        public object GetUIElement(string name, Type type)
        {
            var ui = GetUI(type);
            return ui;
        }
    }
}