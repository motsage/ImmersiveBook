using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
public class LoadAssets : MonoBehaviour
{
    // Set these in the inspector or hardcode them
    public string animalAddress = "AnimalPrefab";
    public string humanAddress = "HumanPrefab";
    public string planetsAddress = "PlanetsPrefab";

    private GameObject currentInstance;

    // Button callbacks
    public void OnAnimalButtonPressed(string adresss) => LoadCategory(adresss);
   // public void OnHumanButtonPressed() => LoadCategory(humanAddress);
    //public void OnPlanetsButtonPressed() => LoadCategory(planetsAddress);

    private async void LoadCategory(string address)
    {
        await UnloadCurrent();

        var handle = Addressables.InstantiateAsync(address);
        await handle.Task;

        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            currentInstance = handle.Result;
        }
        else
        {
            Debug.LogError($"Failed to load prefab: {address}");
        }
    }

    private async Task UnloadCurrent()
    {
        if (currentInstance != null)
        {
            Addressables.ReleaseInstance(currentInstance);
            Destroy(currentInstance);
            await Task.Yield(); // ensure smooth unloading
            currentInstance = null;
        }
    }
}
