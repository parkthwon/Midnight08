using UnityEngine;
using System.IO;

public class MicrophoneRecoder : MonoBehaviour
{
    AudioSource audioSource; // AudioSource ������Ʈ�� ������ ����
    AudioClip recording; // ������ ����� Ŭ���� ������ ����

    bool isRecording = false; // ���� ���� ������ ���θ� ��Ÿ���� ����

    //����ũ ���
    string[] micList;
    //����ũ ���� idx
    int micIdx;
    void Start()
    {
        audioSource = GetComponent<AudioSource>(); // AudioSource ������Ʈ ��������

        micList = Microphone.devices;
        for(int i = 0; i < micList.Length; i++)
        {
            if(micList[i].Contains("Headset Microphone"))
            {
                micIdx = i;
                break;
            }
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            StartRecording();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            StopRecordingAndSave();
        }

    }

    public void StartRecording()
    {
        if (!Microphone.IsRecording(micList[micIdx])) // ���� ���� ���� �ƴ϶��
        {
            recording = Microphone.Start(micList[micIdx], true, 10, 44100); // ����ũ���� ���� ����
            isRecording = true; // ���� �� �÷��� ����
        }
    }

    public void StopRecordingAndSave()
    {
        if (isRecording) // ���� ���̾��ٸ�
        {
            Microphone.End(micList[micIdx]); // ����ũ���� ���� ����
            isRecording = false; // ���� �� �÷��� ����

            string filePath = Path.Combine(Application.dataPath, "TEST.wav"); // ������ ���� ��� ����
            SavWav.Save(filePath, recording); // WAV ���Ϸ� ����
            Debug.Log("Recording saved to: " + filePath); // ����� ���� ��θ� �α׷� ���
        }
    }
}