using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// 외부맵에서 내부맵으로 이동한다.
// 플레이어가 문앞 바닥에 들어오면 씬 전환이 일어난다.

public class PlayerDoorEvent_LYJ : MonoBehaviour
{
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 플레이어 태그 오브젝트와 충돌하면 씬 전환이 일어난다
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            SceneManager.LoadScene("InsideScene");
        }
    }
}
