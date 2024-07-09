using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UIElements;

public class Control_Button_Manager : MonoBehaviour
{
    [SerializeField] private UIDocument UI_Doc;
    [SerializeField] private List<Control_Button> controlButtons;

    [SerializeField] private Control_Button selectedButton;

    // Odin - Tap Define 
    [TabGroup("Tap","Debug",SdfIconType.CodeSlash, TextColor="red")]

    void Start() {
        Init();
    }


    [TabGroup("Tap","Debug")]
    [Button("Init Control Button List"), GUIColor(0,1,0)]
    void Init() {
        var root = UI_Doc.rootVisualElement;

        // Clear Control Button List
        if (controlButtons != null && controlButtons.Count > 0)
            controlButtons.Clear();

        // Load Control Button in UI_Doc
        controlButtons = new List<Control_Button>();
        var buttons = root.Query<Control_Button>().ToList();
        foreach (var button in buttons) {
            button.OnSelect += OnSelectControlButton;
            controlButtons.Add(button);
        }
        Debug.Log($"[Control Button Manager] {controlButtons.Count} Buttons Initialized");
    }

    void OnSelectControlButton(Control_Button currentButton, int cardNumber) {
        Debug.Log($"[Control Button Manager] {currentButton.GetLabelText()} Button Select");

        if (selectedButton == currentButton) {
            selectedButton = null;
            return;
        }
        
        if (selectedButton != null) 
            selectedButton.ToggleSelectStyle(selectedButton, cardNumber); // Untoggle SelectedButton

        selectedButton = currentButton; // change selected Button
    }

#if UNITY_EDITOR
    [TabGroup("Tap","Debug")]
    [Button("Check Selected Control Button")]
    void CheckSelectedControlButton() {
        if (selectedButton != null)
            Debug.Log($"[Control Button Manager] {selectedButton.GetLabelText()} Button Selected Now!");
        else 
            Debug.Log($"[Control Button Manager] No buttons are selected.");
    }
#endif
}
