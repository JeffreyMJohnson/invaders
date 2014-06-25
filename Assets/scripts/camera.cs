using UnityEngine;
using System.Collections;

public class camera : MonoBehaviour
{
    public int livesLabelPaddingTop;
    public int livesLabelPaddingLeft;
    public Font livesLabelFont;
    public int lifeIconPaddingLeft;
    public Texture2D lifeTexture;

    public int scoreLabelPaddingLeft;
    public int scorePadding;
    private int score;
    public int playerLives;
    public string SCORE_TAG = "score";


    void OnGUI()
    {
        GUI.contentColor = Color.green;
        GUIStyle style = new GUIStyle();
        style.padding.top = livesLabelPaddingTop;
        style.padding.left = livesLabelPaddingLeft;
        style.font = livesLabelFont;
        style.normal.textColor = Color.green;
        GUI.Label(new Rect(0, 0, 50, 50), "Lives:", style);
        //style.padding.left = lifeIconPaddingLeft;
        //GUI.Label(new Rect(55, 0, 26, 16), lifeTexture, style);
        drawPlayerLives();

        float scoreLabelX = Camera.main.ViewportToScreenPoint(new Vector3(1.0f, 0.0f, 0.0f)).x / 2;
        //Debug.Log("scoreX?: " + scoreLabelX);
        style.padding.left = scoreLabelPaddingLeft;
        GUI.Label(new Rect(scoreLabelX, 0, 50, 50), "Score: ", style);
        style.padding.left = scorePadding;
        GUI.Label(new Rect(scoreLabelX + 50, 0, 50, 50), string.Format("{0, 4:0000}", score), style);
    }

    private void drawPlayerLives()
    {
        int left = 60;
        int width = 26;
        GUIStyle style = new GUIStyle();
        style.padding.top = livesLabelPaddingTop;
        style.padding.left = lifeIconPaddingLeft;
        for (int i = 0; i < playerLives; i++)
        {
            GUI.Label(new Rect(left, 0, width, 16), lifeTexture, style);
            left += width;
        }
    }

    void Start()
    {
        score = 0;
        playerLives = 3;
    }

    public int getScore()
    {
        return score;
    }

    public void addToScore(int amountToAdd)
    {
        //Debug.Log("addToScore");
        score += amountToAdd;
    }

    public void saveScore()
    {
        PlayerPrefs.SetInt(SCORE_TAG, score);
    }
}
