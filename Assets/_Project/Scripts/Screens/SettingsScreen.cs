using _Project.Services;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Screens
{
    public sealed class SettingsScreen : BaseScreen
    {
        [SerializeField] private Button _goBackButton;
        [SerializeField] private Button _privacyPolicyButton;
        [SerializeField] private Button _termsOfUseButton;
        [SerializeField] private Button _supportButton;

        [SerializeField] private string _privacyPolicyLink;
        [SerializeField] private string _termsOfUseLink;
        [SerializeField] private string _supportLink;

        private void OnEnable()
        {
            _goBackButton.onClick.AddListener(() => 
            {
                ButtonOnClicked(_goBackButton, GoBack);
            });

            _privacyPolicyButton.onClick.AddListener(() => 
            {
                ButtonOnClicked(_privacyPolicyButton, GoPrivacyPolicyLink); 
            });

            _termsOfUseButton.onClick.AddListener(() => 
            {
                ButtonOnClicked(_termsOfUseButton, GoTermsOfUse);
            });

            _supportButton.onClick.AddListener(() => 
            {
                ButtonOnClicked(_supportButton, GoSupport);
            });
        }

        private void OnDisable()
        {
            _goBackButton.onClick.RemoveAllListeners();
            _privacyPolicyButton.onClick.RemoveAllListeners();
            _termsOfUseButton.onClick.RemoveAllListeners();
            _supportButton.onClick.RemoveAllListeners();
        }

        private void GoPrivacyPolicyLink()
        {
            Application.OpenURL(_privacyPolicyLink);
        }

        private void GoTermsOfUse()
        {
            Application.OpenURL(_termsOfUseLink);
        }

        private void GoSupport()
        {
            Application.OpenURL(_supportLink);
        }

        private void OpenSupport()
        {
            //var subject = "Support Request";
            //var body = "Hello, I need help with...";
            //var mailto = $"mailto:{_supportEmail}?subject={Uri.EscapeDataString(subject)}&body={Uri.EscapeDataString(body)}";

            //Application.OpenURL(mailto);
        }

        private void GoBack() => ScreenStateMachine.Instance.SetScreen(State.Menu);
    }
}
