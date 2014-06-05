using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    private GameObject enemyController;
    private EnemyController script;
    private float width, height;
    public float pauseTime;

	void Start () {
        /*enemyController = GameObject.Find("enemyController");
        width = GetComponent<BoxCollider>().size.x;
        height = GetComponent<BoxCollider>().size.y;
        script = enemyController.GetComponent<EnemyController>();*/
	}
	
	// Update is called once per frame
	void Update () {
        /*if (transform.position.x + width / 2 >= script.enemyMaxX || transform.position.x + width / 2 <= script.enemyMinX)
        {
            script.moveEnemiesDown();
        }*/
	}

    void OnTriggerEnter(Collider other)
    {
        GameObject g = other.gameObject;
        if (g.name == "shot(Clone)")
        {
            Debug.Log("shot me!");
            GetComponent<Animator>().SetBool("isShot", true);
            StartCoroutine("pauseToDestroy");
        }

    }
    
    IEnumerator pauseToDestroy()
    {
        yield return new WaitForSeconds(pauseTime);
        Destroy(gameObject);
        
    }
}
