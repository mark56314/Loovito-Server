using System;

public class IncomeContext: DbContext
{
    public DbSet<Income> Incomes { get; set; }
    public DbSet<FnName> FnNsmes { get; set; }
}
