using System;
using System.ComponentModel.DataAnnotations;

namespace APIDomain.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        public Guid Id { get; protected set; }
        public DateTime CreateDate { get; private set; }
        public DateTime? UpdateDate { get; private set; }

        public BaseEntity()
        {
            Id = Guid.NewGuid();
        }
    }
}
