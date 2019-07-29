using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverDetector : MonoBehaviour
{
    [SerializeField]
    private SceneLoader sceneLoader = null;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        sceneLoader.LoadGameOverScene();
    }
}
