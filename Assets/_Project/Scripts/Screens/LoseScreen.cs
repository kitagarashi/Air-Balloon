using _Project.Screens;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace _Project.Scripts.Screens
{
    public sealed class LoseScreen : BaseScreen
    {
        [SerializeField] private Button _retryButton;
        [SerializeField] private Button _exitButton;

        private void OnEnable()
        {
            _retryButton.onClick.AddListener(() =>
            {
                ButtonOnClicked(_retryButton, TryAgain);
            });

            _exitButton.onClick.AddListener(() => 
            {
                ButtonOnClicked(_exitButton, TryAgain);
            });
        }

        private void OnDisable()
        {
            _retryButton.onClick.RemoveAllListeners();
            _exitButton.onClick.RemoveAllListeners();
        }
        
        private void TryAgain() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
