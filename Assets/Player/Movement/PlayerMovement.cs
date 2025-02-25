using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private float moveSpeed;
    private Vector3 desiredMovementDir;

    [Header("Component")]

    [SerializeField] CharacterController characterController;
    private CameraController cameraController;

    void Start()
    {
        cameraController = Camera.main.GetComponent<CameraController>();
    }

    // Update is called once per frame
    void Update()
    {   
        if(cameraController.GetTarget() == null){
            cameraController.SetTarget(transform);
        }

        MovementInput();
    }

    private void MovementInput(){

        if(Input.GetKey(KeyCode.LeftShift)){
            moveSpeed = PlayerManagement.instance.GetPlayerStatus().moveSpeedRun;
        } else {
            moveSpeed = PlayerManagement.instance.GetPlayerStatus().moveSpeed;
        }

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput);

        desiredMovementDir = cameraController.YRotation * movement;


        characterController.Move(desiredMovementDir * moveSpeed * Time.deltaTime);

    }
}
