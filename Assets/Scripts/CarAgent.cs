using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAgent : Agent {
	[SerializeField] GameObject m_StartObject;
	[SerializeField] float m_Speed;
	[SerializeField] float m_Torque;
	Rigidbody m_RigidBody;

	void Start () {
        m_RigidBody = GetComponent<Rigidbody>();
    }

	public override void AgentReset(){

	}

	public override void CollectObservations(){
		// Vector3 relativePosition = Target.position - transform.position;
		
		// // Relative position
		AddVectorObs(transform.position.x/5);
		AddVectorObs(transform.position.z/5);
	}

	public override void AgentAction(float[] vectorAction, string textAction){
		// Reached target
		// if (distanceToTarget < 1.42f)
		// {
		// 	Done();
		// 	AddReward(1.0f);
		// }

		// Time penalty
		AddReward(-0.05f);

		// Actions, size = 2

		float force = Mathf.Clamp(vectorAction[0], -1, 1);
		m_RigidBody.AddForce(transform.forward * force * m_Speed);

		float torque = 0;
		torque = Mathf.Clamp(vectorAction[1], -1, 1);
		m_RigidBody.AddTorque(Vector3.up * torque * m_Torque);
	}
}
