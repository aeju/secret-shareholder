using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CAJ_NewRoom : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void OnNextRoom()
    {
        PhotonNetwork.LoadLevel("6Second_Room");
        //PhotonNetwork.LeaveLobby();
        //PhotonNetwork.LeaveRoom();
    }
}
