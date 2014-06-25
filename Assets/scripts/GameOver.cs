using UnityEngine;
using System.Collections;
using System.IO;

public class GameOver : MonoBehaviour
{

    // Use this for initialization
    public Font font;

    public float GOLabelX;
    public float GOLabelY;
    public int GOLabelFontSize;

    public float scoreLabelX;
    public float scoreLabelY;
    public int scoreLabelFontSize;

    private int score;

    void OnGUI()
    {
        GUILayout.BeginArea(new Rect((Screen.width / 3), (Screen.height / 4), 500, 500));
        GUILayout.BeginVertical();
        GUIStyle style = new GUIStyle();
        style.font = font;
        style.normal.textColor = Color.green;
        style.fontSize = GOLabelFontSize;
        GUILayout.Label("Game Over", style);

        style.fontSize = scoreLabelFontSize;
        string scoreLabelText = string.Format("Score: {0, 4:0000}", score);
        style.padding.top = 25;
        style.padding.left = 100;
        GUILayout.Label(scoreLabelText, style);

        GUILayout.Box("Play another game?", style);
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("No"))
        {
            Debug.Log("No clicked");
        }
        if (GUILayout.Button("Yes"))
        {
            Debug.Log("Yes clicked");
        }

        GUILayout.EndHorizontal();

        GUILayout.EndVertical();

        GUILayout.EndArea();

        /*
        GUI.BeginGroup(new Rect((Screen.width / 2) - 250, (Screen.height / 2) - 250, 500, 500));
        GUIStyle style = new GUIStyle();
        style.font = font;
        style.normal.textColor = Color.green;
        style.fontSize = GOLabelFontSize;
        GUI.Label(new Rect(GOLabelX, GOLabelY, 500, 50), "Game Over", style);

        style.fontSize = scoreLabelFontSize;
        string scoreLabelText = string.Format("Score: {0, 4:0000}", score);
        GUI.Label(new Rect(scoreLabelX, scoreLabelY, 50, 50), scoreLabelText, style);

        GUI.EndGroup();
        */


        /* GUI.contentColor = Color.green;
        
         style.font = font;
         style.normal.textColor = Color.green;
         style.fontSize = 50;
         float left = (Screen.width / 2) - labelWidth;
         float top = (Screen.height / 2) - labelHeight;
         GUI.Label(new Rect(left, top, labelWidth, labelHeight), "Game Over", style);     
         */

    }

    void Start()
    {
        //fileFoo();
        score = PlayerPrefs.GetInt("score");
    }

    private void fileFoo()
    {
        string path = Application.dataPath;
        FileInfo fi = new FileInfo(path + "/textFiles/foo.txt");
        if (fi.Exists)
        {
            Debug.Log("file exists");
            using (StreamReader sr = fi.OpenText())
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    Debug.Log("text line: " + s);
                }
            }
        }
        else
        {
            Debug.Log("file does not exist");

        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
