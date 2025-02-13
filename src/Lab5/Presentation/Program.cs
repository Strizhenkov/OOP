using Infrastructure.Repositories;
using Presentation.Scenarios;
using Presentation.UserInterface;

var ui = new Ui(new InputAdapter(new OutputAdapter()));
ui.Start();