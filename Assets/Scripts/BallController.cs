using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private PaddleController paddleController = null;
    [SerializeField] private Rigidbody2D ballRigidBody = null;
    [SerializeField] private float launchSpeed = 10.0F;

    private Vector2 distanceBetweenBallAndPaddle;
    private bool hasBallBeenLaunched = false;
    private void Start()
    {
        distanceBetweenBallAndPaddle = transform.position - paddleController.transform.position;
    }

    private void Update()
    {

        Vector2 currentPaddlePosition = new Vector2(paddleController.transform.position.x,
   paddleController.transform.position.y);
        transform.position = currentPaddlePosition + distanceBetweenBallAndPaddle;

        /*
        if (hasBallBeenLaunched == false)
        {
            if (Input.GetMouseButtonUp(0))
            {
                ballRigidBody.AddForce(new Vector2(0.0F, launchSpeed));
            }
        }
        */
    }
}
