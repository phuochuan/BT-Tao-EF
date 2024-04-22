using System;
using System.Collections.Generic;

namespace BT_Tao_EF_code_first.Models;

public partial class Company
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? Address { get; set; }

    public virtual ICollection<Department> Departments { get; set; } = new List<Department>();
}
