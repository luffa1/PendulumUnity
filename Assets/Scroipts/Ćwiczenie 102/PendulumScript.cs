using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PendulumScript : MonoBehaviour
{
    // Przekształcanie składowej punktu obrotu wahadła
    public Transform pivot;
    // Bieżący okres wahadła w sekundach
    public Transform anchor;
    // Zmienna przechowująca aktualny okres wahadła w sekundach
    private float period = 0;
    // Komponent timera do śledzenia czasu, który upłynął
    public Timer timer;
    // Komponent Rigidbody2D
    private Rigidbody2D rb2D;
    // Komponent HingeJoint2D
    private HingeJoint2D hing2D;
    // Komponent Slider
    public Slider lengthSlider;
    // Siatka tekstowa do wyświetlania wartości długości
    public TextMeshProUGUI lengthValue;
    // Komponent Kamery
    public Camera cameraa;
    // Określenie czy funkcja sprawdzająca czy wahadło się rusza
    private bool isDragging = false;

    void Start()
    {
        // Inicjowanie zmiennych
        timer = GameObject.Find("Timer").GetComponent<Timer>();
        rb2D = GetComponent<Rigidbody2D>();
        hing2D = GetComponent<HingeJoint2D>();
        // Dodawanie listenera do zmiany długości wahadła
        lengthSlider.onValueChanged.AddListener(SetLength);
        // Ustawienie długości wahadła na podstawie wartości suwaka
        SetLength(lengthSlider.value);
    }
    // Funkcja obsługująca przesuwanie wahadła za pomocą myszy
    void OnMouseDrag() 
    {
        // Sprawdzenie czy gracz przesuwa wahadło
        if (isDragging)
        {
            // Włączenie trybu kinematycznego dla wahadła (brak reakcji na fizykę)
            rb2D.isKinematic = true;
            // Zerowanie prędkości i przyspieszenia wahadła
            rb2D.velocity = Vector2.zero;
            rb2D.angularVelocity = 0;
            // Pobranie pozycji wahadła na ekranie
            Vector3 Screepoint = Camera.main.WorldToScreenPoint (transform.position);
            // Pobranie pozycji kursora myszy na ekranie
            Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Screepoint.z);
            // Przekształcenie pozycji kursora myszy na pozycję w świecie gry
            Vector3 objposition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
            // Ustawienie pozycji wahadła na pozycji kursora myszy
            transform.position = objposition;
            // Ustawienie pozycji wahadła na poziomie 2D (tylko na osi x i y)
            transform.position = new Vector3 (transform.position.x, transform.position.y, 0);
        }    
    }
    // Funkcja obsługująca zwolnienie przycisku myszy
    void OnMouseUp() 
    {  
        // Sprawdzenie czy gracz przesuwał wahadło
        if(isDragging)
        {
            // Rozpoczęcie odliczania czasu przez obiekt "timer"
            timer.startTimer();
            // Zerowanie zmiennej przechowującej okres wahadła
            period = 0;
            // Resetowanie pozycji wahadła
            ResetPosition();
            // Ustawienie flagi "isDragging" na "false"
            isDragging = false;
        }
    }
    // Funkcja obsługująca naciśnięcie przycisku myszy
    void OnMouseDown() 
    {
        // Wykonanie promienia od kamery do pozycji kursora myszy
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        // Sprawdzenie czy promień został przerwany przez jakiś obiekt
        if (hit.collider != null) 
        {
            // Pobranie obiektu przerwanego przez promień
            Transform objectHit = hit.transform;
            // Sprawdzenie czy obiekt ma tag "Circle"
            if (objectHit.tag == "Circle")
            {
                // Ustawienie flagi "isDragging" na "true"
                isDragging = true;
            }
        }
    }
    public void SetLength(float length)
    {
        // Resetowanie pozycji wahadła
        ResetPosition();
        // Ustawienie tekstu z wartością długości wahadła na obiekcie "lengthValue"
        lengthValue.text = length.ToString("") + " cm";  
    }
    // Resetowanie pozycji wahadła do pozycji początkowej
    public void ResetPosition()
    {
        // Włączenie fizyki dla wahadła
        rb2D.isKinematic = false;
        // Obliczenie wektora pomiędzy punktem mocowania a punktem obrotu
        Vector2 v2 = (anchor.position - pivot.position).normalized * lengthSlider.value / 100;
        // Obliczenie obrotu na podstawie wektora pomiędzy punktem mocowania a punktem obrotu
        Quaternion rotation = Quaternion.LookRotation(Vector3.forward, v2);
        // Ustawienie obrotu punktu obrotu
        pivot.rotation = rotation;
        // Ustawienie pozycji punktu obrotu
        pivot.position = anchor.position - (Vector3) v2;
        // Ustawienie punktu mocowania dla komponentu HingeJoint2D
        hing2D.anchor = v2.magnitude * Vector2.up;
    }
}
