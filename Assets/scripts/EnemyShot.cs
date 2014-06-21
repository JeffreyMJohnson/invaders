using UnityEngine;
using System.Collections;

public class EnemyShot : MonoBehaviour
{
    public float speed;

    void Update()
    {
        /*float yViewPos = Camera.main.WorldToViewportPoint(transform.position).y;
        //Debug.Log("shotViewPos: " + yViewPos);
        if (yViewPos < 0.0f)
            Destroy(gameObject);
        else
        {*/
            float distance = speed * Time.deltaTime;
            transform.Translate(Vector3.down * distance);
       // }

    }

    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
