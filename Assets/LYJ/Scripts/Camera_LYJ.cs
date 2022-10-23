using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_LYJ : MonoBehaviour
{
    public Transform Target;               // ī�޶� ����ٴ� Ÿ��
    public Camera cam;
    private new Transform transform;

    public float moveSpeed = 10f;
    public float offsetX = 0.0f;            // ī�޶��� x��ǥ
    public float offsetY = 10.0f;           // ī�޶��� y��ǥ
    public float offsetZ = -10.0f;          // ī�޶��� z��ǥ

    public float CameraSpeed = 10.0f;       // ī�޶��� �ӵ�
    public float zoomSpeed = 10.0f;
    Vector3 TargetPos;                      // Ÿ���� ��ġ

    public Transform player;

    private float xRotateMove, yRotateMove;

    public float rotateSpeed = 500.0f;

    bool isFollow = true;
    private void FixedUpdate()
    {
        if (isFollow)
        {
            // Ÿ���� x, y, z ��ǥ�� ī�޶��� ��ǥ�� ���Ͽ� ī�޶��� ��ġ�� ����
            TargetPos = new Vector3(
                Target.transform.position.x + offsetX,
                Target.transform.position.y + offsetY,
                Target.transform.position.z + offsetZ
                );

            // ī�޶��� �������� �ε巴�� �ϴ� �Լ�(Lerp)
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
