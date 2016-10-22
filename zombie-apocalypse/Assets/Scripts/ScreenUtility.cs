using System;
using UnityEngine;

public static class ScreenUtility
{
	public static bool IsLeftOfScreen( Vector3 postiton)
	{
		return Camera.main.ScreenToWorldPoint( new Vector3(0,0,0)).x > postiton.x; 
	}

	public static float GetScreenSize()
	{
		return Camera.main.orthographicSize * 2.0f * Screen.width / Screen.height;
	}
}

