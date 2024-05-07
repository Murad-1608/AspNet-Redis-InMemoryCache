using StackExchange.Redis;

namespace RedisExchange.Services
{
    public class RedisService
    {
        private readonly ConnectionMultiplexer _connectionMultiplexer;
        public RedisService(string Url)
        {
            _connectionMultiplexer = ConnectionMultiplexer.Connect(Url);
        }

        public IDatabase GetDb(int dbIndex)
        {
            return _connectionMultiplexer.GetDatabase(dbIndex);
        }
    }
}
