using System;
using System.Collections.Generic;
using UnityEngine.UIElements;

public class Control_Card : VisualElement
{
    internal new class UxmlFactory : UxmlFactory<Control_Card, UxmlTraits> { }

    internal new class UxmlTraits : VisualElement.UxmlTraits {
        private readonly UxmlStringAttributeDescription m_CardLabel 
            = new UxmlStringAttributeDescription { name = "card_Label", defaultValue = "0nd Champion" };
        private readonly UxmlStringAttributeDescription m_ButtonLabel
            = new UxmlStringAttributeDescription { name = "button_Label", defaultValue = "Select" };

        public override IEnumerable<UxmlChildElementDescription> uxmlChildElementsDescription 
        {
            get { yield break;}
        }

        public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc)
        {
            base.Init(ve, bag, cc);
            ((Control_Card)ve).CardLabel = m_CardLabel.GetValueFromBag(bag, cc);
            ((Control_Card)ve).ButtonLabel = m_ButtonLabel.GetValueFromBag(bag, cc);
        }
    }
    public string CardLabel { 
        get { return _card_Label.text; }
        set{ _card_Label.text = value; }
    }
    public string ButtonLabel {
        get { return _button_label.text; }
        set{ _button_label.text = value; }
    }

    public int CardNumber;

    private VisualElement _card_BackGround;
    private VisualElement _card_Image;
    private Label _card_Label;
    
    private VisualElement _card_Button;
    private VisualElement _button_icon;
    private Label _button_label;

    public event Action<Control_Card> OnHover;
    public event Action<Control_Card, int> OnSelect;

    public Control_Card() 
    {
        // 카드 뒷배경
        _card_BackGround = new VisualElement { name = "Card_Background" };
        Add(_card_BackGround);

        // 카드 이미지
        _card_Image = new VisualElement { name = "Card_Image" };
        _card_BackGround.Add(_card_Image);

        // 카드 레이블
        _card_Label = new Label { name = "Card_Label" };
        _card_BackGround.Add(_card_Label);

        // 카드 버튼
        _card_Button = new VisualElement { name = "Card_Button" };
        Add(_card_Button);

        // 버튼 아이콘
        _button_icon = new VisualElement { name = "Button_Icon" };
        _card_Button.Add(_button_icon);

        // 버튼 레이블
        _button_label = new Label { name = "Button_Label" };
        _card_Button.Add(_button_label);

        // Preventing Clicks
        _card_BackGround.pickingMode = PickingMode.Ignore;
        _card_Image.pickingMode = PickingMode.Ignore;
        _card_Label.pickingMode = PickingMode.Ignore;
        _card_Button.pickingMode = PickingMode.Ignore;
        _button_icon.pickingMode = PickingMode.Ignore;
        _button_label.pickingMode = PickingMode.Ignore;

        // Load and apply the stylesheet
        this.AddToClassList("card--normal");
        _card_BackGround.AddToClassList("card__background--normal");
        _card_Image.AddToClassList("card__image--normal");
        _card_Label.AddToClassList("card__label--normal");
        _card_Button.AddToClassList("card__button--normal");
        _button_icon.AddToClassList("button__icon--normal");
        _button_label.AddToClassList("button__label--normal");


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
    public void ToggleHoverStyle(Control_Card m_card)
    {
        _card_Image.ToggleInClassList("card__image--hover");
        _card_Button.ToggleInClassList("card__button--hover");
        _button_icon.ToggleInClassList("button__icon--hover");
        _button_label.ToggleInClassList("button__label--hover");
    }

    // Select Style Toggle Method
    public void ToggleSelectStyle(Control_Card m_card, int m_cardNum) {
    }

    // Card Style Update Method
    public void CardStyleUpda(int card_num) {
        this.AddToClassList($"card-{card_num}");
    }
}
