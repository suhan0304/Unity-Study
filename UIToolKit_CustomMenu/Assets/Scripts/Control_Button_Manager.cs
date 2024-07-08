using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Sirenix.OdinInspector;

public class Control_Button_Manager : MonoBehaviour
{
    [SerializeField] private UIDocument UI_Doc;
    [SerializeField] private List<Control_Button> controlButtons;

    [SerializeField] public Control_Button selectedButton;

    [Button("Init Control Buttons List")]
    void Init() {
        var root = GetComponent<UIDocument>().rootVisualElement;

        // UQuery
        controlButtons = new List<Control_Button>();
        var buttons = root.Query<Control_Button>().ToList();
        foreach (var button in buttons) {

            button.OnSelect += OnSelectControlButton;

            controlButtons.Add(button);
        }
        Debug.Log($"[Control Button Manager] {controlButtons.Count} Buttons Update");
    }

    void OnSelectControlButton(Control_Button currentButton, int cardNumber) {
        Debug.Log($"[Control Button Manager] {cardNumber} Button is Select Now!");
        if (currentButton != selectedButton) {
            selectedButton?.ToggleSelectStyle(selectedButton, selectedButton.CardNumber);
            selectedButton = currentButton;
            currentButton.ToggleSelectStyle(currentButton, cardNumber);
        }
    }
}
