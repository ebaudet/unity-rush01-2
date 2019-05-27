using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouttonMenu : MonoBehaviour {
	public string destination;

	public void ButtonDirection()
	{
			Application.LoadLevel(destination);
			Time.timeScale = 1;
	}

	public void	Exit()
	{
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
         Application.Quit();
        #endif
	}

}
