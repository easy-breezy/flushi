using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

	public GameObject explosion;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCoTriggerEnter(Collider other) {
		Debug.Log ("OK");
		if (other.gameObject.tag == "Finish"){
			GameObject explosionClone = (GameObject) Instantiate(explosion, other.transform.position, other.transform.rotation);
			Destroy(explosionClone, 2);
		}
		Destroy (gameObject); // destroy the projectile anyway
		Destroy(other.gameObject);
	}
}
