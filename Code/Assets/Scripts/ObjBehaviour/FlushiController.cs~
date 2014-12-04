using UnityEngine;
using System.Collections;

public class FlushiController : MonoBehaviour {

    public GameObject GlobPrefab;
    public float ObjGlobVelocity = 10f;
    public float GlobDestroyOffset = 1f;

    void Start() {

    }

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Vector3 direction = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;

            GameObject globClone = (GameObject) Instantiate(GlobPrefab, transform.position, transform.rotation);

            AwayFromCameraObjDestroyer globDestroyer = (AwayFromCameraObjDestroyer) globClone.AddComponent(typeof(AwayFromCameraObjDestroyer));
            globDestroyer.Range = AbsObjSpawner.getCameraCircumcircleRadius() + GlobDestroyOffset;

            LinearThruster globCloneLT = (LinearThruster) globClone.GetComponent(typeof(LinearThruster));
            globCloneLT.Direction = direction;
            globCloneLT.Velocity = ObjGlobVelocity * 5;

            gameObject.rigidbody2D.AddForce(-direction * ObjGlobVelocity);
        }
    } 
}