using UnityEngine;

namespace UI
{
    [System.Serializable]
    public abstract class PanelBase : UIBase
    {
        private CanvasGroup _canvasGroup;

        public abstract void Init();

        public virtual void TogglePanel() => gameObject.SetActive(!gameObject.activeSelf);
        

        protected void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
            if (_canvasGroup == null)
                _canvasGroup = gameObject.AddComponent<CanvasGroup>();
        }
    }
}