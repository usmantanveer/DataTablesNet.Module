namespace DataTablesNet.Module {
   public class DTRequest {
      public DataTableColumn[] Columns { get; set; }
      public int Draw { get; set; }
      public int Start { get; set; } = 0;
      public int Length { get; set; }
      public DataTableSearch Search { get; set; }
      public DataTableOrder[] Order { get; set; }
   }
}
