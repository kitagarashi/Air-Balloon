using _Project.Services;
using TMPro;
using UnityEngine;

namespace _Project.Scripts.Gameplay
{
    public sealed class GameManager : Singleton<GameManager>
    {
        [SerializeField] private GameObject _popUp;
        [SerializeField] private PlayerController _player;
        [SerializeField] private TMP_Text _scoreText;

        [SerializeField] private int _requiredScore;
        private int _currentScore;
       

        public void IncreaseScore()
        {
            _currentScore++;
            _scoreText.text =  $"Distance: {_currentScore}/{_requiredScore}";
            if (_currentScore >= _requiredScore)
            {
                _popUp.SetActive(true);
                SaveService.Level++;
                _scoreText.text = $"Distance: {_currentScore}/{_requiredScore}";
            }
        }

        public void Lose()
        {
            //ScreenStateMachine.Instance.SetScreen(State.Lost);
            Destroy(gameObject);
        }
    }
}
