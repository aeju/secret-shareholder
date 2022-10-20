using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Pun.Demo.Cockpit.Forms;
using Photon.Realtime;
using UnityEngine;

public class CAJ_LobbyManager : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        CreateRoom();
    }

    public void CreateRoom()
    {
        //방 옵션을 설정
        RoomOptions roomOptions = new RoomOptions();
        
        //최대 인원 설정
        roomOptions.MaxPlayers = 10;
        
        //룸 리스트에 보이게 ? (기본 = true, 공개방)
        roomOptions.IsVisible = true;
        
        //방 생성 요청 (해당 옵션을 이용해서)
        PhotonNetwork.CreateRoom("MetaMong", roomOptions);
    }
    
    //방이 생성되면 호출 되는 함수
    public override void OnCreatedRoom()
    {
        base.OnCreatedRoom();
        print("OnCreatedRoom");
    }

    
    //방생성이 실패될 때 호출 되는 함수(returnCode = 포톤에서 정의 해놓은 숫자)
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        base.OnCreateRoomFailed(returnCode, message);
        print("OnCreateRoomFailed, " + returnCode + "," + message);
    }
    
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
