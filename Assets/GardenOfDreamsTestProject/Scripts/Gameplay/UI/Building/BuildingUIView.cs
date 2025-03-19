using System;
using System.Collections.Generic;
using System.Linq;
using GardenOfDreamsTestProject.Scripts.Configuration.Buildings;
using UnityEngine;
using UnityEngine.UI;

namespace GardenOfDreamsTestProject.Scripts.Gameplay.UI.Building
{
    public class BuildingUIView : MonoBehaviour, IBuildingUIView
    {
        [SerializeField] private OutlineBehaviour outline;
        [SerializeField] private List<Button> buildingsButtons;
        [SerializeField] private Button buildButton;
        [SerializeField] private Button destroyButton;
        private RectTransform _rectTransform;

        private Dictionary<Button, (EBuildings buildingType, RectTransform rectTransform)> _buttonToAssociatedData;

        public event Action<EBuildings> BuildingSelected;
        public event Action BuildButtonPressed;
        public event Action DestroyButtonPressed;

        public void SetSelectedBuilding(EBuildings building)
        {
            var button = _buttonToAssociatedData.First(kvp => kvp.Value.buildingType == building).Key;
            OnBuildingButtonClicked(button);
        }

        public void ResetTransformParameters()
        {
            var offsetMin = _rectTransform.offsetMin;
            var offsetMax = _rectTransform.offsetMax;
            offsetMin.x = 0;
            offsetMax.x = 0;
            _rectTransform.offsetMin = offsetMin;
            _rectTransform.offsetMax = offsetMax;
        }

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
            
            foreach (var buildingsButton in buildingsButtons)
            {
                buildingsButton.onClick.AddListener(() => OnBuildingButtonClicked(buildingsButton));
            }
            
            buildButton.onClick.AddListener(() => BuildButtonPressed?.Invoke());
            destroyButton.onClick.AddListener(() => DestroyButtonPressed?.Invoke());
        }

        public void Initialize(List<(EBuildings buildingType, Sprite sprite)> buildingsInfo, int firstSelected)
        {
            _buttonToAssociatedData = new ();
            for (var i = 0; i < buildingsInfo.Count; i++)
            {
                _buttonToAssociatedData.Add(buildingsButtons[i], (buildingsInfo[i].buildingType, buildingsButtons[i].GetComponent<RectTransform>()));
                buildingsButtons[i].GetComponentsInChildren<Image>()[1].sprite =buildingsInfo[i].sprite;
            }

            outline.MoveToSelected(_buttonToAssociatedData[buildingsButtons[firstSelected]].rectTransform);
        }

        private void OnBuildingButtonClicked(Button buildingsButton)
        {
            var buttonAssociatedData = _buttonToAssociatedData[buildingsButton];
            outline.MoveToSelected(buttonAssociatedData.rectTransform);
            BuildingSelected?.Invoke(buttonAssociatedData.buildingType);
        }
    }
}