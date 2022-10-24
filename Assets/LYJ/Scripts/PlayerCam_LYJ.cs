using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �÷��̾�� ��� ī�޶� ���ο� �ִ�.
// ���� 360���� ȸ���� �� �ִ�. ���δ� 70�� ����
// ���콺 �ٷ� ȭ�� Ȯ�� ����� �� �ִ�.
// ������ ���콺 ��ư�� ������ ȭ�鰢���� �ٲ� �� �ִ�.

public class PlayerCam_LYJ : MonoBehaviour
{

    public GameObject Target;               // ī�޶� ����ٴ� Ÿ��

    public float offsetX = 0.0f;            // ī�޶��� x��ǥ
    public float offsetY = 10.0f;           // ī�޶��� y��ǥ
    public float offsetZ = -10.0f;          // ī�޶��� z��ǥ


    public float CameraSpeed = 10.0f;       // ī�޶��� �ӵ�
    public float zoomSpeed = 10.0f;

    private Camera mainCamera;

    Vector3 TargetPos;                      // Ÿ���� ��ġ

    // Update is called once per frame
    void FixedUpdate()
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
