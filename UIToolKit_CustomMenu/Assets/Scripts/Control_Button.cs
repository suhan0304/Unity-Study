using System;
using System.Collections.Generic;
using UnityEngine.UIElements;

public class Control_Button : VisualElement
{
    internal new class UxmlFactory : UxmlFactory<Control_Button, UxmlTraits> { }

    internal new class UxmlTraits : VisualElement.UxmlTraits {
        private readonly UxmlIntAttributeDescription m_CardNum
            = new UxmlIntAttributeDescription { name = "card_Number", defaultValue = 4 };
        private readonly UxmlStringAttributeDescription m_ButtonLabel
            = new UxmlStringAttributeDescription { name = "button_Label", defaultValue = "Menu Button" };

        public override IEnumerable<UxmlChildElementDescription> uxmlChildElementsDescription
        {
            get { yield break;}
        }

        public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc)
        {
            base.Init(ve, bag, cc);
            ((Control_Button)ve).CardNumber = m_CardNum.GetValueFromBag(bag, cc);
            ((Control_Button)ve).ButtonLabel = m_ButtonLabel.GetValueFromBag(bag, cc);
        }
    }

    public int CardNumber { get; set; }
    public string ButtonLabel {
        get { return _label.text; }
        set{ _label.text = value; }
    }

    private VisualElement _fill;
    private VisualElement _icon;
    private Label _label;

    public event Action<Control_Button> OnHover;
    public event Action<Control_Button, int> OnSelect;

    public Control_Button() 
    {
        this.name = "Background";

        // 버튼 클릭할 때 작동할 Fill 효과
        _fill = new VisualElement { name = "Fill" };
        Add(_fill);

        // 버튼 아이콘
        _icon = new VisualElement { name = "Label" };
        Add(_icon);

        // 버튼 레이블
        _label = new Label { name = "Icon" };
        Add(_label);

        // Preventing Clicks
        _fill.pickingMode = PickingMode.Ignore;
        _label.pickingMode = PickingMode.Ignore;
        _icon.pickingMode = PickingMode.Ignore;

        // Load and apply the stylesheet
        this.AddToClassList("background--normal");
        _fill.AddToClassList("fill--normal");
        _icon.AddToClassList("icon--normal");
        _label.AddToClassList("label--normal");

        // On Mouse Enter event
        this.RegisterCallback<MouseEnterEvent>(OnMouseEventControlButton);
        this.RegisterCallback<MouseLeaveEvent>(OnMouseEventControlButton);

        // On Mouse Click Event
        this.RegisterCallback<ClickEvent>(OnMouseEventControlButton);
    }   
    public void OnMouseEventControlButton(EventBase evt)
    {
        // Mouse Enter Control Button
        if (evt.eventTypeId == MouseEnterEvent.TypeId() || evt.eventTypeId == MouseLeaveEvent.TypeId()) {
            ToggleHoverStyle(this);
            OnHover?.Invoke(this);
        }

        // Mouse Click Control Button
        if (evt.eventTypeId == ClickEvent.TypeId()) {
            ToggleSelectStyle(this, CardNumber);
            OnSelect?.Invoke(this, CardNumber);
        }
    }

    // Hover Style Toggle Method
    public void ToggleHoverStyle(Control_Button m_button)
    {
        m_button.ToggleInClassList("background--hover");
        m_button._icon.ToggleInClassList("icon--hover");
        m_button._label.ToggleInClassList("label--hover");
    }

    // Select Style Toggle Method
    public void ToggleSelectStyle(Control_Button m_button, int m_cardNum) {
        m_button._fill.ToggleInClassList("fill--select");
        m_button._icon.ToggleInClassList("icon--select");
        m_button._label.ToggleInClassList("label--select");
    }

    // Get Label Text
    public string GetLabelText() {
        return _label.text;
    }
}
