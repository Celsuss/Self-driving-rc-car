using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarReward : MonoBehaviour {
	float m_Reward;

	// Use this for initialization
	void Start () {
		m_Reward = 0;	
	}
	
	public void AddReward(float reward){
		m_Reward += reward;
	}

	public float GetRewardAndReset(){
		return m_Reward;
	}
}
