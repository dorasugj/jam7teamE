using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public Text answerLabel;
    public Image stateLabel;
    public Sprite[] stateSprite;
    public Sprite[] misoSprite;

    Timer timer;

    GameObject misos;
    SpriteRenderer[] miso = new SpriteRenderer[8];
    bool[] isMisoAnswer = new bool[4];

    GameState state;

    int misoAnswer;
    int playerAnswer;

    int answerNum = 0;
	int specialNum = 4;

    int problemNum = 0;

	void Awake ()
    {
        timer = transform.GetComponent<Timer>();
        misos = GameObject.Find("Misos");
        for(int i = 0; i < 8; i++)
        {
            string childName = "sara" + (i + 1).ToString();
            GameObject misoParent = misos.transform.FindChild(childName).gameObject;
            miso[i] = misoParent.transform.FindChild("miso").gameObject.GetComponent<SpriteRenderer>();
        }
        state = GameState.Start;

        StartCoroutine("GameStart");
    }
	
	void Update ()
    {
        if (timer.isFinish) state = GameState.Finish;

        switch(state)
        {
            case GameState.Preparation:
                CreateMiso();
                break;
            case GameState.Move:
                MisoMove();
                break;
            case GameState.Play:
                PlayGame();
                break;
            case GameState.Check:
                CheckAnswer();
                break;
            case GameState.Finish:
                GameFinish();
                break;
            default:
                break;
        }
	}
//Start---------------------------------------------------------------------------------------------------
    IEnumerator GameStart()
    {
        AudioManager.Instance.PlaySE("Yo-i");
        stateLabel.sprite = stateSprite[0];
        float i = 1;

        while(i >= 0)
        {
            stateLabel.color = new Color(1, 1, 1, i);
            yield return new WaitForSeconds(0.1f);
            i -= 0.1f;
        }
        stateLabel.sprite = stateSprite[1];

        AudioManager.Instance.PlaySE("Start");
        while (i <= 1)
        {
            stateLabel.color = new Color(1, 1, 1, i);
            yield return new WaitForSeconds(0.1f);
            i += 0.1f;
        }

        while(i >= 0)
        {
            stateLabel.color = new Color(1, 1, 1, i);
            yield return new WaitForSeconds(0.1f);
            i -= 0.1f;
        }
        stateLabel.color = new Color(1, 1, 1, 1);
        stateLabel.gameObject.SetActive(false);

        timer.isStop = false;
        state = GameState.Preparation;
    }
//Preparation---------------------------------------------------------------------------------------------
    void CreateMiso()
    {
		misoAnswer = Random.Range(0, 4);

        for (int i = 0; i < 4; i++) isMisoAnswer[i] = false;

        isMisoAnswer[misoAnswer] = true;

        for (int i = 0; i < 4; i++)
        {
            if(i == misoAnswer) //正解のみそ
            {
				miso[i + 4].sprite = misoSprite[0];
            }
            else //不正解のみそ
            {
                if (problemNum<2) {
                    miso[i + 4].sprite = misoSprite[1];
                }
                else if (problemNum < 4)
                {
                    var kind = Random.Range(0, 2);
                    miso[i + 4].sprite = misoSprite[kind+1];
                }
                else if (problemNum < 6)
                {
                    var kind = Random.Range(0, 2);
					if (kind == 0)
					{
						miso[i + 4].sprite = misoSprite[6];
					}
					else
					{
						miso[i + 4].sprite = misoSprite[4];
					}
				}
                else
                {
                    var kind = Random.Range(0, 2);
					if (kind==0)
					{
						miso[i + 4].sprite = misoSprite[6];
					}
					else
					{
						miso[i + 4].sprite = misoSprite[9];
					}
                }
            }
        }

        problemNum++;
        AudioManager.Instance.PlaySE("Sara_Husuma");
        state = GameState.Move;
    }
    //Move----------------------------------------------------------------------------------------------------
    void MisoMove()
    {
        misos.transform.position += Vector3.right * 100.0f * Time.deltaTime;
        if (misos.transform.position.x > 17.0f) {
            //画像入れ替え
            for(int i = 0; i < 4; i++)
            {
                miso[i].sprite = miso[i + 4].sprite;
            }
            misos.transform.position = new Vector3(0.0f, 0.0f, 0.0f);

            state = GameState.Play;
        }
    }
        
    //Play----------------------------------------------------------------------------------------------------
    void PlayGame()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            playerAnswer = 0;
            state = GameState.Check;
        }
        else if(Input.GetKeyDown(KeyCode.G))
        {
            playerAnswer = 1;
            state = GameState.Check;
        }
        else if((Input.GetKeyDown(KeyCode.H)))
        {
            playerAnswer = 2;
            state = GameState.Check;
        }
        else if(Input.GetKeyDown(KeyCode.J))
        {
            playerAnswer = 3;
            state = GameState.Check;
        }
    }
//Check---------------------------------------------------------------------------------------------------
    void CheckAnswer()
    {
        AudioManager.Instance.PlaySE("Eat");

        if(misoAnswer == playerAnswer) //正解
        {
            Debug.Log("〇");
            answerNum++;
            state = GameState.Preparation;
        }
        else //不正解
        {
            Debug.Log("×");
            timer.isGameOver = true;
            state = GameState.Finish;
        }
    }
//Finish--------------------------------------------------------------------------------------------------
    void GameFinish()
    {
        answerLabel.text = "Finish:" + answerNum;
        PlayerPrefs.SetInt("POINT", answerNum);
        SceneManager.LoadScene("Scene_Result");
    }
//--------------------------------------------------------------------------------------------------------
    enum GameState
    {
        Start,
        Preparation,
        Move,
        Play,
        Check,
        Finish
    }
}
