using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
public class SafeArea : MonoBehaviour
{

    private RectTransform safeAreaRect;
    private Canvas canvas;
    public bool isScrollingContent = false;
    bool isUpdatedScrolling = false;
    private Rect lastSafeArea;
    void Awake()
    {
        safeAreaRect = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        OnRectTransformDimensionsChange();
    }

    private void OnRectTransformDimensionsChange()
    {
        var safeArea = GetSafeArea();
        if (canvas != null && safeArea != lastSafeArea)
        {
            UpdateSizeToSafeArea(safeArea);
            lastSafeArea = safeArea;
        }
    }

    private void UpdateSizeToSafeArea(Rect safeArea)
    {
        if (!isScrollingContent)
        {
            safeAreaRect.anchoredPosition = Vector2.zero;
            safeAreaRect.sizeDelta = Vector2.zero;

            var anchorMin = safeArea.position;
            var anchorMax = safeArea.position + safeArea.size;
            anchorMin.x /= Screen.width;
            anchorMin.y /= Screen.height;
            anchorMax.x /= Screen.width;
            anchorMax.y /= Screen.height;
            safeAreaRect.anchorMin = anchorMin;
            safeAreaRect.anchorMax = anchorMax;
        }
        else
        {
            if (!isUpdatedScrolling)
            {
                for (int i = 0; i < safeAreaRect.transform.childCount; i++)
                {
                    safeAreaRect.transform.GetChild(i).GetComponent<RectTransform>().anchoredPosition += Vector2.down * GetTopDistance(transform);
                }
                isUpdatedScrolling = true;
            }
        }
    }

    private Rect GetSafeArea()
    {
#if UNITY_EDITOR
        if (GlobalConfig.instance.testNotchDevices)
        {
            return new Rect(0, 0, Screen.width, Screen.height * 0.95f);
        }
        else
        {
            return new Rect(0, 0, Screen.width, Screen.height);
        }
#else
		return Screen.safeArea;
#endif
    }
    public static float GetTopDistance(Transform source)
    {
#if UNITY_EDITOR
        if (GlobalConfig.instance.testNotchDevices)
        {
            return 36;
        }
        else
        {
            return 0;
        }
#else
		return (Screen.height - Screen.safeArea.yMax) * source.GetComponentInParent<CanvasScaler>().referenceResolution.y/Screen.height;
#endif
    }
}

