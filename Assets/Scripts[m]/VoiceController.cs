using System;
using System.Collections;
using System.Collections.Generic;
using TextSpeech;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Android;

public class VoiceController : MonoBehaviour
{
    private const string LANG_CODE = "en-US";

    [SerializeField] Text uiText;
    [SerializeField] GameObject rin;
    private Animator animation;
    private void Start()
    {
        Setup(LANG_CODE);
        //_rin = this.gameObject;
        //Debug.Log("gameobject: "+ rin.name);
        animation = rin.GetComponent<Animator>();
        Debug.Log("voice controller ");
#if UNITY_ANDROID
        SpeechToText.instance.onPartialResultsCallback = OnPartialSpeechResult;
#endif
        
        SpeechToText.instance.onResultCallback = OnFinalSpeechResult;
        CheckPermission();
        
    }

    void CheckPermission()
    {
#if UNITY_ANDROID
        if (!Permission.HasUserAuthorizedPermission(Permission.Microphone))
        {
            Permission.RequestUserPermission(Permission.Microphone);
        }
#endif
       
    }

    #region Speech to Text
   
    public void StartListening()
    {
        SpeechToText.instance.StartRecording();
        Debug.Log("recording");

    }
    public void StopListening()
    {
        SpeechToText.instance.StopRecording();
        Debug.Log("stopped recording");
    }

    void OnFinalSpeechResult(string result)
    {
        Debug.Log("done: "+result);
        uiText.text = result;
        if (result == "please walk" || result == "walk")
        {
            animation.Play("Walk");
        }
        else if (result == "please run" || result == "run")
        {
            animation.Play("Run");
        }
        else if (result == "please stop" || result == "stop")
        {
            animation.Play("Idle");
        }
        else if (result == "hello" || result == "good morning")
        {
            animation.Play("Bow");
        }
    }
    
    void OnPartialSpeechResult(string result)
    {
        uiText.text = result;
    }

    #endregion

    void Setup(string code)
    {
        SpeechToText.instance.Setting(code);
    }
}
