using UnityEngine;

public class GenObjSpawner : AbsObjSpawner {

    protected override void CheckArgsAndState() {
        base.CheckArgsAndState();
        // I'mma too lazy to do it now...
    }
    
    protected override void ApplyObjDestroyer(GameObject obj, float objDestroyRadius) {
        // pass
    }
    
    protected override void PostSpawn(GameObject obj) {
        // pass
    }

}
