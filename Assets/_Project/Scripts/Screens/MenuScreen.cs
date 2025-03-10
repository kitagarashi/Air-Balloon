using System;
using _Project.Services;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

namespace _Project.Screens
{
    public sealed class MenuScreen : BaseScreen
    {
        [SerializeField] private GameObject _game;

        [SerializeField] private Button _storylineButton;
        [SerializeField] private Button _quickGameButton;
        [SerializeField] private Button _settingsButton;
        [SerializeField] private Button _musicButton;

        [SerializeField] private TMP_Text _musicStatus;
        private void OnEnable()
        {
            _storylineButton.onClick.AddListener(() =>
            {
                ButtonOnClicked(_storylineButton,GoStoryline);
            });
            
            _quickGameButton.onClick.AddListener(() =>
            {
                ButtonOnClicked(_quickGameButton, OpenQuickGame);
            });
            
            _musicButton.onClick.AddListener(() =>
            {
                ButtonOnClicked(_musicButton, ChangeMusic);
            });
            _settingsButton.onClick.AddListener(() =>
            {
                ButtonOnClicked(_settingsButton, OpenSettings);
            });
        }

        private void OnDisable()
        {
            _storylineButton.onClick.RemoveAllListeners();
            _quickGameButton.onClick.RemoveAllListeners();
            _musicButton.onClick.RemoveAllListeners();
            _settingsButton.onClick.RemoveAllListeners();
        }

        private void Start()
        {
            Screen.orientation = ScreenOrientation.Portrait;
            UpdateUI();
        }

        private void GoStoryline() => ScreenStateMachine.Instance.SetScreen(State.LevelSelector);
        private void OpenSettings() => ScreenStateMachine.Instance.SetScreen(State.Settings);

        private void OpenQuickGame()
        {
            ScreenStateMachine.Instance.SetScreen(State.CrossingTheSea);  
        }

        private void ChangeMusic()
        {
            SaveService.Sound = !SaveService.Sound;
            UpdateUI();
        }

        private void UpdateUI()
        {
            _musicStatus.text = SaveService.Sound ? "Music: On" : "Music: Off";
        }
    }
}
