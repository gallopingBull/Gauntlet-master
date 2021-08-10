using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public float speed = 0f; 
	public float lifeSpan = 0f; 
	//Rigidbody rb; 

	// Use this for initialization
	void Start () {
		//rb = GetComponent<Rigidbody>();
		Destroy (this.gameObject, lifeSpan);  	
	}
	
	// Update is called once per frame
	void Update () {
		//rb.velocity = new Vector3(0, speed, 0);
	}
	public void DestroyProjectile(){
		Destroy(this.gameObject); 
	}
	void OnCollisionEnter (Collision col) {
		if (col.gameObject.tag == "Enemy") { 
			print ("Collided with enemy"); 
			DestroyProjectile();
		
		} 
		if (col.gameObject.tag == "Wall") { 
			print ("Collided with Wall");  
			DestroyProjectile();
		} 

		if (col.gameObject.tag == "Player") { 
			print ("Collided with Player");  
			DestroyProjectile();
		} 




	}
}
