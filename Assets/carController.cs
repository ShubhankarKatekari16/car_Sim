using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carController : MonoBehaviour
{
    public void getInput()
    {
        mHorizantalInput = Input.GetAxis("Horizontal");
        mVerticalInput = Input.GetAxis("Vertical");
    }

    public void steer()
    {
        mSteeringAngle = maxSteeringAngle * mHorizantalInput;
        fDriverW.steerAngle = mSteeringAngle;
        fPassengerW.steerAngle = mSteeringAngle;
    }

    public void Accelerate()
    {
        fDriverW.motorTorque = mVerticalInput * motorForce;
        fPassengerW.motorTorque = mVerticalInput * motorForce;
    }

    private void updateWheelPosses()
    {
        getWheels(fDriverW, fDriverT);
        getWheels(fPassengerW, fPassengerT);
        getWheels(rDriverW, rDriverT);
        getWheels(rPassengerW, rPassengerT);

    }

    private void getWheels(WheelCollider _wheelCollider, Transform _transform)
    {
        Vector3 _pos = _transform.position;
        Quaternion quaternion = transform.rotation;

        _wheelCollider.GetWorldPose(out _pos, out quaternion);
        transform.position = _pos;
        transform.rotation = quaternion;
    }
    private void FixedUpdate()
    {
        getInput();
        steer();
        Accelerate();
        updateWheelPosses();

    }

    private float mHorizantalInput, mVerticalInput, mSteeringAngle;

    public WheelCollider fDriverW, fPassengerW, rDriverW, rPassengerW;
    public Transform fDriverT, fPassengerT, rDriverT, rPassengerT;

    public float maxSteeringAngle = 30;
    public float motorForce = 50;


}
