using UnityEngine;

public class PaddleController : MonoBehaviour
{
    private void Update()
    {
        float cameraHorizontalSize = 2 * Camera.main.orthographicSize * Camera.main.aspect;
        float paddleX = (Input.mousePosition.x / Screen.width) * cameraHorizontalSize;
        Vector3 paddleBounds = GetComponent<CapsuleCollider2D>().bounds.size;
        paddleX = Mathf.Clamp(paddleX, paddleBounds.x / 2.0F, cameraHorizontalSize - (paddleBounds.x / 2.0F));

        Vector3 currentPaddleTransform = gameObject.transform.position;
        currentPaddleTransform.x = paddleX;

        gameObject.transform.position = currentPaddleTransform;
    }
}
