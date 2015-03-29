using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreView : MonoBehaviour {
	void Update () {
        this.GetComponent<Text>().text = "Score: " + ScoreManager.Score;
	}
}
