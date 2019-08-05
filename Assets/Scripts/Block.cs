using UnityEngine;

public class Block : MonoBehaviour
{
    public delegate void BlockCreatedAction();
    public delegate void BlockDestroyedAction();
    public static event BlockCreatedAction OnBlockCreated;
    public static event BlockCreatedAction OnBlockDestroyed;
    [SerializeField] private AudioClip blockHitSoundEffect = null;

    private void Start()
    {
        if (OnBlockCreated != null)
        {
            OnBlockCreated();
        }
    }

    private void OnDestroy()
    {
        if (OnBlockDestroyed != null)
        {
            OnBlockDestroyed();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(blockHitSoundEffect, Camera.main.transform.position);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
