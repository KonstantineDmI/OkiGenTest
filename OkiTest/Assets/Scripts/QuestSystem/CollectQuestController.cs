
using Factory;
using Products;
using QuestSystem.Base;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuestSystem
{
    public class CollectQuestController : QuestControllerBase
    {
        [SerializeField] private GeneralProductsFactory productsConfig;
        [SerializeField] private Cart cart;

        private Item _itemToCollect;

        private void Start()
        {
            OnAmountChanged += UpdateView;
            quest.InitializeQuestAmount();
            GenerateItem();
            InitializeView();
            cart.OnCartUpdated += CheckItemValid;
        }

        private void GenerateItem()
        {
           _itemToCollect = productsConfig.GetRandomItem();
            cart.targetItemId = _itemToCollect.id;
        }

        private void CheckItemValid(ItemBehaviour item)
        {
            if(_itemToCollect.id == item.id)
            {
                IncreaseAmount(1);
            }
            else
            {
                cart.RemoveFromCart();
                DecreaseAmount(1);
            }
        }

        private void InitializeView()
        {
            questView.SetSprite(_itemToCollect.sprite);
            questView.SetLabelText(quest.amount, _itemToCollect.name);
            UpdateView();
        }

        private void UpdateView()
        {
            questView.SetStatText(_currentAmount, quest.amount);
        }
        
    }
}
