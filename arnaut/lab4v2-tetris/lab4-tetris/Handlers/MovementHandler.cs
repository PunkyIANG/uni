namespace lab4v2_tetris.Handlers;

public abstract class MovementHandler : IInputHandler
{
    protected Vector2 moveDir;
    
    public void HandleInput(ref Vector2 holdPos)
    {
        holdPos += moveDir;
    }
}