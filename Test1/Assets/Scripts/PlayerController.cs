using UnityEngine;

[RequireComponent(requiredComponent: typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private float speed = 4f;

    [SerializeField]
    private float mousespeed = 5f;

    private PlayerMotor motor;

    void Start ()
    {
        motor = GetComponent<PlayerMotor>();
    }

    void Update ()
    {
        // calculate movement velocity as a 3D vector
        float _xMove = Input.GetAxisRaw("Horizontal");
        float _zMove = Input.GetAxisRaw("Vertical");

        Vector3 _moveHorz = transform.right     * _xMove;
        Vector3 _moveVert = transform.forward   * _zMove;
        

        // final movement vector
        Vector3 _velocity = (_moveHorz + _moveVert).normalized * speed;

        // apply movement
        motor.Move(_velocity: _velocity);

        // calculate rotation as a 3D vector
        
        float _xRot = Input.GetAxisRaw("Mouse X");
        
        Vector3 _rotation = new Vector3 (0f, _xRot, 0f) * mousespeed;
        
        // apply rotation
        motor.Rotate(_rotation);

        // calculate camera rotation
        float _yRot = Input.GetAxisRaw("Mouse Y");
        
        Vector3 _camRotation = new Vector3 (_yRot, 0f, 0f) * mousespeed;
        
        // rotate camera
        motor.RotateCamera(_camRotation);

    }

}
