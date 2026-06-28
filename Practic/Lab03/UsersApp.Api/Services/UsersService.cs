using UsersApp.Api.Models;
using UsersApp.Api.Repositories;

namespace UsersApp.Api.Services;

public class UsersService
{
    private readonly IUsersRepository _usersRepository;

    public UsersService(IUsersRepository usersRepository)
    {
        _usersRepository = usersRepository;
    }

    public IList<User> GetUsers()
        => _usersRepository.GetAll();

    public User GetUserById(long id)
    {
        var user = _usersRepository.GetById(id);

        if (user is null)
        {
            throw new KeyNotFoundException($"User not found with id: {id}");
        }

        return user;
    }

    public User AddUser(User user)
    {
        if (string.IsNullOrWhiteSpace(user.Name))
        {
            throw new ArgumentException("Name cannot be empty");
        }

        return _usersRepository.Add(user);
    }
}

