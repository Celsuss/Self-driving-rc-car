using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour {
	[SerializeField] float m_MaxTorque = 20.0f;
	[SerializeField] float m_MaxSteeringAngle = 10.0f;
	[SerializeField] float m_MaxBreakTorque = 20.0f;
	[SerializeField] WheelCollider m_WheelColliderFR;
	[SerializeField] WheelCollider m_WheelColliderFL;
	[SerializeField] WheelCollider m_WheelColliderBR;
	[SerializeField] WheelCollider m_WheelColliderBL;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Reset(){
		m_WheelColliderFR.motorTorque = 0;
		m_WheelColliderFL.motorTorque = 0;
		m_WheelColliderBR.motorTorque = 0;
		m_WheelColliderBL.motorTorque = 0;

		m_WheelColliderFR.steerAngle = 0;
		m_WheelColliderFL.steerAngle = 0;
		m_WheelColliderBR.steerAngle = 0;
		m_WheelColliderBL.steerAngle = 0;
	}

	public void Throttle(float torque){
		m_WheelColliderBL.motorTorque = torque * m_MaxTorque;
		m_WheelColliderBR.motorTorque = torque * m_MaxTorque;
	}

	public void Steer(float steeringAngle){
		m_WheelColliderFL.steerAngle = steeringAngle * m_MaxSteeringAngle;
		m_WheelColliderFR.steerAngle = steeringAngle * m_MaxSteeringAngle;
	}

	public void Break(float breakTorque){
		m_WheelColliderBL.brakeTorque = breakTorque * m_MaxBreakTorque;
		m_WheelColliderBR.brakeTorque = breakTorque * m_MaxBreakTorque;
	}
}
