using System;
using System.Collections.Generic;
using System.Linq;
using GardenOfDreamsTestProject.Scripts.Configuration;
using GardenOfDreamsTestProject.Scripts.Configuration.Buildings;
using GardenOfDreamsTestProject.Scripts.Core.ResourcesSystem;
using UnityEngine;
using UnityEngine.UI;

namespace GardenOfDreamsTestProject.Scripts.Gameplay.UI
{
    public class GameplayUIView : MonoBehaviour
    {
        [SerializeField] private OutlineBehaviour outline;
        [SerializeField] private List<Button> buildingsButtons;
        [SerializeField] private List<Button> controlButtons;

        private Dictionary<Button, EBuildings> _buttonToBuildingType;
        private ResourcesLoader _resourcesLoader;

        public Action<EBuildings> BuildingSelected;

        private void Awake()
        {
            foreach (var buildingsButton in buildingsButtons)
            {
                buildingsButton.onClick.AddListener(() => OnBuildingButtonClicked(buildingsButton));
            }
            
            // Initialize(new ResourcesLoader(),
            //     new List<(EBuildings buildingType, EBuildingsSprites sprite, bool isSpritePartOfAtlas)>()
            //     {
            //         (EBuildings.Red, EBuildingsSprites.Buildings_0, true),
            //         (EBuildings.Green, EBuildingsSprites.Buildings_1, true),
            //         (EBuildings.Blue, EBuildingsSprites.Buildings_2, true),
            //     });
        }

        public void Initialize(ResourcesLoader resourcesLoader, List<(EBuildings buildingType, EBuildingsSprites sprite, bool isSpritePartOfAtlas)> buildingsInfo)
        {
            _resourcesLoader = resourcesLoader;
            _buttonToBuildingType = new Dictionary<Button, EBuildings>();
            for (var i = 0; i < buildingsInfo.Count; i++)
            {
                _buttonToBuildingType.Add(buildingsButtons[i], buildingsInfo[i].buildingType);
                var atlas = _resourcesLoader.LoadAtlas(buildingsInfo[i].sprite);
                buildingsButtons[i].GetComponentsInChildren<Image>()[1].sprite =
                    atlas.First(atlasSprite => atlasSprite.name.Equals(buildingsInfo[i].sprite.ToString()));
            }
        }

        private void OnBuildingButtonClicked(Button buildingsButton)
        {
            outline.MoveToSelected(buildingsButton.gameObject);
            BuildingSelected?.Invoke(_buttonToBuildingType[buildingsButton]);
        }
    }
}