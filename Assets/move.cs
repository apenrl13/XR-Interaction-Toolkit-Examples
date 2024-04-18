using UnityEngine;

public class GhostOrbit : MonoBehaviour
{
    public Transform centerPoint; // 회전의 중심이 될 아파트의 Transform
    public float orbitSpeed = 50.0f; // 초당 회전 속도 (도 단위)
    public float radius = 10.0f; // 중심으로부터의 반경

    private float angle = 0.0f; // 초기 각도

    void Update()
    {
        if (centerPoint == null)
            return;

        // 각도를 시간에 따라 증가시킵니다. Time.deltaTime을 사용하여 프레임 속도에 독립적으로 동작하게 합니다.
        angle += orbitSpeed * Time.deltaTime;
        angle %= 360; // 각도가 360도를 초과하지 않도록 합니다.

        // 귀신의 새 위치를 계산합니다.
        float radian = angle * Mathf.Deg2Rad; // 각도를 라디안으로 변환
        float x = Mathf.Cos(radian) * radius;
        float z = Mathf.Sin(radian) * radius;
        Vector3 orbitPosition = new Vector3(x, 35, z) + centerPoint.position; // Y축은 변하지 않고 X와 Z만 변동

        // 귀신의 위치를 업데이트합니다.
        transform.position = orbitPosition;
        
        // 항상 중심을 바라보게 만듭니다.
        transform.LookAt(centerPoint);
    }
}