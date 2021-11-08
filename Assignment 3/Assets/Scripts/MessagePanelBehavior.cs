using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class MessagePanelBehavior : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI messageDisplay;
    [SerializeField] private float tweenTime;
    [SerializeField] private Transform pTrans;


    private Queue<string> messages = new Queue<string>();

    private void OnEnable() {
        Player.PlayerHit += DisplayPain;
    }

    private void OnDisable() {
        Player.PlayerHit -= DisplayPain;
    }

    private void Awake()
    {
        messageDisplay.rectTransform.localScale = new Vector3(0, 0, 0);
    }

    private void DisplayPain(string obj){
        //messageDisplay.text = obj;
        //messageDisplay.rectTransform.localScale = new Vector3(1.7f, 1.7f, 1.7f);
        //messageDisplay.rectTransform.DOScale(0, tweenTime);

        messages.Enqueue(obj);
        Debug.Log("Current queue length: " + messages.Count.ToString());
    }

    private void Update()
    {
        CheckQueue();
    }

    private void CheckQueue(){
       if (!DOTween.IsTweening(messageDisplay.rectTransform))
       {
           if (messages.Count > 0)
           {
               DisplayMessageAnimate(messages.Dequeue());
           }
       }
    }

    private void DisplayMessageAnimate(string obj){
        messageDisplay.text = obj;
        messageDisplay.rectTransform.localScale = new Vector3(1.7f, 1.7f, 1.7f);
        messageDisplay.rectTransform.position = pTrans.position;
        messageDisplay.rectTransform.DOScale(0, tweenTime);
    }
}
