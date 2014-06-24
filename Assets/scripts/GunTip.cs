using UnityEngine;
using System.Collections;

public class GunTip : MonoBehaviour
{
		public float fireRate = .25f;
		public GameObject shotPrefab;
        public bool canFire;

		private float nextFire = 0.0f;
		
		// Use this for initialization
		void Start ()
		{
            canFire = true;
		}
	
		// Update is called once per frame
		void Update ()
		{
            GameObject shot = GameObject.FindWithTag("shot");
            if (canFire && shot == null)
            {
                fire();
            }
		}

		void fire ()
		{
				//Debug.Log (Input.GetButtonDown ("Fire1"));
		
				if (Input.GetButtonDown ("Fire1") && Time.time > nextFire) {
						nextFire = Time.time + fireRate;
						Instantiate (shotPrefab, transform.position, Quaternion.identity);
                        audio.Play();
				}
		
		}
}
