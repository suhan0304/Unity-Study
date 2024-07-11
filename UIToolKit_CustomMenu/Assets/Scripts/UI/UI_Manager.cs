using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UIElements;
using Cysharp.Threading.Tasks;
using System;
using Unity.VisualScripting;

public class UI_Manager : MonoBehaviour
{
    // Odin - Tap Define 
    [TabGroup("Tap","Control Buttons",SdfIconType.CodeSlash, TextColor="red")]
    [TabGroup("Tap","Control Cards",SdfIconType.CodeSlash, TextColor="green")]
    [TabGroup("Tap","Tab Manager",SdfIconType.CodeSlash, TextColor="blue")]
    
    [SerializeField] private UIDocument UI_Doc;
    [SerializeField] private List<Control_Button> controlButtons;
    [SerializeField] private List<Control_Card> controlCards;

    [SerializeField] private Control_Button selectedButton;
    [SerializeField, TabGroup("Tap","Control Buttons")] private int selectedTabNumber = -1;

    [SerializeField, TabGroup("Tap","Tab Manager")] private List<TabData> tabDatas = new List<TabData>();

    void Start() {
        Init(); 
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
        int _tabNumber = 0;
        foreach (var button in buttons) {
            button.OnSelect += OnSelectControlButton;
            button.TabNumber = _tabNumber++;
            controlButtons.Add(button);
        }
        Debug.Log($"[UI Manager] {controlButtons.Count} Buttons Initialized");
    }

    async void OnSelectControlButton(Control_Button currentButton, int currentTabNumber) {
        
        if (selectedTabNumber != -1) {
            HideCards();
            await UniTask.Delay(TimeSpan.FromSeconds(0.2f));

            if (selectedTabNumber == currentTabNumber) {
                Debug.Log($"[UI Manager][{selectedTabNumber} = {currentTabNumber}] Unselect");
                selectedButton = null;
                selectedTabNumber = -1;
                return;
            }
            selectedButton.ToggleSelectStyle(selectedButton, selectedTabNumber);
            Debug.Log($"[UI Manager][{selectedTabNumber} → {currentTabNumber}] Button Select");
        }
        // change selected Button
        selectedButton = currentButton; 
        selectedTabNumber = currentButton.TabNumber;
        
        // Cards Update (using Tab Number)
        int countCards = await CardsUpdate(currentTabNumber);

        // Show Updated Cards
        ShowCards(countCards);
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
        int index = 1;
        foreach (var card in cards) {
            card.AddToClassList($"card-{index++}");
            controlCards.Add(card);
        }
        Debug.Log($"[UI Manager] {controlCards.Count} Cards Initialized");
    }

    [TabGroup("Tap","Control Cards")]
    [Button("Toggle Show Card Menus")]
    void ShowCards(int countCards) {
        Debug.LogWarning($"[UI Manager] Show Cards");
        for (int i = 0; i < countCards; i++) {
            controlCards[i].AddToClassList($"card-{i + 1}--out");
        }
    }

    [TabGroup("Tap","Control Cards")]
    [Button("Toggle Hide Card Menus")]
    void HideCards() {
        Debug.LogWarning($"[UI Manager] Hide Cards");
        for (int i = 0; i < controlCards.Count; i++) {
            controlCards[i].RemoveFromClassList($"card-{i + 1}--out");
        }
    }

    [TabGroup("Tap","Control Cards")]
    [Button("Cards Update")]
    private UniTask<int> CardsUpdate(int tabNumber) {
        List<CardData> selectedTabData = tabDatas[tabNumber].tabData;
        for (int i = 0; i < selectedTabData.Count; i++) {
            controlCards[i].set_card_Image(selectedTabData[i].card_image);
            controlCards[i].set_card_Label(selectedTabData[i].card_label_text);
        }
        return UniTask.FromResult(selectedTabData.Count);;
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
