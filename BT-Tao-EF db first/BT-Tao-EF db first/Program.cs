// See https://aka.ms/new-console-template for more information
using BT_Tao_EF_db_first.Models;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");
using (var context = new BtTaoEfDbFContext())
{
    var nhanViens = context.Employees
        .Include(nv => nv.Department)
        .Where(nv =>DateTime.Now.Year-nv.DateOfBirth.Value.Year >= 30 &&
                     DateTime.Now.Year - nv.DateOfBirth.Value.Year <= 40 &&
                     nv.Department.Name == "Marketing")
        .ToList();

    foreach (var nhanVien in nhanViens)
    {
        Console.WriteLine($"Tên: {nhanVien.Fullname}, DateOfBirth: {nhanVien.DateOfBirth}, Phòng ban: {nhanVien.Department.Name}");
    }
}