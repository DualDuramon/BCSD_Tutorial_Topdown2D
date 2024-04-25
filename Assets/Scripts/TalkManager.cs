using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    //골드메탈 유니티 강좌 B22 ~B23
    Dictionary<int, string[]> talkData;
    Dictionary<int, Sprite> portraitData;
    public Sprite[] portraitArr;

    void Awake() {
        talkData = new Dictionary<int, string[]>();
        portraitData = new Dictionary<int, Sprite>();
        GenerateData();
    }

    void GenerateData() {
        //npcs
        talkData.Add(1000, new string[] { "안녕?:0", "이 곳에 처음 왔구나?:1" });  //luna
        talkData.Add(2000, new string[] { "반가워.:1", "혹시 그림 잘그리니?:2" }); //ludo
        //objects
        talkData.Add(100, new string[] { "평범한 나무상자다." });   //box
        talkData.Add(200, new string[] { "누군가 사용한 흔적이 있는 책상이다." }); //desk
      

        //Quest Talk (quest Id + questActionIndex + npcId)
        talkData.Add(10 + 1000, new string[] { 
            "어서와.:0",
            "이 마을에 놀라운 전설이 있대:1",
            "루도한테 가서 한번 확인해봐봐.:0"
        });
        
        talkData.Add(10+ 1 + 2000, new string[] { 
            "안녕:1", 
            "이 마을의 전설이 궁금한거야?:0", 
            "그럼 내 심부름좀 해줘:1", 
            "내 집 근처에 떨어진 동전 좀 주워줘:0"
        });

        talkData.Add(20 + 1000, new string[] {
            "루도의 동전?:1",
            "너한테 잡일을 시킨거야?:3",
            "나중에 걔한테 한 마디 좀 해야겠어!:3"
        });
        talkData.Add(20 + 2000, new string[] {
            "찾으면 꼭 좀 가져다줘..:1"
        });
        talkData.Add(20 + 500, new string[] {
            "근처에서 동전을 찾았다."
        }) ;
        talkData.Add(20 + 1 + 2000, new string[] {
            "앗, 찾아줘서 정말 고마워!:2"
        });


        //portrait_npc
        portraitData.Add(1000 + 0, portraitArr[0]); //luna portraits
        portraitData.Add(1000 + 1, portraitArr[1]);
        portraitData.Add(1000 + 2, portraitArr[2]);
        portraitData.Add(1000 + 3, portraitArr[3]);

        portraitData.Add(2000 + 0, portraitArr[4]); //ludo portraits
        portraitData.Add(2000 + 1, portraitArr[5]);
        portraitData.Add(2000 + 2, portraitArr[6]);
        portraitData.Add(2000 + 3, portraitArr[7]);
    }

    public string GetTalk(int id, int talkIndex) {
       
        if (!talkData.ContainsKey(id)) {
            if (!talkData.ContainsKey(id - id % 10)) { 
                return GetTalk(id - id % 100, talkIndex);
            }
            else {
                return GetTalk(id - id % 10, talkIndex);
            }
        }

        if (talkIndex == talkData[id].Length) {
            return null;
        }
        else
            return talkData[id][talkIndex];
    }

    public Sprite GetPortrait(int id, int portraitIdx) {

        return portraitData[id + portraitIdx];
    }

}
