using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class CAJ_LobbyManager : MonoBehaviourPunCallbacks
{
    //1. 방 생성 (지금 : 시작하자마자, 나중엔 고치기)
    // Start is called before the first frame update
    void Start()
    {
        CreateRoom();
    }

    //방 생성
    public void CreateRoom()
    {
        //방 옵션을 설정
        RoomOptions roomOptions = new RoomOptions();
        
        //최대 인원 설정
        roomOptions.MaxPlayers = 20;
        
        //룸 리스트에 보이게 ? (기본 = true, 공개방)
        roomOptions.IsVisible = true;
        
        //방 생성 요청 (해당 옵션을 이용해서)
        PhotonNetwork.CreateRoom("MetaMong", roomOptions);
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
        JoinRoom();
    }
    
    //2-2-1. 방 참가 요청
    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom("MetaMong");
    }
    
        
    //2-2-2. 방 참가가 완료 되었을 때 호출되는 함수
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        print("OnJoinedRoom");
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
