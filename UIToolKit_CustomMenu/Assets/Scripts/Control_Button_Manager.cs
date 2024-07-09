using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UIElements;

public class Control_Button_Manager : MonoBehaviour
{
    [SerializeField] private UIDocument UI_Doc;
    [SerializeField] private List<Control_Button> controlButtons;

    [SerializeField] private Control_Button selectedButton;

    [TabGroup("Tap","Debug",SdfIconType.CodeSlash, TextColor="red")]

    [TabGroup("Tap","Debug")]
    [Button("Init Control Button List")]
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

        // change selected Button
        selectedButton = currentButton;
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
