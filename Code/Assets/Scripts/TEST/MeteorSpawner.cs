using UnityEngine;
using System.Collections;

public class MeteorSpawner : MonoBehaviour {

	static float METEOR_SCALE_MIN = 0.4F;
	static float METEOR_SCALE_MAX = 2.0F;

	static float METEOR_POS_X_MIN = -9F;
	static float METEOR_POS_X_MAX = +9F;

	static float METEOR_LIN_VEL_MIN = 10F;
	static float METEOR_LIN_VEL_MAX = 50F;

	static float METEOR_ANG_VEL_MIN = 10F;
	static float METEOR_ANG_VEL_MAX = 40F;

	static float METEOR_SPAWN_CHANCE = 0.01F;

	// Use this for initialization
	void Start () {
		// pass
	}
	
	// Update is called once per frame
	void Update () {
		// TRY to spawn a meteor
		if (Random.Range (0F, 1F) <= METEOR_SPAWN_CHANCE) {
			GameObject meteor = Instantiate(Resources.Load("TEST_Meteor")) as GameObject;
			MeteorController meteorController = meteor.GetComponent<MeteorController>();

			Vector3 pos = MeteorController.DEFAULT_POS;
			pos.x = Random.Range(METEOR_POS_X_MIN, METEOR_POS_X_MAX);

			float scale_ = Random.Range(METEOR_SCALE_MIN, METEOR_SCALE_MAX);
			Vector3 scale = new Vector3(scale_, scale_, scale_);

			Vector2 linVel = new Vector2(
				Random.Range(-METEOR_LIN_VEL_MAX/2, +METEOR_LIN_VEL_MAX/2),
				Random.Range(-METEOR_LIN_VEL_MIN, -METEOR_LIN_VEL_MAX)
				);

			float angVel = Random.Range(-METEOR_ANG_VEL_MAX, +METEOR_ANG_VEL_MAX);

			meteorController.pos    = pos;
			meteorController.scale  = scale;
			meteorController.linVel = linVel;
			meteorController.angVel = angVel;
		}
	}

}
