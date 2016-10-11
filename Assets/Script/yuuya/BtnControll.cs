using UnityEngine;
using System.Collections;

public class BtnControll : MonoBehaviour {

    public WindowControll wi;

    // マウスオーバー処理
    public void Btn_MouseOver(GameObject obj){
        obj.transform.localScale *= 1.1f;
    }

    // マウスアウト処理
    public void Btn_MouseOut(GameObject obj){
        obj.transform.localScale = Vector3.one;
    }

    public void Btn_Help(){
        AudioManager.Instance.PlaySE("HelpOpen");
        wi.Help_Open();
    }

    public void Btn_HelpClose(){
        AudioManager.Instance.PlaySE("HelpClose");
        wi.Help_Close();
    }
}
