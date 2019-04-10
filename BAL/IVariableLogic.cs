using System.Collections.Generic;

namespace BAL
{
    public interface IVariableLogic
    {
        void Add(VariableDto variableDto);
        void Delete(int id);
        IEnumerable<VariableDto> GetAll();
        void Update(VariableDto variableDto);
    }
}