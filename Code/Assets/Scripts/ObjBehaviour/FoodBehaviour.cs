using UnityEngine;
using System.Collections;

public class FoodBehaviour : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Flushi":
                FlusiCollision(collision);
                break;
        }
    }

    private void FlusiCollision(Collision2D collision)
    {
        Destroy(gameObject);
        ScoreManager.Add(10f);
    }
}
