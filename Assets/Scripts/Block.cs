using UnityEngine;
using UnityEngine.Events;

public class Block : MonoBehaviour
{
    public static event UnityAction OnBlockCreated;
    public static event UnityAction<int> OnBlockDestroyed;
    [SerializeField] private AudioClip blockHitSoundEffect = null;
    [SerializeField] private int pointValueOfBlock = 100;
    private void Start()
    {
        if (OnBlockCreated != null)
        {
            OnBlockCreated();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(blockHitSoundEffect, Camera.main.transform.position);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Destroy(gameObject);
        if (OnBlockDestroyed != null)
        {
            OnBlockDestroyed(pointValueOfBlock);
        }
    }
}
