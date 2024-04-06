using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    //����Ż ����Ƽ ���� B22 ~B23
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
        talkData.Add(1000, new string[] { "�ȳ�?:0", "�� ���� ó�� �Ա���?:1" });  //luna
        talkData.Add(2000, new string[] { "�ݰ���.:1", "Ȥ�� �׸� �߱׸���?:2" }); //ludo
        //objects
        talkData.Add(100, new string[] { "����� �������ڴ�." });   //box
        talkData.Add(200, new string[] { "������ ����� ������ �ִ� å���̴�." }); //desk

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
