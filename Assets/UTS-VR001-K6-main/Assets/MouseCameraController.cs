using UnityEngine;  

public class MouseCameraController : MonoBehaviour  
{  
    [Header("Mouse Look Settings")]  
    public float mouseSensitivity = 50f; // Sensitivitas mouse  
    public bool invertY = false;          // Invers rotasi vertikal  
    public bool lockCursor = true;       // Kunci kursor di tengah layar  

    private float _xRotation = 0f;  

    void Start()  
    {  
        if (lockCursor)  
        {  
            Cursor.lockState = CursorLockMode.Locked; // Kunci kursor  
            Cursor.visible = false;                   // Sembunyikan kursor  
        }  
    }  

    void Update()  
    {  
        // Rotasi kamera berdasarkan input mouse  
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;  
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;  

        // Rotasi vertikal (atas-bawah)  
        _xRotation += (invertY ? 1 : -1) * mouseY;  
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f); // Batasi rotasi vertikal  

        // Terapkan rotasi ke kamera  
        transform.localRotation = Quaternion.Euler(_xRotation, transform.localEulerAngles.y + mouseX, 0f);  
    }  
}