using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatManager : MonoBehaviour
{
    //ChatItem 공장
    public GameObject chatItemFactory;
    
    //InputChat
    public InputField inputChat;
    
    //ScrollView 의 Content transform
    public Transform trContent;

    void OnSubmit(string s)
    {
        
    }
    
    // Start is called before the first frame update
    void Start()
    {
        //InputChat 에서 엔터를 눌렀을 때 호출 되는 함수 등록
        inputChat.onSubmit.AddListener(OnSubmit);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
