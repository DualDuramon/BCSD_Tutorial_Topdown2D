using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //골드메탈 유니티 강좌 B22 ~B23
    public TalkManager talkManager;
    public GameObject talkPanel;
    public Image portraitImg;

    public Text talkText;
    public GameObject scanObject;
    public bool isAction;
    public int talkIndex;

    public void Action(GameObject scanObj) {
        
        ObjData objData = scanObj.GetComponent<ObjData>();
        //talkText.text = $"{scanObject.name} 다.";
        Talk(objData.id, objData.isNpc);

        talkPanel.SetActive(isAction);
    }

    void Talk(int id, bool isNpc) {
        string talkData = talkManager.GetTalk(id, talkIndex);

        if (talkData == null) { //대화가 모두 끝났을때 일시정지 해제
            isAction = false;
            talkIndex = 0;
            return;
        }

        if (isNpc) {
            talkText.text = talkData.Split(':')[0];

            portraitImg.sprite = talkManager.GetPortrait(id, int.Parse(talkData.Split(':')[1]));
            portraitImg.color = new Color(1, 1, 1, 1);
        }
        else {
            talkText.text = talkData;
            portraitImg.color = new Color(0, 0, 0, 0);
        }

        isAction = true;
        talkIndex++;
    }
}
