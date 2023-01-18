using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Conveyor
{
    public class ConveyorAnimation : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private Material material;

        private void Update()
        {
            var currentValue = material.GetTextureOffset("_MainTex").y;
            material.SetTextureOffset("_MainTex", new Vector2(0, currentValue += 0.01f));
        }
    }
}
