using CustomExtensions;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private AudioSource ballAudioSource = null;
    [SerializeField] private AudioClip[] ballCollisionSoundEffects = null;
    [SerializeField] private PaddleController paddleController = null;
    [SerializeField] private Rigidbody2D ballRigidBody = null;
    [SerializeField] private Vector2 ballVelocityOnLaunch = Vector2.zero;

    private Vector2 distanceBetweenBallAndPaddle = Vector2.zero;
    private bool hasBallBeenLaunched = false;

    private void Start()
    {
        distanceBetweenBallAndPaddle = transform.position - paddleController.transform.position;
        if (ballRigidBody == null)
        {
            ballRigidBody = GetComponent<Rigidbody2D>();
        }
    }

    private void Update()
    {
        if (hasBallBeenLaunched == false)
        {
            LockBallToPaddle();
            if (Input.GetMouseButtonDown(0)) // Left Mouse Button Click.
            {
                LaunchBall();
            }
        }
    }

    private void LockBallToPaddle()
    {
        // TODO: Disable physics simulator while you are moving the ball with the paddle.
        Vector2 currentPaddlePosition = new Vector2(paddleController.transform.position.x, paddleController.transform.position.y);
        transform.position = currentPaddlePosition + distanceBetweenBallAndPaddle;
    }

    private void LaunchBall()
    {
        ballRigidBody.velocity = ballVelocityOnLaunch;
        hasBallBeenLaunched = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasBallBeenLaunched == true)
        {
            ballAudioSource.PlayOneShot(ballCollisionSoundEffects.GetRandom());
            //AudioSource.PlayClipAtPoint(, Camera.main.transform.position);
        }
    }
}
