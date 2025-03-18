using System.Collections.Generic;
using UnityEngine;

namespace GardenOfDreamsTestProject.Scripts.Configuration.Buildings
{
    public class BuildingsConfiguration : AbstractConfiguration<EBuildings, IBuildingInfo>
    {
        protected override Dictionary<EBuildings, IBuildingInfo> _typeToData { get; }  = new()
        {
            {
                EBuildings.Red, new BuildingConfigurationData()
                {
                    SpriteInfo = (EBuildingsSprites.Buildings_0, true),
                    Name = "Red",
                    CellsToPlace = new List<List<bool>>
                    {
                        new(){ true, true, true, },
                        new(){ true, true, true, },
                    },
                    LocalCellAnchorPosition = (false, new Vector2(1,1)),
                }
            },
            {
                EBuildings.Blue, new BuildingConfigurationData()
                {
                    SpriteInfo = (EBuildingsSprites.Buildings_1, true),
                    Name = "Blue",
                    CellsToPlace = new List<List<bool>>
                    {
                        new(){ true,  true,  true, true, true, },
                        new(){ true,  true,  true, true, true, },
                        new(){ false, false, true, true, true, },
                    },
                    LocalCellAnchorPosition = (false, new Vector2(3,2)),
                }
            },
            {
                EBuildings.Green, new BuildingConfigurationData()
                {
                    SpriteInfo = (EBuildingsSprites.Buildings_2, true),
                    Name = "Green",
                    CellsToPlace = new List<List<bool>>
                    {
                        new(){ false,  true,  true, true, true, true, },
                        new(){ false,  true,  true, true, true, true, },
                        new(){ true, false, true, true, true, true, },
                    },
                    LocalCellAnchorPosition = (false, new Vector2(4,2)),
                }
            },
        };
    }
}