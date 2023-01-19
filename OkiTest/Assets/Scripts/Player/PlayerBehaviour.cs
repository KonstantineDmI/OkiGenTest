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
        [SerializeField] private AnimationsController animationsController;
        [SerializeField] private TwoBoneIKConstraint grabHand;
        [SerializeField] private TwoBoneIKConstraint holdHand;
        [SerializeField] private Transform point;
        [SerializeField] private Transform cartPoint;
        [SerializeField] private Cart cart;

        private bool _playerIsBusy;

        public void Grab(ItemBehaviour item)
        {
            ActivateHand(1);
            PutToCart(item);
        }

        public void SetVictoryState()
        {
            animationsController.VictoryAnimation();
            holdHand.weight = 0;
        }

        private void ActivateHand(float value)
        {
            DOTween.To(() => grabHand.weight, x => grabHand.weight = x, value, 0.3f);
        }

        private void PutToCart(ItemBehaviour item)
        {
            if (_playerIsBusy)
            {
                return;
            }

            _playerIsBusy = true;
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
                    _playerIsBusy = false;
                    cart.AddItem(item);
                });
            });
        }
    }
}
