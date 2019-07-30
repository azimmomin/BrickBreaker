using UnityEngine;

public class PaddleController : MonoBehaviour
{
    private PolygonCollider2D paddleCollider = null;
    private void Start()
    {
        paddleCollider = GetComponent<PolygonCollider2D>();
    }
    private void Update()
    {
        float cameraHorizontalSize = 2 * Camera.main.orthographicSize * Camera.main.aspect;
        float paddleX = (Input.mousePosition.x / Screen.width) * cameraHorizontalSize;
        Vector3 paddleBounds = paddleCollider.bounds.size;
        paddleX = Mathf.Clamp(paddleX, paddleBounds.x / 2.0F, cameraHorizontalSize - (paddleBounds.x / 2.0F));

        Vector3 currentPaddleTransform = transform.position;
        currentPaddleTransform.x = paddleX;

        transform.position = currentPaddleTransform;
    }
}
