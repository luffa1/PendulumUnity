public class DistanceValue {
    private DistanceValue() {}

    private static DistanceValue instance = null;

    public string distanceValue = "0";

    public static DistanceValue GetInstance() {
        if (instance == null) {
            instance = new DistanceValue();
        }

        return instance;
    }

    public void SetPreviousDistanceValue(string distanceValue) {
        this.distanceValue = distanceValue;
    }

    public string GetPreviousDistanceValue() {
        return distanceValue;
    }
}