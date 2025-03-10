using System;
using System.Collections;
using _Project.Scripts.Gameplay.Spawn;
using _Project.Services;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.Gameplay
{
    public sealed class PlayerController : MonoBehaviour
    {
        [SerializeField] private GameObject _losePopUp;

        [SerializeField] private Button _leftButton;
        [SerializeField] private Button _rightButton;

        [SerializeField] private TMP_Text _strengthText;

        [SerializeField] private Transform _firstLine;
        [SerializeField] private Transform _secondLine;
        [SerializeField] private Transform _thirdLine;
        [SerializeField] private Transform _fourthLine;
        [SerializeField] private Transform _fifthLine;

        [SerializeField] private Ease _ease = Ease.Linear;

        [SerializeField, Range(0, 10)] private float _speed = 10f;

        private int _currentLineIndex; // 0 = first, 1 = second, 2 = third, 3 = fourth, 4 = fifth
        private Transform[] _lines;

        private int _strength = 3;

        private void Start()
        {
            _lines = new[] { _firstLine, _secondLine, _thirdLine, _fourthLine, _fifthLine };
            _currentLineIndex = 1;
        }

        private void OnEnable()
        {
            _leftButton.onClick.AddListener(MoveLeft);
            _rightButton.onClick.AddListener(MoveRight);
        }

        private void OnDisable()
        {
            _leftButton.onClick.RemoveAllListeners();
            _rightButton.onClick.RemoveAllListeners();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.TryGetComponent<Obstacle>(out Obstacle obstacle))
            {
                if (obstacle.IsConsumable)
                {
                    AudioService.Instance.PlaySound("Score");
                }
                else
                {
                    Destroy(obstacle.gameObject);
                    _strength--;
                    _strengthText.text = "Strength " + _strength.ToString();
                    if (_strength == 0)
                    {
                        _losePopUp.SetActive(true);
                        Debug.Log("Lose");
                    }
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.TryGetComponent<Obstacle>(out Obstacle obstacle))
            {
            
                Destroy(obstacle.gameObject);
                _strength--;
                _strengthText.text = $"Strength: {_strength.ToString()}/3";
                if (_strength == 0)
                {
                    _losePopUp.SetActive(true);
                    Debug.Log("Lose");
                }             
            }
        }

        private void MoveLeft()
        {
            if (_currentLineIndex > 0)
            {
                _currentLineIndex--;
                Move(_lines[_currentLineIndex], _leftButton);
            }
        }

        private void MoveRight()
        {
            if (_currentLineIndex < _lines.Length - 1)
            {
                _currentLineIndex++;
                Move(_lines[_currentLineIndex], _rightButton);
            }
        }

        private void Move(Transform line, Button button)
        {
            AudioService.Instance.PlaySound("Move");
            _leftButton.interactable = _currentLineIndex > 0;
            _rightButton.interactable = _currentLineIndex < _lines.Length - 1;

            transform
                .DOMoveY(line.position.y, CalculateTime(line))
                .SetEase(_ease)
                .OnComplete(() => button.interactable = true);
        }

        private float CalculateTime(Transform line)
        {
            return Vector2.Distance(transform.position, line.position) / _speed;
        }

        public void AddStrength()
        {
            _strength++;
            _strengthText.text = "Strength " + _strength.ToString();
        }
    }
}
