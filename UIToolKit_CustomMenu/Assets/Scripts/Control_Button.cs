using System;
using System.Collections.Generic;
using UnityEngine.Rendering;
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
            get {yield break;}
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
        // 버튼 클릭할 떄
        _fill = new VisualElement();
        Add(_fill);

        // 버튼 아이콘
        _icon = new VisualElement();
        Add(_icon);

        // 버튼 레이블
        _label = new Label();
        Add(_label);

        this.name = "Background";
        _fill.name = "Fill";
        _label.name = "Label";
        _icon.name = "Icon";

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
        this.RegisterCallback<MouseEnterEvent>(evt => OnHover?.Invoke(this));
        this.RegisterCallback<MouseLeaveEvent>(evt => OnHover?.Invoke(this));

        // On Mouse Click Event
        this.RegisterCallback<ClickEvent>(evt => OnSelect?.Invoke(this, CardNumber));
    }   
    
    public void AttachMethodToAction()
    {
        OnHover += ToggleHoverStyle;
        OnSelect += ToggleSelectStyle;
    }
    public void DetachMethodToAction()
    {
        OnHover -= ToggleHoverStyle;
        OnSelect -= ToggleSelectStyle;
    }

    // Hover Style Toggle Method
    private void ToggleHoverStyle(Control_Button m_button)
    {
        m_button.ToggleInClassList("background--hover");
        m_button._icon.ToggleInClassList("icon--hover");
        m_button._label.ToggleInClassList("label--hover");
    }

    // Select Style Toggle Method
    private void ToggleSelectStyle(Control_Button m_button, int m_cardNum) {
        m_button._fill.ToggleInClassList("fill--select");
        m_button._icon.ToggleInClassList("icon--select");
        m_button._label.ToggleInClassList("label--select");
    }
}
