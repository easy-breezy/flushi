using UnityEngine;
using System.Collections;

public class FlushiController : ObjMovementController {

    public GameObject ProjectilePrefab;
    public GameObject ExplosionPrefab;

    public GameObject GameOverText;

    public float ProjectileDestroyOffset = 1f;

    public float ObjProjectileVelocity = 30f;
    //important for player experience
    public float SpeedDifferenseVelocity = 5f;
    void Start() {
        MooveSpeedLimit = 30f;
    }

    override public void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Vector3 direction = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;

            GameObject projectileClone = (GameObject) Instantiate(ProjectilePrefab, transform.position, transform.rotation);

            AwayFromCameraObjDestroyer projectileDestroyer = (AwayFromCameraObjDestroyer) projectileClone.AddComponent(typeof(AwayFromCameraObjDestroyer));
            projectileDestroyer.Range = AbsObjSpawner.getCameraCircumcircleRadius() + ProjectileDestroyOffset;

            base.Velocity = ObjProjectileVelocity;
            base.Direction = -direction;
            base.Update();

            ObjMovementController projectileCloneMC = (ObjMovementController) projectileClone.GetComponent(typeof(ObjMovementController));
            projectileCloneMC.Direction = direction;
            projectileCloneMC.Velocity = SpeedDifferenseVelocity * ObjProjectileVelocity + gameObject.rigidbody2D.velocity.magnitude;

            //Fix self-projectiles collisions
            Physics2D.IgnoreCollision(projectileCloneMC.collider2D, this.collider2D);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Meteor" || collision.gameObject.tag == "Enemy")
        {
            GameObject explosionClone = (GameObject)Instantiate(ExplosionPrefab, gameObject.transform.position, gameObject.transform.rotation);
            explosionClone.transform.localScale = collision.gameObject.transform.localScale * 2f;
            Destroy(collision.gameObject);

            foreach (SpriteRenderer render in gameObject.GetComponentsInChildren<SpriteRenderer>())
                render.enabled = false;
            gameObject.GetComponent<FlushiController>().enabled = false;
            gameObject.GetComponent<CircleCollider2D>().enabled = false;

            GameOverText.SetActive(true);
        }
    }
}