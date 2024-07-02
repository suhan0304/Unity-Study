using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

// Static class
public static class ExtensionMethods 
{
    // UI Tool Kit screen Pos를 World Pos로 바꿈
    public static Vector3 ScreenPosToWorldPos(this Vector2 screenPos, Camera camera = null, float zDepth = 10f) {
        if (camera == null)
            camera = Camera.main;
        
        if (camera == null) 
            return Vector2.zero;

        float xPos = screenPos.x;
        float yPos = screenPos.y;
        Vector3 worldPos = Vector3.zero;

        if( !float.IsNaN(screenPos.x) && !float.IsNaN(screenPos.y) && !float.IsInfinity(screenPos.x) && !float.IsInfinity(screenPos.y)) {
            // Camera class를 사용해서 world space로 변환
            Vector3 screenCoord = new Vector3(xPos, yPos, zDepth);
            worldPos = camera.ScreenToWorldPoint(screenCoord);
        }

        return worldPos;
    }

    // UI Tool Kit ClickEvent 위치에서 화면 좌표를 가져옴
    public static Vector2 GetScreenCoordinate(this Vector2 clickPosition, VisualElement rootVisualElement) {
        float borderLeft = rootVisualElement.resolvedStyle.borderLeftWidth;
        float borderTop = rootVisualElement.resolvedStyle.borderTopWidth;
        clickPosition.x += borderLeft;
        clickPosition.y += borderTop;

        Vector2 normalizedPosition = clickPosition.NormalizeClickEventPosition(rootVisualElement);

        float xValue = normalizedPosition.x * Screen.width;
        float yValue = normalizedPosition.y * Screen.height;
        return new Vector2(xValue, yValue);
    }

    // UI ToolKit 클릭 이벤트 위치를 (0,0)과 (1,1) 사이 값으로 정규화 해줌
    public static Vector2 NormalizeClickEventPosition(this Vector2 clickPosition, VisualElement rootVisualElement) {
        // UI Toolkit에서 화면 경계를 나타내는 Rect를 가져옴
        Rect rootWorldBound = rootVisualElement.worldBound;

        float normalizedX = clickPosition.x / rootWorldBound.xMax;

        // Flip the y value (0이 스크린의 바닥)
        float normalizedY = 1 - clickPosition.y / rootWorldBound.yMax;

        return new Vector2(normalizedX, normalizedY);
    } 
}
