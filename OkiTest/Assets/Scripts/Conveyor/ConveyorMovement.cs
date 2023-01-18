using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Conveyor
{
    public class ConveyorMovement : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private Rigidbody rigidbody;

        private void FixedUpdate()
        {
            Vector3 position = rigidbody.position;
            rigidbody.position += Vector3.left * speed * Time.fixedDeltaTime;
            rigidbody.MovePosition(position);
        }

    }
}
