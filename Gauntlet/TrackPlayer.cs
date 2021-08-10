using UnityEngine;
using System.Collections;

public class TrackPlayer : MonoBehaviour {
	GameObject player; 
	bool foundPlayer;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (!foundPlayer) {
			player = GameObject.FindGameObjectWithTag ("Player"); 
			if(player != null){
				foundPlayer = true;
			}

		} else {

			this.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
		}
	
	}
}
