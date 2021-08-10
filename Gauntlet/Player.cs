using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float speed = 0; 
	public float health = 0; 
	public int attack = 0; 
	public int score = 0; 

	public int keys, potions; 

	private bool enemyCollision; 

	//Projectile Variables 
	public bool canShoot = true;
	public float shootingInterval = 0f; 
	public GameObject projectile; 
	public float velocity = 10; 

	public bool ____________________________________________________________;
	public GameObject spawnUp, spawnLeft, spawnRight, spawnDown,
	spawnLU, spawnRU, spawnDL, spawnDR; 

	private bool sUp, sDown, sLeft, sRight, sLU, sRU, sLD, sRD; 
	
	public bool _______________________________________________________________; 


	private GameManager gm; 
	//Movement Variable
	Vector3 newPos; 

	void Awake(){

		gm = GameObject.Find ("Directional Light").GetComponent<GameManager> ();
	}
	// Update is called once per frame
	void Update () {

		//movement implementation 
		newPos.x += Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
		newPos.y += Input.GetAxis ("Vertical") * speed * Time.deltaTime;

		//declare new pos
		gameObject.transform.localPosition = newPos;

		//Attack Input
		if ((Input.GetAxis("Vertical") > 0) &&(Input.GetAxis("Horizontal") == 0) && canShoot) {
			//print ("Up");
			if (Input.GetKeyDown ("space")){
				sUp = true; 
				Attack ();
			}
		} 
		if ((Input.GetAxis("Vertical") < 0)  &&(Input.GetAxis("Horizontal") == 0) && canShoot) {
			//print ("Down");
			if (Input.GetKeyDown ("space")){
				sDown = true;
				Attack ();
			}
		} 
		if ((Input.GetAxis("Horizontal") < 0)  &&(Input.GetAxis("Vertical") == 0) && canShoot) {
			//print ("Left");
			if (Input.GetKeyDown ("space") /*&& !sLD && !sLU*/){
				sLeft = true;
				Attack ();
			}
		} 
		if ((Input.GetAxis("Horizontal") > 0) &&(Input.GetAxis("Vertical") == 0) && canShoot) {
			print ("Right");
			if (Input.GetKeyDown ("space")){
				sRight = true;
				Attack ();
			}
		} 

		//diagonal shooting
		if ((Input.GetAxis("Vertical") == 1f) && (Input.GetAxis("Horizontal") == -1f) && canShoot) {
			//print ("Left-up");
			//sUp = false;
			//sLeft = false;
			sLU = true; 
			if (Input.GetKeyDown ("space")){
				Attack ();
			}
		} 
		if ((Input.GetAxis("Horizontal") == 1) && (Input.GetAxis("Vertical") == 1) &&  canShoot) {
			//print ("Right-up");
			if (Input.GetKeyDown ("space")){
				sRU = true;
				Attack ();
			}
		} 
		if ((Input.GetAxis("Vertical")  == -1f) && (Input.GetAxis("Horizontal") == 1f) && canShoot) {
			//print ("Right-down");
			sUp = false;
			sDown = false;
			sRD = true;
			if (Input.GetKeyDown ("space")){
					//print("Shoot pressed: RD");
					Attack ();
			}
		} 
		if ((Input.GetAxis("Vertical") == -1f) && (Input.GetAxis("Horizontal") == -1f) && canShoot) {
			//print ("Left-down");
			sLD = true;
			if (Input.GetKeyDown ("space")){
				Attack ();
			}
		}		
	}	

	public void Killed(){
		Destroy (this.gameObject);
	}

	public void Attack (){
		Rigidbody rb; 
		if (sUp) {
			GameObject GO = Instantiate(projectile, spawnUp.transform.position, spawnUp.transform.rotation) as GameObject;
			rb = GO.GetComponent<Rigidbody>();
			rb.velocity = Vector3.up * velocity; //new Vector3(0, speed, 0); 
			sUp = false; 
		} else if (sDown) {
			GameObject GO = Instantiate(projectile, spawnDown.transform.position, spawnDown.transform.rotation) as GameObject;
			rb = GO.GetComponent<Rigidbody>();
			rb.velocity = Vector3.down * velocity; //new Vector3(0, speed, 0); 
			sDown = false;
		} else if (sLeft) {
			GameObject GO = Instantiate(projectile, spawnLeft.transform.position, spawnLeft.transform.rotation) as GameObject;
			rb = GO.GetComponent<Rigidbody>();
			rb.velocity = Vector3.left * velocity; //new Vector3(0, speed, 0); 
			sLeft = false;
		} else if (sRight) {
			GameObject GO = Instantiate(projectile, spawnRight.transform.position, spawnRight.transform.rotation) as GameObject;
			rb = GO.GetComponent<Rigidbody>();
			rb.velocity = Vector3.right * velocity; //new Vector3(0, speed, 0); 
			sRight = false;
		} else if (sLU) {
			print ("shooting U"); 
			GameObject GO = Instantiate(projectile, spawnLU.transform.position, spawnLU.transform.rotation) as GameObject;
			rb = GO.GetComponent<Rigidbody>();
			rb.velocity =  new Vector3(-1f,.7f) * velocity;
			sUp = true;
			sLeft = true;
			sLU = false;
		} else if (sRU) {
			GameObject GO =Instantiate(projectile, spawnRU.transform.position, spawnRU.transform.rotation) as GameObject;
			rb = GO.GetComponent<Rigidbody>();
			rb.velocity =  new Vector3(1f,.7f) * velocity;
			sRU = false;
		} else if (sRD) {
			print ("Shootig RD");
			GameObject GO = Instantiate(projectile, spawnDR.transform.position, spawnDR.transform.rotation) as GameObject;
			rb = GO.GetComponent<Rigidbody>();
			rb.velocity =  new Vector3(1f,-.7f) * velocity;
			sRD = false;
		} else if (sLD) {
			GameObject GO = Instantiate(projectile, spawnDL.transform.position, spawnDL.transform.rotation) as GameObject;
			rb = GO.GetComponent<Rigidbody>();
			rb.velocity =  new Vector3(-1f,-.7f) * velocity;
			sRD = false;
		} 
		StartCoroutine(Delay()); 
	}

	public void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "Item") {

		} else {
			print ("collided w/: " + col.gameObject.name); 
		}
	}

	public void OnCollisionStay(Collision col){
		if (col.gameObject.tag == "Enemy") {
			enemyCollision = true; 
			BaseEnemyClass tempEnemy = col.gameObject.GetComponent<BaseEnemyClass>(); 
			health-= tempEnemy.attackDamage * Time.deltaTime;  
			if (health <= 0) {
				print (this.gameObject.name + " has died."); 
				Killed (); 
			} else{ 
				TrackHealth(); 
				//announce life is low
			}
			StartCoroutine (Delay ());
		} 
		else {
			enemyCollision = false; 
		}
	}

	public void TrackHealth(){

		if (health > 450 && health < 500){
			print (this.gameObject.name +" needs food!");
		}
		if (health > 150 && health < 200){
			print (this.gameObject.name +" life force is running out!");
		}
	}

	IEnumerator Delay() {
		if (canShoot && !enemyCollision) {
			canShoot = false; 
			yield return new WaitForSeconds (shootingInterval);
			canShoot = true; 
		} 
		if (enemyCollision == true){
			yield return new WaitForSeconds (.1f);
		}
	}
}
