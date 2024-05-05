using StackExchange.Redis;

namespace RedisExchange.Services
{
    public class RedisService
    {
        private readonly string _redisHost;
        private readonly string _redisPort;
        private ConnectionMultiplexer _redis;
        private IDatabase db;
        public RedisService(IConfiguration configuration,
                            ConnectionMultiplexer redis)
        {
            _redisHost = configuration["Redis:Host"]!;
            _redisPort = configuration["Redis:Port"]!;
            _redis = redis;
        }

        public void Connect()
        {
            string configString = $"{_redisHost}:{_redisPort}";

            _redis = ConnectionMultiplexer.Connect(configString);
        }

        public IDatabase GetDb(int db)
        {
            return _redis.GetDatabase(db);
        }
    }
}
