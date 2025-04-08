﻿using System.Text.Json;

namespace Thunders.TechTest.ApiService.Entities
{
    public class Entity
    {
        public Guid Id { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
        public DateTime? DeletedAt { get; private set; }

        public void SetId()
        {
            Id = Guid.NewGuid();
        }

        public override string? ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
