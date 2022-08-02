
using UnityEngine;

[RequireComponent(requiredComponent: typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour
{
    [SerializeField]
    private Camera cam;
    private Vector3 velocity =          Vector3.zero;
    private Vector3 rotation =          Vector3.zero;
    //private Vector3 camerarotation =    Vector3.zero;
    private float camerarotation =      0f;
    private float currentcamY =         0f;

    private Vector3 thrusterforce =     Vector3.zero;

    private Rigidbody rb;

    void Start ()
    {
        rb = GetComponent<Rigidbody>();
    }

    // gets movement vector
    public void Move(Vector3 _velocity)
    {
        velocity = _velocity;
    }

    // gets rotate vector
    public void Rotate(Vector3 _rotation)
    {
        rotation = _rotation;
    }

    //public void RotateCamera(Vector3 _camerarotation)
    public void RotateCamera(float _camerarotation)
    {
        camerarotation = _camerarotation;
    }

    public void ApplyThruster(Vector3 _thrusterforce)
    {
        thrusterforce = _thrusterforce;
    }

    void Update ()
    {
        PerformMovement();
        PerformRotation();
        PerformCameraRotation();
    }

    // perform movement based on velocity variable
    void PerformMovement () 
    {
        if (velocity != Vector3.zero)
        {
            rb.MovePosition(position: rb.position + velocity * Time.deltaTime);
        }

        if (thrusterforce != Vector3.zero)
        {
            rb.AddForce(thrusterforce * Time.deltaTime, ForceMode.Acceleration);     

        }
    }

    void PerformRotation ()
    {
        rb.MoveRotation(rot: rb.rotation * Quaternion.Euler(euler: rotation * Time.deltaTime));

    }

    void PerformCameraRotation ()
    {
        if (cam != null)
        {
            currentcamY -= camerarotation * Time.deltaTime;
            currentcamY = Mathf.Clamp(currentcamY, -85f, 85f);
            cam.transform.localEulerAngles = new Vector3(currentcamY, 0f, 0f);
            
            //cam.transform.Rotate(-camerarotation * Time.deltaTime);
            //cam.transform.Rotate(-camerarotation * Time.deltaTime);
            //camerarotation = Mathf.Clamp(camerarotation, -85, 85);
            //cam.transform.localEulerAngles = new Vector3(camerarotation, 0f, 0f);

        }
    }

}
