using UnityEngine;
using System.Collections;

public class FlushiController : MonoBehaviour {

	public Rigidbody2D glob;
	Vector2 target;
	int speed = 10;

	// Use this for initialization
	void Start () {
	
	}
	// Update is called once per frame
	void Update () {
		target = new Vector2 ();
		if (Input.GetMouseButtonDown(0)) {
			target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			rigidbody2D.AddForce(target * (-speed));
			Rigidbody2D globClone = (Rigidbody2D) Instantiate(glob, transform.position, transform.rotation);
			globClone.rigidbody2D.AddForce(target * speed);
			Destroy(globClone.gameObject, 2);
		}
	} 
}
