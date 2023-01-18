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


        public void SetKinematic(bool state)
        {
            rigidBody.isKinematic = state;
        }

        private void OnMouseDown()
        {
            Debug.Log("clicked");
            OnMouseClicked?.Invoke(this);
        }
        private void OnDestroy()
        {
            OnDestroyAction?.Invoke(this);
        }
    }
}
