using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TestingCodeForMovement : MonoBehaviour
{
    // Masa wahadła
    public float mass = 1.0f;
    // Długość ramienia wahadła
    public float length = 12.3f;
    // Siła grawitacji
    public float gravity = 9.81f;
    // Siła poruszająca wahadło po kliknięciu
    public float force = 0;
    // Komponent Rigidbody2D obiektu wahadła
    private Rigidbody2D rb;
    // public ReversePendulumTimer timer;
    public InputField swingForceInput;
    public Button startButton;
    public TextMeshProUGUI periodDisplayer;
    public Transform pendulum;
    public ReversePendulumTimer timerr;

    void Start()
    {
        timerr = GameObject.Find("ReversePendulumTimer").GetComponent<ReversePendulumTimer>();
        // Pobranie komponentu Rigidbody2D obiektu wahadła
        rb = GetComponent<Rigidbody2D>();
        startButton.onClick.AddListener(ApplyForce);
        // Ustawienie masy wahadła
        rb.mass = mass;
        // Ustawienie siły grawitacji
        rb.gravityScale = gravity;
    }
    void Update()
    {  
        Period.GetInstance().SetNewCurrentPosition(pendulum.position.x);
        periodDisplayer.text = Period.GetInstance().GetPeriod().ToString();
        if (Period.GetInstance().deviationCounter == 0)
        {
            if(!timerr.isStarted)
            {
                timerr.startTimer();
            }
        } 
    }
    void ApplyForce()
    {
        // Sprawdź, czy użytkownik wprowadził wartość w polu wejściowym
        if (swingForceInput != null && !string.IsNullOrEmpty(swingForceInput.text))
        {
            // Przeanalizuj wartość wejściową i ustaw zmienną wymuszającą
            float.TryParse(swingForceInput.text, out force);

            // Przyłóż siłę do wahadła
            rb.AddForce(Vector2.right * force, ForceMode2D.Impulse);
        }
    }
}
