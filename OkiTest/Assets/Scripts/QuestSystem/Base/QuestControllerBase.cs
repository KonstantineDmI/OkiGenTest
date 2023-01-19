using QuestSystem.Base;
using System;
using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;

namespace QuestSystem
{
    public abstract class QuestControllerBase : MonoBehaviour
    {
        [SerializeField] protected QuestEntity quest;
        [SerializeField] protected QuestView questView;

        protected int _currentAmount;

        public event Action OnQuestComplete;
        public event Action OnAmountChanged;


        protected void IncreaseAmount(int value)
        {
            _currentAmount += value;
            OnAmountChanged?.Invoke();
            CheckComplete();
        }

        protected void DecreaseAmount(int value)
        {
            _currentAmount = _currentAmount - value < 0 ? 0 : _currentAmount - value;
            OnAmountChanged?.Invoke();
        }

        protected void CheckComplete()
        {
            if(_currentAmount == quest.amount)
            {
                OnQuestComplete?.Invoke();
            }
        }




        


    }
}
