﻿namespace TestBlobStorage.Entitiy
{
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public int Age { get; set; }
        public string? ProfilePhotoUrl { get; set; }
    }
}
