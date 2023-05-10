using CompOff_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompOff_App.DTOs;

public class JobDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public JobStatus Status { get; set; }
    public DateTime DateAdded { get; set; }
    public DateTime LastActivity { get; set; }
}
