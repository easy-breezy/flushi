using UnityEngine;
using System.Collections;

public class ProjectileBehaviour : MonoBehaviour {

    public GameObject ExplosionPrefab;

    void Start() {
        
    }
    
    void Update() {
        
    }

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag == "Meteor" || col.gameObject.tag == "Enemy") {
            GameObject explosionClone = (GameObject) Instantiate(ExplosionPrefab, col.gameObject.transform.position, col.gameObject.transform.rotation);
            explosionClone.transform.localScale = col.gameObject.transform.localScale * 2.5f;
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
    }

}
