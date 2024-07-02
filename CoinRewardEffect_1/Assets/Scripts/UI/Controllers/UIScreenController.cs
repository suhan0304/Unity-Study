using UnityEngine;
using UnityEngine.UIElements;

public class UIScreenController : MonoBehaviour
{
    [Header("UI Elements")]
    [Tooltip("UI Document")]
    [SerializeField] UIDocument m_Document;
    [SerializeField] Button m_CoinButton;
    [SerializeField] Button m_ResetButton;
    [SerializeField] Label m_CoinLabel;

    VisualElement root;

    private const string coinButtonID = "Button--Coin";
    private const string coinResetID = "Button--Reset";
    private const string coinLabelID = "Label--Coin";

    private const string coinSequenceId = "CoinSeq";

    void OnEnable() {
        root = m_Document.rootVisualElement;
        m_CoinButton = root.Q<Button>(coinButtonID);
        m_ResetButton = root.Q<Button>(coinResetID);
        m_CoinLabel = root.Q<Label>(coinLabelID);

        m_CoinButton.RegisterCallback<ClickEvent>(OnClickCoinButton);
        m_ResetButton.RegisterCallback<ClickEvent>(OnClickResetButton);

        CoinEvents.CoinUpdate +=  OnUpdateCoinText;
    }

    void OnDisable() {
        m_CoinButton.UnregisterCallback<ClickEvent>(OnClickCoinButton);
        m_ResetButton.UnregisterCallback<ClickEvent>(OnClickResetButton);

        CoinEvents.CoinUpdate -=  OnUpdateCoinText;
    }

    void OnClickCoinButton(ClickEvent evt) {
        Vector2 clickPos = new Vector2(evt.position.x, evt.position.y);

        Vector2 screenPos = clickPos.GetScreenCoordinate(root);

        
        Debug.Log($"[UIScreenController] OnClickCoinButton : clickPos ({clickPos.x}, {clickPos.y})");
        Debug.Log($"[UIScreenController] OnClickCoinButton : screenPos ({screenPos.x}, {screenPos.y})");

        CoinEvents.CoinButtonClick?.Invoke(screenPos);

        GameDataManager.AddCoin();
    }

    void OnUpdateCoinText(int CoinValue) {
        m_CoinLabel.text = CoinValue.ToString();
    }

    void OnClickResetButton(ClickEvent evt) {
        return;
    }
}
