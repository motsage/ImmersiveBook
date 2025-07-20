using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

public class LoadAssets : MonoBehaviour
{
    [Header("Addressable Prefab Addresses")]
    public string animalAddress = "Animal";
    public string humanAddress = "HumanBody";
    public string planetsAddress = "Planet";

    [Header("UI Elements")]
    public GameObject loadingScreen; // Assign a UI panel or canvas in Inspector
    public Slider loadingSlider;     // Assign a UI slider in Inspector

    private GameObject currentInstance;

    // UI button callback
    public void LoadPlanets() => LoadCategory(planetsAddress);
    public void LoadHuman() => LoadCategory(humanAddress);
    public void LoadAnimal() => LoadCategory(animalAddress);
    private async void LoadCategory(string address)
    {
        await UnloadCurrent();

        // Show loading UI
        if (loadingScreen != null)
            loadingScreen.SetActive(true);
        if (loadingSlider != null)
            loadingSlider.value = 0f;

        var handle = Addressables.InstantiateAsync(address);

        // Smooth loading bar progress
        while (!handle.IsDone)
        {
            if (loadingSlider != null)
            {
                float targetProgress = handle.PercentComplete;
                loadingSlider.value = Mathf.MoveTowards(loadingSlider.value, targetProgress, Time.deltaTime * 2f);
            }

            await Task.Yield(); // Wait for the next frame
        }

        // Assign loaded instance or log error
        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            currentInstance = handle.Result;
        }
        else
        {
            Debug.LogError($"Failed to load prefab: {address}");
        }

        // Ensure slider shows 100% at end
        if (loadingSlider != null)
            loadingSlider.value = 1f;

        await Task.Delay(300); // Optional delay to avoid flickering

        // Hide loading UI
        if (loadingScreen != null)
            loadingScreen.SetActive(false);
    }

    private async Task UnloadCurrent()
    {
        if (currentInstance != null)
        {
            Addressables.ReleaseInstance(currentInstance);
            Destroy(currentInstance);
            await Task.Yield(); // Allow Unity to process destruction
            currentInstance = null;
        }
    }
}
