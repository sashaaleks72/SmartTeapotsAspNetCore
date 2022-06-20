using Microsoft.Extensions.Configuration;

namespace SmartTeapotsWebProject.Configs
{
    public class ConnectionConfig
    {
        private readonly string _fileName;
        private readonly string _path;

        public ConnectionConfig(string fileName, string path)
        {
            _fileName = fileName;
            _path = path;
        }

        public IConfigurationRoot Build()
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(_path);
            builder.AddJsonFile(_fileName);

            var config = builder.Build();

            return config;
        }
    }
}
