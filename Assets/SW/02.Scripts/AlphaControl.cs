using UnityEngine;
using UnityEngine.UI;

public class AlphaControl : MonoBehaviour
{
    public Image targetImage; // 알파 값을 조절할 이미지
    public float duration = 2.0f; // 알파 값 변화에 걸릴 시간
    private float elapsedTime = 0.0f; // 경과 시간
    public string networkData = "1"; // 네트워크로부터 받는 데이터
    private Color originalColor; // 원본 색상

    
    private void Start()
    {
        // 시작 시 원본 색상 및 알파 값 초기화
        originalColor = targetImage.color;
        targetImage.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0);
    }

    private void Update()
    {
        // 시간에 따라 알파 값을 변경
        if (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / duration);
            float smoothT = Mathf.SmoothStep(0, 1, t);
            float alpha = Mathf.Lerp(0, 1, smoothT);
            Color newColor = targetImage.color;
            newColor.a = alpha;
            targetImage.color = newColor;
        }
    }
}