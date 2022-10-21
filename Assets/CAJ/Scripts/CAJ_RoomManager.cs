using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CAJ_RoomManager : MonoBehaviour
{
    public 
    
    // Start is called before the first frame update
    void Start()
    {
        //플레이어 생성
        PhotonNetwork.Instantiate("CAJ_Player", Vector3.zero, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
