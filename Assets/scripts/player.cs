using UnityEngine;
using System.Collections;

public class player : MonoBehaviour
{
    public float speed;
    public GameObject gunTip;

    private float playerSize;
    private bool canMove;
    private bool canDie;
    private GunTip gunTipScript;

    // Use this for initialization
    void Start()
    {
        //actually half the size
        playerSize = renderer.bounds.extents.x;
        canMove = true;
        canDie = true;
        gunTipScript = gunTip.GetComponent<GunTip>();

    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
            move();

    }

    void move()
    {
        float translation = Input.GetAxis("Horizontal");

        transform.Translate(new Vector3(translation * speed, 0.0f, 0.0f));
        //Debug.Log ("transPos: " + transform.position);
        Vector3 maxX = transform.position + new Vector3(playerSize, 0, 0);
        Vector3 minX = transform.position - new Vector3(playerSize, 0, 0);
        //Debug.Log ("adjPos:" + adjPos);
        Vector3 viewPosMax = Camera.main.WorldToViewportPoint(maxX);
        Vector3 viewPosMin = Camera.main.WorldToViewportPoint(minX);
        //Debug.Log ("viewPos: " + viewPos);
        viewPosMax.x = Mathf.Clamp01(viewPosMax.x);
        viewPosMin.x = Mathf.Clamp01(viewPosMin.x);
        //Debug.Log ("new pos: " + Camera.main.ViewportToWorldPoint (viewPos));
        if (viewPosMax.x == 1.0f)
        {
            float adjustMax = Camera.main.ViewportToWorldPoint(viewPosMax).x - playerSize;
            transform.position = new Vector3(adjustMax, transform.position.y, transform.position.z);
        }
        else if (viewPosMin.x == 0.0f)
        {
            float adjustMin = Camera.main.ViewportToWorldPoint(viewPosMin).x + playerSize;

            transform.position = new Vector3(adjustMin, transform.position.y, transform.position.z);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("player shot");
        if (canDie)
            die();
    }

    private void die()
    {
        canMove = false;
        canDie = false;
        gunTipScript.canFire = false;
        transform.localScale = new Vector3(2.0f, 2.0f, 1.0f);
        GetComponent<Animator>().SetTrigger("playerDie");
        audio.Play();
        camera cameraScript = Camera.main.GetComponent<camera>();
        --cameraScript.playerLives;
        if (cameraScript.playerLives == 0)
        {   //gameover
            Debug.Log("game over");
            StartCoroutine("gameOver");
        }
        else
        {
            Debug.Log(cameraScript.playerLives + " lives left");
            StartCoroutine("levelRestart");
        }
    }

    IEnumerator gameOver()
    {
        yield return new WaitForSeconds(2.0f);
        Camera.main.GetComponent<camera>().saveScore();
        //load GameOver scene
        Application.LoadLevel(1);
    }

    IEnumerator levelRestart()
    {
        //Debug.Log("wait for 3");
        yield return new WaitForSeconds(2.0f);
        //Debug.Log("restart level");
        GetComponent<Animator>().SetTrigger("resetAnimation");
        transform.localScale = new Vector3(6.0f, 6.0f, 1.0f);
        canMove = true;
        renderer.enabled = true;
        float blinkTime = 2.0f;
        float timer = Time.time + blinkTime;
        while (Time.time < timer)
        {
            yield return new WaitForSeconds(.25f);
            renderer.enabled = !renderer.enabled;
        }
        renderer.enabled = true;
        canDie = true;
        gunTipScript.canFire = true;
    }
}
