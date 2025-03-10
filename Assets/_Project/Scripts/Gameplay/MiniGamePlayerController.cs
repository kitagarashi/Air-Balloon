using _Project.Services;
using TMPro;
using UnityEngine;

namespace _Project.Gameplay
{
    public sealed class MiniGamePlayerController : MonoBehaviour
    {
        [SerializeField] private FixedJoystick _joystick;
        [SerializeField] private int _needToCollect;
        [SerializeField] private GameObject _popUp;
        [SerializeField] private TMP_Text _text;
        private int _collected;

        private void Update()
        {
            transform.Translate(new Vector2(_joystick.Horizontal, _joystick.Vertical) * 4 * Time.deltaTime);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "1")
            {
                collision.gameObject.SetActive(false);
                _collected++;
                _text.text = $"{_collected}/{_needToCollect}";

                if (_collected == _needToCollect)
                {
                    _popUp.SetActive(true);
                    SaveService.Level++;

                }
            }
        }
    }
}
