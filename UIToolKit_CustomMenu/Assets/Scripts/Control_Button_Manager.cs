using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Sirenix.OdinInspector;

public class Control_Button_Manager : MonoBehaviour
{
    [SerializeField] private UIDocument UI_Doc;
    [SerializeField] private List<Control_Button> controlButtons;

    [SerializeField] private Control_Button selectedButton;


    [Button("Init UXML VisualTree")]
    void Init() {
        var root = GetComponent<UIDocument>().rootVisualElement;

        // UQuery
        controlButtons = new List<Control_Button>();
        var buttons = root.Query<Control_Button>().ToList();
        foreach(var button in buttons) {
            controlButtons.Add(button);
        }
    }
    
    void OnSelectControlButton(Control_Button selectingButton) {
        if (selectingButton != selectedButton) {

        }
    }
}
