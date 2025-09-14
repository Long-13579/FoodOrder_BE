using MediatR;

namespace Application.Common.Requests;

public interface ICommand : IRequest { }
public interface ICommand<out TResponse> : IRequest<TResponse> { }
