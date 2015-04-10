using UnityEngine;
using System.Collections;

public class MeteorSpawner : GenObjSpawner {

    public float MeteorDeviationAngleMax = 30f;

    public float MeteorVelocityMin = 10f;
    public float MeteorVelocityMax = 40f;

    public float MeteorTorqueMin = 10f;
    public float MeteorTorqueMax = 40f;

    protected override void checkArgsAndState() {
        base.checkArgsAndState();
        // I'mma too lazy to do it now...
    }
    
    protected override void applyObjDestroyer(GameObject obj, float objDestroyRadius) {
        base.applyObjDestroyer(obj, objDestroyRadius);

        AwayFromCameraObjDestroyer objDestroyer = (AwayFromCameraObjDestroyer) obj.AddComponent(typeof(AwayFromCameraObjDestroyer));
        objDestroyer.Range = objDestroyRadius;
    }
    
    protected override void postSpawn(GameObject obj) {
        base.postSpawn(obj);

        ObjMovementController objMC = (ObjMovementController) obj.GetComponent(typeof(ObjMovementController));

        Vector3 obj2CameraDirection = obj.transform.position - Camera.main.transform.position; 
        float objDeviationAngle = Random.Range(-MeteorDeviationAngleMax, +MeteorDeviationAngleMax);

        Vector2 objDirection = new Vector2(obj2CameraDirection.x * Mathf.Cos(objDeviationAngle),
                                           obj2CameraDirection.y * Mathf.Sin(objDeviationAngle)).normalized;
        float objVelocity = Random.Range(MeteorVelocityMin, MeteorVelocityMax);
        objMC.Direction = objDirection;
        objMC.Velocity = objVelocity;

        float objTorque = Random.Range(-1, 1) * Random.Range(MeteorTorqueMin, MeteorTorqueMax);
        objMC.Torque = objTorque;
    }

}
