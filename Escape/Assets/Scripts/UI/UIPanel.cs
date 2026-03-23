using Managers;
using UI.Attributes;
using UnityEngine;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

namespace UI
{
    public class UIPanel : UIBase
    {
        [Bind("Exit"), SerializeField] private Button exitButton;
        [Bind("ReStart"), SerializeField] private Button mainMenuButton;

        protected override void Start()
        {
            base.Start();

            exitButton.onClick.AddListener(OnToggle);
            mainMenuButton.onClick.AddListener(ExitGame);
            gameObject.SetActive(false);
        }

        public void OnToggle()
        {
            UIManager.Instance.ToggleUI(this);
        }

        public void ExitGame()
        {
            
        }
    }
}