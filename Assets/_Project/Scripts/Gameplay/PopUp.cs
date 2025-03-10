using _Project.Services;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace _Project.Gameplay
{
    public sealed class PopUp : MonoBehaviour
    {
        public void Close()
        {
            gameObject.SetActive(false);
        }

        public void Continue()
        {
            ScreenStateMachine.Instance.SetScreen(State.LevelSelector);
            Screen.orientation = ScreenOrientation.Portrait;
        }

        public void Reset()
        {
            SceneManager.LoadScene(0);
        }
    }
}
