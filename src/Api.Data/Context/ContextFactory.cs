using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Api.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
    {
        public MyContext CreateDbContext(string[] args)
        {
            //Usado para criar as Migrações
            var connetionString = "Server=localhost;Port=3306;Database=dbApi;Uid=root;Pwd=Civic1332!";
            //connetionString = "data source=MAURICIOHF;Initial Catalog=dbApi;Integrated Security=SSPI; ";

            var optionBuilder = new DbContextOptionsBuilder<MyContext>();
            optionBuilder.UseMySql(connetionString);
            //optionBuilder.UseSqlServer(connetionString);
            return new MyContext(optionBuilder.Options);
        }
    }
}
