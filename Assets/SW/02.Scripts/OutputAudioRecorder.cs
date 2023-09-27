using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class OutputAudioRecorder : MonoBehaviour
{
    private AudioClip clip;

    string[] micList;
    void Awake()
    {
        micList = Microphone.devices;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            clip = Microphone.Start(micList[0], true, 10, 44100);
            print("��������");
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            Microphone.End(micList[0]);
            print("�����ߴ�");
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            SaveAudioClipToWAV(Application.dataPath + "/test1.wav");
            print("��������");
        }
    }

    public void SaveAudioClipToWAV(string filePath)
    {
        if (clip == null)
        {
            Debug.LogError("No AudioClip assigned.");
            return;
        }

        // AudioClip�� ����� ������ ��������
        float[] samples = new float[clip.samples];
        clip.GetData(samples, 0);

        // WAV ���� ��� �ۼ�
        using (FileStream fs = File.Create(filePath))
        {
            WriteWAVHeader(fs, clip.channels, clip.frequency, clip.samples);
            ConvertAndWrite(fs, samples);
        }

        Debug.Log("AudioClip saved as WAV: " + filePath);
    }

    // WAV ���� ��� �ۼ�
    private void WriteWAVHeader(FileStream fileStream, int channels, int frequency, int sampleCount)
    {
        var samples = sampleCount * channels;
        var fileSize = samples + 36;

        fileStream.Write(new byte[] { 82, 73, 70, 70 }, 0, 4); // "RIFF" ���
        fileStream.Write(BitConverter.GetBytes(fileSize), 0, 4);
        fileStream.Write(new byte[] { 87, 65, 86, 69 }, 0, 4); // "WAVE" ���
        fileStream.Write(new byte[] { 102, 109, 116, 32 }, 0, 4); // "fmt " ���
        fileStream.Write(BitConverter.GetBytes(16), 0, 4); // 16
        fileStream.Write(BitConverter.GetBytes(1), 0, 2); // ����� ���� (PCM)
        fileStream.Write(BitConverter.GetBytes(channels), 0, 2); // ä�� ��
        fileStream.Write(BitConverter.GetBytes(frequency), 0, 4); // ���� ����Ʈ
        fileStream.Write(BitConverter.GetBytes(frequency * channels * 2), 0, 4); // ����Ʈ ����Ʈ
        fileStream.Write(BitConverter.GetBytes(channels * 2), 0, 2); // ��� ũ��
        fileStream.Write(BitConverter.GetBytes(16), 0, 2); // ��Ʈ ����Ʈ
        fileStream.Write(new byte[] { 100, 97, 116, 97 }, 0, 4); // "data" ���
        fileStream.Write(BitConverter.GetBytes(samples), 0, 4);
    }

    // ����� ������ ��ȯ �� �ۼ�
    private void ConvertAndWrite(FileStream fileStream, float[] samples)
    {
        Int16[] intData = new Int16[samples.Length];
        // float -> Int16 ��ȯ
        for (int i = 0; i < samples.Length; i++)
        {
            intData[i] = (short)(samples[i] * 32767);
        }
        // Int16 ������ �ۼ�
        Byte[] bytesData = new Byte[intData.Length * 2];
        Buffer.BlockCopy(intData, 0, bytesData, 0, bytesData.Length);
        fileStream.Write(bytesData, 0, bytesData.Length);
    }
}
