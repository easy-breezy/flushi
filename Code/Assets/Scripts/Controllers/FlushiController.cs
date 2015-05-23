using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FlushiController : ObjMovementController
{
    public GameObject ExplosionPrefab;
    public GameObject GameOverText;
    public float ObjProjectileVelocity = 30f;
    public float ProjectileDestroyOffset = 1f;
    public GameObject ProjectilePrefab;
    //important for player experience
    public float SpeedDifferenseVelocity = 1f;

    private void Start()
    {
        ScoreManager.Add(100f);
        MoveSpeedLimit = 30f;
    }

    public override void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var direction = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
            
            Direction = -direction;
            ApplyVelocity(ObjProjectileVelocity);
            
            SpawnProjectile(direction);
        }
    }

    private void SpawnProjectile(Vector2 direction)
    {
        var projectileClone = (GameObject)Instantiate(ProjectilePrefab, transform.position + new Vector3(0,0,1), transform.rotation);
        
        //Fix self-projectiles collisions
        Physics2D.IgnoreCollision(projectileClone.GetComponent<Collider2D>(), GetComponent<Collider2D>());

        var projectileDestroyer = projectileClone.AddComponent<AwayFromCameraObjDestroyer>();
        projectileDestroyer.Range = ObjectSpawner.GetCameraCircumcircleRadius() + ProjectileDestroyOffset;

        var projectileCloneMc = projectileClone.GetComponent<ObjMovementController>();
        projectileCloneMc.Direction = direction;
        projectileCloneMc.GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity;
        projectileCloneMc.ApplyVelocity(SpeedDifferenseVelocity * ObjProjectileVelocity);
        ScoreManager.Subtract(1f);
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Meteor":
            case "Enemy":
            case "Star":
                EnemyCollision(collision);
                break;
        }
    }

    private void EnemyCollision(Collision2D collision)
    {
        var explosionClone =
            (GameObject) Instantiate(ExplosionPrefab, gameObject.transform.position, gameObject.transform.rotation);
        explosionClone.transform.localScale = collision.gameObject.transform.localScale*2f;
        
        if (collision.gameObject.tag != "Star") Destroy(collision.gameObject);
        Destroy(gameObject);
        
        //GameOverText.GetComponent<Text>().text += "SCORE: " + ScoreManager.Score;
        GameOverText.SetActive(true);
    }
}