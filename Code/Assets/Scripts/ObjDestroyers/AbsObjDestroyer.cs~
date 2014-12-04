using UnityEngine;
using System.Collections;

public abstract class AbsObjDestroyer : MonoBehaviour {

    void Start() {
        // pass
    }
	
    void Update() {
        if (proc()) {
            Destroy(gameObject);
        }
    }

    protected abstract bool proc();
}
