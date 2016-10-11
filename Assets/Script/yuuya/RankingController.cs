using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RankingController : MonoBehaviour {

    public Text[] ScoreText;
    public Text[] NameText;

    private int[] Score = new int[3]{0,0,0};
    private string[] Name = new string[3]{"", "", ""};

	// Use this for initialization
	void Start () {
        for (int i = 0; i < 3; i++)
        {
            Score[i] = PlayerPrefs.GetInt("RANKING" + i, 0);
            Name[i] = PlayerPrefs.GetString("NAME" + i, "");
        }

        for (int i = 0; i < 3; i++)
        {
            ScoreText[i].text = Score[i].ToString();
            NameText[i].text = Name[i];
        }

    }
}
