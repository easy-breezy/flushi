using UnityEngine;
using System.Collections;

public class LinearThruster : MonoBehaviour {

    public Vector2 Direction;
    public float Velocity;

    void Start() {
        // pass
    }
	
    void Update() {
        gameObject.rigidbody2D.AddForce(Direction.normalized * Velocity);
    }

}
