using UnityEngine;

public class ObjMovementController : MonoBehaviour
{
    public Vector2 Direction;
    public float MoveSpeedLimit = 30f;
    public float RotateSpeedLimit = 360f;

    public void ApplyTorque(float value)
    {
            //if (value == 0) value = 10f;
            gameObject.rigidbody2D.AddTorque(value);

            if (Mathf.Abs(rigidbody2D.angularVelocity) > RotateSpeedLimit)
                rigidbody2D.angularVelocity = Mathf.Sign(rigidbody2D.angularVelocity) * RotateSpeedLimit;
    }

    public void ApplyVelocity(float value)
    {
            if (value <= 0) return;
            gameObject.rigidbody2D.AddForce(Direction.normalized * value);

            if (rigidbody2D.velocity.magnitude > MoveSpeedLimit)
                rigidbody2D.velocity = rigidbody2D.velocity.normalized * MoveSpeedLimit;
    }

    private void Start()
    {
    }

    public virtual void Update()
    {
    }
}