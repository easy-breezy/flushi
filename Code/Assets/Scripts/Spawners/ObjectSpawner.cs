using UnityEngine;

public abstract class AbsObjSpawner : MonoBehaviour
{
    // Static declarations
    protected static float CameraCircumcircleRadius = -1f;
    // Public UnityEditor-resettable values
    public GameObject Object;
    public float ObjectDestroyOffset = 1f;
    public float ObjectScaleMax = 1f;
    public float ObjectScaleMin = 1f;
    public float ObjectSpawnChance = 0f;
    public float ObjectSpawnOffset = 1f;

    private void Start()
    {
        CheckArgsAndState();
    }

    private void Update()
    {
        if (!Proc()) return;
        var objScale = GetObjScale();

        var objSpawnRadius = GetObjSpawnRadius();
        var objDestroyRadius = GetObjDestroyRadius();

        var objPosition = GetObjPosition(objSpawnRadius);
        var objRotation = GetObjRotation();

        var obj = (GameObject) Instantiate(Object, objPosition, objRotation);
        ApplyObjScale(obj, objScale);

        // Abstract methods usage
        ApplyObjDestroyer(obj, objDestroyRadius);
        PostSpawn(obj);
        // ...
    }

    protected virtual void CheckArgsAndState()
    {
        if (Object == null)
        {
            throw new UnityException("ObjSpawner exception: no Object given.");
        }

        if (ObjectSpawnChance < 0f || ObjectSpawnChance > 100f)
        {
            throw new UnityException("ObjSpawner exception: invalid ObjectSpawnChance value.");
        }

        if (ObjectScaleMin < 0 || ObjectScaleMax < 0 || ObjectScaleMin > ObjectScaleMax)
        {
            throw new UnityException("ObjSpawner exception: invalid ObjectScaleRange value.");
        }
    }

    protected bool Proc()
    {
        return (ObjectSpawnChance > Random.Range(0f, 100f));
    }

    protected float GetObjScale()
    {
        return (Random.Range(ObjectScaleMin, ObjectScaleMax));
    }

    public static float GetCameraCircumcircleRadius()
    {
        if (CameraCircumcircleRadius != -1f) return CameraCircumcircleRadius;
        var cameraHeight = Camera.main.orthographicSize;
        var cameraWidth = cameraHeight*Camera.main.aspect;

        CameraCircumcircleRadius = Mathf.Sqrt(Mathf.Pow(cameraHeight, 2f) + Mathf.Pow(cameraWidth, 2f));

        return CameraCircumcircleRadius;
    }

    // ...


    protected float GetObjSpawnRadius()
    {
        return (GetCameraCircumcircleRadius() + ObjectSpawnOffset);
    }

    protected float GetObjDestroyRadius()
    {
        return (GetCameraCircumcircleRadius() + ObjectSpawnOffset + ObjectDestroyOffset);
    }

    protected static Vector3 GetObjPosition(float objSpawnRadius)
    {
        var angle = Random.Range(0f, 1f)*Mathf.PI*2;

        var x = Camera.main.transform.position.x + Mathf.Cos(angle)*objSpawnRadius;
        var y = Camera.main.transform.position.y + Mathf.Sin(angle)*objSpawnRadius;

        return new Vector3(x, y);
    }

    protected static Quaternion GetObjRotation()
    {
        return new Quaternion();
    }

    protected static void ApplyObjScale(GameObject obj, float objScale)
    {
        obj.transform.localScale = new Vector3(objScale, objScale, objScale);
    }

    // Abstract methods
    protected abstract void ApplyObjDestroyer(GameObject obj, float objDestroyRadius);
    protected abstract void PostSpawn(GameObject obj);
}