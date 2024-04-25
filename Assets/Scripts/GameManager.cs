using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //골드메탈 유니티 강좌 B27
    public TalkManager talkManager;
    public QuestManager questManager;
    public GameObject talkPanel;
    public Image portraitImg;

    public Text talkText;
    public GameObject scanObject;
    public bool isAction;
    public int talkIndex;

    void Start() {
        Debug.Log(questManager.CheckQuest());
    }
    public void Action(GameObject scanObj) {
        
        ObjData objData = scanObj.GetComponent<ObjData>();
        //talkText.text = $"{scanObject.name} 다.";
        Talk(objData.id, objData.isNpc);

        talkPanel.SetActive(isAction);
    }

    void Talk(int id, bool isNpc) {
        int questTalkIndex = questManager.GetQuestTalkIndex(id);
        string talkData = talkManager.GetTalk(id + questTalkIndex, talkIndex);

        //end Talk
        if (talkData == null) { //대화가 모두 끝났을때 일시정지 해제
            isAction = false;
            talkIndex = 0;
            Debug.Log(questManager.CheckQuest(id));
            return;
        }

        //continue talk
        if (isNpc) {
            talkText.text = talkData.Split(':')[0];

            //show Portrait
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
