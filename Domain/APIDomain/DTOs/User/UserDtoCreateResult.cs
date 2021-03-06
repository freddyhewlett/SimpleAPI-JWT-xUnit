using System;

namespace APIDomain.DTOs.User
{
    public class UserDtoCreateResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
