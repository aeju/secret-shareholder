using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

public class CAJ_LobbyManager : MonoBehaviourPunCallbacks
{
    //방 이름, 총 인원 -> 방 참가 되도록
    //방이름 InputField
    public InputField inputRoomName;
    //총인원 InputField
    public InputField inputMaxPlayer;
    //방참가 Button
    public Button btnJoin;
    //방생성 Button
    public Button btnCreate;

    void Start()
    {
        //CreateRoom();
        //방 이름이 변할 때마다 호출하게 하는 함수 등록
        inputRoomName.onValueChanged.AddListener(OnRoomNameValueChanged);
        //총 인원이 변할 때마다 호출하게 하는 함수 등록
        inputMaxPlayer.onValueChanged.AddListener(OnMaxPlayerValueChanged);
    }
    
    private void OnRoomNameValueChanged(string room)
    {
        //생성 버튼 활성화
        btnCreate.interactable = room.Length > 0;
        print("방 이름 입력 : " + room);
        //참여 버튼 활성화
        btnJoin.interactable = room.Length > 0 && inputMaxPlayer.text.Length > 0;
    }


    private void OnMaxPlayerValueChanged(string max)
    {
        btnCreate.interactable = max.Length > 0 && inputRoomName.text.Length > 0;
    }
    

    //방 생성
    public void CreateRoom()
    {
        //방 옵션을 설정
        RoomOptions roomOptions = new RoomOptions();
        
        //최대 인원 설정
        //roomOptions.MaxPlayers = 20;
        roomOptions.MaxPlayers = byte.Parse(inputMaxPlayer.text);
        
        //룸 리스트에 보이게 ? (기본 = true, 공개방)
        roomOptions.IsVisible = true;
        
        //방 생성 요청 (해당 옵션을 이용해서)
        PhotonNetwork.CreateRoom(inputRoomName.text, roomOptions);
    }

    //2-1-1. 방이 생성되면 호출 되는 함수
    public override void OnCreatedRoom()
    {
        base.OnCreatedRoom();
        print("OnCreatedRoom");
    }

    //2-1-2. 방생성이 실패될 때 호출 되는 함수(returnCode = 포톤에서 정의 해놓은 숫자)
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        base.OnCreateRoomFailed(returnCode, message);
        print("OnCreateRoomFailed, " + returnCode + "," + message);
        
        //JoinRoom();
    }
    
    //2-2-1. 방 참가 요청
    public void JoinRoom()
    {
        //PhotonNetwork.JoinRoom("MetaMong");
        PhotonNetwork.JoinRoom(inputRoomName.text);
    }
    
        
    //2-2-2. 방 참가가 완료 되었을 때 호출되는 함수
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        print("OnJoinedRoom");
        PhotonNetwork.LoadLevel("CAJ_RoomScene");
    }
        
    //2-2-3. 방 참가가 실패 되었을 때 호출되는 함수
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        base.OnJoinRoomFailed(returnCode, message);
        print("OnJoinRoomFailed, " + returnCode + ", " + message);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
