using System;
using System.Reflection;
using Managers.Base;
using UI;
using UI.AutoBinder;
using UnityEngine;

namespace Managers
{
    public class UIManager : SingletonManagerBase<UIManager>
    {
        [SerializeField] public UIDatas uis;
        [SerializeField] public UIPanel panel;

        public void ToggleESC()
        {
            panel.gameObject.SetActive(!panel.gameObject.activeSelf);
        }
    }
}