using UnityEngine;
using System.Collections;

public class FlushiController : MonoBehaviour {

    public GameObject ProjectilePrefab;
    public float ProjectileDestroyOffset = 1f;
    public float ObjProjectileVelocity = 10f;

    void Start() {

    }

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Vector3 direction = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;

            GameObject projectileClone = (GameObject) Instantiate(ProjectilePrefab, transform.position, transform.rotation);

            AwayFromCameraObjDestroyer projectileDestroyer = (AwayFromCameraObjDestroyer) projectileClone.AddComponent(typeof(AwayFromCameraObjDestroyer));
            projectileDestroyer.Range = AbsObjSpawner.getCameraCircumcircleRadius() + ProjectileDestroyOffset;

            ObjMovementController projectileCloneMC = (ObjMovementController) projectileClone.GetComponent(typeof(ObjMovementController));
            projectileCloneMC.Direction = direction;
            projectileCloneMC.Velocity = ObjProjectileVelocity * 5;

            gameObject.rigidbody2D.AddForce(-direction * ObjProjectileVelocity);
        }
    } 

}