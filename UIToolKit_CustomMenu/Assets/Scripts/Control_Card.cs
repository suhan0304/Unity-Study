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

    public Control_Card() {
        // 카드 뒷배경
        _card_BackGround = new VisualElement();
        Add(_card_BackGround);
    }
}
