using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypeEffect : MonoBehaviour
{
    public int CharPerSec;
    public GameObject EndCursor;
    public bool isAnimation;

    string targetMsg;
    int idx;
    float interval;
    Text msgText;
    AudioSource audioSource;

    private void Awake() {
        msgText = GetComponent<Text>();
        audioSource = GetComponent<AudioSource>();
    }


    public void SetMsg(string msg) {
        if (isAnimation) { //Inturrpt
            msgText.text = targetMsg;
            CancelInvoke();
            EffectEnd();
        }
        else {
            targetMsg = msg;
            EffectStart();
        }
    }

    public void EffectStart() {
        msgText.text = "";
        EndCursor.SetActive(false);
        idx = 0;

        interval = 1.0f / CharPerSec;
        Debug.Log(interval);

        isAnimation = true;
        Invoke("Effecting", interval);
    }

    public void Effecting() {
        if (msgText.text == targetMsg) {
            EffectEnd();
            return;
        }

        msgText.text += targetMsg[idx];
        if (targetMsg[idx] != ' ' || targetMsg[idx] != '.') audioSource.Play(); //play Efect Sound
        idx++;

        //call next function recursively
        Invoke("Effecting", interval);
    }

    public void EffectEnd() {
        isAnimation = false;
        EndCursor.SetActive(true);
    }
}
