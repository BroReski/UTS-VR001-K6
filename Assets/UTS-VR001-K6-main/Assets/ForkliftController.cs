using UnityEngine;  

[RequireComponent(typeof(Rigidbody))]  
public class ForkliftController : MonoBehaviour  
{  
    public float motorForce = 100f;          // Gaya dorong maju/mundur  
    public float turnTorque = 20f;           // Torsi untuk belok  
    public Transform steeringWheel;           // Referensi ke objek stir  
    public float steerRotationAmount = 90f;   // Jumlah rotasi stir  

    private Rigidbody rb;  
    private float lastTurnInput = 0f;         // Menyimpan input belok terakhir  

    void Start()  
    {  
        rb = GetComponent<Rigidbody>();  
        rb.centerOfMass = new Vector3(0, -0.5f, 0); // Turunkan center of mass untuk stabilitas  
    }  

    void FixedUpdate()  
    {  
        float moveInput = Input.GetAxis("Vertical");   // Input maju/mundur (W/S)  
        float turnInput = Input.GetAxis("Horizontal"); // Input belok (A/D)  

        // Tambahkan gaya maju/mundur di sumbu Z lokal  
        Vector3 force = transform.forward * moveInput * motorForce * Time.fixedDeltaTime;  
        rb.AddForce(force, ForceMode.Force);  

        // Rotasi mobil berdasarkan input belok  
        float direction = Vector3.Dot(rb.velocity, transform.forward) > 0 ? 1 : -1;  
        rb.MoveRotation(rb.rotation * Quaternion.Euler(0f, turnInput * direction * turnTorque * Time.fixedDeltaTime, 0f));  

        // Simpan input belok terakhir jika ada input  
        if (Mathf.Abs(turnInput) > 0.1f)  
        {  
            lastTurnInput = turnInput;  
        }  

        // Animasi stir (terlihat meskipun mobil tidak bergerak)  
        if (steeringWheel != null)  
        {  
            steeringWheel.localRotation = Quaternion.Euler(0, 0, -lastTurnInput * steerRotationAmount);  
        }  
    }  
}