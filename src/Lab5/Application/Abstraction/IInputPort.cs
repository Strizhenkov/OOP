using Application.Models;

namespace Application.Contracts;

public interface IInputPort
{
    public string Auth(AuthRequestObject data);

    public string Request(ActionRequestObject data);
}