using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class QuestView : MonoBehaviour
    {
        [SerializeField] private string labelTemplate;
        [SerializeField] private string statLabelTemplate;
        [SerializeField] private Image itemIcon;
        [SerializeField] private TextMeshProUGUI questLabel;
        [SerializeField] private TextMeshProUGUI questStat;


        public void SetSprite(Sprite sprite)
        {
            itemIcon.sprite = sprite;
        }

        public void SetStatText(int currentValue, int targetValue)
        {
            questStat.text = string.Format(statLabelTemplate, currentValue, targetValue);
        }

        public void SetLabelText(int amount, string name)
        {
            questLabel.text = string.Format(labelTemplate, amount, name);
        }
    }
}
