namespace BulletMLI
{
    /// <summary>
    /// Store data that can change the way patterns are interpreted
    /// </summary>
    public static class Configuration
    {
        // The default direction is up for an angle of 0 (X = sin(angle), Y = -cos(angle))
        // and with an Y-down axis, if you use an Y-up axis, you can set this variable to true
        public static bool YUpAxis = false;

        public static RandomNextFloat RandomNextFloat;
        public static RandomNextInt RandomNextInt;
    }
}