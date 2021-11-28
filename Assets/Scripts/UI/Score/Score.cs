using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI.ScoreUI
{
    //Class for displaying score 
    public class Score : MonoBehaviour
    {
        [SerializeField] private Text _scoreText;

        private void Start()
        {
            _scoreText.text = "0";
        }
        //Adding score to Text
        public void AddScore(int score)
        {
            _scoreText.text = score.ToString();
        }
    }
}
