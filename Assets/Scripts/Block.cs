using UnityEngine;
using UnityEngine.Events;

public class Block : MonoBehaviour
{
    public static event UnityAction OnBreakableBlockCreated;
    public static event UnityAction<int> OnBreakableBlockDestroyed;

    private const string BreakableTag = "Breakable";
    private const string UnbreakableTag = "Unbreakable";

    [SerializeField] private SpriteRenderer blockSpriteRenderer = null;
    [SerializeField] private Sprite blockDamagedSprite = null;
    [SerializeField] private GameObject blockHitParticleEffect = null;
    [SerializeField] private AudioClip blockHitSoundEffect = null;
    [SerializeField] private int pointValueOfBlock = 100;
    [SerializeField] private uint hitsRequiredToBreakBlock = 1;

    private uint timesHit = 0;

    private void Start()
    {
        if (IsBlockBreakable() == true)
        {
            OnBreakableBlockCreated?.Invoke();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (IsBlockBreakable() == false)
        {
            return;
        }

        StartBlockHitEffects();
        timesHit++;

        if (timesHit >= hitsRequiredToBreakBlock)
        {
            Destroy(gameObject);
            OnBreakableBlockDestroyed?.Invoke(pointValueOfBlock);
        }
        else
        {
            DisplayDamagedBlock();
        }
    }

    private bool IsBlockBreakable()
    {
        return gameObject.tag == BreakableTag;
    }

    private void StartBlockHitEffects()
    {
        AudioSource.PlayClipAtPoint(blockHitSoundEffect, Camera.main.transform.position);
        GameObject particleEffect = Instantiate(blockHitParticleEffect, transform.position, transform.rotation);
        Destroy(particleEffect, 2.0F); // Destroy particle effect after 2 seconds.
    }

    private void DisplayDamagedBlock()
    {
        blockSpriteRenderer.sprite = blockDamagedSprite;
    }
}
