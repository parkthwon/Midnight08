using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class FlaskClient : MonoBehaviour
{
    public Image targetImage; // 알파 값을 조절할 이미지
    public Image errorImage; // 에러 이미지
    public float duration = 2.0f; // 알파 값 변화에 걸릴 시간
    private float elapsedTime = 0.0f; // 경과 시간
    private Color originalColor; // 원본 색상
    //public string targetMessage = "message : 0"; // 원하는 메시지
    public int targetMessageValue = 0; // 메시지 성공 값
    public int targetMessageValueFlase = 1; // 메시지 실패 값
    public AudioSource audioSource; // AudioSource 컴포넌트
    public AudioClip wavAudioClip; // WAV 오디오 클립
    bool bEnding; // 엔딩 이미지
    bool errorImage0; // 에러 이미지
    
    public float errorCloseTime = 2; // 에러 이미지 끌 시간
    private float activationTime; // 에러 이미지 활성화된 시간
    // Start is called before the first frame update
    void Start()
    {
        // 시작 시 원본 색상 및 알파 값 초기화
        originalColor = targetImage.color;
        targetImage.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0);

        // AudioClip을 WAV 오디오 파일로 설정
        audioSource.clip = wavAudioClip;

        errorImage.gameObject.SetActive(false);
    }

    public void Update()
    {
        if (bEnding == true)
        {
            AlphaChange();
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            HttpInfo info = new HttpInfo();
            info.Set(RequestType.GET, "/test", (DownloadHandler downloadHandler) =>
            {
                print("OnReceiveGet : " + downloadHandler.text);
            });
            HttpManager.Get().SendRequest(info);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            HttpInfo info = new HttpInfo();
            info.Set(RequestType.FILE_UPLOAD, "/test", (DownloadHandler downloadHandler) =>
            {
                print("OnReceiveGet : " + downloadHandler.text);
                AAA aaa = JsonUtility.FromJson<AAA>(downloadHandler.text);
                print(aaa.message);
                //print(int.TryParse(aaa.message));

                if (int.TryParse(aaa.message, out int messageValue))
                {
                    //print(messageValue);
                    if (messageValue == targetMessageValue)
                    {
                        bEnding = true;
                    }
                    else if (messageValue == targetMessageValueFlase)
                    {
                        print("dddddddddddddddddd");
                        errorImage.gameObject.SetActive(true);

                        Invoke("TargetImageEnactive", errorCloseTime);



                    }
                }  
            });
            HttpManager.Get().SendRequest(info);
        }
    }
    void TargetImageEnactive()
    {
        errorImage.gameObject.SetActive(false);
    }




    IEnumerator GetRequest(string url)
    {
        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Received: " + www.downloadHandler.text);
            }
        }
    }

    public void AlphaChange()
    {
        //print("dddddddddddddddddddddd");        // 시간에 따라 알파 값을 변경
        if (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / duration);
            float smoothT = Mathf.SmoothStep(0, 1, t);
            float alpha = Mathf.Lerp(0 /255, 255/255, smoothT);
            Color newColor = targetImage.color;
            newColor.a = alpha;
            targetImage.color = newColor;
            audioSource.Play(); // 오디오 재생
        }
    }
}