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
    }
}
