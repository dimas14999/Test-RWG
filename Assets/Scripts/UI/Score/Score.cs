using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI.ScoreUI
{
    //Класс для отображения очков 
    public class Score : MonoBehaviour
    {
        [SerializeField] private Text _scoreText;

        //Добавление очков в Text
        public void AddScore(int score)
        {
            _scoreText.text = score.ToString();
        }
    }
}
