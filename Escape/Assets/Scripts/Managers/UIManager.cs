using System;
using System.Collections;
using System.Collections.Generic;
using Managers.Base;
using UI;
using UI.Panel;
using UnityEngine;

namespace Managers
{
    public class UIManager : SingletonManagerBase<UIManager>
    {
        [SerializeField] private List<PanelList> _panels;
        [SerializeField] private GameObject _statusText;
        private Stack<PanelBase> panels;

        public override void Initialize()
        {
            base.Initialize();
            panels = new Stack<PanelBase>();
            _panels.ForEach(panel => panel.panel.Init());
        }
        
        public void TogglePanel(string name)
        {
            var panelData = _panels.Find(p => p.name == name);
            if (panelData == null)
            {
                Debug.LogWarning($"Panel {name} not found.");
                return;
            }

            var panel = panelData.panel;

            if (panel.gameObject.activeSelf)
            {
                panel.TogglePanel();

                if (panels.Contains(panel))
                {
                    var tempStack = new Stack<PanelBase>();

                    while (panels.Count > 0)
                    {
                        var p = panels.Pop();
                        if (p != panel)
                            tempStack.Push(p);
                    }

                    while (tempStack.Count > 0)
                        panels.Push(tempStack.Pop());
                }
            }
            else
            {
                panel.TogglePanel();
                panels.Push(panel);
            }
        }
    }

    [System.Serializable]
    public class PanelList
    {
        public string name;
        public PanelBase panel;
    }
}