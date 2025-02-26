using UnityEngine;

public class GunSystem : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private CameraController cameraController;
    
    [Header("Gun Config")]
    public Transform FirePoint;
    public float maxDistance;
    public float aimingSpeed = 5f;

    [SerializeField] private Vector3 offset;
    [SerializeField] private Vector3 offsetDefault;

    [SerializeField] private Vector3 offsetAiming;
    [SerializeField] private GameObject gunObject;
    [SerializeField] private bool keepGun = false;
    private Vector3 desiredPos;

    [Header("Gun Status")]
    public int numberBalls = 10;
    public int numberCurrent = 10;

    void Start()
    {
        cameraController = Camera.main.GetComponent<CameraController>();
    }

    // Update is called once per frame
    void Update()
    {
        CameraGunRotation();
        GetGun();
        Aiming();
        Shoot();

        if(!keepGun){
            RaycastHit hit;

            if(Physics.Raycast(FirePoint.position, transform.TransformDirection(Vector3.forward), out hit, maxDistance)){
                Debug.DrawRay(FirePoint.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            }
        }
    }

    void GetGun(){
        if(Input.GetKeyDown(KeyCode.Alpha1)){
            keepGun = !keepGun;

            gunObject.SetActive(!keepGun);
        }
    }

    void Aiming(){
        if(keepGun){
            return;
        }

        if(Input.GetMouseButton(1)){
            offset = Vector3.Lerp(offset, offsetAiming, aimingSpeed * Time.deltaTime);
        } else {
            offset = Vector3.Lerp(offset, offsetDefault, aimingSpeed * Time.deltaTime);
        }
    }

    void Shoot(){
        if(keepGun){
            return;
        }

        if(Input.GetMouseButtonDown(0)){
            if(numberBalls >= 1){
                Debug.Log("Shoot: " + numberBalls);
                numberBalls--;
            } else {
                Debug.Log("No Balls");
            }
        }
        
    }

    void CameraGunRotation() {
        Vector3 desiredPos = cameraController.transform.position + cameraController.transform.forward * offset.z 
                             + cameraController.transform.right * offset.x
                             + cameraController.transform.up * offset.y;

        transform.position = desiredPos;

        transform.rotation = cameraController.transform.rotation;
    }
}
