using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using GREEN_CARD.Core.Data;


namespace GREEN_CARD.Api.Helpers
{
    // https://github.com/graphql-dotnet/graphql-dotnet/issues/648#issuecomment-431489339
    public class ContextServiceLocator
    {
        public IPlayerRepository PlayerRepository => _httpContextAccessor.HttpContext.RequestServices.GetRequiredService<IPlayerRepository>();
        public ISkaterStatisticRepository SkaterStatisticRepository => _httpContextAccessor.HttpContext.RequestServices.GetRequiredService<ISkaterStatisticRepository>();

        public IUserRepository UserRepository => _httpContextAccessor.HttpContext.RequestServices.GetRequiredService<IUserRepository>();

        public ITransactionRepository TransactionRepository => _httpContextAccessor.HttpContext.RequestServices.GetRequiredService<ITransactionRepository>();

        public IItemRepository ItemRepository => _httpContextAccessor.HttpContext.RequestServices.GetRequiredService<IItemRepository>();

        public IReceiptRepository ReceiptRepository => _httpContextAccessor.HttpContext.RequestServices.GetRequiredService<IReceiptRepository>();

        private readonly IHttpContextAccessor _httpContextAccessor;

        public ContextServiceLocator(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
    }
}
