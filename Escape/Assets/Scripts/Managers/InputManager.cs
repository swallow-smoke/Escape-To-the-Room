using Data.Object;
using UnityEngine;

namespace Managers
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class InputManager : SingletonManagerBase<InputManager>
    {
        private KeyCode Interaction = KeyCode.E;

        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private float _maxSpeed = 5f;
        [SerializeField] private float _acceleration = 8f;
        [SerializeField] private float _deceleration = 10f;
        [SerializeField] private LayerMask tileLayer;
        [SerializeField] public GameObject SelectedObject;
        [SerializeField] private float raycastDistance = 5;

        private Vector2 _input;
        private Vector2 _currentVelocity;

        private void Awake()
        {
            if (_rb == null)
                _rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            HandleInput();

            if (Input.GetKeyDown(Interaction)) HandleInteractionInCharacter();
            if (Input.GetMouseButtonDown(0)) HandleInteractionInMouse();
        }

        private void FixedUpdate()
        {
            HandleMovement();
        }

        private void HandleInput()
        {
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");

            _input = new Vector2(h, v).normalized;
        }

        private void HandleMovement()
        {
            Vector2 targetVelocity = _input * _maxSpeed;

            float rate = (_input.magnitude > 0) ? _acceleration : _deceleration;

            _currentVelocity = Vector2.Lerp(
                _currentVelocity,
                targetVelocity,
                rate * Time.fixedDeltaTime
            );

            _rb.MovePosition(_rb.position + _currentVelocity * Time.fixedDeltaTime);
        }

        private void HandleInteractionInCharacter()
        {
            Vector2 direction = transform.right * Input.GetAxisRaw("Horizontal");
            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, raycastDistance, tileLayer);

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

        private void HandleInteractionInMouse()
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = transform.position.z;
            
            RaycastHit2D hit = Physics2D.Raycast(transform.position, mousePos, raycastDistance, tileLayer);

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