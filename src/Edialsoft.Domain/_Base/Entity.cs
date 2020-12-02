using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Edialsoft.Domain._Base
{
    public abstract class Entity
    {
        public int Id { get; protected set; }

        [NotMapped] public List<string> Errors { get; set; } = new List<string>();
    }
}
