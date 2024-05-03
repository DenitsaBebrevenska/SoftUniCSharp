﻿using MusicHub.Common;
using System.ComponentModel.DataAnnotations;

namespace MusicHub.Data.Models;
public class Producer
{
    public Producer()
    {
        Albums = new HashSet<Album>();
    }
    public int Id { get; set; }

    [MaxLength(DatabaseConstraints.ProducerNameLength)]
    public string Name { get; set; }
    public string? Pseudonym { get; set; }
    public string? PhoneNumber { get; set; }

    public virtual ICollection<Album> Albums { get; set; }

}
