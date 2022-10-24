using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using UnityEngine.EventSystems;

public class ChatManager : MonoBehaviourPun
{
    //ChatItem 공장
    public GameObject chatItemFactory;
    
    //InputChat
    public InputField inputChat;
    
    //Scrollview 의 Content transform
    public Transform trContent;

    void Start()
    {
        //InputChat에서 엔터를 눌렀을 때 호출 되는 함수 등록
        inputChat.onSubmit.AddListener(OnSubmit);
    }
    
    void OnSubmit(string s)
    {
        Debug.Log(s);
        photonView.RPC("RpcAddChat", RpcTarget.All, s);
    }

    [PunRPC]
    void RpcAddChat(string chat)
    {
        GameObject item = Instantiate(chatItemFactory, trContent);

        Text t = item.GetComponent<Text>();
        //t.text = inputChat.text;
        t.text = chat;

        inputChat.text = "";
        
        inputChat.ActivateInputField();
    }
}