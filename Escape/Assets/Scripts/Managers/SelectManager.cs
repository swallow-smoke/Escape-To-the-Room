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
        private Vector2 direction = Vector2.right;

        
        public void HandleInteractionInCharacter(Transform position)
        {
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");

            if (h != 0 || v != 0)
            {
                if (Mathf.Abs(h) >= Mathf.Abs(v))
                {
                    direction = new Vector2(h > 0 ? 1 : -1, 0);
                }
                else
                {
                    direction = new Vector2(0, v > 0 ? 1 : -1);
                }
            }
            Debug.DrawRay(position.position, direction, color:Color.red);
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