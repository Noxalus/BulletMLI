namespace BulletML
{
    /// <summary>
    /// This is a callback method for getting a position
    /// used to break out dependencies.
    /// </summary>
    /// <returns>A method to get a position.</returns>
    public delegate Vector2 PositionDelegate();

    /// <summary>
    /// A method to get a float from somewhere
    /// separate from delgates.
    /// </summary>
    /// <returns>Get a float from somewhere.</returns>
    public delegate float FloatDelegate();

    /// <summary>
    /// A method to generate a random float between 0 and 1.
    /// </summary>
    public delegate float RandomNextFloat();

    /// <summary>
    /// A method to generate a random integer number between min (inclusive) and max (exclusive).
    /// </summary>
    public delegate int RandomNextInt(int min, int max);
}