using System;

public class Income
{
    public int Id { get; set; }
    public FnName Name { get; set; }
    public int Sum { get; set; }
    public DateTime Date { get; set; }
    [MaxLenth(300)]
    public string Comment { get; set; }
    public User User { get; set; }
    public Enums.Status Status {get; set;}

}
