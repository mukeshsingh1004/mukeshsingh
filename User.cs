using Microsoft.WindowsAzure.Storage.Table;

namespace mukeshsingh
{
    public class User: TableEntity
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
    }
}
