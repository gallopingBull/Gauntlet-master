using UnityEngine;
using System.Collections;

public class Generator : MonoBehaviour
{

    public Transform[] spawnArea;
    public GameObject enemyPrefab;

    public int health;
    public float timeToWait;
    private float waitToSpawn;

    // Use this for initialization
    void Start()
    {
        for (int index = 0; index < 8; index++)
        {
            GameObject go = Instantiate(enemyPrefab);
            go.transform.position = spawnArea[index].transform.position;

        }
        waitToSpawn = timeToWait;
    }

	public void Killed(){
		Destroy (this.gameObject);
	}
	
	public void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "Projectile") {
			print (this.gameObject.name + " Hit by projectile");
			health--; 
			if (health <= 0) {
				print (this.gameObject.name + " has been killed."); 
				Killed (); 
			}
		}
		//print (this.gameObject.name + " collided w/ " + col.gameObject.name);
	}
    
    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<Renderer>().isVisible)
        {
            if (waitToSpawn < Time.time)
            {
                for (int index = 0; index < 8; index++)
                {
                    GameObject go = Instantiate(enemyPrefab);
                    go.transform.position = spawnArea[index].transform.position;
                }
                waitToSpawn = Time.time + timeToWait;
            }
        }
    }
}
