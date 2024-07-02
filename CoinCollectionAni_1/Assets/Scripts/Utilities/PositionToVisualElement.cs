using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.UIElements;

public class PositionToVisualElement : MonoBehaviour
{
    /// GameObject의 위치를 ​​지정된 UI 상의 VisualElement 위치에 할당
    
    [Header("Transform")]
    [SerializeField] GameObject m_ObjectToMode;

    [Header("Camera parameters")]
    [SerializeField] Camera m_Camera;
    [SerializeField] float m_Depth = 10f;

    [Header("UI Target")]
    [SerializeField] UIDocument m_Document;
    [SerializeField] string m_ElementName;

    VisualElement m_TargetElement;

    void OnEnable() {
        if (m_Document == null) {
            Debug.LogError("[PositionToVisualElement] : UIDocument 할당 오류");
            return;
        }

        VisualElement root = m_Document.rootVisualElement;
        m_TargetElement = root.Q<VisualElement>(name : m_ElementName);

        if (m_TargetElement == null) {
            Debug.LogError($"[PositionToVisualElement] : Element '{m_ElementName}'를 찾을 수 없습니다.");
            return;
        }
    }

    void Start() {
        MoveToElement();
    }

    public void MoveToElement() {
        if (m_Camera == null) {
            Debug.LogError("[PositionToVisualElement] MoveToElement : Camera 할당 오류");
            return;
        }

        if (m_ObjectToMode == null) {
            Debug.LogError("[PositionToVisualElement] MoveToElement : ObjectToMove 할당 오류");
            return;
        }

        // UI Tool Kit의 center screen Position 위치 계산
        Rect worldBound = m_TargetElement.worldBound;
        Vector2 centerPosion = new Vector2(worldBound.x + worldBound.width / 2, worldBound.y + worldBound.height / 2);

        // 확장 함수를 사용해서 클릭 이벤트의 screen Pos 계산
        Vector2 screenPos = centerPosion.GetScreenCoordinate(m_Document.rootVisualElement);

        // 확장 함수를 사용해서 screen Pos를 world Pos로 변환
        Vector3 worldPosition = screenPos.ScreenPosToWorldPos(m_Camera, m_Depth);

        if (m_ObjectToMode != null) {
            m_ObjectToMode.transform.position = worldPosition;
        }
    }
}
