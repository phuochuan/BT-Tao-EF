using System;
using System.Collections.Generic;

namespace BT_Tao_EF_code_first.model;

public partial class Employee
{
    public int Id { get; set; }

    public string? Fullname { get; set; }

    public DateOnly? DateOfBirth { get; set; }

    public int? DepartmentId { get; set; }

    public virtual Department? Department { get; set; }
}
