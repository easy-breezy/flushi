using UnityEngine;
using System.Collections;

public class ScriptScrollingBackground : MonoBehaviour {
		
		public float scrollSpeed;
		private Vector2 savedOffset;
		
		void Start () {
			savedOffset = new Vector2(transform.position.x,transform.position.y);
		}
		
		void Update () {
		Vector2 offset = new Vector2 (Mathf.Repeat (transform.position.x*scrollSpeed, 1), Mathf.Repeat (transform.position.y*scrollSpeed, 1));
				renderer.sharedMaterial.SetTextureOffset ("_MainTex", offset);
				savedOffset = new Vector2(transform.position.x,transform.position.y);
		}
		
		void OnDisable () {
			renderer.sharedMaterial.SetTextureOffset ("_MainTex", new Vector2());
		}
}