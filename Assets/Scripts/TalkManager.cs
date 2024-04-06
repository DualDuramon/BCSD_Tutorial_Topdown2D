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
