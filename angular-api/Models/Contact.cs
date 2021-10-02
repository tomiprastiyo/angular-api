﻿using System;

namespace angular_api.Models
{
    public class Contact
    {
        public Guid ContactId { get; set; }
        public ContactTypes ContactType { get; set; }
        public string ContactData { get; set; }
        public bool IsPreferred { get; set; }
    }
}
