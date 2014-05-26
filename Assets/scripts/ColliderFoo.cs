using UnityEngine;
using System.Collections;

public class ColliderFoo : MonoBehaviour
{

		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		void  OnTriggerEnter (Collider other)
		{
				Debug.Log ("trigger detected on foo: " + other.name);
				Destroy (gameObject);
		}
		void OnCollisionEnter (Collision coll)
		{
				Debug.Log ("collision detected on ColliderFoo");
		}
}
