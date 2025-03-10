using _Project.Services;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Screens
{
    public sealed class LevelSelectorScreen : BaseScreen
    {
        [SerializeField] private Button _goBackButton;
 
        [SerializeField] private Button[] _levels;

        [SerializeField] private Sprite _unlockedSprite;
        [SerializeField] private Sprite _greenButton;

        private void OnEnable()
        {
            _goBackButton.onClick.AddListener(() =>
            {
                ButtonOnClicked(_goBackButton, GoBack);
            });
            int unlockedLevels = SaveService.Level;
            for (int i = 0; i < unlockedLevels; i++)
            {
                _levels[i].transform.GetChild(1).GetComponent<Image>().sprite = _unlockedSprite;
                _levels[i].GetComponent<Image>().sprite = _greenButton;
            }
        }

        private void OnDisable() 
        {
            _goBackButton.onClick.RemoveAllListeners();
        }

        public void OpenLevel(int level)
        {
            Screen.orientation = ScreenOrientation.LandscapeRight;
            switch (level)
            {
                case 1:
                    ScreenStateMachine.Instance.SetScreen(State.SearchForATree);
                    break;
                case 2:
                    ScreenStateMachine.Instance.SetScreen(State.SearchForAFabric);
                    break;
                case 3:
                    ScreenStateMachine.Instance.SetScreen(State.SearchForARopes);
                    break;
                case 4:
                    ScreenStateMachine.Instance.SetScreen(State.TransportRepair);
                    break;
                case 5:
                    ScreenStateMachine.Instance.SetScreen(State.DepartureFromIsland);
                    break;
                case 6:
                    ScreenStateMachine.Instance.SetScreen(State.CrossingTheSea);    
                    break;
                case 7:
                    ScreenStateMachine.Instance.SetScreen(State.TheWayHome);
                    break;
            }
        }

        private void GoBack()
        {
            ScreenStateMachine.Instance.SetScreen(State.Menu);
        }
    }
}
