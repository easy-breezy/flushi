using UnityEngine;

public abstract class ObjectDestroyer : MonoBehaviour
{
    private void Update()
    {
        if (Proc())
            Destroy(gameObject);
    }

    protected abstract bool Proc();
}