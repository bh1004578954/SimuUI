#region License
/*
 * Copyright (c) 2018 AutoCore
 */
#endregion

using Assets.Scripts.Element;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts.SimuUI
{
    public class MainUI : PanelBase<MainUI>,ISimuPanel
    {
        public bool isMouseOnUI;
        private void Start()
        {
            Application.targetFrameRate = 60;
        }

        private float timeTemp;
        private float time_tipTemp;
        private void Update()
        {
            isMouseOnUI = EventSystem.current.IsPointerOverGameObject();
        }

        public void RResetCar()
        {
            MapManager.Instance.ResetCar();
            TestDataManager.Instance.WriteTestData("Reset ego vehicle");
        }
        public bool isCarCameraMain;

        private List<ISimuPanel> panels=new List<ISimuPanel>();
        public void CloseLastPanel()
        {
            if (panels.Count > 0)
            {
                ISimuPanel simuPanel = panels[panels.Count - 1];
                simuPanel.SetPanelActive(false);
                panels.Remove(simuPanel);
            }
        }
        public void AddPanel(ISimuPanel simuPanel)
        {
            panels.Add(simuPanel);
        }
        public void RemovePanel(ISimuPanel simuPanel)
        {
            if(panels.Contains(simuPanel)) panels.Remove(simuPanel);
        }



        public GameObject eButtonPre;
        public Transform ElementParent;
        public GameObject AddCarAIButton(GameObject car)
        {
            GameObject button = Instantiate(eButtonPre, ElementParent);
            button.GetComponent<ElementButton>().elementObj = car;
            //button.transform.SetSiblingIndex(ElementsManager.Instance.CarList.Count);
            button.name = button.transform.GetChild(0).GetComponent<Text>().text = car.name;
            ElementsManager.Instance.AddCarElement(car.GetComponent<ElementObject>());
            return button;
        }
        public GameObject AddTestCarButton(GameObject car)
        {
            GameObject button = Instantiate(eButtonPre, ElementParent);
            button.GetComponent<ElementButton>().elementObj = car;
            //button.transform.SetSiblingIndex(ElementsManager.Instance.CarList.Count);
            button.name = button.transform.GetChild(0).GetComponent<Text>().text = car.name;
            //ElementsManager.Instance.AddCarElement(car.GetComponent<ElementObject>());
            return button;
        }
        public GameObject AddHumanButton(GameObject human)
        {
            GameObject button = Instantiate(eButtonPre, ElementParent);
            button.GetComponent<ElementButton>().elementObj = human;
            //button.transform.SetSiblingIndex(ElementsManager.Instance.CarList.Count + ElementsManager.Instance.HumanList.Count);
            button.name = button.transform.GetChild(0).GetComponent<Text>().text = human.name;
            ElementsManager.Instance.AddHumanElement(human.GetComponent<ElementObject>());
            return button;
        }
        public GameObject AddTrafficLightButton(GameObject tlObj)
        {
            GameObject button = Instantiate(eButtonPre, ElementParent);
            button.GetComponent<ElementButton>().elementObj = tlObj;
            //button.transform.SetAsLastSibling();
            button.transform.GetChild(0).GetComponent<Text>().text = tlObj.name;
            ElementsManager.Instance.AddTrafficLightElement(tlObj.GetComponent<ElementObject>());
            return button;
        }
        public GameObject AddStaticButton(GameObject staticObj)
        {
            GameObject button = Instantiate(eButtonPre, ElementParent);
            button.GetComponent<ElementButton>().elementObj = staticObj;
            //button.transform.SetAsLastSibling();
            button.name = staticObj.name = button.transform.GetChild(0).GetComponent<Text>().text = staticObj.name;
            ElementsManager.Instance.AddObstacleElement(staticObj.GetComponent<ElementObject>());
            return button;
        }
        public GameObject AddCheckPointButton(GameObject checkPointObj)
        {
            GameObject button = Instantiate(eButtonPre, ElementParent);
            button.GetComponent<ElementButton>().elementObj = checkPointObj;
            //button.transform.SetAsLastSibling();
            button.name = checkPointObj.name = button.transform.GetChild(0).GetComponent<Text>().text = checkPointObj.name;
            ElementsManager.Instance.AddCheckPointElement(checkPointObj.GetComponent<ElementObject>());
            return button;
        }
    }
}