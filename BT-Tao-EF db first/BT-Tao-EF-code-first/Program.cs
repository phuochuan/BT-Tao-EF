using Microsoft.EntityFrameworkCore;
using BT_Tao_EF_code_first.model;

class Program
{
    static void Main(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<DemoDbContext>();
        optionsBuilder.UseSqlServer("Data Source=PHUOC_HUAN;Initial Catalog=BT_Tao_EF_Code_F;Integrated Security=True;Trust Server Certificate=True");

        using (var context = new DemoDbContext(optionsBuilder.Options))
        {
            // Use your DbContext here
        }
    }
}