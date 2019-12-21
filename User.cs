using Microsoft.WindowsAzure.Storage.Table;

namespace mukeshsingh
{
    public class User: TableEntity
    {
        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
    }
}
