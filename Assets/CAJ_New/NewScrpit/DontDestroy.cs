using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class DontDestroy : MonoBehaviourPun
{
    public static DontDestroy Instance;
    
    // private void Awake()
    // {
    //     DontDestroyOnLoad(gameObject);
    // }
    
    void Awake()
    {
        if (photonView.IsMine == false) return;
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
