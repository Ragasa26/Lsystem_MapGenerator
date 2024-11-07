using UnityEngine;
using UnityEngine.UI;

public class CameraSwitcher : MonoBehaviour {
    public Camera camera1;
    public Camera camera2;
    // public Button switchButton;
    [SerializeField] public GameObject canvas1;
    [SerializeField] public GameObject canvas2;
    

    private bool isCamera1Active = true;

    void Start() {
        // Pastikan kamera awal aktif dan tombol memiliki listener
       
        // switchButton.onClick.AddListener(SwitchCamera);
        camera2.enabled  = true;
        canvas1.SetActive(false);
        canvas2.SetActive(true);
        
    }

    public void SwitchCamera() {
        // Toggle status kamera
        isCamera1Active = !isCamera1Active;
        
        UpdateCamera();
    }

    void UpdateCamera() {
        // Aktifkan kamera yang dipilih
        if (isCamera1Active) {
            camera1.enabled = false;
            camera2.enabled = true;
            canvas1.SetActive(false);
            canvas2.SetActive(true);


        } else {
            camera1.enabled = true;
            camera2.enabled = false;
            canvas1.SetActive(true);
            canvas2.SetActive(false);
        }
    }
}
