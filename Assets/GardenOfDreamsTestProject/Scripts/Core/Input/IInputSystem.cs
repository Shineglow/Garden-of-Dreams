using System;
using UnityEngine;

namespace GardenOfDreamsTestProject.Scripts.Core.Input
{
    public interface IInputSystem
    {
        event Action LeftMouseDown;
        Vector2 GetMousePosition();
    }
}