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
    [SerializeField, TabGroup("Tap","Control Buttons")] private int seletedTabNumber = 0;

    // Odin - Tap Define 
    [TabGroup("Tap","Control Buttons",SdfIconType.CodeSlash, TextColor="red")]
    [TabGroup("Tap","Control Cards",SdfIconType.CodeSlash, TextColor="green")]

    void Start() {
        //InitButtons();
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
        int _tabNumber = 1;
        foreach (var button in buttons) {
            button.OnSelect += OnSelectControlButton;
            button.OnSelect += ToggleShowHideCards;
            button.TabNumber = _tabNumber++;
            controlButtons.Add(button);
        }
        Debug.Log($"[UI Manager] {controlButtons.Count} Buttons Initialized");
    }

    [TabGroup("Tap","Control Cards")]
    [Button("Init Control Button List"), GUIColor(0,1,0)]
    void InitCards() {
        var root = UI_Doc.rootVisualElement;

        // Clear Control Card List
        if (controlCards != null && controlCards.Count > 0)
            controlCards.Clear();
        
        // Load Control Card in UI_Doc
        controlCards = new List<Control_Card>();
        var cards = root.Query<Control_Card>().ToList();
        int cardIndex = 1;
        foreach (var card in cards) {
            card.AddToClassList($"card-{cardIndex++}");
            controlCards.Add(card);
        }
        Debug.Log($"[UI Manager] {controlCards.Count} Cards Initialized");
    }

    [TabGroup("Tap","Control Cards")]
    [Button("Toggle Show/Hide Card Menus")]
    void ToggleShowHideCards(Control_Button currentButton, int tabNumber) {
        for (int i = 0; i < controlCards.Count; i++) {
            controlCards[i].ToggleInClassList($"card-{i + 1}--out");
        }
    }

    void OnSelectControlButton(Control_Button currentButton, int tabNumber) {

        if (selectedButton == currentButton) {
            Debug.Log($"[UI Manager] Control Button Unselect.");
            seletedTabNumber = 0;
            selectedButton = null;
            return;
        }
        
        if (selectedButton != null) 
            selectedButton.ToggleSelectStyle(selectedButton, selectedButton.TabNumber); // Untoggle SelectedButton

        // change selected Button
        selectedButton = currentButton; 
        seletedTabNumber = currentButton.TabNumber;
        Debug.Log($"[UI Manager][{tabNumber}] {currentButton.GetLabelText()} Button Select");
    }

#if UNITY_EDITOR
    [TabGroup("Tap","Control Buttons")]
    [Button("Check Selected Control Button")]
    void CheckSelectedControlButton() {
        if (selectedButton != null)
            Debug.Log($"[Control Button Manager][{selectedButton.TabNumber}] {selectedButton.GetLabelText()} Button Selected Now!");
        else 
            Debug.Log($"[Control Button Manager] No buttons are selected.");
    }
#endif
}
