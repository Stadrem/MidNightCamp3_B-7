using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using static System.Net.WebRequestMethods;
public class GetTest : MonoBehaviour
{

    private void Start()
    {
        Get();
    }
    private string url = "http://192.168.1.11:8080/api-test";
    public void Get()
    {
       
        StartCoroutine(GetRequest(url));
    }

    // Get 통신 코루틴 함수
    IEnumerator GetRequest(string url)
    {
        // http Get 통신 준비를 한다.
        UnityWebRequest request = UnityWebRequest.Get(url);

        // 서버에 Get 요청을 하고, 서버로부터 응답이 올 때까지 대기한다.
        yield return request.SendWebRequest();

        // 만일, 서버로부터 온 응답이 성공(200)이라면...
        if (request.result == UnityWebRequest.Result.Success)
        {
            // 응답받은 데이터를 출력한다.
            string response = request.downloadHandler.text;

            print(response);
        }
        // 그렇지 않다면(400, 404 etc)...
        else
        {
            // 에러 내용을 출력한다.
            print(request.error);
        }

    }
}
