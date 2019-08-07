using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    const int IndexOfMainMenuScene = 0;
    const int IndexOfGameOverScene = 1;
    const int IndexOfFirstGameLevelScene = 2;

    public void LoadFirstGameLevelScene()
    {
        SceneManager.LoadScene(IndexOfFirstGameLevelScene);
    }

    public void LoadNextGameLevelScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        // If we are at the last game level scene, load the game over scene.
        if (currentSceneIndex == SceneManager.sceneCount - 1)
        {
            LoadGameOverScene();
            return;
        }

        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(IndexOfMainMenuScene);
    }

    public void LoadGameOverScene()
    {
        SceneManager.LoadScene(IndexOfGameOverScene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
