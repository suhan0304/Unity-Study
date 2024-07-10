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
    [SerializeField, TabGroup("Tap","Control Buttons")] private int selectedTabNumber = 0;

    // Odin - Tap Define 
    [TabGroup("Tap","Control Buttons",SdfIconType.CodeSlash, TextColor="red")]
    [TabGroup("Tap","Control Cards",SdfIconType.CodeSlash, TextColor="green")]

    void Start() {
        //InitButtons();
    }


#region ControlButtons

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
            button.TabNumber = _tabNumber++;
            controlButtons.Add(button);
        }
        Debug.Log($"[UI Manager] {controlButtons.Count} Buttons Initialized");
    }

    void OnSelectControlButton(Control_Button currentButton, int currentTabNumber) {

        Debug.Log($"[UI Manager][{selectedTabNumber} - {currentTabNumber}] Button Select");
        if (selectedTabNumber != 0) {
            selectedButton.ToggleSelectStyle(selectedButton, selectedTabNumber);
            if (selectedTabNumber == currentTabNumber) {
                selectedButton = null;
                selectedTabNumber = 0;
                return;
            }
        }
        // change selected Button
        selectedButton = currentButton; 
        selectedTabNumber = currentButton.TabNumber;
        
        // TODO - Cards Update (Tab Number!)

        // Show Updated Cards
        ShowCards();
    }

#endregion

#region ControlCards

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
        foreach (var card in cards) {
            controlCards.Add(card);
        }
        Debug.Log($"[UI Manager] {controlCards.Count} Cards Initialized");
    }

    [TabGroup("Tap","Control Cards")]
    [Button("Toggle Show Card Menus")]
    void ShowCards() {
        Debug.LogWarning($"[UI Manager] Show Cards");
        for (int i = 0; i < controlCards.Count; i++) {
            controlCards[i].AddToClassList($"card-{i}");
            controlCards[i].AddToClassList($"card-{i + 1}--out");
        }
    }

    [TabGroup("Tap","Control Cards")]
    [Button("Toggle Hide Card Menus")]
    void HideCards() {
        Debug.LogWarning($"[UI Manager] Hide Cards");
        for (int i = 0; i < controlCards.Count; i++) {
            controlCards[i].RemoveFromClassList($"card-{i}");
            controlCards[i].RemoveFromClassList($"card-{i + 1}--out");
        }
    }

#endregion

#if UNITY_EDITOR
    [Button("Init All Element"), GUIColor(1,1,1)]
    void Init() {
        InitButtons();
        InitCards();
    }

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
