using UnityEngine;

public class RandomCarMovement : MonoBehaviour
{
    [Header("이동 범위 (중앙 기준 ±)")]
    public float rangeX = 4f;
    public float rangeZ = 4f;

    [Header("이동 속도")]
    public float smoothSpeed = 2f;
    public float rotateSpeed = 5f;   // 회전 부드러움

    [Header("방향 전환 타이밍")]
    public float minChangeTime = 1f;
    public float maxChangeTime = 3f;

    private Vector3 startPos;
    private Vector3 targetPos;
    private float timer;

    void Start()
    {
        startPos = transform.position;
        PickNewTarget();
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
            PickNewTarget();

        // X, Z만 이동 (Y는 고정)
        Vector3 newPos = Vector3.Lerp(transform.position, targetPos, smoothSpeed * Time.deltaTime);
        newPos.y = startPos.y;
        transform.position = newPos;

        // 이동 방향으로 부드럽게 회전
        Vector3 direction = (targetPos - transform.position);
        direction.y = 0f;
        if (direction.sqrMagnitude > 0.01f)
        {
            Quaternion targetRot = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, rotateSpeed * Time.deltaTime);
        }
    }

    void PickNewTarget()
    {
        float newX = startPos.x + Random.Range(-rangeX, rangeX);
        float newZ = startPos.z + Random.Range(-rangeZ, rangeZ);
        targetPos = new Vector3(newX, startPos.y, newZ);
        timer = Random.Range(minChangeTime, maxChangeTime);
    }
}
