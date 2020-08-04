#region License
/*
 * Copyright (c) 2018 AutoCore
 */
#endregion

using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.SimuUI
{
    public class AimPos : MonoBehaviour
    {
        public Vector3 Value;
        public InputField inputField_X;
        public InputField inputField_Y;
        public Button btn_Delete;
        void Start()
        {
            inputField_X.onEndEdit.AddListener(
                (string value) =>
                {
                    if (float.TryParse(value, out float num))
                    {
                        Value.x = num;
                    }
                });
            inputField_Y.onEndEdit.AddListener(
                (string value) =>
                {
                    if (float.TryParse(value, out float num))
                    {
                        Value.z = num;
                    }
                });
        }
        public void Init(Vector3 pos)
        {
            Value = pos;
            inputField_X.text = Value.x.ToString();
            inputField_Y.text = Value.z.ToString();
            btn_Delete.onClick.RemoveAllListeners();
            btn_Delete.onClick.AddListener(() =>
            {
                Destroy(gameObject);
            });
        }
        private void OnDestroy()
        {
            Destroy(gameObject);
        }
    }

}
