public class Maze
{
    private readonly Dictionary<ValueTuple<int, int>, bool[]> _mazeMap;
    private int _currX = 1;
    private int _currY = 1;

    public Maze(Dictionary<ValueTuple<int, int>, bool[]> mazeMap)
    {
        _mazeMap = mazeMap;
    }

    /// <summary>
    /// Check to see if you can move left. If you can, then move. If you
    /// can't move, throw an InvalidOperationException.
    /// </summary>
    public void MoveLeft()
    {
        // Check if current position exists in maze and if left movement is allowed
        if (_mazeMap.TryGetValue((_currX, _currY), out bool[] directions) && directions[0])
        {
            _currX--;
        }
        else
        {
            throw new InvalidOperationException("Can't go that way!");
        }
    }

    /// <summary>
    /// Check to see if you can move right. If you can, then move. If you
    /// can't move, throw an InvalidOperationException.
    /// </summary>
    public void MoveRight()
    {
        // Check if current position exists in maze and if right movement is allowed
        if (_mazeMap.TryGetValue((_currX, _currY), out bool[] directions) && directions[1])
        {
            _currX++;
        }
        else
        {
            throw new InvalidOperationException("Can't go that way!");
        }
    }

    /// <summary>
    /// Check to see if you can move up. If you can, then move. If you
    /// can't move, throw an InvalidOperationException.
    /// </summary>
    public void MoveUp()
    {
        // Check if current position exists in maze and if up movement is allowed
        if (_mazeMap.TryGetValue((_currX, _currY), out bool[] directions) && directions[2])
        {
            _currY--;
        }
        else
        {
            throw new InvalidOperationException("Can't go that way!");
        }
    }

    /// <summary>
    /// Check to see if you can move down. If you can, then move. If you
    /// can't move, throw an InvalidOperationException.
    /// </summary>
    public void MoveDown()
    {
        // Check if current position exists in maze and if down movement is allowed
        if (_mazeMap.TryGetValue((_currX, _currY), out bool[] directions) && directions[3])
        {
            _currY++;
        }
        else
        {
            throw new InvalidOperationException("Can't go that way!");
        }
    }

    public string GetStatus()
    {
        return $"Current location (x={_currX}, y={_currY})";
    }
}