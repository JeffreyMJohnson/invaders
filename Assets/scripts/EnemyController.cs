using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyController : MonoBehaviour
{

    public Transform alien1;
    public float enemyStartPosX;
    public float enemyStartPosY;
    public float xPadding;
    public float yPadding;
    public float enemyMaxX;
    public float enemyMinX;
    public float movePauseTime;


    private int COLS = 12;
    private int ROWS = 5;
    private float enemyWidth;
    private float enemyHeight;
    private float moveDistance;
    private int direction;
    private float moveTimer;
    private bool moveDown;
    private int moveAnimation;


    // Use this for initialization
    void Start()
    {
        BoxCollider enemyCollider = alien1.GetComponent<BoxCollider>();
        enemyWidth = enemyCollider.size.x * alien1.localScale.x;
        enemyHeight = enemyCollider.size.y * alien1.localScale.y;
        
        moveDistance = enemyWidth + xPadding;
        direction = 1;
        createEnemies();
        moveTimer = 0.0f;
        moveDown = false;
        moveAnimation = -1;
    }

    // Update is called once per frame
    void Update()
    {
        if (!moveDown)
            move();
        else
            moveEnemiesDown();

    }
    
    private void move()
    {
        moveTimer += Time.deltaTime;
        
        //enemies = enemiesSort (enemies);
        if (moveTimer >= movePauseTime)
        {

            List<GameObject> enemies = new List<GameObject>(GameObject.FindGameObjectsWithTag("enemy"));
            foreach (GameObject enemy in enemies)
            {
                enemy.GetComponent<Animator>().SetInteger("moveAnimation", moveAnimation);
                enemy.transform.Translate(new Vector3(moveDistance * direction, 0.0f, 0.0f));
                //Debug.Log ("pos: " + enemy.transform.position.x);
                if (NearlyEqual(enemy.transform.position.x, enemyMaxX, 0.0001f) || enemy.transform.position.x > enemyMaxX)
                {
                    enemy.transform.position = new Vector3(enemyMaxX, enemy.transform.position.y, enemy.transform.position.z);
                    moveDown = true;
                }
                // else if (enemy.transform.position.x <= enemyMinX)
                else if (NearlyEqual(enemy.transform.position.x, enemyMinX, 0.0001f) || enemy.transform.position.x < enemyMinX)
                {
                    enemy.transform.position = new Vector3(enemyMinX, enemy.transform.position.y, enemy.transform.position.z);
                    moveDown = true;
                }

            }
            moveTimer = 0.0f;
            moveAnimation *= -1;

        }

    }

    private bool NearlyEqual(float a, float b, float epsilon)
    {
        float absA = Mathf.Abs(a);
        float absB = Mathf.Abs(b);
        float diff = Mathf.Abs(a - b);

        if (a == b)
        { // shortcut, handles infinities
            return true;
        }
        else if (a == 0 || b == 0 || diff < float.MinValue)
        {
            // a or b is zero or both are extremely close to it
            // relative error is less meaningful here
            return diff < (epsilon * float.MinValue);
        }
        else
        { // use relative error
            return diff / (absA + absB) < epsilon;
        }
    }

    public void moveEnemiesDown()
    {
        
            moveTimer += Time.deltaTime;
            //Debug.Log(moveTimer);
            if (moveTimer >= movePauseTime)
            {
                foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("enemy"))
                {
                    enemy.transform.Translate(new Vector3(0.0f, (enemyHeight + yPadding) * -1, 0.0f));
                    enemy.GetComponent<Animator>().SetInteger("moveAnimation", moveAnimation);
                }
                direction *= -1;
                moveTimer = 0.0f;
                moveDown = false;
                moveAnimation *= -1;
            }
    }
    private List<GameObject> enemiesSort(List<GameObject> enemies)
    {
        List<GameObject> result = new List<GameObject>(enemies);
        for (int i = 1; i < result.Count; i++)
        {
            GameObject enemy = result[i];
            float enemyValue = enemy.transform.position.y;

            int j = i;
            while (j > 0 && result[j - 1].transform.position.y > enemyValue)
            {
                result[j] = result[j - 1];
                j = j - 1;
            }
            result[j] = enemy;
        }
        return result;
    }

    private void printEnemiesList(List<GameObject> enemies)
    {
        foreach (GameObject enemy in enemies)
        {
            if (enemy != null)
            {
                Debug.Log("enemy[position: " + enemy.transform.position + "]");
            }
            else
            {
                Debug.Log("null");
            }
        }
    }

    void createEnemies()
    {
        float xPos;
        float yPos = enemyStartPosY;

        for (int row = 0; row < ROWS; row++)
        {
            xPos = enemyStartPosX;
            for (int col = 0; col < COLS; col++)
            {
                Instantiate(alien1, new Vector3(xPos, yPos, 0.0f), Quaternion.identity);
                xPos += enemyWidth + xPadding;

            }
            yPos -= enemyHeight + yPadding;
        }
    }

    Vector3 getWorldPosition(float xPosition, float yPosition)
    {
        Vector3 result = Camera.main.ScreenToWorldPoint(new Vector3(xPosition, yPosition, 0.0f));
        result.z = 0.0f;
        return result;
    }
}
