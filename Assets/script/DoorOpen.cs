using UnityEngine;

public class DoorOpenSmooth : MonoBehaviour
{
    public Transform door;
    private Quaternion closedRotation;
    private Quaternion openRotation;
    private float rotationProgress = -1;

    void Start()
    {
        // 초기 문의 회전 상태를 저장
        closedRotation = door.rotation;
        openRotation = Quaternion.Euler(door.eulerAngles.x, door.eulerAngles.y + 90, door.eulerAngles.z);
    }

    void Update()
    {
        // 스페이스바가 눌렸고, 문이 이미 열리고 있지 않을 때
        if (Input.GetKeyDown(KeyCode.Space) && rotationProgress < 0)
        {
            rotationProgress = 0;  // 문 열기 시작
        }

        // 문이 열리고 있는 상태에서
        if (rotationProgress >= 0)
        {
            rotationProgress += Time.deltaTime;  // 시간에 따라 진행 상태 증가
            door.rotation = Quaternion.Lerp(closedRotation, openRotation, rotationProgress);  // 점진적으로 문 회전

            // 문이 완전히 열렸다면
            if (rotationProgress >= 1)
            {
                rotationProgress = -1;  // 진행 상태 초기화
            }
        }
    }
}