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

    // Abstract method
    protected abstract bool proc();
    // ...

}
