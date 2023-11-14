using Domain.Abstractions;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure;

public class FakeMessageService : IMessageService
{
    public void Send(Message message)
    {
        Console.WriteLine(message);
    }
}
