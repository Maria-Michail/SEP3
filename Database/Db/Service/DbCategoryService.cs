using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Model;

namespace Db
{
    public class DbCategoryService:IDbCategoryService
    {
        DatabaseContext ctx = new DatabaseContext();

        
    }
}