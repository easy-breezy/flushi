public static class ScoreManager
{
    public static float Score { get; private set; } 

    public static float Add(float value)
    {
        return Score += value;
    }

    public static float Subtract(float value)
    {
        return Score -= value;
    }

    public static void SetNew()
    {
        Score = 0;
    }
}