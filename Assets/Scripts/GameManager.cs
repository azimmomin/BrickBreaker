using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static event UnityAction<int> OnScoreUpdated;

    [SerializeField] private SceneLoader sceneLoader = null;
    private uint totalNumberOfBlocksInLevel = 0;
    private int score = 0;
    private void Awake()
    {
        Block.OnBreakableBlockCreated += OnBlockCreated;
        Block.OnBreakableBlockDestroyed += OnBlockDestroyed;
        SceneManager.sceneLoaded += OnSceneLoaded;
        GameOverDetector.OnGameOver += OnGameOver;

        ResetGame();
    }

    private void OnBlockCreated()
    {
        totalNumberOfBlocksInLevel += 1;
    }

    private void OnBlockDestroyed(int pointValueOfBlock)
    {
        score += pointValueOfBlock;
        OnScoreUpdated?.Invoke(score);

        totalNumberOfBlocksInLevel -= 1;
        if (totalNumberOfBlocksInLevel == 0)
        {
            sceneLoader.LoadNextGameLevelScene();
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        // Broadcast the score so that our UI can update on scene load.
        OnScoreUpdated?.Invoke(score);
    }

    private void OnGameOver()
    {
        sceneLoader.LoadGameOverScene();
        Destroy(gameObject);
    }

    private void ResetGame()
    {
        totalNumberOfBlocksInLevel = 0;
        score = 0;
    }

    private void OnDestroy()
    {
        Block.OnBreakableBlockCreated -= OnBlockCreated;
        Block.OnBreakableBlockDestroyed -= OnBlockDestroyed;
        SceneManager.sceneLoaded -= OnSceneLoaded;
        GameOverDetector.OnGameOver -= OnGameOver;
    }
}
