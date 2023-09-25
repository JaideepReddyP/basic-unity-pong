using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

	public static int PlayerScore1 = 0;
	public static int PlayerScore2 = 0;
	public static bool IsComputer = false;

	public GUISkin layout;

	GameObject theBall, rightPaddle;

	// Use this for initialization
	void Start()
	{
		theBall = GameObject.FindGameObjectWithTag("Ball");
		rightPaddle = GameObject.FindGameObjectWithTag("RightPaddle");
	}

	public static void Score(string wallID)
	{
		Debug.Log("score");
		if (wallID == "RightWall")
		{
			PlayerScore1++;
		}
		else
		{
			PlayerScore2++;
		}
	}

	void OnGUI()
	{
		GUI.skin = layout;
		GUI.Label(new Rect(Screen.width / 2 - 150 - 12, 20, 100, 100), "" + PlayerScore1);
		GUI.Label(new Rect(Screen.width / 2 + 150 + 12, 20, 100, 100), "" + PlayerScore2);

		if (GUI.Button(new Rect(Screen.width / 2 - 120, 35, 120, 53), "RESTART"))
		{
			PlayerScore1 = 0;
			PlayerScore2 = 0;
			theBall.SendMessage("RestartGame", 0.5f, SendMessageOptions.RequireReceiver);
		}
		if (GUI.Button(new Rect(Screen.width / 2 + 30, 35, 120, 53), "COMPUTER"))
		{
			IsComputer = !IsComputer;
			rightPaddle.SendMessage("IsComputer", IsComputer, SendMessageOptions.RequireReceiver);
		}

		if (PlayerScore1 == 10)
		{
			GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "PLAYER ONE WINS");
			theBall.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
		}
		else if (PlayerScore2 == 10)
		{
			GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "PLAYER TWO WINS");
			theBall.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
		}
	}

}