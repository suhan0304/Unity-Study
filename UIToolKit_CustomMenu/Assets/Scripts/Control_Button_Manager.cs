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

    [Button("Init Control Button List")]
    void Init() {
        var root = UI_Doc.rootVisualElement;

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
        if (selectedButton != null && selectedButton != currentButton) {
            selectedButton.ToggleSelectStyle(selectedButton, selectedButton.CardNumber);
        }
        if (selectedButton != currentButton) {
            selectedButton = currentButton;
            selectedButton.ToggleSelectStyle(selectedButton, cardNumber);
        }

    }
}
