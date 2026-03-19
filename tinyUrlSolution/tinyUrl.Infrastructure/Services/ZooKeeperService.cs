namespace tinyUrl.Infrastructure.Services
{
    using Microsoft.Extensions.Logging;
    using System.Collections.Concurrent;

    public class ZooKeeperService
    {
        private readonly ILogger<ZooKeeperService> _logger;
        private readonly ConcurrentDictionary<string, (string Address, int Port)> _registrations = new();
        private readonly ConcurrentDictionary<string, SemaphoreSlim> _locks = new();
        private bool _connected;
        private string? _connectionString;

        public ZooKeeperService(ILogger<ZooKeeperService> logger)
        {
            _logger = logger;
        }

        public Task ConnectAsync(string connectionString, TimeSpan timeout)
        {
            // This is a lightweight stub implementation so the project compiles
            // and the application can be wired to ZooKeeper later. Replace with
            // a real ZooKeeper client (e.g. Apache.Zookeeper) when ready.
            _connectionString = connectionString;
            _connected = true;
            _logger.LogInformation("(Stub) Connected to ZooKeeper at {ConnectionString} (timeout {Timeout})", connectionString, timeout);
            return Task.CompletedTask;
        }

        public Task RegisterServiceAsync(string serviceName, string address, int port)
        {
            if (!_connected)
            {
                _logger.LogWarning("Attempted to register service while ZooKeeperService is not connected");
            }

            var key = GetRegistrationKey(serviceName, address, port);
            _registrations[key] = (address, port);
            _logger.LogInformation("(Stub) Registered service {Service} at {Address}:{Port}", serviceName, address, port);
            return Task.CompletedTask;
        }

        public Task UnregisterServiceAsync(string serviceName, string address, int port)
        {
            var key = GetRegistrationKey(serviceName, address, port);
            _registrations.TryRemove(key, out _);
            _logger.LogInformation("(Stub) Unregistered service {Service} at {Address}:{Port}", serviceName, address, port);
            return Task.CompletedTask;
        }

        public Task<bool> AcquireLockAsync(string lockName, TimeSpan timeout)
        {
            var sem = _locks.GetOrAdd(lockName, _ => new SemaphoreSlim(1, 1));
            var acquired = sem.Wait(timeout);
            _logger.LogInformation("(Stub) Lock {LockName} acquired={Acquired}", lockName, acquired);
            return Task.FromResult(acquired);
        }

        public Task ReleaseLockAsync(string lockName)
        {
            if (_locks.TryGetValue(lockName, out var sem))
            {
                try
                {
                    sem.Release();
                }
                catch (SemaphoreFullException)
                {
                    // ignore
                }
            }
            _logger.LogInformation("(Stub) Lock {LockName} released", lockName);
            return Task.CompletedTask;
        }

        public Task CloseAsync()
        {
            _connected = false;
            _logger.LogInformation("(Stub) ZooKeeper connection closed for {ConnectionString}", _connectionString);
            return Task.CompletedTask;
        }

        private static string GetRegistrationKey(string serviceName, string address, int port)
            => $"{serviceName}:{address}:{port}";
    }
}
