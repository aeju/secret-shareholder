using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class CAJ_RoomManager : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        //플레이어 생성
        //PhotonNetwork.Instantiate("CAJ_Player", Vector3.zero, Quaternion.identity);
        PhotonNetwork.Instantiate("CAJ_Player", new Vector3(0, 2, 0), Quaternion.identity);
    }
    
    //방에 플레이어가 참여했을 때 호출해주는 함수
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        base.OnPlayerEnteredRoom(newPlayer);
        print(newPlayer.NickName + "님이 방에 들어왔습니다.");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
