using UnityEngine;

/**
 * This class helps enforce that only one object of each
 * specified type is active in the scene. It assumes that 
 * the types being checked exists in the current gameobject
 * and will set the game object to not destroy on load if
 * it contains the only object of the specified type.
 */
public class DontDestroyOnLoad : MonoBehaviour
{
    [SerializeField] private Object[] objectsOnCurrentGameObjectToNotDestroy = null;
    void Awake()
    {
        int numObjects = 0;
        for (int i = 0, count = objectsOnCurrentGameObjectToNotDestroy.Length; i < count; i++)
        {
            numObjects = Object.FindObjectsOfType(objectsOnCurrentGameObjectToNotDestroy[i].GetType()).Length;
            if (numObjects > 1)
            {
                gameObject.SetActive(false);
                Destroy(gameObject);
            }
        }

        // If there is only one object of each type, set that object to not be destroyed.
        DontDestroyOnLoad(gameObject);
    }
}
