using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{    
    //골드메탈 유니티 강좌 B27
    public int questId;
    public int questActionIndex;    //퀘스트 대화 순서
    public GameObject[] questObject;
    Dictionary<int, QuestData> questList;


    void Awake() {
        questList = new Dictionary<int, QuestData>();
        GenerateData();
    }

    void GenerateData() {
        questList.Add(10, new QuestData("마을 사람들과 대화하기", new int[] { 1000, 2000 }));
        questList.Add(20, new QuestData("루도의 동전 찾아주기", new int[] { 500, 2000 }));
        questList.Add(30, new QuestData("퀘스트 올 클리어", new int[] {0}));
    }

    public int GetQuestTalkIndex(int id) {
        return questId + questActionIndex;
    }

    public string CheckQuest(int id) {
        //Next Talk Target
        if (id == questList[questId].npcId[questActionIndex]) 
            questActionIndex++;

        //Control Quest Object
        ControlObject();

        //Talk Complete & next Quest
        if (questActionIndex == questList[questId].npcId.Length)
            NextQuest();

        return questList[questId].questName;
    }

    public string CheckQuest() {
     
        return questList[questId].questName;
    }

    public void NextQuest() {
        questId += 10;
        questActionIndex = 0;
    }

    public void ControlObject() {
        switch (questId) {
            case 10:
                if (questActionIndex == 2) {
                    questObject[0].SetActive(true);
                }
                break;
            case 20:
                if (questActionIndex == 0)
                    questObject[0].SetActive(true);
                else if (questActionIndex == 1)
                    questObject[0].SetActive(false);
                break;
        }
    }
}
