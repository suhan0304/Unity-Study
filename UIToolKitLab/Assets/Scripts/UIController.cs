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

    private VisualElement _boy;
    private VisualElement _girl;

    private void Start() {
        // Find Root-Element
        var root = GetComponent<UIDocument>().rootVisualElement; 

        // UQuery
        _bottomContainer = root.Q<VisualElement>("Container_Bottom");

        _openButton = root.Q<Button>("Button_Open");
        _closeButton = root.Q<Button>("Button_Close");

        _bottomSheet = root.Q<VisualElement>("BottomSheet");
        _scrim = root.Q<VisualElement>("Scrim");

        _boy = root.Q<VisualElement>("Image_Boy");
        _girl = root.Q<VisualElement>("Image_Girl");

        // Hide bottom-sheet
        _bottomContainer.style.display = DisplayStyle.None;

        // Button Callback
        _openButton.RegisterCallback<ClickEvent>(OnOpenButtonClicked);
        _closeButton.RegisterCallback<ClickEvent>(OnCloseButtonClicked);

        // Boy Animation
        Invoke("AnimateBoy", .1f);
    }

    private void AnimateBoy() {
        _boy.RemoveFromClassList("image--boy--inair");
    }

    private void OnOpenButtonClicked(ClickEvent evt) {
        // Open Bottom-Sheet
        _bottomContainer.style.display = DisplayStyle.Flex;

        _bottomSheet.AddToClassList("bottomsheet--up");
        _scrim.AddToClassList("Scrim--fadein");

        AnimateGirl();
    }

    private void OnCloseButtonClicked(ClickEvent evt) {
        // Close Bottom-Sheet
        _bottomContainer.style.display = DisplayStyle.None;

        _bottomSheet.RemoveFromClassList("bottomsheet--up");
        _scrim.RemoveFromClassList("Scrim--fadein");
    }

    private void AnimateGirl() {
        _girl.ToggleInClassList("image--girl--up");
        _girl.RegisterCallback<TransitionEndEvent>(AnimateBackGirl);
    }

    private void AnimateBackGirl(TransitionEndEvent evt) {
        _girl.ToggleInClassList("image--girl--up");
    }
}

