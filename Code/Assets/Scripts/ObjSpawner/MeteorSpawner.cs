using UnityEngine;

public class MeteorSpawner : GenObjSpawner
{
    public float MeteorDeviationAngleMax = 30f;
    public float MeteorTorqueMax = 40f;
    public float MeteorTorqueMin = 10f;
    public float MeteorVelocityMax = 40f;
    public float MeteorVelocityMin = 10f;

    protected override void CheckArgsAndState()
    {
        base.CheckArgsAndState();
        // I'mma too lazy to do it now...
    }

    protected override void ApplyObjDestroyer(GameObject obj, float objDestroyRadius)
    {
        base.ApplyObjDestroyer(obj, objDestroyRadius);

        var objDestroyer = (AwayFromCameraObjDestroyer) obj.AddComponent(typeof (AwayFromCameraObjDestroyer));
        objDestroyer.Range = objDestroyRadius;
    }

    protected override void PostSpawn(GameObject obj)
    {
        base.PostSpawn(obj);

        var objMc = (ObjMovementController) obj.GetComponent(typeof (ObjMovementController));

        var obj2CameraDirection = obj.transform.position - Camera.main.transform.position;
        var objDeviationAngle = Random.Range(-MeteorDeviationAngleMax, +MeteorDeviationAngleMax);

        var objDirection = new Vector2(obj2CameraDirection.x*Mathf.Cos(objDeviationAngle),
            obj2CameraDirection.y*Mathf.Sin(objDeviationAngle)).normalized;
        var objVelocity = Random.Range(MeteorVelocityMin, MeteorVelocityMax);
        objMc.Direction = objDirection;
        objMc.ApplyVelocity(objVelocity);

        var objTorque = Random.Range(-1, 1)*Random.Range(MeteorTorqueMin, MeteorTorqueMax);
        objMc.ApplyTorque(objTorque);
    }
}