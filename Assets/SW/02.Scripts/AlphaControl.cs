using UnityEngine;
using UnityEngine.UI;

public class AlphaControl : MonoBehaviour
{
    public Image targetImage; // ���� ���� ������ �̹���
    public float duration = 2.0f; // ���� �� ��ȭ�� �ɸ� �ð�
    private float elapsedTime = 0.0f; // ��� �ð�
    public string networkData = "1"; // ��Ʈ��ũ�κ��� �޴� ������
    private Color originalColor; // ���� ����

    
    private void Start()
    {
        // ���� �� ���� ���� �� ���� �� �ʱ�ȭ
        originalColor = targetImage.color;
        targetImage.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0);
    }

    private void Update()
    {
        // �ð��� ���� ���� ���� ����
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