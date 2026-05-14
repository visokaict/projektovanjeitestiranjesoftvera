using Core.Shared.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interfaces
{
    public interface ICommonBusinessOperations<ICommand, ICommandResponse>
    {
        OperationResult<IReadOnlyCollection<ICommandResponse>> GetAll();
        OperationResult<ICommandResponse> Save(ICommand command);  
        OperationResult<ICommandResponse> Delete(ICommand command);
        OperationResult<ICommandResponse> Update(ICommand command);
    }
}
