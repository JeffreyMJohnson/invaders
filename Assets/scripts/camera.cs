using UnityEngine;
using System.Collections;

public class camera : MonoBehaviour
{
		public int livesLabelPaddingTop;
		public int livesLabelPaddingLeft;
		public Font livesLabelFont;

		public Transform rightWall;
		public Transform leftWall;

		void OnGUI ()
		{
				GUI.contentColor = Color.green;
				GUIStyle style = new GUIStyle ();
				style.padding.top = livesLabelPaddingTop;
				style.padding.left = livesLabelPaddingLeft;
				style.font = livesLabelFont;
				style.normal.textColor = Color.green;
				GUI.Label (new Rect (0, 0, 50, 50), "Lives:", style);
		}

		void Start ()
		{
				BoxCollider2D collider = GetComponent<BoxCollider2D> ();
				Vector2 size = collider.size;
				//Debug.Log ("collider size: " + size);
				
				//Debug.Log ("cam width: " + camera.pixelWidth);
		}
}
