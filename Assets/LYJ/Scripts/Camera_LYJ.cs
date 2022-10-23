using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_LYJ : MonoBehaviour
{
    public Transform Target;               // 카메라가 따라다닐 타겟
    public Camera cam;
    private new Transform transform;

    public float moveSpeed = 10f;
    public float offsetX = 0.0f;            // 카메라의 x좌표
    public float offsetY = 10.0f;           // 카메라의 y좌표
    public float offsetZ = -10.0f;          // 카메라의 z좌표

    public float CameraSpeed = 10.0f;       // 카메라의 속도
    public float zoomSpeed = 10.0f;
    Vector3 TargetPos;                      // 타겟의 위치

    public Transform player;

    private float xRotateMove, yRotateMove;

    public float rotateSpeed = 500.0f;

    bool isFollow = true;
    private void FixedUpdate()
    {
        if (isFollow)
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
    }
    void Start()
    {
        transform = GetComponent<Transform>();
    }

    // Update is called once per frame

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            isFollow = false;
            xRotateMove = Input.GetAxis("Mouse X") * Time.deltaTime * rotateSpeed;
            yRotateMove = Input.GetAxis("Mouse Y") * Time.deltaTime * rotateSpeed;

            Vector3 playerPosition = player.transform.position;

            Debug.Log(xRotateMove +" "+yRotateMove);
            transform.RotateAround(playerPosition, Vector3.right, -yRotateMove);
            transform.RotateAround(playerPosition, Vector3.up, xRotateMove);
            //transform.LookAt(playerPosition);

            xRotateMove = Mathf.Clamp(xRotateMove, -90, 90);
        }


        Zoom();
  

    }

    private void Zoom()
    {
        float distance = Input.GetAxis("Mouse ScrollWheel") * -1 * zoomSpeed;
        if (distance != 0)
        {
            cam.fieldOfView += distance;
        }
    }


}
