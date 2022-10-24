using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 플레이어는 계속 카메라 메인에 있다.
// 가로 360도로 회전할 수 있다. 세로는 70도 제한
// 마우스 휠로 화면 확대 축소할 수 있다.
// 오른쪽 마우스 버튼을 누르면 화면각도를 바꿀 수 있다.

public class PlayerCam_LYJ : MonoBehaviour
{

    public GameObject Target;               // 카메라가 따라다닐 타겟

    public float offsetX = 0.0f;            // 카메라의 x좌표
    public float offsetY = 10.0f;           // 카메라의 y좌표
    public float offsetZ = -10.0f;          // 카메라의 z좌표


    public float CameraSpeed = 10.0f;       // 카메라의 속도
    public float zoomSpeed = 10.0f;

    private Camera mainCamera;

    Vector3 TargetPos;                      // 타겟의 위치

    // Update is called once per frame
    void FixedUpdate()
    {
        // 타겟의 x, y, z 좌표에 카메라의 좌표를 더하여 카메라의 위치를 결정
        TargetPos = new Vector3(
            Target.transform.position.x + offsetX,
            Target.transform.position.y + offsetY,
            Target.transform.position.z + offsetZ
            );

        // 카메라의 움직임을 부드럽게 하는 함수(Lerp)
        transform.position = Vector3.Lerp(transform.position, TargetPos, Time.deltaTime * CameraSpeed);
 
    }
 
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        Zoom();
    }

    private void Zoom()
    {
        float distance = Input.GetAxis("Mouse ScrollWheel") * -1 * zoomSpeed;
        if (distance != 0)
        {
            mainCamera.fieldOfView += distance;
        }
    }

}
