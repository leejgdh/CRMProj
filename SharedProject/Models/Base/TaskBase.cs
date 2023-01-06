using Newtonsoft.Json;
using System;

namespace SharedProject.Models.Base
{
    public class TaskBase<T>
    {
        public TaskBase(bool isSuccess)
        {
            IsSuccess= isSuccess;
        }

        public bool IsSuccess { get; set; }

        public string Message { get; set; }

        public Guid? ProcessId { get; set; }

        public string Key { get; set; }

        public T Result { get; set; }

        public string Hash { get; set; }

        [JsonIgnore]
        public Exception Exception { get; set; }
    }
}
