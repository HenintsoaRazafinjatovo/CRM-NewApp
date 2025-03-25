namespace newApp.Models;
public class UserProfile
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Country { get; set; }
    public string Phone { get; set; }
    public string Position { get; set; }
    public string Department { get; set; }
    public decimal? Salary { get; set; }
    public string Status { get; set; }
    public string Facebook { get; set; }
    public string Twitter { get; set; }
    public string Youtube { get; set; }
    public string OathUserImageLink { get; set; }
    public string UserImage { get; set; }
    public string Bio { get; set; }
    public string Address { get; set; }
}

public class Role
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Status { get; set; }
    public string Token { get; set; }
    public DateTime? HireDate { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string OauthUser { get; set; }
    public List<Role> Roles { get; set; }
    public UserProfile UserProfile { get; set; }
    public bool PasswordSet { get; set; }
    public bool InactiveUser { get; set; }
}
