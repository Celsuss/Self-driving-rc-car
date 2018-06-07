using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnCollision : MonoBehaviour {

	[SerializeField] int m_Damage = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionStay(Collision collisionInfo) {
		CarDamage car = collisionInfo.gameObject.GetComponentInParent<CarDamage>();
		if(car)
			car.AddDamage(m_Damage);
    }	
}