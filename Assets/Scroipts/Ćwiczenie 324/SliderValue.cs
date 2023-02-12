public class SliderValue {
    private SliderValue() {}

    private static SliderValue instance = null;

    public float sliderValue = 0;

    public static SliderValue GetInstance() {
        if (instance == null) {
            instance = new SliderValue();
        }

        return instance;
    }

    public void SetPreviousSliderValue(float sliderValue) {
        this.sliderValue = sliderValue;
    }

    public float GetPreviousSliderValue() {
        return sliderValue;
    }
}