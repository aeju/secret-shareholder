using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class CAJ_LobbyManager : MonoBehaviourPunCallbacks
{
    public void CreateRoom()
    {
        // 방 옵션을 설정
        RoomOptions roomOptions = new RoomOptions();
        
        // 최대 인원 설정
        roomOptions.MaxPlayers = 20;
        
        // 룸 리스트에 보이게 ? 보이지 않게? (기본 = true, 공개방)
        roomOptions.IsVisible = true;
        
        // 방 생성 요청 (해당 옵션을 이용해서)
        PhotonNetwork.CreateRoom("MetaMong", roomOptions);
    }
    
    // 방이 생성되면 호출 되는 함수
    public override void OnCreatedRoom()
    {
        base.OnCreatedRoom();
        print("OnCreatedRoom");
    }
    
    // 방 생성이 실패될 때 호출되는 함수 (returnCode는 포톤에서 정의 해놓은 숫자)
    // 방 생성이 실패되면, 그 방으로 JoinRoom하게 하기 
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        base.OnCreateRoomFailed(returnCode, message);
        print("OnCreateRoomFailed, " + returnCode + ", " + message);
        JoinRoom();
    }

    // Start is called before the first frame update
    void Start()
    {
        //시작하자마자 방 생성되게
        CreateRoom();
    }

    //방 참가 요청! 
    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom("MetaMong");
    }
    
    //방 참가가 완료 되었을 때 호출되는 함수
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        print("OnJoinedRoom");
        PhotonNetwork.LoadLevel("CAJ_RoomScene");
    }
    
    //방 참가가 완료 되었을 때 호출되는 함수
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        base.OnJoinRoomFailed(returnCode, message);
        print("OnJoinRoomFailed, " + returnCode + "," + message);
    }
    
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
