﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

///Developed by Indie Studio
///https://assetstore.unity.com/publishers/9268
///www.indiestd.com
///info@indiestd.com

namespace IndieStudio.DrawingAndColoring.Logic
{
	[DisallowMultipleComponent]
	public class Logo : MonoBehaviour
	{
		/// <summary>
		/// The sleep time.
		/// </summary>
		public float sleepTime = 5;

		/// <summary>
		/// The name of the scene to load.
		/// </summary>
		public string nextSceneName;

		// Use this for initialization
		void Start ()
		{
			Invoke ("LoadScene", sleepTime);
		}

		private void LoadScene ()
		{
			if (string.IsNullOrEmpty (nextSceneName)) {
				return;
			}
			SceneManager.LoadScene (nextSceneName);
		}
	}
}
