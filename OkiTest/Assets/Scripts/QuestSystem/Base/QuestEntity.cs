using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace QuestSystem.Base
{
    [Serializable]
    public class QuestEntity
    {
        [SerializeField] private int minValue;
        [SerializeField] private int maxValue;

        public int amount;
        public void InitializeQuestAmount()
        {
            amount = Random.Range(minValue, maxValue);
        }
    }
}
