using System.Collections;
using UnityEngine;

public class DoorOpenScript : MonoBehaviour
{
    public float openAngle = 90.0f; // 문이 열릴 각도
    public float openSpeed = 2.0f; // 문이 열리는 속도

    private bool isOpening = false; // 문이 현재 열리고 있는지 여부
    private float initialAngle; // 문의 초기 각도

    void Start()
    {
        initialAngle = transform.eulerAngles.y; // 시작할 때 문의 초기 각도를 저장
    }

    void Update()
    {
        if (isOpening)
        {
            // 문을 열린 각도까지 서서히 회전시킴
            float angle = Mathf.LerpAngle(transform.eulerAngles.y, initialAngle + openAngle, Time.deltaTime * openSpeed);
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, angle, transform.eulerAngles.z);

            if (Mathf.Abs(angle - (initialAngle + openAngle)) < 0.01f)
            {
                // 문이 완전히 열렸다고 간주, 열기 중지
                isOpening = false;
            }
        }
    }

    // 이 함수를 외부에서 호출하여 문 열기 시작
    public void OpenDoor()
    {
        isOpening = true;
    }
}