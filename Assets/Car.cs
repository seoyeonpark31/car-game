using UnityEngine;

public class CarController : MonoBehaviour
{
    [Header("이동")]
    public float speed = 10f;
    public float turnSpeed = 80f;

    [Header("바퀴 (Inspector에서 연결)")]
    public Transform wheelFL;
    public Transform wheelFR;
    public Transform wheelRL;
    public Transform wheelRR;

    private float moveInput;
    private float turnInput;

    void Update()
    {
        moveInput = Input.GetAxis("Vertical");
        turnInput = Input.GetAxis("Horizontal");

        // 앞뒤 이동
        transform.Translate(Vector3.forward * moveInput * speed * Time.deltaTime);

        // 좌우 회전 (달릴 때만)
        if (moveInput != 0)
        {
            transform.Rotate(Vector3.up * turnInput * turnSpeed * Time.deltaTime);
        }

        // 바퀴 굴리기
        RotateWheels();
    }

    void RotateWheels()
    {
        float wheelRotateSpeed = moveInput * speed * 6f;

        wheelFL.Rotate(Vector3.right * wheelRotateSpeed * Time.deltaTime, Space.World);
        wheelFR.Rotate(Vector3.right * wheelRotateSpeed * Time.deltaTime, Space.World);
        wheelRL.Rotate(Vector3.right * wheelRotateSpeed * Time.deltaTime, Space.World);
        wheelRR.Rotate(Vector3.right * wheelRotateSpeed * Time.deltaTime, Space.World);
    }
}