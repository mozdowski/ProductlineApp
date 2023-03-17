﻿using MediatR;

namespace ProductlineApp.Application.Common.Interfaces;

public interface ICommand<out TResponse> : IRequest<TResponse>
{
}