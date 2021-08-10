using UnityEngine;
using System.Collections;

public class Items : MonoBehaviour {
	public int scoreValue = 0; 

	public bool isFood = false; 
	public bool isKey = false; 
	public bool isTeasure = false; 
	public bool isPotion = false; 


	public void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "Player") {
			Player player = col.gameObject.GetComponent<Player> ();
			if (isFood) {
				player.health += 100f; 
			}
			if (isKey) {
				player.score += scoreValue; 
				player.keys += 1; 
				print ("keys = " + player.keys); 
			}
			if (isPotion) {
				player.potions += 1; 
				print ("potions = " + player.potions);
			}
			if (isTeasure) {
				player.score += scoreValue; 
			}
			Destroy (this.gameObject); 
		}

		if (col.gameObject.tag == "Projectile") {
			Projectile projectile = col.gameObject.GetComponent<Projectile>();
			
			
			if(isPotion){
				//player.potions += 1; 
				print ("projectile hit potion");
				projectile.DestroyProjectile(); 
			}
			if(isTeasure){
				projectile.DestroyProjectile();
			}
			if(isFood){
				projectile.DestroyProjectile();
				Destroy(this.gameObject); 
			}
			
			if(isKey){
				//player.potions += 1; 
				print ("projectile hit potion");
				
			}
			
		}

	}
}
