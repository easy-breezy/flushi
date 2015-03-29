using UnityEngine;

public class PrefubSpawner : GenObjSpawner
{
    public float DeviationAngleMax = 30f;
    public float TorqueMax = 40f;
    public float TorqueMin = 10f;
    public float VelocityMax = 40f;
    public float VelocityMin = 10f;

    protected override void CheckArgsAndState()
    {
        base.CheckArgsAndState();
        // I'mma too lazy to do it now...
    }

    protected override void ApplyObjDestroyer(GameObject obj, float objDestroyRadius)
    {
        base.ApplyObjDestroyer(obj, objDestroyRadius);

        var objDestroyer = obj.AddComponent<AwayFromCameraObjDestroyer>();
        objDestroyer.Range = objDestroyRadius;
    }

    protected override void PostSpawn(GameObject obj)
    {
        base.PostSpawn(obj);

        var objMc = obj.GetComponent<ObjMovementController>();

        if (objMc)
        {
            var obj2CameraDirection = obj.transform.position - Camera.main.transform.position;
            var objDeviationAngle = Random.Range(-DeviationAngleMax, +DeviationAngleMax);

            var objDirection = new Vector2(obj2CameraDirection.x * Mathf.Cos(objDeviationAngle),
                obj2CameraDirection.y * Mathf.Sin(objDeviationAngle)).normalized;
            var objVelocity = Random.Range(VelocityMin, VelocityMax);
            objMc.Direction = objDirection;
            objMc.ApplyVelocity(objVelocity);

            var objTorque = (Random.Range(0, 2) == 0 ? 1 : -1) * Random.Range(TorqueMin, TorqueMax);
            objMc.ApplyTorque(objTorque);
        }
    }
}