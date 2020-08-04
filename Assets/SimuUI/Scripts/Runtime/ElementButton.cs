#region License
/*
 * Copyright (c) 2018 AutoCore
 */
#endregion
using UnityEngine;
using UnityEngine.UI;


namespace Assets.Scripts.SimuUI
{

    public class ElementButton : Button
    {
        public GameObject elementObj;
        protected override void Start()
        {
            GetComponent<Button>()?.onClick.AddListener(delegate ()
            {
            });
        }
        protected override void OnDestroy()
        {
            if (elementObj != null) Destroy(elementObj);
        }
    }
}
