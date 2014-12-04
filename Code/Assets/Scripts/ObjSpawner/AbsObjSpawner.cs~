using UnityEngine;
using System.Collections;

public abstract class AbsObjSpawner : MonoBehaviour {
	
    // Public UnityEditor-resettable values
    public GameObject Object;
    public float      ObjectSpawnChance = 0f;
    public float      ObjectScaleMin = 1f;
    public float      ObjectScaleMax = 1f;
    public float      ObjectSpawnOffset = 1f;
    public float      ObjectDestroyOffset = 1f;
	
    void Start() {
        checkArgsAndState();
    }
	
    void Update() {
        if (proc()) {
            float objScale = getObjScale();
			
            float objSpawnRadius = getObjSpawnRadius();
            float objDestroyRadius = getObjDestroyRadius();
			
            Vector3 objPosition = getObjPosition(objSpawnRadius);
            Quaternion objRotation = getObjRotation();
			
            GameObject obj = (GameObject) Instantiate(Object, objPosition, objRotation);
            applyObjScale(obj, objScale);
			
            // Abstract methods usage
            applyObjDestroyer(obj, objDestroyRadius);
            postSpawn(obj);
            // ...
        } 
    }
	
    protected virtual void checkArgsAndState() {
        if (Object == null) {
            throw new UnityException("ObjSpawner exception: no Object given.");
        }
		
        if (ObjectSpawnChance < 0f || ObjectSpawnChance > 100f) {
            throw new UnityException("ObjSpawner exception: invalid ObjectSpawnChance value.");
        }
		
        if (ObjectScaleMin < 0 || ObjectScaleMax < 0 || ObjectScaleMin > ObjectScaleMax) {
            throw new UnityException("ObjSpawner exception: invalid ObjectScaleRange value.");
        }
    }
	
    protected bool proc() {
        return (ObjectSpawnChance > Random.Range(0f, 100f));
    }
	
    protected float getObjScale() {
        return (Random.Range(ObjectScaleMin, ObjectScaleMax));
    }
	
    // Static declarations
    protected static float CameraCircumcircleRadius = -1f;
	
    public static float getCameraCircumcircleRadius() {
        if (CameraCircumcircleRadius == -1f) {
            float cameraHeight = Camera.main.orthographicSize;
            float cameraWidth = cameraHeight * Camera.main.aspect;
			
            CameraCircumcircleRadius = Mathf.Sqrt(Mathf.Pow(cameraHeight, 2f) + Mathf.Pow(cameraWidth, 2f));
        }
		
        return CameraCircumcircleRadius;
    }
    // ...
	
   	
    protected float getObjSpawnRadius() {
        return (getCameraCircumcircleRadius() + ObjectSpawnOffset);
    }
	
    protected float getObjDestroyRadius() {
        return (getCameraCircumcircleRadius() + ObjectSpawnOffset + ObjectDestroyOffset);
    }
	
    protected Vector3 getObjPosition(float objSpawnRadius) {
        float angle = Random.Range(0f, 1f) * Mathf.PI * 2;
		
        float x = Camera.main.transform.position.x + Mathf.Cos(angle) * objSpawnRadius;
        float y = Camera.main.transform.position.y + Mathf.Sin(angle) * objSpawnRadius;
		
        return new Vector3(x, y);
    }
	
    protected Quaternion getObjRotation() {
        return new Quaternion();
    }
	
    protected void applyObjScale(GameObject obj, float objScale) {
        obj.transform.localScale = new Vector3(objScale, objScale, objScale);
    }
	
    // Abstract methods
    // Could be tricky redifined for specific GameObjects
    protected abstract void applyObjDestroyer(GameObject obj, float objDestroyRadius);
    protected abstract void postSpawn(GameObject obj);
    // ...
}
