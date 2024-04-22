using System;
using System.Collections.Generic;

namespace BT_Tao_EF_code_first.Models;

public partial class Department
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public int? StaffCount { get; set; }

    public int? CompanyId { get; set; }

    public virtual Company? Company { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
