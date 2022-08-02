using UnityEngine;

[RequireComponent(typeof(ConfigurableJoint))]
[RequireComponent(requiredComponent: typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private float speed =       4f;

    [SerializeField]
    private float mousespeed =  5f;

    [SerializeField]
    private float thrust =      2000f;

    [Header("Spring Settings")]
    
    //[SerializeField]
    //private JointDriveMode mode;
    //private float _yRot =       0f;
    // comment this out when switch

    [SerializeField]
    private float jointspring = 20f;
    [SerializeField]
    private float jointmaxforce = 40f;
    
    private PlayerMotor motor;
    private ConfigurableJoint joint;

    void Start ()
    {
        motor = GetComponent<PlayerMotor>();
        joint = GetComponent<ConfigurableJoint>();

        SetJointSettings(jointspring);
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
        
        float _camerarotation = _yRot * mousespeed;
        //Vector3 _camRotation = new Vector3 (_yRot, 0f, 0f) * mousespeed;
        
        // rotate camera
        motor.RotateCamera(_camerarotation);

        // calculate thrust force
        Vector3 _thrusterForce = Vector3.zero;
        if (Input.GetButton("Jump"))
        {
            _thrusterForce = Vector3.up * thrust; 
            SetJointSettings(0f);
        } else {
            SetJointSettings(jointspring);
        }

        motor.ApplyThruster(_thrusterForce);

    }

    private void SetJointSettings (float _jointspring)
    {
        joint.yDrive = new JointDrive 
        {
            positionSpring =    _jointspring,
            maximumForce =      jointmaxforce
        };   
    }

}
