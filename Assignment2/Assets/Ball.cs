using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
   [SerializeField] private float moveSpeed = 2f;

    public Rigidbody ball;
    public Transform target;
    public float h = 12;
    public float gravity = -15;

	private bool isInField = false;
	private bool takingShot = false;
	public bool debugPath;
	bool moveAble;
	public float test;
	public Vector3 offset;





	public Vector3 jump;
    void Start()
    {
		Physics.gravity = Vector3.up * gravity;
		moveAble = true;
	}

    private void Update()
    {
		if (Input.GetKeyDown(KeyCode.Space))
        {
			if (!isInField)
            {
				moveAble = false;
				Jump();
				
			}
			else
            {
				
				moveAble = false;
				Launch();
			}
			
		}
		
		





		if (debugPath)
		{
			DrawPath();
		}
	}
	void Move()
    {
		Vector3 direction = new Vector3(Input.GetAxisRaw("Horizontal") * Time.deltaTime * moveSpeed, ball.velocity.y , Input.GetAxisRaw("Vertical") * Time.deltaTime * moveSpeed);
		ball.velocity = direction;
	}
    private void FixedUpdate() 
    {
		if (moveAble)
        {
			Move();
			

		}
			
	}

	
    void Launch()
	{
		ball.velocity = CalculateLaunchData().initialVelocity;
	}
	void Jump()
    {
		ball.velocity = CalculateJumpData().initialVelocity;
    }

	LaunchData CalculateLaunchData()
	{
		float displacementY = target.position.y - ball.position.y;
		Vector3 displacementXZ = new Vector3(target.position.x - ball.position.x, 0, target.position.z - ball.position.z);
		float time = Mathf.Sqrt(-2 * h / gravity) + Mathf.Sqrt(2 * (displacementY - h) / gravity);
		Vector3 velocityY = Vector3.up * Mathf.Sqrt(-2 * gravity * h);
		Vector3 velocityXZ = displacementXZ / time;

		return new LaunchData(velocityXZ + velocityY * -Mathf.Sign(gravity), time);
	}

	LaunchData CalculateJumpData()
	{
		float displacementY = h - ball.position.y;
		Vector3 displacementXZ = new Vector3(0, 0, (ball.position.z + 3) - ball.position.z);
		float time = Mathf.Sqrt(-2 * h / gravity) + Mathf.Sqrt(2 * (displacementY - h) / gravity);
		Vector3 velocityY = Vector3.up * Mathf.Sqrt(-2 * gravity * h);
		Vector3 velocityXZ = displacementXZ / time;

		return new LaunchData(velocityXZ + velocityY * -Mathf.Sign(gravity), time);
	}

	void DrawPath()
	{
		LaunchData launchData = CalculateLaunchData();
		Vector3 previousDrawPoint = ball.position;

		int resolution = 30;
		for (int i = 1; i <= resolution; i++)
		{
			float simulationTime = i / (float)resolution * launchData.timeToTarget;
			Vector3 displacement = launchData.initialVelocity * simulationTime + Vector3.up * gravity * simulationTime * simulationTime / 2f;
			Vector3 drawPoint = ball.position + displacement;
			Debug.DrawLine(previousDrawPoint, drawPoint, Color.green);
			previousDrawPoint = drawPoint;
		}
	}

	struct LaunchData
	{
		public readonly Vector3 initialVelocity;
		public readonly float timeToTarget;

		public LaunchData(Vector3 initialVelocity, float timeToTarget)
		{
			this.initialVelocity = initialVelocity;
			this.timeToTarget = timeToTarget;
		}

	}
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Field"))
        {
			Debug.Log("Field");
			isInField = true;
        }
		else
        {
			Debug.Log("outField");
			isInField = false;
        }
    }
	public bool isGrounded()
    {
		return Physics.Raycast(transform.position, Vector3.down, 1.5f);
    }
    private void OnCollisionEnter(Collision collision)
    {
		moveAble = true;
    }
}
