using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace DTInventory {

    public class Tooltip : MonoBehaviour
    {
        public Text itemName;
        public Text itemDescription;

        public static Text s_itemName;
        public static Text s_itemDescription;

        public static RectTransform m_rectTransform;

        public static Tooltip instance;

        private void Start()
        {
            instance = this;

            m_rectTransform = GetComponent<RectTransform>();

            s_itemName = itemName;
            s_itemDescription = itemDescription;
        }

        public static void GenerateContent(string name, string description, Vector2 tooltipPos)
        {
            s_itemName.text = name;
            s_itemDescription.text = description;

            m_rectTransform.position = tooltipPos;

            m_rectTransform.gameObject.transform.SetAsLastSibling();
        }

        public static void HideTooltip()
        {
            m_rectTransform.anchoredPosition = new Vector2(7000, 7000);
        }
    }

}