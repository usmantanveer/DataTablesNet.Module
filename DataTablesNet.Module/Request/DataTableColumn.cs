namespace DataTablesNet.Module {
   public class DataTableColumn {
      public string Name { get; set; }
      public string Data { get; set; }
      public bool Searchable { get; set; }
      public bool Orderable { get; set; }
      public DataTableSearch Search { get; set; }
   }
}
