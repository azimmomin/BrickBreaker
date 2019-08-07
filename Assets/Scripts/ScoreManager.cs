using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText = null;
    private void Awake()
    {
        GameManager.OnScoreUpdated += this.UpdateScore;
    }

    private void UpdateScore(int newScore)
    {
        scoreText.text = newScore.ToString();
    }

    void OnDestroy()
    {
        GameManager.OnScoreUpdated += this.UpdateScore;
    }
}
