using Data.Object;
using Managers.Base;
using Player;
using UnityEngine;

namespace Managers
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class InputManager : SingletonManagerBase<InputManager>
    {
        [SerializeField] private KeyCode Interaction = KeyCode.E;
        [SerializeField] private KeyCode Esc = KeyCode.Escape;
        [SerializeField] private KeyCode Inventory = KeyCode.Tab;

        private void Update()
        {
            PlayerController.instance.HandleMovement();
            PlayerController.instance.HandleInput();
            
            if (Input.GetKeyDown(Esc)) UIManager.Instance.ToggleESC();
            if (Input.GetKeyDown(Interaction)) SelectManager.Instance.HandleInteractionInCharacter(transform);
            if (Input.GetMouseButtonDown(0)) SelectManager.Instance.HandleInteractionInMouse(transform);
        }
    }
}