using UnityEngine;
using System.Collections;

public class WindowControll : MonoBehaviour {

    [SerializeField]
    private float Speed = 5.0f;

    private float lerp = 0;
    private bool MoveFlag = false;

    void Start(){
        transform.localScale = Vector3.zero;
    }

    public void Help_Open(){
        if (MoveFlag){
            return;
        }
        StartCoroutine(ScaleChange(true));
        MoveFlag = true;
    }

    public void Help_Close(){
        if (MoveFlag){
            return;
        }
        StartCoroutine(ScaleChange(false));
        MoveFlag = true;
    }
        
    IEnumerator ScaleChange(bool openFlag){
        lerp = 0;
        while (lerp <= 1){
            lerp += Time.deltaTime * Speed;
            float size =  Mathf.Clamp(lerp, 0, 1);
            if (openFlag)
            {
                transform.localScale = new Vector3(size, size, size);
            }
            else
            {
                transform.localScale = new Vector3(1-size, 1-size, 1-size);
            }
            yield return 0;
        }

        if (openFlag)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(0, 0, 0);
        }

        MoveFlag = false;
    }
}
