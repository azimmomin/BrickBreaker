using UnityEngine;

public class GameSpeedScaler : MonoBehaviour
{
    [Range(0.1F, 10.0F)] [SerializeField] private float gameSpeed = 1.0F;
    void Update()
    {
        Time.timeScale = gameSpeed;
    }
}