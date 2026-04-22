using System;
using System.Collections;
using System.Collections.Generic;
using Data.Items;
using Data.Object;
using Data.SOJ;
using Managers;
using UnityEngine;
using Util;

namespace Controller
{
    public class PlayerController : MonoBehaviour
    {
        [Header("PlayerInfo")]
        [SerializeField] public List<ItemBase> Inventory = new List<ItemBase>();
        [SerializeField] private InventoryController invController;
        [SerializeField] public ItemDataBase DataBase;
        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private float _maxSpeed = 5f;
        [SerializeField] private float _acceleration = 8f;
        [SerializeField] private float _deceleration = 10f;
        [SerializeField] private Animator Animator;

        private Vector2 _input;
        private Vector2 _currentVelocity;
        
        private void Awake()
        {
            if (_rb == null)
                _rb = GetComponent<Rigidbody2D>();
        }
        
        public void HandleInput()
        {
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");

            if (Mathf.Abs(h) > Mathf.Abs(v)) v = 0;
            else h = 0;

            _input = new Vector2(h, v).normalized;
        }

        public void HandleMovement()
        {
            Vector2 targetVelocity = _input * _maxSpeed;
            Vector2 direction = targetVelocity.normalized;

             Animator.SetFloat("Horizontal", direction.x);
             Animator.SetFloat("Vertical", direction.y);
             Animator.SetFloat("Speed", targetVelocity.magnitude);

            float rate = (_input.magnitude > 0) ? _acceleration : _deceleration;

            _currentVelocity = Vector2.Lerp(
                _currentVelocity,
                targetVelocity,
                rate * Time.fixedDeltaTime
            );

            _rb.MovePosition(_rb.position + _currentVelocity * Time.fixedDeltaTime);
        }
    }
}
