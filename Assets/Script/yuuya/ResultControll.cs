using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ResultControll : MonoBehaviour {

    public int NomalScore = 0;
    public Text NomalScoreText;
    public Text SumScoreText;
    public InputField inp;
    public WindowControll wi;

    private int SumScore;
    private int RankingNum = 4;

    private int[] Ranking = new int[3]{0,0,0};
    private string[] Name = new string[3]{"","",""};

	// Use this for initialization
	void Start () {
        

        this.NomalScore = PlayerPrefs.GetInt("POINT", 0);
        NomalScoreText.text = this.NomalScore.ToString();
        SumScore = NomalScore * 100;
        this.SumScoreText.text = SumScore.ToString();

        for(int i = 0; i < 3; i++){
            Ranking[i] = PlayerPrefs.GetInt("RANKING" + i);
            Name[i] = PlayerPrefs.GetString("NAME" + i);
        }

        for(int i = 2; i >= 0; i--){
            Debug.Log(Ranking[i]);
            if (Ranking[i] < SumScore)
            {
                RankingNum = i;
            }
        }

        int pt00 = PlayerPrefs.GetInt("POINT" + 0);
        int pt01 = PlayerPrefs.GetInt("POINT" + 1);
        int pt02 = PlayerPrefs.GetInt("POINT" + 2);

        string name00 = PlayerPrefs.GetString("NAME" + 0);
        string name01 = PlayerPrefs.GetString("NAME" + 1);
        string name02 = PlayerPrefs.GetString("NAME" + 2);

        if (RankingNum == 0)
        {
            PlayerPrefs.SetInt("POINT" + 1, pt00);
            PlayerPrefs.SetInt("POINT" + 2, pt01);
            PlayerPrefs.SetString("POINT" + 1, name00);
            PlayerPrefs.SetString("POINT" + 2, name01);
        }
        if (RankingNum == 1)
        {
            PlayerPrefs.SetInt("POINT" + 2, pt01);
            PlayerPrefs.SetString("POINT" + 2, name01);
        }


        if (RankingNum < 3)
        {
            PlayerPrefs.SetInt("RANKING" + RankingNum,SumScore);
            // ここでインプットフィールドを表示する
            wi.Help_Open();
        }

        //PlayerPrefs.DeleteAll();
    }

    // Update is called once per frame
    void Update () {
	
	}

    public void Name_Register(){
        if (inp.text == "")
        {
            return;
        }

        PlayerPrefs.SetString("NAME" + RankingNum , inp.text);
        wi.Help_Close();
    }
}
