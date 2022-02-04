using System;
using System.ComponentModel.DataAnnotations;

namespace APIDomain.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        public BaseEntity()
        {
            if (Id == null)
            {
                Id = Guid.NewGuid();
            }            
        }
    }
}
