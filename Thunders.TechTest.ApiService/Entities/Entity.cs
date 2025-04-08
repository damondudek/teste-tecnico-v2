using System.Text.Json;

namespace Thunders.TechTest.ApiService.Entities
{
    public class Entity
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public void SetId()
        {
            Id = Guid.NewGuid();
        }

        public void SetCreation()
        {
            CreatedAt = DateTime.Now;
        }

        public void SetUpdate()
        {
            UpdatedAt = DateTime.Now;
        }

        public void SetDeletion()
        {
            DeletedAt = DateTime.Now;
            SetUpdate();
        }

        public override string? ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
