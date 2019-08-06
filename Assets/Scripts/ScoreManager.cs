using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText = null;
    private void Awake()
    {
        LevelManager.OnScoreUpdated += this.UpdateScore;
    }

    private void UpdateScore(int newScore)
    {
        scoreText.text = newScore.ToString();
    }

    void OnDestroy()
    {
        LevelManager.OnScoreUpdated += this.UpdateScore;
    }
}
