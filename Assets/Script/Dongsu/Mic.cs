using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Networking;

public class Mic : MonoBehaviour
{
    private AudioClip _audioClip;
    private string _microphone;

    public GameObject recodingText;

    // 서버 URL
    private string uploadURL = "https://yourserver.com/upload"; // 실제 서버의 URL로 변경하세요.

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            recodingText.SetActive(true);
            StartRecording();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            recodingText.SetActive(false);
            StopRecordingAndSave();
        }
    }

    void Start()
    {
        // 첫 번째 마이크 장치 선택
        if (Microphone.devices.Length > 0)
        {
            _microphone = Microphone.devices[0];
        }
        else
        {
            Debug.LogError("마이크 장치가 없습니다.");
        }
    }

    public void StartRecording()
    {
        if (_microphone != null)
        {
            _audioClip = Microphone.Start(_microphone, true, 10, 44100);
            Debug.Log("녹음 시작");
        }
    }

    public void StopRecordingAndSave()
    {
        if (_microphone != null && Microphone.IsRecording(_microphone))
        {
            Microphone.End(_microphone);
            SaveRecording(_audioClip);
            Debug.Log("녹음 종료 및 저장");
        }
    }

    private void SaveRecording(AudioClip clip)
    {
        SavWav.Save("MyRecording", clip);
    }

    // 파일 업로드를 호출하는 함수
    public void UploadFile()
    {
        // 코루틴 호출
        StartCoroutine(Upload());
    }

    private IEnumerator Upload()
    {
        // 파일 경로
        string filePath = System.IO.Path.Combine(Application.persistentDataPath, "MyRecording.wav");

        // 파일을 바이트 배열로 읽기
        byte[] fileData = System.IO.File.ReadAllBytes(filePath);

        // 파일을 MultipartFormDataSection으로 생성
        List<IMultipartFormSection> formData = new List<IMultipartFormSection>();
        formData.Add(new MultipartFormFileSection("file", fileData, "MyRecording.wav", "audio/wav"));

        // UnityWebRequest 생성
        UnityWebRequest www = UnityWebRequest.Post(uploadURL, formData);

        // 요청 전송
        yield return www.SendWebRequest();

        // 응답 처리
        if (www.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("파일 업로드 성공");
        }
        else
        {
            Debug.Log("파일 업로드 실패: " + www.error);
        }
    }
}

public static class SavWav
{
    public static void Save(string filename, AudioClip clip)
    {
        var filepath = Path.Combine(Application.persistentDataPath, filename + ".wav");
        using (var fileStream = CreateEmpty(filepath))
        {
            Debug.Log("저장");
            ConvertAndWrite(fileStream, clip);
            WriteHeader(fileStream, clip);
        }
    }

    private static FileStream CreateEmpty(string filepath)
    {
        var fileStream = new FileStream(filepath, FileMode.Create);
        byte emptyByte = new byte();
        for (int i = 0; i < 44; i++) // 헤더 공간 확보
            fileStream.WriteByte(emptyByte);
        return fileStream;
    }

    private static void ConvertAndWrite(FileStream fileStream, AudioClip clip)
    {
        var samples = new float[clip.samples];
        clip.GetData(samples, 0);
        var intData = new short[samples.Length];
        var bytesData = new byte[samples.Length * 2];
        int rescaleFactor = 32767; // to convert float to Int16

        for (int i = 0; i < samples.Length; i++)
        {
            intData[i] = (short)(samples[i] * rescaleFactor);
            byte[] byteArr = System.BitConverter.GetBytes(intData[i]);
            byteArr.CopyTo(bytesData, i * 2);
        }
        fileStream.Write(bytesData, 0, bytesData.Length);
    }

    private static void WriteHeader(FileStream fileStream, AudioClip clip)
    {
        fileStream.Seek(0, SeekOrigin.Begin);
        byte[] riff = System.Text.Encoding.UTF8.GetBytes("RIFF");
        fileStream.Write(riff, 0, 4);
        byte[] chunkSize = System.BitConverter.GetBytes(fileStream.Length - 8);
        fileStream.Write(chunkSize, 0, 4);
        byte[] wave = System.Text.Encoding.UTF8.GetBytes("WAVE");
        fileStream.Write(wave, 0, 4);
        byte[] fmt = System.Text.Encoding.UTF8.GetBytes("fmt ");
        fileStream.Write(fmt, 0, 4);
        byte[] subChunk1 = System.BitConverter.GetBytes(16);
        fileStream.Write(subChunk1, 0, 4);
        ushort two = 2;
        ushort one = 1;
        byte[] audioFormat = System.BitConverter.GetBytes(one);
        fileStream.Write(audioFormat, 0, 2);
        byte[] numChannels = System.BitConverter.GetBytes(clip.channels);
        fileStream.Write(numChannels, 0, 2);
        byte[] sampleRate = System.BitConverter.GetBytes(clip.frequency);
        fileStream.Write(sampleRate, 0, 4);
        byte[] byteRate = System.BitConverter.GetBytes(clip.frequency * clip.channels * 2);
        fileStream.Write(byteRate, 0, 4);
        ushort blockAlign = (ushort)(clip.channels * 2);
        fileStream.Write(System.BitConverter.GetBytes(blockAlign), 0, 2);
        ushort bps = 16;
        byte[] bitsPerSample = System.BitConverter.GetBytes(bps);
        fileStream.Write(bitsPerSample, 0, 2);
        byte[] datastring = System.Text.Encoding.UTF8.GetBytes("data");
        fileStream.Write(datastring, 0, 4);
        byte[] subChunk2 = System.BitConverter.GetBytes(clip.samples * clip.channels * 2);
        fileStream.Write(subChunk2, 0, 4);
    }
}
