using System.ComponentModel;

namespace TaskManagementSystem.Core.Enums
{
    public enum Status : byte
    {
        [Description("To Do")] todo = 1,
        [Description("In Progress")] in_progress,
        [Description("Done")] done
    }

    public enum TaskPriority : byte
    {
        [Description("Low")] low = 1,
        [Description("Medium")] medium,
        [Description("High")] high
    }
}
