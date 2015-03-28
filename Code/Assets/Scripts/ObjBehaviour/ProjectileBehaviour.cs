using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    public GameObject ExplosionPrefab;

    private void Start()
    {
    }

    private void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Meteor" || collision.gameObject.tag == "Enemy")
        {
            var explosionClone =
                (GameObject)
                    Instantiate(ExplosionPrefab, collision.gameObject.transform.position,
                        collision.gameObject.transform.rotation);
            explosionClone.transform.localScale = collision.gameObject.transform.localScale*2.5f;
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}