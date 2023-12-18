public class Review
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Comment { get; set; }
    public int Rating { get; set; }
    public DateTime now = DateTime.Now;
}
