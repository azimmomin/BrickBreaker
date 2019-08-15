using UnityEngine;

public class PaddleController : MonoBehaviour
{
    [SerializeField] Camera mainCamera = null;
    private PolygonCollider2D paddleCollider = null;
    private void Start()
    {
        paddleCollider = GetComponent<PolygonCollider2D>();
    }
    private void Update()
    {
        float paddleX = GetPaddleXPos();
        Vector3 currentPaddleTransform = transform.position;
        currentPaddleTransform.x = paddleX;

        transform.position = currentPaddleTransform;
    }

    private float GetPaddleXPos()
    {
        float cameraHorizontalSize = 2 * mainCamera.orthographicSize * mainCamera.aspect;
        float paddleX = (Input.mousePosition.x / Screen.width) * cameraHorizontalSize;
        Vector3 paddleBounds = paddleCollider.bounds.size;
        return Mathf.Clamp(paddleX, paddleBounds.x / 2.0F, cameraHorizontalSize - (paddleBounds.x / 2.0F));
    }
}
