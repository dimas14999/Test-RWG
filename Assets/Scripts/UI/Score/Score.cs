using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI.ScoreUI
{

    public class Score : MonoBehaviour
    {
        [SerializeField] private Text _scoreText;

        private void Start()
        {
            _scoreText.text = "0";
        }

        public void DisplayScore(int score)
        {
            _scoreText.text = score.ToString();
        }
    }
}
