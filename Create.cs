using UnityEngine;
using UnityEngine.UI;

public class Create : MonoBehaviour {
    public TerrainMapGenerator terrainMapGenerator;

    // UI Elements
    // public InputField seedInputField;
    // public Slider waterLevelSlider;
    // public Slider chunkGridWidthSlider;
    // public Toggle createForestToggle;
    // public Toggle createWaterToggle;

    // public Button generateButton;
    // public Button clearButton;
    public Button randomizeButton;

    void Start() {
        // Initialize UI values based on the terrainMapGenerator values
        // seedInputField.text = terrainMapGenerator.seed.ToString();
        // waterLevelSlider.value = terrainMapGenerator.waterLevel;
        // chunkGridWidthSlider.value = terrainMapGenerator.chunkGridWidth;
        // createForestToggle.isOn = terrainMapGenerator.createForest;
        // createWaterToggle.isOn = terrainMapGenerator.createWater;

        // // Attach listeners for when UI values are changed
        // seedInputField.onValueChanged.AddListener(OnSeedChanged);
        // waterLevelSlider.onValueChanged.AddListener(OnWaterLevelChanged);
        // chunkGridWidthSlider.onValueChanged.AddListener(OnChunkGridWidthChanged);
        // createForestToggle.onValueChanged.AddListener(OnCreateForestToggle);
        // createWaterToggle.onValueChanged.AddListener(OnCreateWaterToggle);

        // // Attach listeners for button clicks
        // generateButton.onClick.AddListener(OnGenerateButtonClicked);
        // clearButton.onClick.AddListener(OnClearButtonClicked);
        randomizeButton.onClick.AddListener(OnRandomizeButtonClicked);
    }

    // void OnSeedChanged(string newValue) {
    //     if (int.TryParse(newValue, out int seed)) {
    //         terrainMapGenerator.seed = seed;
    //     }
    // }

    // void OnWaterLevelChanged(float newValue) {
    //     terrainMapGenerator.waterLevel = newValue;
    // }

    // void OnChunkGridWidthChanged(float newValue) {
    //     terrainMapGenerator.chunkGridWidth = Mathf.RoundToInt(newValue);
    // }

    // void OnCreateForestToggle(bool isOn) {
    //     terrainMapGenerator.createForest = isOn;
    // }

    // void OnCreateWaterToggle(bool isOn) {
    //     terrainMapGenerator.createWater = isOn;
    // }

    // void OnGenerateButtonClicked() {
    //     terrainMapGenerator.Generate();
    // }

    // void OnClearButtonClicked() {
    //     terrainMapGenerator.Clear();
    // }

    void OnRandomizeButtonClicked() {
        terrainMapGenerator.Randomize();
        // UpdateUIValues();
    }

    // void UpdateUIValues() {
    //     // Update the UI to reflect any random changes
    //     seedInputField.text = terrainMapGenerator.seed.ToString();
    //     waterLevelSlider.value = terrainMapGenerator.waterLevel;
    //     chunkGridWidthSlider.value = terrainMapGenerator.chunkGridWidth;
    //     createForestToggle.isOn = terrainMapGenerator.createForest;
    //     createWaterToggle.isOn = terrainMapGenerator.createWater;
    // }
}
