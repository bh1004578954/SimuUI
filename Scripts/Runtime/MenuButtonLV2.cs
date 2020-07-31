using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Scripts.SimuUI
{
    [RequireComponent(typeof(Button))]
    public class MenuButtonLV2 : MonoBehaviour
    {
        Button button;
        void Start()
        {
            button = GetComponent<Button>();
            button.onClick.AddListener(() =>
            {
                PanelTools.Instance.CloseAllMenu();
            });
        }
    }
}
