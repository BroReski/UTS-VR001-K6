using UnityEngine;
using TMPro;

public class MissionManager : MonoBehaviour
{
    public TMP_Text missionText;

    private string[] missions = {
        "Ambil box di Area A dan letakkan di Area B",
        "Ambil box di Area C dan letakkan di Check Point 1",
        "Ambil box di Gudang dan taruh ke Truk Pengiriman"
    };

    private int currentMissionIndex = 0;

    void Start()
    {
        ShowMission();
    }

    public void NextMission()
    {
        currentMissionIndex++;
        if (currentMissionIndex < missions.Length)
        {
            ShowMission();
        }
        else
        {
            missionText.text = "Semua misi selesai!";
        }
    }

    void ShowMission()
    {
        missionText.text = missions[currentMissionIndex];
    }
}
