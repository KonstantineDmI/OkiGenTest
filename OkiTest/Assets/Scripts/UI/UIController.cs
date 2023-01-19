using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private Button nextLevelButton;
        [SerializeField] private GameObject content;
        [SerializeField] private Image fade;

        private void Start()
        {
            nextLevelButton.onClick.AddListener(ReloadScene);
        }

        public void ActivateContent()
        {
            content.SetActive(true);
            fade.DOFade(0.8f, 1f);
        }

        private void ReloadScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
