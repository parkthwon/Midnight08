using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class FlaskClient : MonoBehaviour
{
    public Image targetImage; // ���� ���� ������ �̹���
    public Image errorImage; // ���� �̹���
    public float duration = 2.0f; // ���� �� ��ȭ�� �ɸ� �ð�
    private float elapsedTime = 0.0f; // ��� �ð�
    private Color originalColor; // ���� ����
    //public string targetMessage = "message : 0"; // ���ϴ� �޽���
    public int targetMessageValue = 0; // �޽��� ���� ��
    public int targetMessageValueFlase = 1; // �޽��� ���� ��
    public AudioSource audioSource; // AudioSource ������Ʈ
    public AudioClip wavAudioClip; // WAV ����� Ŭ��
    bool bEnding; // ���� �̹���
    bool errorImage0; // ���� �̹���
    
    public float errorCloseTime = 2; // ���� �̹��� �� �ð�
    private float activationTime; // ���� �̹��� Ȱ��ȭ�� �ð�
    // Start is called before the first frame update
    void Start()
    {
        // ���� �� ���� ���� �� ���� �� �ʱ�ȭ
        originalColor = targetImage.color;
        targetImage.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0);

        // AudioClip�� WAV ����� ���Ϸ� ����
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
        //print("dddddddddddddddddddddd");        // �ð��� ���� ���� ���� ����
        if (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / duration);
            float smoothT = Mathf.SmoothStep(0, 1, t);
            float alpha = Mathf.Lerp(0 /255, 255/255, smoothT);
            Color newColor = targetImage.color;
            newColor.a = alpha;
            targetImage.color = newColor;
            audioSource.Play(); // ����� ���
        }
    }
}