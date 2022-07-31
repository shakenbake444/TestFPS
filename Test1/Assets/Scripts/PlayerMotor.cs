
using UnityEngine;

[RequireComponent(requiredComponent: typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour
{
    [SerializeField]
    private Camera cam;
    private Vector3 velocity =          Vector3.zero;
    private Vector3 rotation =          Vector3.zero;
    private Vector3 camerarotation =    Vector3.zero;
    
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

    public void RotateCamera(Vector3 _camerarotation)
    {
        camerarotation = _camerarotation;
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
    }

    void PerformRotation ()
    {
        rb.MoveRotation(rot: rb.rotation * Quaternion.Euler(euler: rotation * Time.deltaTime));

    }

    void PerformCameraRotation ()
    {
        if (cam != null)
        {
            cam.transform.Rotate(-camerarotation * Time.deltaTime);
        }
    }

}
