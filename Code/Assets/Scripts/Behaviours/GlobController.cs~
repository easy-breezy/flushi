using UnityEngine;
using System.Collections;

public class GlobController : MonoBehaviour {

    public GameObject ExplosionPrefab;

    void Start() {
	
    }
	
    void Update() {
	
    }

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag == "Meteor" || col.gameObject.tag == "Enemy") {
            GameObject explosionClone = (GameObject) Instantiate(ExplosionPrefab, col.transform.position, col.transform.rotation);
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
    }
}
