namespace GL_Final.Models
{
  public class House
  {
    public int Id { get; set; }
    public int? Year { get; set; }
    public string Type { get; set; }
    public int? Bed { get; set; }
    public int? Bath { get; set; }
    public int? Sqft { get; set; }
    public string Location { get; set; }
    public int Price { get; set; }
  }
}