using UnityEngine;

public abstract class AbsObjDestroyer : MonoBehaviour
{
    private void Start()
    {
        // pass
    }

    private void Update()
    {
        if (Proc())
        {
            Destroy(gameObject);
        }
    }

    // Abstract method
    protected abstract bool Proc();
}