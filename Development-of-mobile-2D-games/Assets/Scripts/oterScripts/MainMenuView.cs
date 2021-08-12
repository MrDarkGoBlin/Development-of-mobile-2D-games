using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Ui
{
    public class MainMenuView : MonoBehaviour
    {
        [SerializeField]
        private Button _buttonStart;
        [SerializeField]
        private Button _buttonReward;
        [SerializeField]
        private Button _buttonExit;

        public void Init(UnityAction startGame, UnityAction dailyReward)
        {
            _buttonStart.onClick.AddListener(startGame);
            _buttonReward.onClick.AddListener(dailyReward);
            _buttonExit.onClick.AddListener(ExitGame);
        }

        protected void OnDestroy()
        {
            _buttonStart.onClick.RemoveAllListeners();
            _buttonReward.onClick.RemoveAllListeners();
            _buttonExit.onClick.RemoveAllListeners();
        }

        private void ExitGame()
        {
            Application.Quit();
        }
    }
}
