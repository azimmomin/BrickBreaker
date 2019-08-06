using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static event UnityAction<int> OnScoreUpdated;

    [SerializeField] private SceneLoader sceneLoader = null;

    private uint totalNumberOfBlocksInLevel = 0;
    private int score = 0;
    private void Awake()
    {
        Block.OnBlockCreated += OnBlockCreated;
        Block.OnBlockDestroyed += OnBlockDestroyed;
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnBlockCreated()
    {
        totalNumberOfBlocksInLevel += 1;
    }

    private void OnBlockDestroyed(int pointValueOfBlock)
    {
        score += pointValueOfBlock;
        if (OnScoreUpdated != null)
        {
            OnScoreUpdated(score);
        }

        totalNumberOfBlocksInLevel -= 1;
        if (totalNumberOfBlocksInLevel == 0)
        {
            sceneLoader.LoadNextGameLevelScene();
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        // Broadcast the score so that our UI can update on scene load.
        if (OnScoreUpdated != null)
        {
            OnScoreUpdated(score);
        }
    }

    private void OnDestroy()
    {
        Block.OnBlockCreated -= OnBlockCreated;
        Block.OnBlockDestroyed -= OnBlockDestroyed;
    }
}
