using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAgent : Agent {
	[SerializeField] GameObject m_StartObject;
	CarController m_Controller;
	Rigidbody m_RigidBody;
	CarReward m_Reward;
	CarDamage m_Damage;

	void Start () {
        m_RigidBody = GetComponent<Rigidbody>();
		m_Controller = GetComponent<CarController>();
		m_Reward = GetComponent<CarReward>();
		m_Damage = GetComponent<CarDamage>();
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
		// Time penalty
		AddReward(-0.05f);

		// Car damage penalty
		float damage = m_Damage.GetDamageAndReset();
		AddReward(-damage);

		// Car rewards
		float reward = m_Reward.GetRewardAndReset();
		AddReward(reward);

		// Actions, size = 2

		float force = Mathf.Clamp(vectorAction[0], -1, 1);
		m_Controller.Throttle(force);

		float steer = 0;
		steer = Mathf.Clamp(vectorAction[1], -1, 1);
		m_Controller.Steer(steer);

	}
}