using Managers;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Panel
{
    public class ESCPanel : PanelBase
    {
        [SerializeField] private Button exitButton;
        
        public override void Init()
        {
            exitButton.onClick.AddListener(TogglePanel);
            

            gameObject.SetActive(false);
        }
    }
}
