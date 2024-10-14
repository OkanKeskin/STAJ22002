using System.Text;
using MediatR;
using RabbitMQ.Client;

namespace Application.Features.Mediator.Commands.Queue;

public class QueueCommandHandler : IRequestHandler<QueueCommand>
{
    public async Task Handle(QueueCommand request, CancellationToken cancellationToken)
    {
        var factory = new ConnectionFactory();
        factory.Uri = new Uri("amqps://pqfxhqhv:qPhHjkuY3DZyAAG6M8geMCEgAWWjIKoH@octopus.rmq3.cloudamqp.com/pqfxhqhv");

        using var connection = factory.CreateConnection();

        var channel = connection.CreateModel();

        channel.QueueDeclare("mesaj-kuyruk", true, false, false);

        var mesaj = "Deneme mesaj";
        /*
        var mesaj = new
        {
            Test = "test",
            Deneme = "Deneme",
        };
        */
        var body = Encoding.UTF8.GetBytes(mesaj);
        
        channel.BasicPublish(String.Empty, "mesaj-kuyruk",null,body);
    }
}