using UnityEngine;
using System.Collections;

public class Destroy : MonoBehaviour {
	int scoreValue = 0; 


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter (Collision col){
		if (col.gameObject.name == "Projectile") {
			Destroy(this.gameObject); 
			//pass score to this playerType
		}
		if (col.gameObject.name == "WizardProjectile" && this.gameObject.tag == "Enemy") {
			Destroy(this.gameObject); 
			//pass score to this playertype
		}
		if (col.gameObject.name == "WarriorProjectile" && this.gameObject.tag == "Enemy") {
			Destroy(this.gameObject); 
			//pass score to this playertype
		}
		if (col.gameObject.name == "ValkyrieProjectile" && this.gameObject.tag == "Enemy") {
			Destroy(this.gameObject); 
		}
		if (col.gameObject.name == "ElfProjectile" && this.gameObject.tag == "Enemy") {
			Destroy(this.gameObject); 
			//pass score to this playertype
		}
	}
}
