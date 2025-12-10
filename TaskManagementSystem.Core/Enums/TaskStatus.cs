namespace TaskManagementSystem.Core.Enums
{
    public enum Status : byte
    {
        todo = 1,
        in_progress,
        done
    }

    public enum TaskPriority : byte
    {
        low = 1,
        medium,
        high
    }
}
