using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarReward : MonoBehaviour {
	float m_Reward;
	bool m_Kill;
	public bool Kill{ get{ return m_Kill; } set{ m_Kill = value; }}

	// Use this for initialization
	void Start () {
		m_Reward = 0;
		m_Kill = false;
	}
	
	public void AddReward(float reward){
		m_Reward += reward;
	}

	public float GetRewardAndReset(){
		float reward = m_Reward;
		m_Reward = 0;
		return reward;
	}
}
