using UnityEngine;

public class CarController : MonoBehaviour
{
    [Header("이동")]
    public float speed = 10f;
    public float turnSpeed = 80f;


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

          }

    
}