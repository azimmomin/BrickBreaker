using UnityEngine;

public class GameOverDetector : MonoBehaviour
{
    [SerializeField] private SceneLoader sceneLoader = null;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        sceneLoader.LoadGameOverScene();
        // TODO: Fire an event that the game is over.
        // Listen for event in LevelManager so that we
        // can reset the score.
    }
}
