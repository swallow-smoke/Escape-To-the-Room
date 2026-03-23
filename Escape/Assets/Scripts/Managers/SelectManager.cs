using Data.Object;
using Data.Object.Interface;
using Managers.Base;
using UnityEngine;

namespace Managers
{
    public class SelectManager : SingletonManagerBase<SelectManager>
    {
        private GameObject _currentSelected;
        
        [SerializeField] private LayerMask tileLayer;
        [SerializeField] public GameObject SelectedObject;
        [SerializeField] private float raycastDistance = 5;

        
        public void HandleInteractionInCharacter(Transform position)
        {
            Vector2 direction = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
            RaycastHit2D hit = Physics2D.Raycast(position.position, direction, raycastDistance, tileLayer);

            if (hit.collider != null)
            {   
                ISelectable selectable = hit.collider.GetComponent<ISelectable>();

                if (selectable != null)
                {
                    SelectedObject = hit.collider.gameObject;
                    Debug.Log(selectable);
                    selectable.OnSelect();
                }
            }
        }

        public void HandleInteractionInMouse(Transform position)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = position.position.z;
            
            RaycastHit2D hit = Physics2D.Raycast(position.position, mousePos, raycastDistance, tileLayer);

            if (hit.collider != null)
            {
                ISelectable selectable = hit.collider.GetComponent<ISelectable>();

                if (selectable != null)
                {
                    SelectedObject = hit.collider.gameObject;
                    Debug.Log(selectable);
                    selectable.OnSelect();
                }
            }
        }
    }
}