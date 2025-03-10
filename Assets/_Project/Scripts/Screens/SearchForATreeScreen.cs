using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Screens
{
    public sealed class SearchForATreeScreen : BaseScreen
    {
        [SerializeField] private Button _goBackButton;
        [SerializeField] private GameObject _game;

        private void OnEnable()
        {
            _game.SetActive(true);
        }

        private void OnDisable() 
        {
            _game.SetActive(false);
        }
    }
}
