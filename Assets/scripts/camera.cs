using UnityEngine;
using System.Collections;

public class camera : MonoBehaviour
{
		public int livesLabelPaddingTop;
		public int livesLabelPaddingLeft;
		public Font livesLabelFont;

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
			
		}
}
