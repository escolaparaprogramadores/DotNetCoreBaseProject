using System;

namespace Demo.Application.DTO
{
    public class BaseDTO
    {
     public Guid Id { get; set; }

        protected BaseDTO()
        => Id = Guid.NewGuid();
    }
}