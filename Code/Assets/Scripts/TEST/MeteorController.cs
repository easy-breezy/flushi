using UnityEngine;
using System.Collections;
using System;

public class MeteorController : MonoBehaviour {

	public static Vector3 DEFAULT_POS     = new Vector3 (0F, 35F, 0F);
	public static Vector3 DEFAULT_SCALE   = new Vector3 (1.7F, 1.7F, 1.7F);
	public static Vector2 DEFAULT_LIN_VEL = new Vector2 (0F, -50F);
	public static float   DEFAULT_ANG_VEL = 0F;

	public Vector3 pos    = DEFAULT_POS;
	public Vector3 scale  = DEFAULT_SCALE;
	public Vector2 linVel = DEFAULT_LIN_VEL;
	public float   angVel = DEFAULT_ANG_VEL;

	// Use this for initialization
	void Start () {
		this.gameObject.transform.position = pos;
		this.gameObject.transform.localScale = scale;
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.rigidbody2D.AddForce  (linVel);
		gameObject.rigidbody2D.AddTorque (angVel);

		Vector3 position = gameObject.transform.position;
		if (Math.Abs(position.x + position.y) >= 50) {
				Destroy (gameObject);
		}
	}
}
