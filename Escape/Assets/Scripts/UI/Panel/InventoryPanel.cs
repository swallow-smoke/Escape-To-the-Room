using System.Collections.Generic;
using Controller;
using Data.Items;
using Managers;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Panel
{
    public class InventoryPanel : PanelBase
    {
        [SerializeField] private GameObject itemPrefab;
        [SerializeField] private Button exitButton;

        public override void Init()
        {
            exitButton.onClick.AddListener(TogglePanel);
            

            gameObject.SetActive(false);
        }
        
        public void Refresh(List<ItemBase> list)
        {
            
        }
    }
}