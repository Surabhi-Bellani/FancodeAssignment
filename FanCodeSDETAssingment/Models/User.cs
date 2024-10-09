using System.Collections.Generic;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Address Address { get; set; }
    public List<Todo> Todos { get; set; }
}