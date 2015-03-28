using UnityEngine;
using System.Collections;

public class ScoreManager {

	public static ScoreManager instance;
	private static float Score;

	private ScoreManager() {
		Score = 0.0f;
	}

	public static ScoreManager Instance() {
		if (instance==null) {instance = new ScoreManager();}
		return instance;
	}

	public float add(float num) {
		Score +=num;
		return Score;
	}
	public float subtract(float num) {
		Score -=num;
		return Score;
	}
	public float get() {
		return Score;
	}
}
