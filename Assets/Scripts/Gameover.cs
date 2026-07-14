using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
    // 주인공 차량에 붙이는 스크립트
    // NPC 차량 태그를 "NPC"로 설정해야 함

    [Header("신호등 스크립트와 공유하는 UI")]
    public TextMeshProUGUI failText;

    private bool isDead = false;

    void OnTriggerEnter(Collider other)
    {
        if (isDead) return;

        if (other.CompareTag("NPC"))
        {
            Fail();
        }
    }

    void Fail()
    {
        isDead = true;

        // 차 멈추기
        CarController car = FindObjectOfType<CarController>();
        if (car != null) car.enabled = false;

        // 실패 텍스트 표시
        if (failText != null) failText.gameObject.SetActive(true);
    }
}
