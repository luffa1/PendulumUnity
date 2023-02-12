using UnityEngine;

public class PeriodMathPendulum 
{
    private PeriodMathPendulum() {}
    private static PeriodMathPendulum instance = null;
    public float previousPreviousPosition = 0.0f;
    public float previousPosition = 0.0f;
    public float currentPosition = 0.0f;

    public int deviationCounter = -1;     
    public int periodCounter = 0;

    private int delayer = 0;

    public static PeriodMathPendulum GetInstance() {
        if (instance == null) {
            instance = new PeriodMathPendulum();
        }

        return instance;
    }
    public void SetNewCurrentPosition(float newCurrentPosition)
    {
        this.delayer++;
        if (this.delayer > 10) {
            this.previousPreviousPosition = this.previousPosition;
            this.previousPosition = this.currentPosition;
            this.currentPosition = newCurrentPosition;

            if (Mathf.Abs(this.previousPreviousPosition) < Mathf.Abs(this.previousPosition) && Mathf.Abs(this.currentPosition) < Mathf.Abs(this.previousPosition)) 
            {
                deviationCounter++;
            }
            this.delayer = 0;
        }
    }
    public void OnMouseUp()
    {
        this.deviationCounter = -1;
        this.periodCounter = 0;
    }
    public void Reset()
    {
        this.deviationCounter = -1;
        this.periodCounter = 0;
    }
    public int GetPeriod() 
    {
        return (int)((float) this.deviationCounter / 2.0f);
    }
}