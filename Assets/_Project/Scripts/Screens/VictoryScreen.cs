using System;
using _Project.Screens;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace _Project.Scripts.Screens
{
    public sealed class VictoryScreen : BaseScreen
    {
        [SerializeField] private Button _goHomeButton;

        private void OnEnable()
        {
            _goHomeButton.onClick.AddListener(() =>
            {
                ButtonOnClicked(_goHomeButton, GoHome);
            });
        }

        private void OnDisable()
        {
            _goHomeButton.onClick?.RemoveAllListeners();
        }
        
        private void GoHome() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
