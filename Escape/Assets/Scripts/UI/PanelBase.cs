using UI.Attributes;
using UnityEngine;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

namespace UI
{
    [Bind("UIPanel")]
    public class UIPanel : UIBase
    {
        [Bind("Exit"), SerializeField] private Button exitButton;
        [Bind("ReStart"), SerializeField] private Button mainMenuButton;

        protected override void Awake()
        {
            base.Awake();
            
            exitButton.onClick.AddListener(OnClose);
            mainMenuButton.onClick.AddListener(ExitGame);
        }
        
        public void OnClose()
        {
            base.Close();
        }

        public void ExitGame()
        {
            
        }
    }
}