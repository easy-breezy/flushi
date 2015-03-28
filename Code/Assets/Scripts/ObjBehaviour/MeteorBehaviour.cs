using UnityEngine;
using System.Collections;

public class MeteorBehaviour : MonoBehaviour
{
    public GameObject FoodPrefab;
    public float FoodDestroyOffset = 1f;
    public GameObject ExplosionPrefab;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Glob":
                GlobCollision(collision);
                break;
        }
    }

    private void GlobCollision(Collision2D collision)
    {
        var food = (GameObject)Instantiate(FoodPrefab, transform.position, transform.rotation);
        food.transform.localScale = transform.localScale;

        var foodDestroyer = food.AddComponent<AwayFromCameraObjDestroyer>();
        foodDestroyer.Range = AbsObjSpawner.GetCameraCircumcircleRadius() + FoodDestroyOffset;

        var foodCloneMc = food.GetComponent<ObjMovementController>();
        foodCloneMc.Direction = gameObject.GetComponent<ObjMovementController>().Direction;

        var explosionClone = (GameObject) 
            Instantiate(ExplosionPrefab, collision.gameObject.transform.position,
            collision.gameObject.transform.rotation);

        explosionClone.transform.localScale = collision.gameObject.transform.localScale * 2.5f;
        Destroy(collision.gameObject);
        Destroy(gameObject);
    }
}
