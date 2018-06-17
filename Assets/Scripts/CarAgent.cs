using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAgent : Agent {
	[SerializeField] GameObject m_StartObject;
	CarController m_Controller;
	Rigidbody m_RigidBody;
	CarReward m_Reward;
	Vector3 m_StartPosition;
	Quaternion m_StartRotation;

	void Start () {
        m_RigidBody = GetComponent<Rigidbody>();
		m_Controller = GetComponent<CarController>();
		m_Reward = GetComponent<CarReward>();
		m_StartPosition = transform.position;
		m_StartRotation = transform.rotation;
    }

	public override void AgentReset(){
		m_Controller.Reset();
		transform.SetPositionAndRotation(m_StartPosition, m_StartRotation);
		m_RigidBody.velocity = Vector3.zero;
		m_Reward.Kill = false;	
	}

	public override void CollectObservations(){
		// Camera
		
		// Position
		AddVectorObs(transform.position.x/5);
		AddVectorObs(transform.position.z/5);

		// Agent velocity
		//AddVectorObs(m_RigidBody.velocity.x/5);
		//AddVectorObs(m_RigidBody.velocity.z/5);
	}

	public override void AgentAction(float[] vectorAction, string textAction){
		AddRewards();

		if(m_Reward.Kill)
		{
			Debug.Log("Done");
			Done();
			AgentReset();
		}

		// Actions, size = 3

		float force = Mathf.Clamp(vectorAction[0], -1, 1);
		m_Controller.Throttle(force);

		float steer = Mathf.Clamp(vectorAction[1], -1, 1);;
		m_Controller.Steer(steer);

		float breakForce = Mathf.Clamp(vectorAction[2], 0, 1);
		m_Controller.Break(breakForce);
	}

	void AddRewards(){
		// Time penalty
		AddReward(-0.05f);

		// Get total reward for this update
		float reward = m_Reward.GetRewardAndReset();
		AddReward(reward);
		
	}
}