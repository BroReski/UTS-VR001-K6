using UnityEngine;  

public class ForkliftControllerUpdate : MonoBehaviour  
{  
    [Header("Steering Wheel Settings")]  
    public Transform steeringWheel;      // Objek stir  
    public float maxSteerAngle = 90f;    // Sudut maksimal rotasi stir  
    public float turnSpeed = 100f;       // Kecepatan belok (A/D)  

    void Update()  
    {  
        // Input belok (A/D)  
        float turnInput = Input.GetAxis("Horizontal");  

        // Animasi stir (jika ada objek stir)  
        if (steeringWheel != null)  
        {  
            steeringWheel.localRotation = Quaternion.Euler(0, 0, -turnInput * maxSteerAngle);  
        }  

        // Rotasi mobil berdasarkan input belok  
        transform.Rotate(Vector3.up * turnInput * turnSpeed * Time.deltaTime);  
    }  
}