using UnityEngine;
using System.Collections;

public class Exit : MonoBehaviour {

	void OnCollisionEnter (Collision col){
		if(col.gameObject.tag == "Player"){
			Application.LoadLevel("Level_02");
		}
	}
}
