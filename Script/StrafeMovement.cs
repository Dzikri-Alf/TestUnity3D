using UnityEngine;

public class StrafeMovement : MonoBehaviour
{
    [SerializeField]
    private float accel = 200f;         // How fast the player accelerates on the ground
    [SerializeField]
    private float airAccel = 200f;      // How fast the player accelerates in the air
    [SerializeField]
    private float maxSpeed = 6.4f;      // Maximum player speed on the ground
    [SerializeField]
    private float maxAirSpeed = 0.6f;   // "Maximum" player speed in the air
    [SerializeField]
    private float friction = 8f;        // How fast the player decelerates on the ground
    [SerializeField]
    private float jumpForce = 5f;       // How high the player jumps
    [SerializeField]
    private LayerMask groundLayers;

    [SerializeField]
    private GameObject camObj;

    [SerializeField] 
    private Rigidbody cameraRespawn;
    [SerializeField] 
    private Transform player;
    private bool isFirstPersonView = false;

    private float lastJumpPress = -1f;
    private float jumpPressDuration = 0.1f;
	private bool onGround = false;
    public float smoothSpeed = 5f;
    public float maxCameraHeight = -2f; // Maximum height of the camera above the player
    public float minCameraHeight = -3.5f; // Minimum height of the camera above the player
    public GameObject objectToFollowPlayerDirection; // The object that follows the player's direction
    
    void Start()
    {
        Physics.SyncTransforms();
        cameraRespawn.freezeRotation = true;
    }

	private void Update()
    {
        print(new Vector3(GetComponent<Rigidbody>().velocity.x, 0f, GetComponent<Rigidbody>().velocity.z).magnitude);
        if (Input.GetButton("Jump"))
		{
			lastJumpPress = Time.time;
		}
        float ScrollWheelChange = Input.GetAxis( "Mouse ScrollWheel" );
            if( Mathf.Abs( ScrollWheelChange ) > 0 && onGround == true){
                lastJumpPress = Time.time;
            }
	}

	private void FixedUpdate()
	{

		Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        // Get player velocity
        Vector3 playerVelocity = GetComponent<Rigidbody>().velocity;
        // Slow down if on ground
        playerVelocity = CalculateFriction(playerVelocity);
        // Add player input
        playerVelocity += CalculateMovement(input, playerVelocity);
        // Assign new velocity to player object
		GetComponent<Rigidbody>().velocity = playerVelocity;
	}

    /// <summary>
    /// Slows down the player if on ground
    /// </summary>
    /// <param name="currentVelocity">Velocity of the player</param>
    /// <returns>Modified velocity of the player</returns>
	private Vector3 CalculateFriction(Vector3 currentVelocity)
	{
        onGround = CheckGround();
		float speed = currentVelocity.magnitude;

        if (!onGround || Input.GetButton("Jump") || speed == 0f)
            return currentVelocity;
        //Gravity Method
        float drop = speed * friction * Time.deltaTime;
        return currentVelocity * (Mathf.Max(speed - drop, 0f) / speed);
    }
    
    /// <summary>
    /// Moves the player according to the input. (THIS IS WHERE THE STRAFING MECHANIC HAPPENS)
    /// </summary>
    /// <param name="input">Horizontal and vertical axis of the user input</param>
    /// <param name="velocity">Current velocity of the player</param>
    /// <returns>Additional velocity of the player</returns>
	private Vector3 CalculateMovement(Vector2 input, Vector3 velocity)
	{
        onGround = CheckGround();

        //Different acceleration values for ground and air
        float curAccel = accel;
        if (!onGround)
            curAccel = airAccel;

        //Ground speed
        float curMaxSpeed = maxSpeed;

        //Air speed
        if (!onGround)
            curMaxSpeed = maxAirSpeed;
        
        // Get rotation input and make it a vector
        Vector3 camRotation = camObj.transform.eulerAngles; // Get current camera rotation
        Vector3 inputVelocity = Quaternion.Euler(0f, camRotation.y, 0f) * // Apply only yaw rotation
                                new Vector3(input.x * curAccel, 0f, input.y * curAccel);

        //Ignore vertical component of rotated input
        Vector3 alignedInputVelocity = new Vector3(inputVelocity.x, 0f, inputVelocity.z) * Time.deltaTime;

        //Get current velocity
        Vector3 currentVelocity = new Vector3(velocity.x, 0f, velocity.z);

        //How close the current speed to max velocity is (1 = not moving, 0 = at/over max speed)
        float max = Mathf.Max(0f, 1 - (currentVelocity.magnitude / curMaxSpeed));

        //How perpendicular the input to the current velocity is (0 = 90°)
        float velocityDot = Vector3.Dot(currentVelocity, alignedInputVelocity);

        //Scale the input to the max speed
        Vector3 modifiedVelocity = alignedInputVelocity * max;

        //The more perpendicular the input is, the more the input velocity will be applied
        Vector3 correctVelocity = Vector3.Lerp(alignedInputVelocity, modifiedVelocity, velocityDot);

        //Apply jump
        correctVelocity += GetJumpVelocity(velocity.y);

        // Set the camera position and rotation based on the view mode
        if (isFirstPersonView)
        {
            // Set camera position to be at player's head level
            camObj.transform.position = cameraRespawn.transform.position + cameraRespawn.transform.up * 1;
            // Rotate camera to match player's rotation
            camObj.transform.rotation = Quaternion.Euler(camRotation);
        }
        else
        {
            // Set the camera behind the player
            Vector3 desiredCamPosition = cameraRespawn.transform.position - camObj.transform.forward * 4;
            // Calculate the height of the camera based on the angle of the camera
            float angle = Vector3.Angle(Vector3.up, camObj.transform.forward);
            float heightRatio = Mathf.InverseLerp(0f, 90f, angle); // Calculate ratio based on angle between 0 and 90 degrees
            float desiredHeight = Mathf.Lerp(minCameraHeight, maxCameraHeight, heightRatio); // Interpolate between min and max heights
            // Adjust the camera position vertically based on the player's current Y position
            float playerHeight = cameraRespawn.transform.position.y;
            desiredCamPosition.y = Mathf.Clamp(playerHeight + desiredHeight, playerHeight + 0, playerHeight + 1);

            // Smoothly move the camera to its desired position and rotation
            camObj.transform.position = Vector3.Lerp(camObj.transform.position, desiredCamPosition, smoothSpeed * Time.deltaTime);
            camObj.transform.rotation = Quaternion.Lerp(camObj.transform.rotation, Quaternion.Euler(0f, camRotation.y, 0f), smoothSpeed * Time.deltaTime);
        }

        // Update the object to follow the player's direction
        if (objectToFollowPlayerDirection != null)
        {
            Vector3 newPosition = cameraRespawn.transform.position + (camObj.transform.forward * (1 - 0.6f)) + (camObj.transform.right * 0.6f);
            newPosition.y += 0.8f;

            objectToFollowPlayerDirection.transform.position = newPosition;
            // Update the object's rotation to face the same direction as the player's camera
            Vector3 objectRotation = objectToFollowPlayerDirection.transform.eulerAngles;
            objectRotation.y = camRotation.y; // Only update the Y rotation
            objectToFollowPlayerDirection.transform.rotation = Quaternion.Euler(objectRotation);
        }

        // Toggle between first-person and third-person views when pressing the "Q" key
        if (Input.GetKeyDown(KeyCode.Q))
        {
            isFirstPersonView = !isFirstPersonView;
        }

        //Return
        return correctVelocity;
    }

    /// <summary>
    /// Calculates the velocity with which the player is accelerated up when jumping
    /// </summary>
    /// <param name="yVelocity">Current "up" velocity of the player (velocity.y)</param>
    /// <returns>Additional jump velocity for the player</returns>
	private Vector3 GetJumpVelocity(float yVelocity)
	{
		Vector3 jumpVelocity = Vector3.zero;

		if(Time.time < lastJumpPress + jumpPressDuration && yVelocity < jumpForce && CheckGround())
		{
			lastJumpPress = -1f;
			jumpVelocity = new Vector3(0f, jumpForce - yVelocity, 0f);
		}

		return jumpVelocity;
	}
	
    /// <summary>
    /// Checks if the player is touching the ground. This is a quick hack to make it work, don't actually do it like this.
    /// </summary>
    /// <returns>True if the player touches the ground, false if not</returns>
	private bool CheckGround()
	{
        Ray ray = new Ray(transform.position, Vector3.down);
        bool result = Physics.Raycast(ray, GetComponent<Collider>().bounds.extents.y + 0.1f, groundLayers);
        return result;
	}
}
