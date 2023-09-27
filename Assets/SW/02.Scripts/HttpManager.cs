using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

// https://jsonplaceholder.typicode.com



[Serializable]
public class JsonList<T>
{
    public List<T> data;
}

[Serializable]
public class AAA
{
    public string message;
}

public enum RequestType
{
    GET,
    POST,
    PUT,
    DELETE,
    TEXTURE,
    FILE_UPLOAD
}

// 웹 통신하기 위한 정보
public class HttpInfo
{
    public RequestType requestType;
    public string url = "";
    public string body = "{}";
    public Action<DownloadHandler> onReceive;

    public void Set(RequestType type, string u, Action<DownloadHandler> callback, bool useDefaultUrl = true)
    {
        requestType = type;
        if (useDefaultUrl) url = "http://172.16.17.78:5000";
        url += u;
        onReceive = callback;
    }
}

public class HttpManager : MonoBehaviour
{
    static HttpManager instance;
   
    public static HttpManager Get()
    {
        if(instance == null)
        {
            // 게임 오브젝트 만든다
            GameObject go = new GameObject("HttpStudy");
            // 만들어진 게임 오브젝트에 HttpManager 컴포넌트 붙이자
            go.AddComponent<HttpManager>();
        }

        return instance;
    }
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    // 서버에게 REST API 요청 (GET, POST, PTU, DELETE)
    public void SendRequest(HttpInfo httpInfo)
    {
        StartCoroutine(CoSendRequest(httpInfo));
    }

    IEnumerator CoSendRequest(HttpInfo httpInfo)
    {
        // 로딩바 돌게

        UnityWebRequest req = null;

        // POST, GET, PUT, DELETE 분기
        switch(httpInfo.requestType)
        {
            case RequestType.GET:
                // GET 방식으로 req 에 정보 셋팅
                req = UnityWebRequest.Get(httpInfo.url);
                break;
            case RequestType.POST:

                req = UnityWebRequest.Post(httpInfo.url, httpInfo.body);
                byte[] byteBody = Encoding.UTF8.GetBytes(httpInfo.body);
                req.uploadHandler = new UploadHandlerRaw(byteBody);
                //헤더 추가
                req.SetRequestHeader("Content-Type", "application/json");
                break;
            case RequestType.PUT:
                req = UnityWebRequest.Put(httpInfo.url, "");
                break;
            case RequestType.DELETE:
                req = UnityWebRequest.Delete(httpInfo.url);
                break;
            case RequestType.TEXTURE:
                req = UnityWebRequestTexture.GetTexture(httpInfo.url);
                break;
            case RequestType.FILE_UPLOAD:

                FileStream file = new FileStream(Application.dataPath + "/test1.wav", FileMode.Open);
                // file 의 크기만큼 byte 배열을 할당한다.
                byte[] byteData = new byte[file.Length];
                // byteData 에 file 의 내용을 읽어온다.
                file.Read(byteData, 0, byteData.Length);
                // file 을 닫아주자
                file.Close();

                WWWForm form = new WWWForm();
                form.AddBinaryData("file", byteData);
                req = UnityWebRequest.Post(httpInfo.url, form);
                break;
        }

        //Get 방식으로 req 에 정보 셋팅
        //req = UnityWebRequest.Get(httpInfo.url);

        // 서버에 요청을 보내고 응답이 올 때까지 양보한다.
        yield return req.SendWebRequest();

        // 만약에 응답이 성공했다면
        if(req.result == UnityWebRequest.Result.Success)
        {
            //print("네트워크 응답 : " + req.downloadHandler.text);

            if (httpInfo.onReceive != null)
            {
                httpInfo.onReceive(req.downloadHandler);
            }
        }
        // 통신 실패
        else
        {
            print("네트워크 에러 : " + req.error);
        }

        req.Dispose();
        // 로딩바 안 돌게
    }
}
