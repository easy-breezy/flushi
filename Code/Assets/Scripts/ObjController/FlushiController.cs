using UnityEngine;
using System.Collections;

public class FlushiController : ObjMovementController {

    public GameObject ProjectilePrefab;
    public float ProjectileDestroyOffset = 1f;
    public float ObjProjectileVelocity = 3f;
    //important for player experience
    public float SpeedDifferenseVelocity = 5f;
    void Start() {
        MooveSpeedLimit = 9f;
    }

    override public void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Vector3 direction = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;

            GameObject projectileClone = (GameObject) Instantiate(ProjectilePrefab, transform.position, transform.rotation);

            AwayFromCameraObjDestroyer projectileDestroyer = (AwayFromCameraObjDestroyer) projectileClone.AddComponent(typeof(AwayFromCameraObjDestroyer));
            projectileDestroyer.Range = AbsObjSpawner.getCameraCircumcircleRadius() + ProjectileDestroyOffset;

            ObjMovementController projectileCloneMC = (ObjMovementController) projectileClone.GetComponent(typeof(ObjMovementController));
            projectileCloneMC.Direction = direction;
            projectileCloneMC.Velocity = ObjProjectileVelocity;

            //Fix self-projectiles collisions
            Physics2D.IgnoreCollision(projectileCloneMC.collider2D, this.collider2D);

            //gameObject.rigidbody2D.AddForce(-direction * ObjProjectileVelocity);
            base.Velocity = SpeedDifferenseVelocity*ObjProjectileVelocity;
            base.Direction = -direction;
            base.Update();
        }
    }
}