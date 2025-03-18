using System.Threading.Tasks;
using GardenOfDreamsTestProject.Scripts.Core;
using GardenOfDreamsTestProject.Scripts.Gameplay.World;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GardenOfDreamsTestProject.Scripts
{
    public class Bootstrap : MonoBehaviour
    {
        private async void Start()
        {
            Debug.Log("Bootstrapper: Начало инициализации...");

            CompositionRoot.SaveSystem.SetRootObject(new WorldEntity(CompositionRoot.GridSystem));
            CompositionRoot.SaveSystem.Save("save01");
            
            var saves = CompositionRoot.SaveSystem.GetAllSaves();
            
            await LoadGameDataAsync();
        
            Debug.Log("Bootstrapper: Загрузка основной сцены...");
            SceneManager.LoadScene(ScenesNames.Main);
        }

        private async Task LoadGameDataAsync()
        {
            Debug.Log("Загрузка конфигурации...");
            await Task.Delay(1000); // Имитация загрузки файла
            Debug.Log("Конфигурация загружена!");
        }
    }
}