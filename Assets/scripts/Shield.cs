using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour {
    public int damageLevel = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("shield trigger fired");
        //Animator a = other.GetComponent<Animator>();
        //int damage = a.GetInteger("damage");
        if (damageLevel < 4)
        {
            //Debug.Log("damage: " + damageLevel);
            GetComponent<Animator>().SetInteger("damage", ++damageLevel);
            //Debug.Log("new damage: " + GetComponent<Animator>().GetInteger("damage"));
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
