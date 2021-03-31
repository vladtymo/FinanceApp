using System;

namespace ServerTypes
{
    public interface ICommandResult
    {
        object Result { get; set; }

        Type CommandType { get; }
    }
}