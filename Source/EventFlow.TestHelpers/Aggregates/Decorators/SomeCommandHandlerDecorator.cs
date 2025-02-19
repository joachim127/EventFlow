// The MIT License (MIT)
// 
// Copyright (c) 2015-2024 Rasmus Mikkelsen
// https://github.com/eventflow/EventFlow
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of
// this software and associated documentation files (the "Software"), to deal in
// the Software without restriction, including without limitation the rights to
// use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
// the Software, and to permit persons to whom the Software is furnished to do so,
// subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
// FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
// COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
// IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
// CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

using System.Threading;
using System.Threading.Tasks;
using EventFlow.Aggregates;
using EventFlow.Aggregates.ExecutionResults;
using EventFlow.Commands;
using EventFlow.Core;

namespace EventFlow.TestHelpers.Aggregates.Decorators
{
    /// <summary>
    /// Caused StackOverflowException when colocated with command handlers and using options.AddDefaults().
    /// </summary>
    /// <seealso cref="http://github.com/eventflow/EventFlow/issues/523"/>
    public class SomeCommandHandlerDecorator<TAggregate, TIdentity, TResult, TCommand> :
        CommandHandler<TAggregate, TIdentity, TResult, TCommand>
        where TAggregate : IAggregateRoot<TIdentity>
        where TIdentity : IIdentity
        where TResult : IExecutionResult
        where TCommand : ICommand<TAggregate, TIdentity, TResult>
    {
        public SomeCommandHandlerDecorator(ICommandHandler<TAggregate, TIdentity, TResult, TCommand> inner)
        {
        }

        public override Task<TResult> ExecuteCommandAsync(TAggregate aggregate, TCommand command, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
