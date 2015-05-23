using UnityEngine;

public class AwayFromCameraObjDestroyer : ObjectDestroyer
{
    public float Range;

    protected override bool Proc()
    {
        var objPos = gameObject.transform.position;
        var camPos = Camera.main.transform.position;
        camPos.z = objPos.z;

        return (Vector3.Distance(objPos, camPos) > Range);
    }
}