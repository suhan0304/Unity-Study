using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UIElements;

public class UI_Manager : MonoBehaviour
{
    [SerializeField] private UIDocument UI_Doc;
    [SerializeField] private List<Control_Button> controlButtons;
    [SerializeField] private List<Control_Card> controlCards;

    [SerializeField] private Control_Button selectedButton;
    [SerializeField, TabGroup("Tap","Control Buttons")] private int seletedCardNumber = 0;

    // Odin - Tap Define 
    [TabGroup("Tap","Control Buttons",SdfIconType.CodeSlash, TextColor="red")]

    void Start() {
        InitButtons();
    }


    [TabGroup("Tap","Control Buttons")]
    [Button("Init Control Button List"), GUIColor(0,1,0)]
    void InitButtons() {
        var root = UI_Doc.rootVisualElement;

        // Clear Control Button List
        if (controlButtons != null && controlButtons.Count > 0)
            controlButtons.Clear();

        // Load Control Button in UI_Doc
        controlButtons = new List<Control_Button>();
        var buttons = root.Query<Control_Button>().ToList();
        int _CardNumber = 1;
        foreach (var button in buttons) {
            button.OnSelect += OnSelectControlButton;
            button.CardNumber = _CardNumber++;
            controlButtons.Add(button);
        }
        Debug.Log($"[Control Button Manager] {controlButtons.Count} Buttons Initialized");
    }

    void OnSelectControlButton(Control_Button currentButton, int cardNumber) {
        Debug.Log($"[Control Button Manager][{cardNumber}] {currentButton.GetLabelText()} Button Select");

        if (selectedButton == currentButton) {
            seletedCardNumber = 0;
            selectedButton = null;
            return;
        }
        
        if (selectedButton != null) 
            selectedButton.ToggleSelectStyle(selectedButton, cardNumber); // Untoggle SelectedButton

        // change selected Button
        selectedButton = currentButton; 
        seletedCardNumber = currentButton.CardNumber;
    }

#if UNITY_EDITOR
    [TabGroup("Tap","Control Buttons")]
    [Button("Check Selected Control Button")]
    void CheckSelectedControlButton() {
        if (selectedButton != null)
            Debug.Log($"[Control Button Manager][{selectedButton.CardNumber}] {selectedButton.GetLabelText()} Button Selected Now!");
        else 
            Debug.Log($"[Control Button Manager] No buttons are selected.");
    }
#endif
}
