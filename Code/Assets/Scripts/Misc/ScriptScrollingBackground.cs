using UnityEngine;
using System.Collections;

public class ScriptScrollingBackground : MonoBehaviour {
	public float scrollSpeed;
	public GameObject Flushi;
	private Vector3 _savedOffset;
	
	void Start () {
		_savedOffset = Flushi.transform.position;
	}
	
	void FixedUpdate () {
		var offset = new Vector2 (Mathf.Repeat (Flushi.transform.position.x*scrollSpeed, 1), Mathf.Repeat (Flushi.transform.position.y*scrollSpeed, 1));
		renderer.sharedMaterial.SetTextureOffset ("_MainTex", offset);
		transform.Translate( Flushi.transform.position - _savedOffset);
		_savedOffset = Flushi.transform.position;
	}
	
	void OnDisable () {
		renderer.sharedMaterial.SetTextureOffset ("_MainTex", new Vector2());
	}
}