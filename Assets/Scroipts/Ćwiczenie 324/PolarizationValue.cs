public class PolarizationValue {
    private PolarizationValue() {}

    private static PolarizationValue instance = null;

    public int polarizationValue = 0;

    public static PolarizationValue GetInstance() {
        if (instance == null) {
            instance = new PolarizationValue();
        }

        return instance;
    }

    public void SetPreviousPolarizationValue(int polarizationValue) {
        this.polarizationValue = polarizationValue;
    }

    public int GetPreviousPolarizationValue() {
        return polarizationValue;
    }
}