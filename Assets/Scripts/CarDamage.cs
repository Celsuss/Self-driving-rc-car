using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarDamage : MonoBehaviour {
	float m_Damage;

	// Use this for initialization
	void Start () {
		m_Damage = 0;
	}

	public void AddDamage(int damage){
		m_Damage += damage;
	}
	
	public float GetDamageAndReset(){
		float damage = m_Damage;
		m_Damage = 0;
		return damage;
	}
}
