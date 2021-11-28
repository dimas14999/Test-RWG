using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class DeadScreen : MonoBehaviour
{
    [SerializeField] private Text _score;

    // Displaying the score
    public void Score(int score)
    {
        _score.text = $"Score: {score}";
    }

    // Restarting the level
    public void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
