using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {

    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float lookSensitivity = 3;
    private PlayerMotor motor;

    void Start()
    {
        motor = GetComponent<PlayerMotor>();
    }

    void Update()
    {
        float xMove = Input.GetAxisRaw("Horizontal");
        float zMove = Input.GetAxisRaw("Vertical");

        Vector3 moveHorizontal  = transform.right * xMove;
        Vector3 moveVertical    = transform.forward * zMove;

        Vector3 velocity = (moveHorizontal + moveVertical).normalized * speed;

        motor.Move(velocity);

        //Calculating Rotation for turning on X axis
        float yRoatation = Input.GetAxisRaw("Mouse X");

        Vector3 rotation = new Vector3(0, yRoatation, 0) * lookSensitivity;

        //Apply rotation
        motor.Rotate(rotation);

        //Calculating Rotation for turning on X axis
        float xRoatation = Input.GetAxisRaw("Mouse Y");

        Vector3 cameraRotation = new Vector3(xRoatation, 0, 0) * lookSensitivity;

        //Apply rotation
        motor.RotateCamera(cameraRotation);

    }
}
