using System;
using System.Collections.Generic;
using UnityEngine.UIElements;

public class Control_Card : VisualElement
{
    internal new class UxmlFactory : UxmlFactory<Control_Card, UxmlTraits> { }

    internal new class UxmlTraits : VisualElement.UxmlTraits {
        private readonly UxmlStringAttributeDescription m_CardLabel 
            = new UxmlStringAttributeDescription { name = "card_Label", defaultValue = "" };
        private readonly UxmlStringAttributeDescription m_ButtonLabel
            = new UxmlStringAttributeDescription { name = "button_Label", defaultValue = "Menu Button" };

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
        get; 
        set; 
    }
    public string ButtonLabel {
        get;
        set;
    }

    private VisualElement _card_BackGround;
    private VisualElement _card_Image;
    private VisualElement _card_Label;
    
    private VisualElement _card_Button;
    private VisualElement _button_icon;
    private VisualElement _button_label;

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
    }
}
