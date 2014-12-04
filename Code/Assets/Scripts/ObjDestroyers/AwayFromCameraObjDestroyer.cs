using UnityEngine;
using System.Collections;

public class AwayFromCameraObjDestroyer : AbsObjDestroyer {

    public float Range;

    protected override bool proc() {
        Vector3 objPos = gameObject.transform.position;
        Vector3 camPos = Camera.main.transform.position;
        camPos.z = objPos.z;

        return (Vector3.Distance(objPos, camPos) > Range);
    } 

}
