using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CAJ_BackBtn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void OnLeftRoom()
    {
        PhotonNetwork.LoadLevel(0);
        //PhotonNetwork.LeaveLobby();
        //PhotonNetwork.LeaveRoom();
    }
}
