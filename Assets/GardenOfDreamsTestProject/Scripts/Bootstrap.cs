using GardenOfDreamsTestProject.Scripts.Configuration;
using GardenOfDreamsTestProject.Scripts.Core.Constants;
using GardenOfDreamsTestProject.Scripts.Gameplay;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace GardenOfDreamsTestProject.Scripts
{
    public class Bootstrap : MonoBehaviour
    {
        private Camera _cameraInstance;
        private PlayerInput _input;

        private void Start()
        {
            Debug.Log("Bootstrapper: Начало инициализации...");

            var resourcesLoader = CompositionRoot.GetResourcesLoader();
            _cameraInstance = resourcesLoader.CreatePrefabInstance<Camera, EGeneralPrefabs>(EGeneralPrefabs.MainCamera);
            _input = resourcesLoader.CreatePrefabInstance<PlayerInput, EGeneralPrefabs>(EGeneralPrefabs.Input_UIInput_Event_Systems);
            DontDestroyOnLoad(_cameraInstance);
            DontDestroyOnLoad(_input);

            Debug.Log("Bootstrapper: Загрузка основной сцены...");
            SceneManager.LoadScene(ScenesNames.Main);
        }
    }
}