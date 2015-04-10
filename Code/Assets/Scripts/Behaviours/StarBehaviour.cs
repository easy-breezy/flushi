using UnityEngine;
using System.Collections;

public class StarBehaviour : MonoBehaviour {
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Flushi")
            Destroy(collision.gameObject);
    }
       
}
