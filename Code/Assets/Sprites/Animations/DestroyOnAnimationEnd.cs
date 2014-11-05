using UnityEngine;
using System.Collections;

public class DestroyOnAnimationEnd : MonoBehaviour {
    public void DestroyMe(){
		GameObject.Destroy(gameObject);
	}
}
