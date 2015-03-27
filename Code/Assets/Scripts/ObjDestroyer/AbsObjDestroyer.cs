using UnityEngine;

public abstract class AbsObjDestroyer : MonoBehaviour {

	void Start() {
		// pass
	}
	
	void Update() {
		if (Proc()) {
			Destroy(gameObject);
		}
	}

	// Abstract method
	protected abstract bool Proc();
	// ...

}
