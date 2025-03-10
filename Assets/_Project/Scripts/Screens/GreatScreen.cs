using System;
using _Project.Screens;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace _Project.Scripts.Screens
{
    public sealed class GreatScreen : BaseScreen
    {
        [SerializeField] private Button _homeButton;

        private void OnEnable()
        {
            _homeButton.onClick.AddListener(() =>
            {
                ButtonOnClicked(_homeButton, RestartGame);
            });
        }

        private void OnDisable()
        {
            _homeButton.onClick?.RemoveAllListeners();
        }
        
        private void RestartGame() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
