using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
		public GameObject enemyController;
		private float width, height;
		public int scoreValue;
		public float pauseTime;
		public bool canFire;
		public int fireProb; //int from 0-100 representing probability of firing when able
		public GameObject enemy_shot;
		public float shotOffset;


		void Start ()
		{
				scoreValue = 10;
				//canFire = false;
		}

		// Update is called once per frame
		void Update ()
		{
				if (canFire) {
						fire ();
				}
		}

		void fire ()
		{
				GetComponent<SpriteRenderer> ().color = Color.red;

				int x = Random.Range (0, 100);
				//Debug.Log("rand: " + x);
				if (x > (100 - fireProb)) {
						Instantiate (enemy_shot, (transform.position + (Vector3.down * shotOffset)), Quaternion.identity);
						//Debug.Break();
				}
		}

		void OnTriggerEnter (Collider other)
		{
				GameObject g = other.gameObject;
				if (g.name == "shot(Clone)") {
						GetComponent<Animator> ().SetBool ("isShot", true);
						Camera.main.GetComponent<camera> ().addToScore (scoreValue);
						StartCoroutine ("pauseToDestroy");
				}

		}

		IEnumerator pauseToDestroy ()
		{
				yield return new WaitForSeconds (pauseTime);
				Destroy (gameObject);
		}
}
