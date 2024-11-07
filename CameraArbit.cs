using UnityEngine;

public class CameraArbit : MonoBehaviour
{
    public Transform target;  // Objek yang akan dikelilingi kamera (contohnya model tumbuhan L-System)
    public float distance = 10.0f;  // Jarak kamera dari objek
    public float rotationSpeed = 50.0f;  // Kecepatan rotasi kamera
    public float scrollSpeed = 2.0f;  // Kecepatan zoom saat scroll
    public float minDistance = 2.0f;  // Jarak minimum kamera dari target
    public float maxDistance = 20.0f; // Jarak maksimum kamera dari target

    private float currentX = 0.0f;  // Sudut rotasi sumbu X
    private float currentY = 0.0f;  // Sudut rotasi sumbu Y
    public float yMinLimit = -20f;  // Batas minimal rotasi sumbu Y
    public float yMaxLimit = 80f;   // Batas maksimal rotasi sumbu Y

    void Start()
    {
        // Mengatur posisi kamera pada jarak awal
        Vector3 angles = transform.eulerAngles;
        currentX = angles.y;
        currentY = angles.x;
    }

    void Update()
    {
        // Input dari mouse untuk menggerakkan kamera
        if (Input.GetMouseButton(1))  // Klik kanan mouse untuk menggerakkan kamera
        {
            currentX += Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
            currentY -= Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;
            currentY = Mathf.Clamp(currentY, yMinLimit, yMaxLimit);  // Membatasi sudut rotasi pada sumbu Y
        }

        // Input scroll untuk zoom in/out
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        distance -= scroll * scrollSpeed;  // Menambah/mengurangi jarak berdasarkan input scroll
        distance = Mathf.Clamp(distance, minDistance, maxDistance);  // Membatasi jarak minimum dan maksimum

        // Mengatur posisi kamera mengelilingi target berdasarkan rotasi yang dihitung
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        Vector3 position = rotation * new Vector3(0.0f, 0.0f, -distance) + target.position;

        transform.rotation = rotation;  // Mengatur rotasi kamera
        transform.position = position;  // Mengatur posisi kamera
    }
}
