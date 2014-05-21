using UnityEngine;
using System.Collections;

public class player : MonoBehaviour
{
		public float speed;

		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
				float translationX = Input.GetAxis ("Horizontal") * speed;
				translationX *= Time.deltaTime;
				Debug.Log ("screen width: " + Screen.width);
				transform.Translate (new Vector3 (translationX, 0, 0));
		}
}
