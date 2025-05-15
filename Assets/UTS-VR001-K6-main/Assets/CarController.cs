using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    // Variabel untuk input dari pengguna
    private float horizontalInput, verticalInput;
    private float currentSteerAngle, currentbreakForce;
    private bool isBreaking;

    // Pengaturan mobil yang dapat disesuaikan di Inspector
    [SerializeField] private float motorForce, breakForce, maxSteerAngle;

    // Wheel Colliders untuk tiap roda mobil
    [SerializeField] private WheelCollider frontLeftWheelCollider, frontRightWheelCollider;
    [SerializeField] private WheelCollider rearLeftWheelCollider, rearRightWheelCollider;

    // Transform untuk tampilan visual roda (mesin model mobil)
    [SerializeField] private Transform frontLeftWheelTransform, frontRightWheelTransform;
    [SerializeField] private Transform rearLeftWheelTransform, rearRightWheelTransform;

    // AudioSource untuk suara pergerakan mobil
    [SerializeField] private AudioSource moveSFX; // Suara gerak mobil di-assign di Inspector

    private void FixedUpdate()
    {
        // Mengambil input dari pengguna
        GetInput();
        
        // Mengatur motor berdasarkan input
        HandleMotor();
        
        // Mengatur kemudi berdasarkan input
        HandleSteering();
        
        // Memperbarui posisi dan rotasi roda
        UpdateWheels();
        
        // Menangani suara pergerakan mobil
        HandleMoveSound(); // <-- Menambahkan suara pergerakan mobil
    }

    // Mengambil input dari pemain untuk kontrol mobil
    private void GetInput()
    {
        // Input untuk kemudi
        horizontalInput = Input.GetAxis("Horizontal");

        // Input untuk percepatan (depan atau mundur)
        verticalInput = Input.GetAxis("Vertical");

        // Input untuk pengereman (menggunakan spasi)
        isBreaking = Input.GetKey(KeyCode.Space);
    }

    // Mengatur motor mobil berdasarkan input percepatan (membuat mobil bergerak)
    private void HandleMotor()
    {
        // Mengatur torsi motor untuk roda depan berdasarkan input vertikal
        frontLeftWheelCollider.motorTorque = verticalInput * motorForce;
        frontRightWheelCollider.motorTorque = verticalInput * motorForce;

        // Menentukan kekuatan pengereman berdasarkan status tombol break
        currentbreakForce = isBreaking ? breakForce : 0f;

        // Menerapkan pengereman
        ApplyBreaking();
    }

    // Menerapkan pengereman ke semua roda mobil
    private void ApplyBreaking()
    {
        frontRightWheelCollider.brakeTorque = currentbreakForce;
        frontLeftWheelCollider.brakeTorque = currentbreakForce;
        rearLeftWheelCollider.brakeTorque = currentbreakForce;
        rearRightWheelCollider.brakeTorque = currentbreakForce;
    }

    // Mengatur sudut kemudi berdasarkan input horizontal (membelokkan roda)
    private void HandleSteering()
    {
        // Menghitung sudut kemudi berdasarkan input horizontal
        currentSteerAngle = maxSteerAngle * horizontalInput;

        // Menetapkan sudut kemudi pada roda depan
        frontLeftWheelCollider.steerAngle = currentSteerAngle;
        frontRightWheelCollider.steerAngle = currentSteerAngle;
    }

    // Memperbarui posisi dan rotasi roda di dunia game berdasarkan posisi roda collider
    private void UpdateWheels()
    {
        // Memperbarui posisi dan rotasi tiap roda (depan kiri, depan kanan, belakang kiri, belakang kanan)
        UpdateSingleWheel(frontLeftWheelCollider, frontLeftWheelTransform);
        UpdateSingleWheel(frontRightWheelCollider, frontRightWheelTransform);
        UpdateSingleWheel(rearRightWheelCollider, rearRightWheelTransform);
        UpdateSingleWheel(rearLeftWheelCollider, rearLeftWheelTransform);
    }

    // Memperbarui posisi dan rotasi dari satu roda berdasarkan WheelCollider
    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;
        // Mendapatkan posisi dan rotasi dari wheel collider
        wheelCollider.GetWorldPose(out pos, out rot);
        
        // Menetapkan rotasi dan posisi transform roda agar sesuai dengan wheel collider
        wheelTransform.rotation = rot;
        wheelTransform.position = pos;
    }

    // Menangani suara mobil saat bergerak
    private void HandleMoveSound()
    {
        // Mengecek apakah tombol W atau S sedang ditekan
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            // Jika suara belum diputar, putar suara sekarang
            if (!moveSFX.isPlaying)
            {
                moveSFX.Play();
            }
        }
        else
        {
            // Jika tidak ada input gerakan dan suara sedang diputar, hentikan suara
            if (moveSFX.isPlaying)
            {
                moveSFX.Stop();
            }
        }
    }
}