public static class RobotState
{
    public static Position? Position { get; set; }
    public static Direction? Direction { get; set; }
    public static bool IsPlaced => Position != null;
}