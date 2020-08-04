using UnityEngine;
using UnityEngine.UI;


namespace Assets.Scripts.SimuUI
{
    public class PanelVoyageConfig : MonoBehaviour
    {
        public GameObject Indicator;
        public Text text_Title;
        public InputField inputField_TargetSpeed;
        public InputField inputField_MinSpeed;
        public InputField inputField_MaxSpeed;
        public InputField inputField_MinDis;
        public InputField inputField_MaxDis;
        public InputField inputField_Duration;
        public Button button_Delete;
        private int index_config;
        // Start is called before the first frame update
        void Start()
        {
            inputField_TargetSpeed?.onEndEdit.AddListener((string str) =>
            {
                float value = float.Parse(str);
                value = Mathf.Clamp(value, 0, 100);
            });
            inputField_MinSpeed?.onEndEdit.AddListener((string str) =>
            {
                float value = float.Parse(str);
                value = Mathf.Clamp(value, 0, 100);
            });
            inputField_MaxSpeed?.onEndEdit.AddListener((string str) =>
            {

                float value = float.Parse(str);
                value = Mathf.Clamp(value, 0, 100);
            });
            inputField_MinDis?.onEndEdit.AddListener((string str) =>
            {

                float value = float.Parse(str);
                value = Mathf.Clamp(value, 0, 100);
            });
            inputField_MaxDis?.onEndEdit.AddListener((string str) =>
            {
                float value = float.Parse(str);
                value = Mathf.Clamp(value, 0, 100);

            });
            inputField_Duration?.onEndEdit.AddListener((string str) =>
            {
                float value = float.Parse(str);
                value = Mathf.Clamp(value, 0, 100);
            });
            button_Delete?.onClick.AddListener(() =>
            {
                
            });
        }
        //public void InitPanel(VoyageConfig config)
        //{
        //    voyageConfig = config;
        //    if (!VoyageTestManager.Instance.VoyageConfigs.Contains(config)) VoyageTestManager.Instance.VoyageConfigs.Add(config);
        //    index_config = VoyageTestManager.Instance.VoyageConfigs.IndexOf(config);

        //    text_Title.text = "Step:" + index_config;
        //    inputField_TargetSpeed.text = voyageConfig.targetSpeed.ToString();
        //    inputField_MinSpeed.text = voyageConfig.testCarMinSpeed.ToString();
        //    inputField_MaxSpeed.text = voyageConfig.testCarMaxSpeed.ToString();
        //    inputField_MinDis.text = voyageConfig.minDis2Target.ToString();
        //    inputField_MaxDis.text = voyageConfig.maxDis2Target.ToString();
        //    inputField_Duration.text = voyageConfig.duration.ToString();
        //}
        public void RemoveVoyageConfig()
        {
           // VoyageTestManager.Instance.VoyageConfigs.Remove(voyageConfig);
            Destroy(gameObject);
        }
        public void SetIndicatorActive(bool isactive)
        {
            Indicator.SetActive(isactive);
        }
    }
}
