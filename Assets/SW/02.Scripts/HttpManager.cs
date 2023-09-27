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

// �� ����ϱ� ���� ����
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
            // ���� ������Ʈ �����
            GameObject go = new GameObject("HttpStudy");
            // ������� ���� ������Ʈ�� HttpManager ������Ʈ ������
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

    // �������� REST API ��û (GET, POST, PTU, DELETE)
    public void SendRequest(HttpInfo httpInfo)
    {
        StartCoroutine(CoSendRequest(httpInfo));
    }

    IEnumerator CoSendRequest(HttpInfo httpInfo)
    {
        // �ε��� ����

        UnityWebRequest req = null;

        // POST, GET, PUT, DELETE �б�
        switch(httpInfo.requestType)
        {
            case RequestType.GET:
                // GET ������� req �� ���� ����
                req = UnityWebRequest.Get(httpInfo.url);
                break;
            case RequestType.POST:

                req = UnityWebRequest.Post(httpInfo.url, httpInfo.body);
                byte[] byteBody = Encoding.UTF8.GetBytes(httpInfo.body);
                req.uploadHandler = new UploadHandlerRaw(byteBody);
                //��� �߰�
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
                // file �� ũ�⸸ŭ byte �迭�� �Ҵ��Ѵ�.
                byte[] byteData = new byte[file.Length];
                // byteData �� file �� ������ �о�´�.
                file.Read(byteData, 0, byteData.Length);
                // file �� �ݾ�����
                file.Close();

                WWWForm form = new WWWForm();
                form.AddBinaryData("file", byteData);
                req = UnityWebRequest.Post(httpInfo.url, form);
                break;
        }

        //Get ������� req �� ���� ����
        //req = UnityWebRequest.Get(httpInfo.url);

        // ������ ��û�� ������ ������ �� ������ �纸�Ѵ�.
        yield return req.SendWebRequest();

        // ���࿡ ������ �����ߴٸ�
        if(req.result == UnityWebRequest.Result.Success)
        {
            //print("��Ʈ��ũ ���� : " + req.downloadHandler.text);

            if (httpInfo.onReceive != null)
            {
                httpInfo.onReceive(req.downloadHandler);
            }
        }
        // ��� ����
        else
        {
            print("��Ʈ��ũ ���� : " + req.error);
        }

        req.Dispose();
        // �ε��� �� ����
    }
}
