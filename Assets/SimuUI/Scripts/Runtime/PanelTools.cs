using Assets.Scripts.Element;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.SimuUI
{
    public class PanelTools : PanelBase<PanelTools>, ISimuPanel
    {
        public Transform transform_menu;
        public MenuLV1[] menuButtons
        {
            get
            {
                MenuLV1[] list= GetComponentsInChildren<MenuLV1>();
                return list;
            }
        }

        string[] menuNames = new string[]
        {
        "Reset",
        "Elements",
        "Set Car Pose",
        "Settings",
        "Help",
        "Exit"
        };
        public UnityAction[] menuActions;

        public List<string[]> menusNames = new List<string[]>
    {
        new string[]{"All Reset","Car Pose Reset" },
        new string[]{"Add CarAI","Add Human", "Add Obstacle", "Remove All" }
    };
        public List<UnityAction[]> menusActions = new List<UnityAction[]>();

        public string[] menuName1 = new string[] { "All Reset", "Car Reset" };

        private MenuLV1 menuButtonSelected = null;
        public MenuLV1 MenuButtonSelected
        {
            get
            {
                return menuButtonSelected;
            }
            set
            {
                menuButtonSelected = value;
                if (menuButtonSelected != null)
                {
                    OpenSeletedMenu();
                }
            }
        }
        void Start()
        {
            menuActions = new UnityAction[]
            {
            null,
            null,
            ()=>{ ElementsManager.Instance.SetEditMode(ElementsManager.EditMode.SetCarPose);},
            ()=>{ PanelSettings.Instance.SwitchPanelActive(); },
            ()=>{ Application.OpenURL("https://github.com/autocore-ai/autocore_pcu_doc/blob/master/docs/Simulation_autoware.md"); },
            ()=>{  PanelExit.Instance.SwitchPanelActive();},
            };
            menusActions = new List<UnityAction[]>
            {
                new UnityAction[]{AllReset,CarReset },
                new UnityAction[]{ AddCarAI,AddHuman,AddObstacle,RemoveAll }
            };
            //for (int i = 0; i < menuNames.Length; i++)
            //{
            //    MenuButtonLV1 MB = Instantiate(ToolButtonLV1).GetComponent<MenuButtonLV1>();
            //    MB.transform.SetParent(transform_menu);
            //    menuButtons.Add(MB);
            //    if (i < menusNames.Count)
            //    {
            //        for (int j = 0; j < menusNames[i].Length; j++)
            //        {
            //            MB.AddMunuButton(menusNames[i][j], menusActions[i][j], ToolButtonLV2);
            //        }
            //    }
            //}
            CloseAllMenu();
        }
        public void OpenSeletedMenu()
        {
            foreach (MenuLV1 button in menuButtons)
            {
                button.SetMenuActive(button == MenuButtonSelected && !menuButtonSelected.isOpen);
            }
        }
        public void CloseAllMenu()
        {
            foreach (MenuLV1 button in menuButtons)
            {
                button.SetMenuActive(false);
            }
        }
        public void OpenGitURL()
        {
            Application.OpenURL("https://github.com/autocore-ai/autocore_pcu_doc/blob/master/docs/Simulation_autoware.md");
        }
        #region tools
        void AllReset()
        {
            MapManager.Instance.Mapinit();
        }
        void CarReset()
        {
            MapManager.Instance.ResetCar();
            TestDataManager.Instance.WriteTestData("Reset ego vehicle");
            OverLookCamera.Instance?.OLCameraReset();
        }
        void AddCarAI()
        {
            ElementsManager.Instance.SetEditMode(ElementsManager.EditMode.SetCarAI);
        }
        void AddHuman()
        {
            ElementsManager.Instance.SetEditMode(ElementsManager.EditMode.SetHuman);
        }
        void AddObstacle()
        {
            ElementsManager.Instance.SetEditMode(ElementsManager.EditMode.SetStatic);
        }
        void RemoveAll()
        {
            ElementsManager.Instance.RemoveAllElements();
        }
        
        #endregion
        public override void SetPanelActive(bool value)
        {
            return;
        }
    }
}
