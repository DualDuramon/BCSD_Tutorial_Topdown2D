using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //골드메탈 유니티 강좌 B28
    public TalkManager talkManager;
    public QuestManager questManager;
    public Animator talkPanel;
    public Animator PortraitAnim;
    public Sprite prevPortrait;
    public Image portraitImg;

    public TypeEffect talk;
    public Text questText;
    public GameObject menuSet;
    public GameObject scanObject;
    public bool isAction;
    public int talkIndex;

    //gameSave and Load
    public GameObject player;

    void Start() {
        GameLoad();
        questText.text = questManager.CheckQuest();
    }

    void Update() {

        //subMenu
        if (Input.GetButtonDown("Cancel")) {
            SubMenuActive();
        }
    }

    public void SubMenuActive() {
        if (menuSet.activeSelf) menuSet.SetActive(false);
        else menuSet.SetActive(true);
    }

    public void Action(GameObject scanObj) {
        
        ObjData objData = scanObj.GetComponent<ObjData>();
        Talk(objData.id, objData.isNpc);

        talkPanel.SetBool("isShow", isAction);
    }

    void Talk(int id, bool isNpc) {
        int questTalkIndex = 0;
        string talkData = "";

        if (talk.isAnimation) {
            talk.SetMsg("");
            return;
        }
        else {
            questTalkIndex = questManager.GetQuestTalkIndex(id);
            talkData = talkManager.GetTalk(id + questTalkIndex, talkIndex);
        }

        //end Talk
        if (talkData == null) { //대화가 모두 끝났을때 일시정지 해제
            isAction = false;
            talkIndex = 0;
            questText.text = questManager.CheckQuest(id);
            return;
        }

        //continue talk
        if (isNpc) {
            talk.SetMsg(talkData.Split(':')[0]);

            //show Portrait
            portraitImg.sprite = talkManager.GetPortrait(id, int.Parse(talkData.Split(':')[1]));
            portraitImg.color = new Color(1, 1, 1, 1);
            
            //Animation Portrait
            if(prevPortrait != portraitImg.sprite) {
                PortraitAnim.SetTrigger("doEffect");
                prevPortrait = portraitImg.sprite;
            }
        }
        else {
            talk.SetMsg(talkData);
            portraitImg.color = new Color(1, 1, 1, 0);
        }

        isAction = true;
        talkIndex++;
    }

    public void GameSave() {
        //GameSave, PlayerPrefs : 게임 저장 기능을 지원하는 클래스
        PlayerPrefs.SetFloat("PlayerX", player.transform.position.x);
        PlayerPrefs.SetFloat("PlayerY", player.transform.position.y);
        PlayerPrefs.SetInt("QuestId", questManager.questId);
        PlayerPrefs.SetInt("QuestActionIndex", questManager.questActionIndex);
        PlayerPrefs.Save();

        menuSet.SetActive(false);
    }

    public void GameLoad() {
        if (!PlayerPrefs.HasKey("PlayerX")) return;

        //GameLoad. Playerprefs.Get~~~(): 해당타입 데이터 불러오기
        float x = PlayerPrefs.GetFloat("PlayerX");
        float y = PlayerPrefs.GetFloat("PlayerY");
        int questId = PlayerPrefs.GetInt("QuestId");
        int questActionIndex = PlayerPrefs.GetInt("QuestActionIndex");

        player.transform.position = new Vector3(x, y, 0);
        questManager.questId = questId;
        questManager.questActionIndex = questActionIndex;
        questManager.ControlObject();
    }

    public void GameExit() {
        Application.Quit();
    }
}
