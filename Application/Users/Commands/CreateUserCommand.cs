using System.Windows.Input;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Users.Commands;

public class CreateUserCommand: IRequest<Guid>
{
    public string UserName { get; init; }
    public string Password { get; init; }
    public string FullName { get; init; }
}

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreateUserCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = new User()
        {
            UserName = request.UserName,
            Password = request.Password,
            FullName = request.FullName
        };

        _context.Users.Add(user);
        
        await _context.SaveChangesAsync(cancellationToken);

        return user.Id;
    }
}