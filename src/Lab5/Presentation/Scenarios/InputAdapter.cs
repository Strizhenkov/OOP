using Application.ApplicationLogic;
using Application.Contracts;
using Application.Models;
using Infrastructure.Repositories;

namespace Presentation.Scenarios;

public class InputAdapter : IInputPort
{
    public InputAdapter(OutputAdapter outputPort)
    {
        ControllerLogic = new Logic(outputPort);
    }

    private Logic ControllerLogic { get; set; }

    public string Auth(AuthRequestObject data)
    {
        return ControllerLogic.AuthOperator(data);
    }

    public string Request(ActionRequestObject data)
    {
        return ControllerLogic.RequestSelectOperator(data);
    }
}