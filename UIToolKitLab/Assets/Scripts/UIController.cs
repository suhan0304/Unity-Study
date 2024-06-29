using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIController : MonoBehaviour
{
    // Bottom - Sheet
    private VisualElement _bottomContainer;

    private Button _openButton;
    private Button _closeButton;

    private VisualElement _bottomSheet;
    private VisualElement _scrim;

    private void Start() {
        // Find Root-Element
        var root = GetComponent<UIDocument>().rootVisualElement; 

        // UQuery
        _bottomContainer = root.Q<VisualElement>("Container_Bottom");

        _openButton = root.Q<Button>("Button_Open");
        _closeButton = root.Q<Button>("Button_Close");

        _bottomSheet = root.Q<VisualElement>("BottomSheet");
        _scrim = root.Q<VisualElement>("Scrim");

        // Hide bottom-sheet
        _bottomContainer.style.display = DisplayStyle.None;

        // Button Callback
        _openButton.RegisterCallback<ClickEvent>(OnOpenButtonClicked);
        _closeButton.RegisterCallback<ClickEvent>(OnCloseButtonClicked);

    }

    private void OnOpenButtonClicked(ClickEvent evt) {
        // Open Bottom-Sheet
        _bottomContainer.style.display = DisplayStyle.Flex;

        _bottomSheet.AddToClassList("bottomsheet--up");
        _scrim.AddToClassList("Scrim--fadein");
    }

    private void OnCloseButtonClicked(ClickEvent evt) {
        // Close Bottom-Sheet
        _bottomContainer.style.display = DisplayStyle.None;

        _bottomSheet.RemoveFromClassList("bottomsheet--up");
        _scrim.RemoveFromClassList("Scrim--fadein");
    }
}

