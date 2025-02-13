using Application.Models;

namespace Application.Abstractions;

public interface IOutputPort
{
    public string GetData();

    public string Post(DataBaseRequestObject data);
}