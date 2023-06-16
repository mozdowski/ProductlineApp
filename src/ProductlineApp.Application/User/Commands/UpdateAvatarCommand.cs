using FluentValidation;
using Microsoft.AspNetCore.Http;
using ProductlineApp.Application.Common.Interfaces;
using ProductlineApp.Application.Common.Services.Interfaces;
using ProductlineApp.Application.User.DTO;
using ProductlineApp.Domain.Aggregates.User.Repository;
using ProductlineApp.Domain.Aggregates.User.ValueObjects;
using ProductlineApp.Domain.ValueObjects;
using ProductlineApp.Shared.Models.Files;

namespace ProductlineApp.Application.User.Commands;

public class UpdateAvatarCommand
{
    public record Command(
        Guid UserId,
        IFormFile File) : IResultCommand<UpdateAvatarDtoResponse>;

    public class Validator : AbstractValidator<Command>
    {
        public Validator()
        {
            this.RuleFor(x => x.File).NotNull();
            this.RuleFor(x => x.UserId).NotEmpty().NotEqual(Guid.Empty);
        }
    }

    public class Handler : IResultCommandHandler<Command, UpdateAvatarDtoResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUploadFileService _uploadFileService;

        public Handler(
            IUserRepository userRepository,
            IUploadFileService uploadFileService)
        {
            this._userRepository = userRepository;
            this._uploadFileService = uploadFileService;
        }

        public async Task<UpdateAvatarDtoResponse> Handle(Command request, CancellationToken cancellationToken)
        {
            var user = await this._userRepository.GetUserByIdAsync(UserId.Create(request.UserId));

            if (user is null)
            {
                throw new Exception($"No user found with id: {request.UserId}");
            }

            var file = await this._uploadFileService.UploadFileAsync(request.File, FileType.IMAGE);

            user.UpdateAvatar((Image)file);
            await this._userRepository.UpdateUserAsync(user);

            return new UpdateAvatarDtoResponse(file.Url.ToString(), $"{request.UserId}_avatar");
        }
    }
}
