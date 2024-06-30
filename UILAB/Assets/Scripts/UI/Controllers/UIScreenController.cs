using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class UIScreenController : MonoBehaviour
{
    [Header("UI Elements")]
    [Tooltip("UI Document")]
    [SerializeField] UIDocument m_Document;
    [SerializeField] Button m_CoinButton;
    [SerializeField] Button m_ResetButton;

    VisualElement root;

    private const string coinButtonID = "Button--Coin";
    private const string coinResetID = "Button--Reset";

    void OnEnable() {
        root = m_Document.rootVisualElement;
        m_CoinButton = root.Q<Button>(coinButtonID);
        m_ResetButton = root.Q<Button>(coinResetID);

        m_CoinButton.RegisterCallback<ClickEvent>(OnClickCoinButton);
        m_ResetButton.RegisterCallback<ClickEvent>(OnClickResetButton);
    }

    void OnDisable() {
        m_CoinButton.UnregisterCallback<ClickEvent>(OnClickCoinButton);
        m_ResetButton.UnregisterCallback<ClickEvent>(OnClickResetButton);
    }

    void OnClickCoinButton(ClickEvent evt) {
        Vector2 clickPos = new Vector2(evt.position.x, evt.position.y);
        Debug.Log($"[UIScreenController] OnClickCoinButton : clickPos ({clickPos.x}, {clickPos.y})");
        Vector2 screenPos = clickPos.GetScreenCoordinate(root);

        CoinEvents.CoinButtonClick?.Invoke(screenPos);
    }

    void OnClickResetButton(ClickEvent evt) {
        return;
    }
}
