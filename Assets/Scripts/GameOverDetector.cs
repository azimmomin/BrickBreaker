using UnityEngine;
using UnityEngine.Events;

public class GameOverDetector : MonoBehaviour
{
    public static event UnityAction OnGameOver;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (OnGameOver != null)
        {
            OnGameOver();
        }
    }
}
