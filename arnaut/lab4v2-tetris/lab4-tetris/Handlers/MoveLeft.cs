namespace lab4v2_tetris.Handlers;

public class MoveLeft : MovementHandler
{
    public MoveLeft()
    {
        moveDir = new Vector2(-1, 0);
    }
}