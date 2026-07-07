using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnEnable()
    {
        // 3초 후 자동 삭제
        Destroy(gameObject, 3f);
    }
}