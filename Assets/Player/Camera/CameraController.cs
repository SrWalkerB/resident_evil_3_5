using UnityEngine;

public class CameraController : MonoBehaviour
{
     [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float height = 1.09f;

    private Quaternion targetRotation;

    private float yRotation;
    private float xRotation;
    private float xRotationClamped;

    [SerializeField] private float xRotationMin = -23.19f;
    [SerializeField] private float xRotationMax = 39f;

    [SerializeField] private float xSensitivity = 1;
    [SerializeField] private float ySensitivity = 1;

    [SerializeField] private bool invertX = true;
    private int xInvertedValue;

    private Vector3 desiredPos;

    private void Start()
    {
        
    }


    public void DisabledCursor(){
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        xInvertedValue = invertX ? -1 : 1;
    }

    private void Update()
    {
        yRotation += Input.GetAxis("Mouse X") * ySensitivity;
        xRotation += Input.GetAxis("Mouse Y") * xSensitivity * xInvertedValue;

        if(target){
            DisabledCursor();
        }
    }

    private void LateUpdate()
    {
        if(target){
            xRotationClamped = Mathf.Clamp(xRotation, xRotationMin, xRotationMax);
            targetRotation = Quaternion.Euler(xRotationClamped, yRotation, 0.0f);

            desiredPos = target.position - targetRotation * offset + Vector3.up * height;

            transform.SetPositionAndRotation(desiredPos, targetRotation);
        }
       
    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

    public Transform GetTarget(){
        return target;
    }

    public Quaternion YRotation => Quaternion.Euler(0.0f, yRotation, 0.0f);
}
