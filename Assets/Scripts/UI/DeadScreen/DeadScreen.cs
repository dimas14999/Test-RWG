using UnityEngine.UI;
using UnityEngine;

public class DeadScreen : MonoBehaviour
{
    [SerializeField] private Text _score;

    public void DisplayScore(int score)
    {
        _score.text = $"Score: {score}";
    }  
}
