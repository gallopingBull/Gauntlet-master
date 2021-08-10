using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public GameObject p1, p2, p3, p4; 
	public GameObject spawnLoc1,spawnLoc2, spawnLoc3, spawnLoc4;  
	private Player player1, player2, player3, player4; 
	public int p1Score, p2Score, p3Score, p4Score;
	public float p1Health, p2Health, p3Health, p4Health;

	bool p1Used, p2Used, p3Used, p4Used; 


	public float damageInterval = 0;
	bool begin = false; 

	// Use this for initialization
	void Start() {
		p1Used = p2Used = p3Used = p4Used = false; 

		//player1 = GameObject.Find ("Warrior").GetComponent<Player> (); 
	}


	bool GameInitialization(){
	
		if (!begin) {
			if(Input.GetKeyDown(KeyCode.Alpha1) && !p1Used){
				p1Used = true; 
				GameObject GO = Instantiate(p1, spawnLoc1.transform.position, spawnLoc1.transform.rotation) as GameObject;
				player1 = GameObject.Find ("Warrior(Clone)").GetComponent<Player> (); 
				p1Score = player1.score; 
				p1Health = player1.health; 
				print ("pressed 1");
			}
			if(Input.GetKeyDown(KeyCode.Alpha2) && !p2Used){
				p2Used = true; 
				GameObject GO = Instantiate(p2, spawnLoc2.transform.position, spawnLoc2.transform.rotation) as GameObject;
				player2 = GameObject.Find ("Valkyrie(Clone)").GetComponent<Player> (); 
				p2Score = player2.score; 
				p2Health = player2.health; 
				print ("pressed 2");
			}
			if(Input.GetKeyDown(KeyCode.Alpha3) && !p3Used){
				p3Used = true; 
				GameObject GO = Instantiate(p3, spawnLoc3.transform.position, spawnLoc3.transform.rotation) as GameObject;
				player3 = GameObject.Find ("Wizard(Clone)").GetComponent<Player> (); 
				p3Score = player3.score; 
				p3Health = player3.health; 
				print ("pressed 3");
			}
			if(Input.GetKeyDown(KeyCode.Alpha4) && !p4Used){
				p4Used = true; 
				GameObject GO = Instantiate(p4, spawnLoc4.transform.position, spawnLoc4.transform.rotation) as GameObject;
				player4 = GameObject.Find ("Elf(Clone)").GetComponent<Player> (); 
				p4Score = player4.score; 
				p4Health = player4.health; 
				print ("pressed 4");
			}
		}

		if(Input.GetKeyDown("space")){
			print ("begin equals true");

			begin = true;  
		}	
		return begin; 
	}

	// Update is called once per frame
	void FixedUpdate () {

		if (GameInitialization () == false) {
			GameInitialization(); 
		}

		else 
			StartCoroutine(Delay ());  

	}
	void OnGUI(){
		//player one info 
		GUI.Label(new Rect(900, 60, 100, 100), "WARRIOR");

		GUI.Label(new Rect(875, 80, 100, 100), "SCORE");

		GUI.Label(new Rect(950, 80, 100, 100), "HEALTH");

		if(p1Used){
			GUI.Label(new Rect(875, 100, 100, 100), "" + player1.score); 
			GUI.Label(new Rect(950, 100, 100, 100), "" + Mathf.Ceil(p1Health)); 
		}
		//player two info
		//p2Score = player2.score; 
		GUI.Label(new Rect(900, 150, 100, 100), "VALKYRIE");
		
		GUI.Label(new Rect(875, 170, 100, 100), "SCORE");
		GUI.Label(new Rect(950, 170, 100, 100), "HEALTH");

		if(p2Used){
			GUI.Label(new Rect(875, 190, 100, 100), "" + p2Score);
			GUI.Label(new Rect(950, 190, 100, 100), "" + Mathf.Ceil(p2Health));
		}
		//player three info
		//p3Score = player3.score; 
		GUI.Label(new Rect(900, 240, 100, 100), "WIZARD");
		
		GUI.Label(new Rect(875, 260, 100, 100), "SCORE");	
		GUI.Label(new Rect(950, 260, 100, 100), "HEALTH");

		if(p3Used){
			GUI.Label(new Rect(875, 280, 100, 100), "" + p3Score);
			GUI.Label(new Rect(950, 280, 100, 100), "" + Mathf.Ceil(p3Health));
		}
		//player four info
		//p4Score = player4.score; 
		GUI.Label(new Rect(900, 310, 100, 100), "ELF");
		
		GUI.Label(new Rect(875, 330, 100, 100), "SCORE");
		GUI.Label(new Rect(950, 330, 100, 100), "HEALTH");

		if(p4Used){
			GUI.Label(new Rect(875, 350, 100, 100), "" + p4Score); 
			GUI.Label(new Rect(950, 350, 100, 100), "" + Mathf.Ceil(p4Health));
		}

	}


	IEnumerator Delay(){
		if (p1Health > 0 && p1Used) {
			p1Health -= 1f * Time.deltaTime;
			player1.TrackHealth(); 
		}
		if (p2Health > 0 && p2Used) {
			p2Health -= 1f * Time.deltaTime;
			player2.TrackHealth(); 
		}
		if (p3Health > 0 && p3Used) {
			p3Health -= 1f * Time.deltaTime;
			player3.TrackHealth(); 
		}
		if (p4Health > 0 && p4Used) {
			p4Health -= 1f * Time.deltaTime;
			player4.TrackHealth(); 
		}
		yield return new WaitForSeconds (damageInterval);

	}
	
}
