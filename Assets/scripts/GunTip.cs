using UnityEngine;
using System.Collections;

public class GunTip : MonoBehaviour
{
		public float speed;
		public GameObject shotPrefab;

		private bool isShotAlive;
		private GameObject shot;
		private float maxYView;
		// Use this for initialization
		void Start ()
		{
				Debug.Log ("gunTip started");
				isShotAlive = false;
				maxYView = Camera.main.ViewportToWorldPoint (new Vector3 (0.0f, 1.0f, 0.0f)).y;
				Debug.Log ("maxYView:" + maxYView);
		}
	
		// Update is called once per frame
		void Update ()
		{
				//transform.rigidbody2D.AddForce (Vector3.up * speed);
				fire ();
				if (isShotAlive) {
						shot.transform.Translate (Vector3.up * speed * Time.deltaTime);
				}

				if (isShotAlive && shot.transform.position.y > maxYView) {
						Destroy (shot);
						isShotAlive = false;
				}
		}

		void fire ()
		{
				//Debug.Log (Input.GetButtonDown ("Fire1"));
		
				if (Input.GetButton ("Fire1")) {
						Debug.Log ("fire");
						Debug.Log (transform.position);
						shot = Instantiate (shotPrefab, transform.position, Quaternion.Euler (new Vector3 (0, 0, 0)))as GameObject;
						Debug.Break ();
						isShotAlive = true;
						//
				}
		
		}
}
