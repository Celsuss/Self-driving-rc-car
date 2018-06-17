using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnCollision : MonoBehaviour {

	[SerializeField] bool m_KillCar = false;
	[SerializeField] int m_Punishment = -1;

	// Use this for initialization
	void Start () {
		
	}

	// Give the car a punishment if it's not set to kill the car
	void OnCollisionStay(Collision collisionInfo) {
		CarReward car = collisionInfo.gameObject.GetComponentInParent<CarReward>();
		if(car){
			if(!m_KillCar)
				car.AddReward(m_Punishment);
			else
				car.Kill = true;
		}
    }

	void OnTriggerEnter(Collider other) {
        CarReward car = other.gameObject.GetComponentInParent<CarReward>();
		if(car){
			if(!m_KillCar)
				car.AddReward(m_Punishment);
			else
				car.Kill = true;
		}
    }

}