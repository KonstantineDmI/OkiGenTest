using DG.Tweening;
using Products;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

namespace Player
{
    public class PlayerBehaviour : MonoBehaviour
    {
        [SerializeField] private TwoBoneIKConstraint twoBoneIKConstraint;
        [SerializeField] private Transform point;
        [SerializeField] private Transform cartPoint;

        public void Grab(ItemBehaviour item)
        {
            ActivateHand(1);
            PutToCart(item);
        }

        private void ActivateHand(float value)
        {
            DOTween.To(() => twoBoneIKConstraint.weight, x => twoBoneIKConstraint.weight = x, value, 0.3f);
        }

        private void PutToCart(ItemBehaviour item)
        {
            point.DOMove(item.transform.position, 0.3f).OnComplete(() => 
            {
                item.SetKinematic(true);
                item.transform.parent = point.transform;
                item.transform.localPosition = Vector3.zero;
                point.DOMove(cartPoint.position, 0.3f).OnComplete(() =>
                {
                    item.transform.parent = null;
                    ActivateHand(0);
                    point.DOLocalMove(Vector3.zero, 0.3f);
                    item.SetKinematic(false);
                });
            });
        }
    }
}
