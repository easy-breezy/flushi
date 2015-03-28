using UnityEngine;
using System.Collections;

public class CameraBehaviour : MonoBehaviour
{
	public GameObject Target;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (Target == null) return;
		transform.position = new Vector3(Target.transform.position.x, Target.transform.position.y, transform.position.z);
	}
}
