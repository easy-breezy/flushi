using UnityEngine;
using System.Collections;

public class MeteorBehaviour : MonoBehaviour
{
    public GameObject FoodPrefab;
    public float FoodDestroyOffset = 1f;

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

        //Fix self-food collisions
        Physics2D.IgnoreCollision(food.collider2D, collider2D);

        var foodDestroyer = food.AddComponent<AwayFromCameraObjDestroyer>();
        foodDestroyer.Range = AbsObjSpawner.GetCameraCircumcircleRadius() + FoodDestroyOffset;

        var foodCloneMc = food.GetComponent<ObjMovementController>();
        foodCloneMc.Direction = gameObject.GetComponent<ObjMovementController>().Direction;
        foodCloneMc.rigidbody2D.velocity = rigidbody2D.velocity;
    }
}
