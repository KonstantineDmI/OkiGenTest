using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Conveyor
{
    public class DespawnZone : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Product"))
            {
                Destroy(other.gameObject);
            }
        }
    }
}
