using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class CAJ_ConnectionManager : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        //서버 접속
        //App ID, 지역, 서버에 요청을 함
        //요청을 했으면 받아야 함
        PhotonNetwork.ConnectUsingSettings();
    }

    //마스터 서버 접속 성공시 호출(Lobby에 진입할 수 없는 상태)
    public override void OnConnected()
    {
        base.OnConnected();
        print(System.Reflection.MethodBase.GetCurrentMethod().Name);
    }
    
    //마스터 서버 접속 성공시 호출(Lobby에 진입할 수 있는 상태)
    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        print(System.Reflection.MethodBase.GetCurrentMethod().Name);
        
        //로비 진입 요청
        PhotonNetwork.JoinLobby();
    }
    
    //로비 진입 성공시 호출
    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
        print(System.Reflection.MethodBase.GetCurrentMethod().Name);
        
        //LobbyScene으로 이동
        SceneManager.LoadScene("CAJ_LobbyScene");
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
