public class SkryptObliczeniowy {
    public float CalculateAmper(float u) {
        float r = 11;

        return u / r;
    }
    public float CalculateVoltage(float i) {
        float r = 11;

        return i * r;
    }
    // Obliczanie wychylenia ramienia 
    // public float CalculateSwing(float f)   // to jest tylko przykład zapisu poszukać wzoru 
    // {
    //     float c = 2.65f;
    //     for (int x = 1; x < 10; x++)
    //     {
    //         return c * x;
    //     }
    // }
    public float CalculateWinding(float l) // obliczanie liczby uzwojeń "l" - długość przewodnika
    {
        float windingNumber = 0; // tutaj zrobić buttony z wartościami 0, 5, 15, 25 tak żeby można było kliknąć i zmienić wartość
        float lowerSideLenght = 13;
        return windingNumber * lowerSideLenght;
    }
}