using UnityEngine;

/**
 * This class helps enforce that only one object of a specified
 * is active in the scene. It assumes that the type being
 * checked exists in the current gameobject and will set
 * the game object to not destroy on load if it contains the
 * only object of the specified type.
 */
public class DontDestroyOnLoad : MonoBehaviour
{
    [SerializeField] private Object objectOnCurrentGameObjectToNotDestroy = null;
    void Awake()
    {
        int numObjects = Object.FindObjectsOfType(objectOnCurrentGameObjectToNotDestroy.GetType()).Length;
        if (numObjects > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
