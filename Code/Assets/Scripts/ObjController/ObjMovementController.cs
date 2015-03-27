using UnityEngine;

public class ObjMovementController : MonoBehaviour
{
    public Vector2 Direction = new Vector2();
    public float MooveSpeedLimit = 30f;
    public float RotateSpeedLimit = 360f;
    public float Torque;
    public float Velocity;

    private void Start()
    {
    }

    public virtual void Update()
    {
        if (Velocity > 0)
        {
            gameObject.rigidbody2D.AddForce(Direction.normalized*Velocity);

            if (rigidbody2D.velocity.magnitude > MooveSpeedLimit)
                rigidbody2D.velocity = rigidbody2D.velocity.normalized*MooveSpeedLimit;

            Velocity = 0;
        }

        if (Torque != 0)
        {
            gameObject.rigidbody2D.AddTorque(Torque);

            if (Mathf.Abs(rigidbody2D.angularVelocity) > RotateSpeedLimit)
                rigidbody2D.angularVelocity = Mathf.Sign(rigidbody2D.angularVelocity)*RotateSpeedLimit;
            Torque = 0;
        }
    }
}