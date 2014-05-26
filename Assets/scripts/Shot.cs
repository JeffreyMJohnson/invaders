using UnityEngine;
using System.Collections;

public class Shot : MonoBehaviour
{
		public float speed;
		private float maxYView;

		// Use this for initialization
		void Start ()
		{
				Debug.Log ("shot started");
				maxYView = Camera.main.ViewportToWorldPoint (new Vector3 (0.0f, 1.0f, 0.0f)).y;
		}
	
		// Update is called once per frame
		void FixedUpdate ()
		{
				move ();
				checkLocation ();
		}

		void move ()
		{
				transform.Translate (Vector3.up * speed * Time.deltaTime);
				//transform.rigidbody2D.AddForce (new Vector2 (0, speed * Time.deltaTime));

		}

		void checkLocation ()
		{
				if (transform.position.y > maxYView) {
						Destroy (gameObject);
				}
		}

		void  OnCollisionEnter (Collision coll)
		{
				Debug.Log ("collision detected on shot");
		}
		void  OnTriggerEnter (Collider other)
		{
				Debug.Log ("trigger on shot");
				if (other.tag == "enemy") {
						Destroy (gameObject);
				}
				
		}
}