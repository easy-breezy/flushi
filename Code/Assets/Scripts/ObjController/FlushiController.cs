using UnityEngine;

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
            var direction = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;

            var projectileClone = (GameObject) Instantiate(ProjectilePrefab, transform.position, transform.rotation);

            var projectileDestroyer = projectileClone.AddComponent<AwayFromCameraObjDestroyer>();
            projectileDestroyer.Range = AbsObjSpawner.GetCameraCircumcircleRadius() + ProjectileDestroyOffset;

            Velocity = ObjProjectileVelocity;
            Direction = -direction;
            base.Update();

            var projectileCloneMc = projectileClone.GetComponent<ObjMovementController>();
            projectileCloneMc.Direction = direction;
            projectileCloneMc.Velocity = SpeedDifferenseVelocity * ObjProjectileVelocity + gameObject.rigidbody2D.velocity.magnitude;

            //Fix self-projectiles collisions
            Physics2D.IgnoreCollision(projectileCloneMc.collider2D, collider2D);
        }
    }



    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Meteor" || collision.gameObject.tag == "Enemy")
        {
            var explosionClone = (GameObject) Instantiate(ExplosionPrefab, gameObject.transform.position, gameObject.transform.rotation);
            explosionClone.transform.localScale = collision.gameObject.transform.localScale * 2f;
            Destroy(collision.gameObject);

            foreach (var render in gameObject.GetComponentsInChildren<SpriteRenderer>())
                render.enabled = false;
            gameObject.GetComponent<FlushiController>().enabled = false;
            gameObject.GetComponent<CircleCollider2D>().enabled = false;

            GameOverText.SetActive(true);
        }
    }
}