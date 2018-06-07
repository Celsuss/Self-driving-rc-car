using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {
	static int s_NextCheckpoint = 1;
	static int s_LastCheckpoint = 0;
	[SerializeField] int m_CheckpointIndex = -1;
	[SerializeField] int m_Reward = 1;
	[SerializeField] int m_Punishment = -1;

	// Use this for initialization
	void Start () {
		s_LastCheckpoint++;
	}

	// Set the next checkpoint, set next checkpoint to 1 if we are at last checkpoint
	void SetNextCheckpoint(){
		s_NextCheckpoint++;
			if(s_NextCheckpoint > s_LastCheckpoint)
				s_NextCheckpoint = 1;
	}
	
	// Add a reward to the car if it´s the currect checkpoint, otherwise give the car a punishment
	void OnCollisionEnter(Collision collision){
		CarReward car = collision.gameObject.GetComponentInParent<CarReward>();
		if(!car)
			return;

		if(s_NextCheckpoint < 0 || m_CheckpointIndex < 0 || s_NextCheckpoint == m_CheckpointIndex){
			// Correct checkpoint
			car.AddReward(m_Reward);
		}
		else {
			// Incorrect checkpoint
			car.AddReward(m_Punishment);
		}
    }
}