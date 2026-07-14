using UnityEngine;
using TMPro;

public class TrafficLight : MonoBehaviour
{
    public TextMeshProUGUI failText;

    [Header("신호등 불빛 (Renderer 연결)")]
    public Renderer redLight;
    public Renderer yellowLight;
    public Renderer greenLight;

    [Header("신호 시간 (초)")]
    public float redTime = 3f;
    public float yellowTime = 1f;
    public float greenTime = 3f;

    private enum State { Red, Yellow, Green }
    private State current;
    private float timer;
    private bool failed = false;

    void Start()
    {
        SetLight(State.Red);
    }

    void Update()
    {
        if (failed) return;

        // 빨간불인데 움직이면 실패
        if (current == State.Red)
        {
            bool moving = Mathf.Abs(Input.GetAxis("Vertical")) > 0.1f
                       || Mathf.Abs(Input.GetAxis("Horizontal")) > 0.1f;
            if (moving)
            {
                Fail();
                return;
            }
        }

        // 타이머
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            switch (current)
            {
                case State.Red:    SetLight(State.Green);  break;
                case State.Green:  SetLight(State.Yellow); break;
                case State.Yellow: SetLight(State.Red);    break;
            }
        }
    }

    void SetLight(State state)
    {
        current = state;

        // 일단 다 어둡게
        redLight.material.color    = new Color(0.3f, 0f, 0f);
        yellowLight.material.color = new Color(0.3f, 0.3f, 0f);
        greenLight.material.color  = new Color(0f, 0.3f, 0f);

        // 해당 불만 켜기
        switch (state)
        {
            case State.Red:
                redLight.material.color = Color.red;
                timer = redTime;
                break;
            case State.Yellow:
                yellowLight.material.color = Color.yellow;
                timer = yellowTime;
                break;
            case State.Green:
                greenLight.material.color = Color.green;
                timer = greenTime;
                break;
        }
    }

   void Fail()
{
    failed = true;
    
    // 차 멈추기
    FindObjectOfType<CarController>().enabled = false;
    
    // 실패 텍스트 표시
    failText.gameObject.SetActive(true);
}
}