using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Products
{
    public class ItemBehaviour : MonoBehaviour
    {
        [SerializeField] private Rigidbody rigidBody;

        public event Action<ItemBehaviour> OnDestroyAction;

        public event Action<ItemBehaviour> OnMouseClicked;

        public int id;
        private bool _isUsed;

        public void SetKinematic(bool state)
        {
            rigidBody.isKinematic = state;
        }

        private void OnMouseDown()
        {
            if (_isUsed)
            {
                return;
            }

            OnMouseClicked?.Invoke(this);
            _isUsed = true;
        }
        private void OnDestroy()
        {
            OnDestroyAction?.Invoke(this);
        }
    }
}
