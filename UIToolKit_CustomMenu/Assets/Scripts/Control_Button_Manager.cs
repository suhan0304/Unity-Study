using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Sirenix.OdinInspector;

public class Control_Button_Manager : MonoBehaviour
{
    [SerializeField] private VisualTreeAsset visualTreeAsset;
    [SerializeField] private List<Control_Button> controlButtons;

    [SerializeField] private Control_Button selectedButton;

    [Button("Init UXML VisualTree")]
    void Init() {
    }
    
    void OnSelectControlButton(Control_Button selectingButton) {
        if (selectingButton != selectedButton) {

        }
    }
}
