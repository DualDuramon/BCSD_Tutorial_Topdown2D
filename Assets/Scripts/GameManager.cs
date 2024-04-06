using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //����Ż ����Ƽ ���� B22
    public GameObject talkPanel;
    public Text talkText;
    public GameObject scanObject;
    public bool isAction;

    public void Action(GameObject scanObj) {
        
        if (isAction) {
            isAction = false;
        }
        else {
            isAction = true;
            scanObject = scanObj;
            talkText.text = $"{scanObject.name} ��.";
        }
        talkPanel.SetActive(isAction);
    }
}
