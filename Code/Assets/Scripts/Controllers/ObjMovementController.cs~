using UnityEngine;
using System.Collections;

public class ObjMovementController : MonoBehaviour {

    public Vector2 Direction = new Vector2();
    public float Velocity = 0f;
    public float Torque = 0f;

    void Start() {
	
    }

    void Update() {
        gameObject.rigidbody2D.AddForce(Direction.normalized * Velocity);
        gameObject.rigidbody2D.AddTorque(Torque);
    }

}
