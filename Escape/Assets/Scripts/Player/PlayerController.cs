using System;
using System.Collections;
using System.Collections.Generic;
using Data.Items;
using Data.Object;
using Data.SOJ;
using Managers;
using UnityEngine;
using Util;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        public static PlayerController instance;
        
        [SerializeField] public List<ItemBase> Inventory = new List<ItemBase>();
        [SerializeField] private StatusEffectController effectController;
        [SerializeField] private InventoryController invController;
        [SerializeField] public ItemDataBase DataBase;
        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private float _maxSpeed = 5f;
        [SerializeField] private float _acceleration = 8f;
        [SerializeField] private float _deceleration = 10f;

        private Vector2 _input;
        private Vector2 _currentVelocity;
        
        private void Awake()
        {
            if (instance != null && instance != this)
            {
                Debug.Log("instance isn't allowed multiple");
                Destroy(gameObject);
                return;
            }

            instance = this;
            
            if (_rb == null)
                _rb = GetComponent<Rigidbody2D>();
        }
        
        public void HandleInput()
        {
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");

            _input = new Vector2(h, v).normalized;
        }

        public void HandleMovement()
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
    }
}
