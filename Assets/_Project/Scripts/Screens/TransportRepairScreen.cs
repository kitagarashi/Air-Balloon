using _Project.Services;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

namespace _Project.Screens
{
    public sealed class TransportRepairScreen : BaseScreen
    {
        [SerializeField] private Button _backButton;
        [SerializeField] private Button _fixButton;

        [SerializeField] private TMP_Text _clicksText;

        [SerializeField] private GameObject _firstPhase;
        [SerializeField] private GameObject _secondPhase;
        [SerializeField] private GameObject _thirdPhase;

        [SerializeField] private GameObject _popUp;

        private int _clicks = 0;

        private void OnEnable()
        {
            _fixButton.onClick.AddListener(() => 
            {
                ButtonOnClicked(_fixButton, Click);
            });
        }

        private void OnDisable()
        {
            _backButton.onClick.RemoveAllListeners();
            _fixButton.onClick.RemoveAllListeners();
        }

        private void Click()
        {
            _clicks++;
            _clicksText.text = $"(Fix {_clicks}/20)";
            if (_clicks == 5)
            {
                _firstPhase.SetActive(true);
            }
            if (_clicks == 10) 
            {
                _secondPhase.SetActive(true);
                _firstPhase.SetActive(false);
            }
            if (_clicks == 15) 
            {
                _thirdPhase.SetActive(true);
                _secondPhase.SetActive(false);
            }
            if (_clicks == 20) 
            {
                _popUp.SetActive(true);
                SaveService.Level++;
            }
        }
    }
}
