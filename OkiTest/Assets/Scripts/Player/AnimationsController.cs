using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class AnimationsController : MonoBehaviour
    {
        [SerializeField] private Animator animator;

        public void VictoryAnimation()
        {
            animator.SetTrigger("IsVictory");
        }
    }
}
