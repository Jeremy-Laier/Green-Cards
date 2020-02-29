 
 
 
using Microsoft.EntityFrameworkCore;
 

namespace GREEN_CARD.Data
{
    public class TemporaryDbContextFactory : DesignTimeDbContextFactoryBase<GREEN_CARDContext>
    {
        protected override GREEN_CARDContext CreateNewInstance(
            DbContextOptions<GREEN_CARDContext> options)
        {
            return new GREEN_CARDContext(options);
        }
    }
}
