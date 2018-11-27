using System;
using System.Collections.Generic;
using System.Linq;

namespace CQRS
{
    /// <summary>
    /// Example CQRS and Event Sourcing
    /// CQRS = command query responsibility separation
    /// CQS = command query separation
    ///
    ///     //  Goal - separate the Command(Write) and Query(Read) 
    ///     //  Command = do/change
    ///     //  Events should be serializable - serialize the Target id in specific command
    ///  
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var eventBroker = new EventBroker();
            var person = new Person(eventBroker);
            eventBroker.OnCommands(new ChangeAgeCommand(person, 123));

            PrintAllEvent(eventBroker);

            var ageQuery = new AgeQuery { Target = person };
            var age = eventBroker.OnQueries<int>(ageQuery);
            Console.WriteLine(age);

            eventBroker.UndoLast();

            PrintAllEvent(eventBroker);

            ageQuery = new AgeQuery { Target = person };
            age = eventBroker.OnQueries<int>(ageQuery);
            Console.WriteLine(age);

            Console.ReadLine();
        }

        private static void PrintAllEvent(EventBroker eventBroker)
        {
            foreach (var @event in eventBroker.AllEvents)
            {
                Console.WriteLine(@event);
            }
        }
    }

    public class PersonStorage
    {
        public Dictionary<int,Person> Persons { get; set; }
    }

    public class Person
    {
        public int UniqueId;
        private int _age;
        private readonly EventBroker _broker;

        public Person(EventBroker broker)
        {
            _broker = broker;
            _broker.Commands += BrokerOnCommands;
            _broker.Queries += BrokerOnQueries;
        }

        private void BrokerOnQueries(object sender, Query query)
        {
            var aq = query as AgeQuery;
            if (aq != null && aq.Target == this)
            {
                aq.Result = _age;
            }
        }

        private void BrokerOnCommands(object sender, Command command)
        {
            var cac = command as ChangeAgeCommand;
            if (cac != null && cac.Target == this)
            {
                if (cac.Register)
                {
                    _broker.AllEvents.Add(new AgeChangeEvent(this, _age, cac.Age));
                }

                _age = cac.Age;
            }
        }

        public bool CanVote => _age >= 16;
    }

    public class EventBroker
    {
        //1. All events that happened 
        public IList<Event> AllEvents = new List<Event>();
        //2. Commands
        public event EventHandler<Command> Commands;
        //3. Queries
        public event EventHandler<Query> Queries;

        public void OnCommands(Command command)
        {
            Commands?.Invoke(this, command);
        }

        public T OnQueries<T>(Query query)
        {
            Queries?.Invoke(this, query);
            return (T)query.Result;
        }

        public void UndoLast()
        {
            var e = AllEvents.LastOrDefault();
            var ac = e as AgeChangeEvent;
            if (ac != null)
            {
                var changeAgeCommand = new ChangeAgeCommand(ac.Target,ac.OldValue)
                {
                    Register = false
                };
                OnCommands(changeAgeCommand);
                AllEvents.Remove(e);
            }
        }
    }

    public class Event
    {
        //backtrack
    }
    public class AgeChangeEvent : Event
    {
        public Person Target;
        public int OldValue;
        public int NewValue;

        public AgeChangeEvent(Person target, int oldValue, int newValue)
        {
            Target = target;
            OldValue = oldValue;
            NewValue = newValue;
        }

        public override string ToString()
        {
            return $"Age change from {OldValue} to {NewValue}";
        }
    }

    public class Query
    {
        public object Result { get; set; }
    }

    public class AgeQuery : Query
    {
        public Person Target { get; set; }
    }

    public class Command : EventArgs
    {
        public bool Register = true;
    }

    public class ChangeAgeCommand : Command
    {
        public Person Target; // Can't be serializable 
        public int TargetId;

        public int Age;

        public ChangeAgeCommand(Person target, int age)
        {
            Age = age;
            Target = target;
        }
    }
}
