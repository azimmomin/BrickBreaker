using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private uint totalNumberOfBlocksInLevel = 0;
    private void Awake()
    {
        Block.OnBlockCreated += OnBlockCreated;
        Block.OnBlockDestroyed += OnBlockDestroyed;
    }

    private void OnBlockCreated()
    {
        totalNumberOfBlocksInLevel += 1;
        Debug.Log("total blocks =" + totalNumberOfBlocksInLevel);
    }

    private void OnBlockDestroyed()
    {
        totalNumberOfBlocksInLevel -= 1;
        Debug.Log("total blocks =" + totalNumberOfBlocksInLevel);
        if (totalNumberOfBlocksInLevel == 0)
        {
            Debug.Log("GAME OVER!");
        }
    }

    private void OnDestroy()
    {
        Block.OnBlockCreated -= OnBlockCreated;
        Block.OnBlockDestroyed -= OnBlockDestroyed;
    }
}
