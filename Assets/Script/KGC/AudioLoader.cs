using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

public class AudioLoader : MonoBehaviour
{
    private string audioUrl = "http://munhwasoft.iptime.org:7070/api/music/"; // API에서 MP3 파일 URL
    public AudioSource audioSource;

    void Start()
    {
        StartCoroutine(DownloadAndSaveAudio(audioUrl));
    }

    IEnumerator DownloadAndSaveAudio(string url)
    {
        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            www.downloadHandler = new DownloadHandlerBuffer();
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError(www.error);
            }
            else
            {
                // MP3 파일을 로컬에 저장
                SaveAudioToFile(www.downloadHandler.data);
            }
        }
    }


    void SaveAudioToFile(byte[] audioData)
    {
        string path = Path.Combine(Application.persistentDataPath, "downloadedAudio.mp3");
        File.WriteAllBytes(path, audioData);
        Debug.Log("Audio saved to: " + path);

        // 로컬 파일에서 오디오 클립 로드
        StartCoroutine(LoadAudioClip(path));
    }

    IEnumerator LoadAudioClip(string filePath)
    {
        using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip("file://" + filePath, AudioType.MPEG))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError(www.error);
            }
            else
            {
                AudioClip clip = DownloadHandlerAudioClip.GetContent(www);
                audioSource.clip = clip;
                audioSource.Play();
                Debug.Log("Audio playing...");
            }
        }
    }
}