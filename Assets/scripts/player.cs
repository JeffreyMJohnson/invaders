using UnityEngine;
using System.Collections;

public class player : MonoBehaviour
{
		public float speed;
		public Camera camera;

		private float playerSize;
		private Vector3 screenWidthWorldPos;

		// Use this for initialization
		void Start ()
		{
				//actually half the size
				playerSize = renderer.bounds.extents.x;
				Debug.Log ("playerSize: " + playerSize);
				
	
		}
	
		// Update is called once per frame
		void Update ()
		{
				float translation = Input.GetAxis ("Horizontal");

				transform.Translate (new Vector3 (translation * speed, 0.0f, 0.0f));
				//Debug.Log ("transPos: " + transform.position);
				Vector3 maxX = transform.position + new Vector3 (playerSize, 0, 0);
				Vector3 minX = transform.position - new Vector3 (playerSize, 0, 0);
				//Debug.Log ("adjPos:" + adjPos);
				Vector3 viewPosMax = Camera.main.WorldToViewportPoint (maxX);
				Vector3 viewPosMin = Camera.main.WorldToViewportPoint (minX);
				//Debug.Log ("viewPos: " + viewPos);
				viewPosMax.x = Mathf.Clamp01 (viewPosMax.x);
				viewPosMin.x = Mathf.Clamp01 (viewPosMin.x);
				//Debug.Log ("new pos: " + Camera.main.ViewportToWorldPoint (viewPos));
				if (viewPosMax.x == 1.0f) {
						float adjustMax = Camera.main.ViewportToWorldPoint (viewPosMax).x - playerSize;
						transform.position = new Vector3 (adjustMax, transform.position.y, transform.position.z);
				} else if (viewPosMin.x == 0.0f) {
						float adjustMin = Camera.main.ViewportToWorldPoint (viewPosMin).x + playerSize;
				
						transform.position = new Vector3 (adjustMin, transform.position.y, transform.position.z);
				}
		}
}
