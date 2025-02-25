using UnityEngine;

public class GunMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private CameraController cameraController;
    [SerializeField] private Vector3 offset;
    private Vector3 desiredPos;


    void Start()
    {
        cameraController = Camera.main.GetComponent<CameraController>();
    }

    // Update is called once per frame
    void Update()
    {
         Vector3 desiredPos = cameraController.transform.position + cameraController.transform.forward * offset.z 
                             + cameraController.transform.right * offset.x
                             + cameraController.transform.up * offset.y;

        transform.position = desiredPos;

        transform.rotation = cameraController.transform.rotation;
    }
}
