using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TypewriterEffect : MonoBehaviour
{
    public Text uiText; // UI Text 컴포넌트 참조
    public float typingSpeed = 0.05f; // 각 글자 출력 간격

    public string fullText; // 전체 텍스트
    private string currentText = ""; // 현재까지 출력된 텍스트

    void Start()
    {
        StartCoroutine(ShowText());

    }

    public void TypeStart()
    {
        StartCoroutine(ShowText());

    }


    IEnumerator ShowText()
    {
        //fullText = "동해물과 백두산이 마르고 닳도록\r\n하느님이 보우하사 우리나라 만세\r\n무궁화 삼천리 화려강산\r\n대한 사람 대한으로 길이 보전하세 \r\n애국가 가사 2절\r\n남산 위에 저 소나무 철갑을 두른 듯\r\n바람 서리 불변함은 우리 기상일세\r\n무궁화 삼천리 화려강산\r\n대한 사람 대한으로 길이 보전하세\r\n애국가 가사 3절\r\n가을 하늘 공활한데 높고 구름 없이\r\n밝은 달은 우리 가슴 일편단심일세"; // 전체 텍스트 설정

        for (int i = 0; i <= fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);
            uiText.text = currentText;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
}
