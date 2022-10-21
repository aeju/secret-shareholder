using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class CAJ_ConnectionManager : MonoBehaviourPunCallbacks
{
    void Start()
    {
        //1. 서버 접속 요청 (App Id, 지역, 서버에 요청)
        PhotonNetwork.ConnectUsingSettings();
    }

    //2-1. 마스터 서버 접속성공시 호출(Lobby에 진입할 수 없는 상태)
    public override void OnConnected()
    {
        base.OnConnected();
        print(System.Reflection.MethodBase.GetCurrentMethod().Name);
    }

    //2-2. 마스터 서버 접속성공시 호출(Lobby에 진입할 수 있는 상태)
    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        print(System.Reflection.MethodBase.GetCurrentMethod().Name);

        //로비 진입 요청
        PhotonNetwork.JoinLobby();
    }

    //3. 로비 진입 성공시 호출
    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
        print(System.Reflection.MethodBase.GetCurrentMethod().Name);
        
        //내 닉네임 설정
        PhotonNetwork.NickName = "MetaMong_" + Random.Range(1, 100);

        //LobbyScene으로 이동
        //SceneManager.LoadScene("CAJ_LobbyScene");
        //Scene이 로드 되는 순간 네트워크 유실 되지 않기 위해서 -> PhotonNetwork.LoadLevel 사용
        PhotonNetwork.LoadLevel("CAJ_LobbyScene");
    }


    void Update()
    {

    }
}