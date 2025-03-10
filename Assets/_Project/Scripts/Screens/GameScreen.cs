using System;
using _Project.Services;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace _Project.Screens
{
    public sealed class GameScreen : BaseScreen
    {
        [SerializeField] private GameObject _gameScreen;
        [SerializeField] private Button _backButton;

        private void OnEnable()
        {
            _gameScreen.SetActive(true);
            _backButton.onClick.AddListener(() =>
            {
                ButtonOnClicked(_backButton, GoBack);
            });
        }

        private void OnDisable()
        {
            _gameScreen.SetActive(false);
            _backButton.onClick.RemoveAllListeners();
        }

        private void GoBack() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }   
}
