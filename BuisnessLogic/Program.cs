using BuisnessLogic;
using Microsoft.Extensions.Configuration;

class Program
{

	static void Main(string[] args)
	{
        using var db = new DatabaseContext();
        db.Add(new User { UserId = Guid.NewGuid(), Username = "kat", Password = "kattemis" });
        db.SaveChanges();

        var userKat = db.Users.First(u => u.Username == "kat");

        db.Add(new Account { AccountId = Guid.NewGuid(), Points = 1, UserId = userKat.UserId });
        db.SaveChanges();
    }
}