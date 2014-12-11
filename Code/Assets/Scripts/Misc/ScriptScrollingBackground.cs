using UnityEngine;
using System.Collections;

using UnityEngine;
using System.Collections;
public class ScriptScrollingBackground : MonoBehaviour {
	public float scrollSpeed;
	public GameObject Flushi;
	private Vector3 savedOffset;
	
	void Start () {
		savedOffset = Flushi.transform.position;
	}
	
	void FixedUpdate () {
		Vector2 offset = new Vector2 (Mathf.Repeat (Flushi.transform.position.x*scrollSpeed, 1), Mathf.Repeat (Flushi.transform.position.y*scrollSpeed, 1));
		renderer.sharedMaterial.SetTextureOffset ("_MainTex", offset);
		transform.Translate( Flushi.transform.position - savedOffset);
		savedOffset = Flushi.transform.position;
	}
	
	void OnDisable () {
		renderer.sharedMaterial.SetTextureOffset ("_MainTex", new Vector2());
	}
}