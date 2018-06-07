using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {
	static int s_NextCheckpoint = 0;
	[SerializeField] int m_CheckpointIndex = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	void OnCollisionEnter(Collision collision){
		if(s_NextCheckpoint == m_CheckpointIndex){
			// Correct checkpoint
		}
		else {
			// Incorrect checkpoint
			
		}

        CarReward car = collision.gameObject.GetComponentInParent<CarReward>();
		if(car){
			
		}
    }
}