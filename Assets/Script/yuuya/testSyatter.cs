using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class testSyatter : MonoBehaviour {

    public GameObject DoorLeft;
    public GameObject DoorRight;

    private bool flag = false;
    private Vector3 startposleft;
    private Vector3 startposright;

    public void Close(){
        startposleft = DoorLeft.transform.position;
        startposright = DoorRight.transform.position;
        StartCoroutine("Move");
    }

    IEnumerator Move(){
        float lerp = 0;
        while (lerp <= 1)
        {
            lerp += Time.deltaTime;
            DoorLeft.transform.position = Vector3.Lerp(startposleft, Vector3.zero, lerp);
            DoorRight.transform.position = Vector3.Lerp(startposright, Vector3.zero, lerp);
            yield return 0;
        }
        SceneManager.LoadScene("Scene_Result");
    }
}
