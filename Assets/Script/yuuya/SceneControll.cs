using UnityEngine;
using System.Collections;

public class SceneControll : MonoBehaviour {

    // ゲームスタートボタンを押した時
    public void btnStart(){
        AudioManager.Instance.PlaySE("Button2");
        FadeManager.Instance.LoadLevel("Scene_Game");
    }

    // ランキングボタンを押した時
    public void btnRanking(){
        AudioManager.Instance.PlaySE("Button2");
        FadeManager.Instance.LoadLevel("Scene_Ranking");
    }

    public void btnTitle(){
        AudioManager.Instance.PlaySE("Button2");
        FadeManager.Instance.LoadLevel("Scene_Title");
    }
}
