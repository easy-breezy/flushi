using UnityEngine;

public class ObjMovementController : MonoBehaviour
{
    public Vector2 Direction;
    public float MoveSpeedLimit = 30f;
    public float RotateSpeedLimit = 360f;

    public void ApplyTorque(float value)
    {
            //if (value == 0) value = 10f;
            gameObject.GetComponent<Rigidbody2D>().AddTorque(value);

            if (Mathf.Abs(GetComponent<Rigidbody2D>().angularVelocity) > RotateSpeedLimit)
                GetComponent<Rigidbody2D>().angularVelocity = Mathf.Sign(GetComponent<Rigidbody2D>().angularVelocity) * RotateSpeedLimit;
    }

    public void ApplyVelocity(float value)
    {
            if (value <= 0) return;
            gameObject.GetComponent<Rigidbody2D>().AddForce(Direction.normalized * value);

            if (GetComponent<Rigidbody2D>().velocity.magnitude > MoveSpeedLimit)
                GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity.normalized * MoveSpeedLimit;
    }

    private void Start()
    {
    }

    public virtual void Update()
    {
    }
}